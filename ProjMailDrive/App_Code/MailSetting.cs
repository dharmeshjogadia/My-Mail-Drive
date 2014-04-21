using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MailSetting
{
    private int maxPageSize;
    private string userId;
    private string theme;

    public string Theme
    {
        get { return theme; }
        set { theme = value; }
    }
    public string UserId
    {
        get { return userId; }
        set { userId = value; }
    }
    public int MaxPageSize
    {
        get { return maxPageSize; }
        set { maxPageSize = value; }
    }

    private bool notification;

    public bool Notification
    {
        get { return notification; }
        set { notification = value; }
    }

    private string signature;

    public string Signature
    {
        get { return signature; }
        set { signature = value; }
    }

    private bool autoCreateContact;

    public bool AutoCreateContact
    {
        get { return autoCreateContact; }
        set { autoCreateContact = value; }
    }
    public bool updateMailSetting()
    {

        ConnectionMyMail x = new ConnectionMyMail();
        Int16 k1, k2;
        try
        {
            if (this.autoCreateContact == true)
                k1 = 1;
            else
                k1 = 0;
            if (this.notification == true)
                k2 = 1;
            else
                k2 = 0;
            string query = "update MailSetting set ";
            query += "maxPageSize=" + this.maxPageSize + ",";
            query += "theme='" + this.Theme + "',";
            query += "signature='" + this.Signature + "',";
            query += "notification=" + k2 + ",";
            query += "autoCreateContact=" + k1 + " ";
            query += "where userId='" + this.UserId + "'";
            x.exec(query);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool insertMailSetting()
    {
        string str;
        ConnectionMyMail x = new ConnectionMyMail();
        str = "insert into MailSetting values('" + this.UserId + "'," + this.maxPageSize + ",";
        str += (this.notification) ? "1" : "0" + ",'" + this.signature + "',";
        str+=(this.autoCreateContact)?"1":"0" + ",'" + this.theme + "')";
        x.exec(str);
        return true;
    }
}
