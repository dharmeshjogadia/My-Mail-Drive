using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ComposeMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                if (Session["IsForward"] != null)
                {
                    Mail m = (Mail)Session["mailforward"];
                    //set the values
                    txtTOEmailId.Text = "";
                    txtBCCEmailId.Text = "";
                    txtCCEmailId.Text = "";
                    CKEditor1.Text = "";
                    FillComposeMail(m);
                    //set the session variable to null
                    Session["mailforward"] = null;
                    Session["IsForward"] = null;
                }
                if (Session["IsReply"] != null)
                {
                    Mail argMail = (Mail)Session["mailreply"];
                    //set the values
                    txtTOEmailId.Text = "";
                    txtBCCEmailId.Text = "";
                    txtCCEmailId.Text = "";
                    CKEditor1.Text = "";
                    txtTOEmailId.Text = argMail.Sender.Username;
                    txtSubject.Text = "Reply:" + argMail.Subject;
                    //set the session variable to null
                    Session["mailreply"] = null;
                    Session["IsReply"] = null;
                }
            }
        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Server Error");
            lblMsg.CssClass += " msg show";
        }

    }
    void FillComposeMail(Mail argMail)
    {

        CKEditor1.Text = "<br><br><br>-----------------------------------------------<br>";
        CKEditor1.Text += "Date:" + argMail.Send_time;
        CKEditor1.Text += "<bt>From:" + argMail.Sender.Firstname + " " + argMail.Sender.Lastname;
        CKEditor1.Text += "<br>To:";
        for (int i = 0; i < argMail.Receiver.Count; i++)
            CKEditor1.Text += argMail.Receiver[i].Username + ",";
        CKEditor1.Text += "<br>Cc:";
        for (int i = 0; i < argMail.Cc.Count; i++)
            CKEditor1.Text += argMail.Cc[i].Username + ",";
        CKEditor1.Text += "<br>Subject:" + argMail.Subject;
        CKEditor1.Text += "<br>Body:<br>" + Server.HtmlDecode(argMail.MailBody);
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            // Response.Write("<pre>" + Server.HtmlEncode(CKEditor1.Text) + "</pre>");
            Mail ComposeMail = new Mail();
            setMailDetail(ComposeMail);
            if (ComposeMail.Receiver.Count > 0 || ComposeMail.Cc.Count > 0 || ComposeMail.Bcc.Count > 0)
            {
                ComposeMail.sendMail();
                Response.Redirect("Inbox.aspx?success='Mail Sent Successfully'");
            }
            else
            {
                throw new Exception();
            }
                
        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In Mail Send");
            lblMsg.CssClass += " msg show";
        }
    }
    void setMailDetail(Mail ComposeMail)
    {

        ComposeMail.Sender = new Users(Session["username"].ToString());
        ComposeMail.Send_time = DateTime.Now;
        ComposeMail.LastAutoSaved = DateTime.Now;
        ComposeMail.MailBody = Server.HtmlEncode(CKEditor1.Text);
        ComposeMail.Subject = txtSubject.Text;
        ComposeMail.Receiver = CreateList(txtTOEmailId.Text);
        ComposeMail.Cc = CreateList(txtCCEmailId.Text);
        ComposeMail.Bcc = CreateList(txtBCCEmailId.Text);
        ComposeMail.AttachedFiles = new List<string>();
    }
    List<Users> CreateList(string Receiver)
    {
        List<string> list = Receiver.Split(',').ToList();
        List<Users> MailIds = new List<Users>();
        for (int i = 0; i < list.Count; i++)
        {
            if (Mail.userIsPresent(list[i]))
                MailIds.Add(new Users(list[i]));

        }
        if (list.Count != MailIds.Count)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Some Mail Ids are not valid");
            lblMsg.CssClass += " msg show";
        }
        return MailIds;
    }
    protected void btnSave_Click(Object sender, EventArgs e)
    {
        Mail ComposeMail = new Mail();
        setMailDetail(ComposeMail);
        ComposeMail.IsDraft = true;
        //ComposeMail. = true;
        // ComposeMail.saveAsDraft();
        ComposeMail.sendMail();
        Label lblMsg = (Label)Master.FindControl("Msg");
        lblMsg.Text = utility.SuccessMsg("Mail Drafted Successully");
        lblMsg.CssClass += " msg show";
    }
}