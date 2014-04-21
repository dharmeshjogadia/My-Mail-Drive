using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


public enum Priority
{
    LOW, MEDIUM, HIGH, VERY_HIGH
}


public class Mail
{
    public static long nextComposeID;
    public Mail()
    {
        composeID = generateNextComposeID(); //
    }
    public long generateNextComposeID()
    {
        return nextComposeID;
    }
    private long composeID;

    public long ComposeID
    {
        get { return composeID; }
        set { composeID = value; }
    }
    private Users sender; //

    public Users Sender
    {
        get { return sender; }
        set { sender = value; }
    }
    private List<Users> receiver;

    public List<Users> Receiver
    {
        get { return receiver; }
        set { receiver = value; }
    }
    private List<Users> cc;

    public List<Users> Cc
    {
        get { return cc; }
        set { cc = value; }
    }
    private List<Users> bcc;

    public List<Users> Bcc
    {
        get { return bcc; }
        set { bcc = value; }
    }
    private Priority mailPriority;

    public Priority MailPriority
    {
        get { return mailPriority; }
        set { mailPriority = value; }
    }
    private bool starred;

    public bool Starred
    {
        get { return starred; }
        set { starred = value; }
    }
    private string subject;

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }
    private DateTime send_time;

    public DateTime Send_time
    {
        get { return send_time; }
        set { send_time = value; }
    }
    private List<string> attachedFiles;    // Data Type in Database .....?

    public List<string> AttachedFiles
    {
        get { return attachedFiles; }
        set { attachedFiles = value; }
    }
    private string mailBody;

    public string MailBody
    {
        get { return mailBody; }
        set { mailBody = value; }
    }
    private DateTime lastAutoSaved;

    public DateTime LastAutoSaved
    {
        get { return lastAutoSaved; }
        set { lastAutoSaved = value; }
    }
    private bool isDraft;

    public bool IsDraft
    {
        get { return isDraft; }
        set { isDraft = value; }
    }
    private bool isSpam;

    public bool IsSpam
    {
        get { return isSpam; }
        set { isSpam = value; }
    }

    private bool isThrash;

    public bool IsThrash
    {
        get { return isThrash; }
        set { isThrash = value; }
    }
    public void NextComposeId()
    {
        string str = "Select Max(composeId)+1 from Mail";
        DataSet ds = new DataSet();
        ConnectionMyMail x = new ConnectionMyMail();
        ds = x.search(str);
        nextComposeID = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());

        ComposeID = nextComposeID;
    }
    public void sendMail()
    {
        NextComposeId();
        string str = "Insert into Mail values(" + this.composeID + ",'" + this.sender.Username + "','" + this.mailPriority + "','" + this.starred + "','" + this.subject + "',CONVERT(DATETIME,'" + this.send_time + "',103),'" + this.mailBody + "',CONVERT(DATETIME,'" + this.lastAutoSaved + "', 103)," + ((this.isDraft) ? "1" : "0") + "," + ((this.isSpam) ? "1" : "0") + "," + ((this.isThrash) ? "1" : "0") + ")";
        ConnectionMyMail x = new ConnectionMyMail();
        x.exec(str);
        foreach (Users u in this.Bcc)
        {
            str = "Insert into bccOfMail values(" + this.ComposeID + ",'" + u.Username + "')";
            x.exec(str);
        }
        foreach (Users u in this.Cc)
        {
            str = "Insert into ccOfMail values(" + this.ComposeID + ",'" + u.Username + "')";
            x.exec(str);
        }
        foreach (Users u in this.receiver)
        {
            str = "Insert into ReceiverOfMail values(" + this.ComposeID + ",'" + u.Username + "')";
            x.exec(str);
        }
        foreach (String s in this.attachedFiles)
        {
            str = "Insert into attachFile values(" + this.ComposeID + ",'" + s + "')";
            x.exec(str);
        }
    }


    public static bool userIsPresent(string username)
    {
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "select * from [User] where userId='" + username + "'";
        DataSet ds = new DataSet();
        ds = x.search(str);
        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    public long composeMail()
    {
        return composeID;
    }
    //Transfer to trash
    public bool discardMail()
    {
        ConnectionMyMail x = new ConnectionMyMail();
        try
        {
            string query = "update Mail set isThrash=1 where composeId=" + this.composeID + "";
            x.exec(query);
            this.isThrash = true;
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public void saveAsDraft()
    {
        ConnectionMyMail x = new ConnectionMyMail();
        string query = "Update Mail set IsDraft=1 where composeId=" + this.composeID + "";
        x.exec(query);
        this.IsDraft = true;
    }
    public void markAsSpam()
    {
        ConnectionMyMail x = new ConnectionMyMail();
        string query = "Update Mail set IsSpam=1 where composeId=" + this.composeID + "";
        x.exec(query);
        this.IsSpam = true;
    }
    public static List<Mail> getMail(string username)
    {
        List<Mail> m = new List<Mail>();
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "Select * from Mail m ";
        str += "join [user] u on m.senderid=u.userid ";
        str += " where composeId in(Select composeId from bccOfMail";
        str += " where userId='" + username + "'";
        str += " union Select composeId from ccOfMail where userId='" + username + "' union Select composeId from ReceiverOfMail where userId='" + username + "";
        str += "')  order by sendTime desc ";
        DataSet ds = new DataSet();

        ds = x.search(str);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Mail temp = new Mail();
            temp.Sender = new Users();
            temp.composeID = Convert.ToInt32(ds.Tables[0].Rows[i]["composeId"].ToString());
            temp.Sender.Firstname = ds.Tables[0].Rows[i]["firstName"].ToString();
            temp.Sender.Lastname = ds.Tables[0].Rows[i]["lastName"].ToString();
            temp.Sender.Username = ds.Tables[0].Rows[i]["senderId"].ToString();
            temp.mailBody = ds.Tables[0].Rows[i]["mailBody"].ToString();
            temp.ComposeID = Convert.ToInt64(ds.Tables[0].Rows[i]["composeId"]);
            temp.starred = Convert.ToBoolean(ds.Tables[0].Rows[i]["starred"]);
            temp.subject = ds.Tables[0].Rows[i]["subject"].ToString();
            temp.send_time = (DateTime)ds.Tables[0].Rows[i]["sendTime"];

            // temp.lastAutoSaved = (DateTime)ds.Tables[0].Rows[i]["isAutoSaved"];
            temp.isDraft = (Boolean)ds.Tables[0].Rows[i]["isDraft"];
            temp.isSpam = (Boolean)ds.Tables[0].Rows[i]["isSpam"];
            temp.isThrash = (Boolean)ds.Tables[0].Rows[i]["isThrash"];
            m.Add(temp);
        }
        return m;
    }

    public static Mail getMailDetail(long composeId)
    {
        Mail mailDetail = new Mail();
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "Select * from Mail m  join [user] u on m.senderid=u.userid  where composeId=" + composeId + " order by sendTime desc ";
        DataSet ds = new DataSet();
        DataSet dsRecv;
        ds = x.search(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            mailDetail.Sender = new Users();
            mailDetail.composeID = Convert.ToUInt32(ds.Tables[0].Rows[0]["composeId"].ToString());
            mailDetail.Sender.Firstname = ds.Tables[0].Rows[0]["firstName"].ToString();
            mailDetail.Sender.Lastname = ds.Tables[0].Rows[0]["lastName"].ToString();
            mailDetail.Sender.Username = ds.Tables[0].Rows[0]["senderId"].ToString();
            mailDetail.mailBody = ds.Tables[0].Rows[0]["mailBody"].ToString();
            mailDetail.starred = (Boolean)ds.Tables[0].Rows[0]["starred"];
            mailDetail.subject = ds.Tables[0].Rows[0]["subject"].ToString();
            mailDetail.send_time = (DateTime)ds.Tables[0].Rows[0]["sendTime"];
            mailDetail.isDraft = (Boolean)ds.Tables[0].Rows[0]["isDraft"];
            mailDetail.isSpam = (Boolean)ds.Tables[0].Rows[0]["isSpam"];
            mailDetail.isThrash = (Boolean)ds.Tables[0].Rows[0]["isThrash"];
        }

        List<Users> listOfReceiver = new List<Users>();
        str = "select * from ReceiverOfMail where composeId=" + composeId + "";
        ds = new DataSet();
        ds = x.search(str);
        if (ds.Tables.Count > 0)
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                str = "select * from [User] where userId='" + ds.Tables[0].Rows[j]["userId"].ToString() + "'";
                dsRecv = new DataSet();
                dsRecv = x.search(str);
                Users userDetail = new Users();
                if (dsRecv.Tables.Count > 0 && dsRecv.Tables[0].Rows.Count > 0)
                {
                    userDetail.Username = dsRecv.Tables[0].Rows[0]["userId"].ToString();
                    userDetail.Firstname = dsRecv.Tables[0].Rows[0]["firstName"].ToString();
                    userDetail.Lastname = dsRecv.Tables[0].Rows[0]["lastName"].ToString();
                    listOfReceiver.Add(userDetail);
                }
            }
        mailDetail.receiver = listOfReceiver;

        List<Users> listOfcc = new List<Users>();
        str = "select * from ccOfMail where composeId=" + composeId + "";
        ds = new DataSet();
        ds = x.search(str);
        if (ds.Tables.Count > 0)
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                str = "select * from [User] where userId='" + ds.Tables[0].Rows[j]["userId"].ToString() + "'";
                dsRecv = new DataSet();
                dsRecv = x.search(str);
                Users userDetail = new Users();
                if (dsRecv.Tables.Count > 0 && dsRecv.Tables[0].Rows.Count > 0)
                {
                    userDetail.Username = dsRecv.Tables[0].Rows[0]["userId"].ToString();
                    userDetail.Firstname = dsRecv.Tables[0].Rows[0]["firstName"].ToString();
                    userDetail.Lastname = dsRecv.Tables[0].Rows[0]["lastName"].ToString();
                    listOfcc.Add(userDetail);
                }
            }
        mailDetail.cc = listOfcc;

        List<string> attachments = new List<string>();
        str = "select * from attachFile where composeId=" + composeId + " ";
        ds = new DataSet();
        ds = x.search(str);
        if (ds.Tables.Count > 0)
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                attachments.Add(ds.Tables[0].Rows[j]["fileName"].ToString());
            }
        mailDetail.attachedFiles = attachments;


        return mailDetail;
    }
    public static List<Mail> getInbox(string username)
    {
        List<Mail> mails = new List<Mail>();
        foreach (Mail m in getMail(username))
        {
            if (!m.isDraft && !m.isSpam && !m.isThrash)
                mails.Add(m);
        }
        return mails;
    }
    public static List<Mail> getSpamMail(string username)
    {
        List<Mail> mails = new List<Mail>();
        foreach (Mail m in getMail(username))
        {
            if (m.IsSpam)
                mails.Add(m);
        }
        return mails;
    }
    public static List<Mail> getTrashMail(string username)
    {
        List<Mail> mails = new List<Mail>();
        foreach (Mail m in getMail(username))
        {
            if (m.IsThrash)
                mails.Add(m);
        }
        return mails;

    }
    public static List<Mail> getsentMails(string username)
    {
        List<Mail> mails = new List<Mail>();
        string query = "Select * from Mail where senderid='" + username + "' order by sendTime desc ";
        DataSet ds = new DataSet();
        ConnectionMyMail x = new ConnectionMyMail();
        ds = x.search(query);
        if (ds != null)
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Mail m = new Mail();
                m.composeID = long.Parse(dr["composeId"].ToString());
                m = getMailDetail(m.composeID);
                if(m.IsDraft==false)
                    mails.Add(m);
            }
        return mails;
    }
    public static List<Mail> getDrafts(string username)
    {
        List<Mail> mails = new List<Mail>();
        string query = "Select * from Mail where isDraft=1 and senderid='" + username + "' ";
        DataSet ds = new DataSet();
        ConnectionMyMail x = new ConnectionMyMail();
        ds = x.search(query);
        if (ds != null)
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Mail m = new Mail();
                m.composeID = long.Parse(dr["composeId"].ToString());
                m = getMailDetail(m.composeID);
                
                    mails.Add(m);
            }
        return mails;
    }
    public static List<Mail> search(string keyword, string username)
    {
        Dictionary<long, Mail> mailbox = new Dictionary<long, Mail>();
        foreach (Mail m in getMail(username))
        {
            if (m.Subject.ToLower().Contains(keyword.ToLower()) || m.mailBody.ToLower().Contains(keyword.ToLower()))
            {
                if (!mailbox.ContainsKey(m.ComposeID))
                    mailbox.Add(m.ComposeID, m);
                continue;
            }
            foreach (Users u in m.cc)
            {
                if (u.Username.Contains(keyword))
                {
                    if (!mailbox.ContainsKey(m.ComposeID))
                        mailbox.Add(m.ComposeID, m);
                }
            }//cc
            foreach (Users u in m.bcc)
            {
                if (u.Username.ToLower().Contains(keyword.ToLower()))
                {
                    if (!mailbox.ContainsKey(m.ComposeID))
                        mailbox.Add(m.ComposeID, m);
                }
            }//bcc
            foreach (Users u in m.Receiver)
            {
                if (u.Username.ToLower().Contains(keyword.ToLower()))
                {
                    if (!mailbox.ContainsKey(m.ComposeID))
                        mailbox.Add(m.ComposeID, m);
                }
            }//receiver

        }//mails
        return mailbox.Values.ToList<Mail>();
    }//function

}

