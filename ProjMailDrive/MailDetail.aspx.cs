using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                if (Session["ComposeId"] != null)
                {
                    string composeId = Session["ComposeId"].ToString();
                    Mail readMail = Mail.getMailDetail(Convert.ToInt32(composeId));
                    ltlSenderName.Text = readMail.Sender.Firstname + " " + readMail.Sender.Lastname;
                    ltlSenderId.Text = readMail.Sender.Username;
                    ltlSubject.Text = readMail.Subject;

                    for (int i = 0; i < readMail.Receiver.Count; i++)
                        ltlTo.Text += readMail.Receiver[i].Firstname + " " + readMail.Receiver[i].Lastname + "&lt" + readMail.Receiver[i].Username + "&gt,";
                    for (int i = 0; i < readMail.Cc.Count; i++)
                        ltlCc.Text += readMail.Cc[i].Firstname + " " + readMail.Cc[i].Lastname + "&lt" + readMail.Cc[i].Username + "&gt,";

                    ltlDateTime.Text = readMail.Send_time.ToString();
                    ltlBody.Text = Server.HtmlDecode(readMail.MailBody);
                }
                else
                    Response.Redirect("Inbox.aspx");


            }
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void btnForvard_Click(object sender, EventArgs e)
    {
        //Create mail object
        //Mail m=new Mail();
        //set the values
        try
        {
            string composeId = Session["ComposeId"].ToString();
            Mail forwardMail = Mail.getMailDetail(Convert.ToInt32(composeId));
            //forwardMail.discardMail();

            Session["MailForward"] = forwardMail;
            Session["IsForward"] = true;
            Response.Redirect("ComposeMail.aspx");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void btnSpam_Click(object sender, EventArgs e)
    {
        try
        {
            string composeId = Session["ComposeId"].ToString();
            Mail spamMail = Mail.getMailDetail(Convert.ToInt32(composeId));
            spamMail.markAsSpam();
            Response.Redirect("Inbox.aspx?success='Mail Spam Successully'");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string composeId = Session["ComposeId"].ToString();
            Mail deleteMail = Mail.getMailDetail(Convert.ToInt32(composeId));

            deleteMail.discardMail();

            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.SuccessMsg(" Mail Deleted Successully");
            lblMsg.CssClass += " msg show";
            Response.Redirect("Inbox.aspx?success='Mail Deleted Successully'");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void btnReplay_Click(object sender, EventArgs e)
    {
        try
        {
            string composeId = Session["ComposeId"].ToString();
            Mail replyMail = Mail.getMailDetail(Convert.ToInt32(composeId));
            //forwardMail.discardMail();
            Session["MailReply"] = replyMail;
            Session["IsReply"] = true;

            Response.Redirect("ComposeMail.aspx");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected string getSenderName(Users Sender)
    {
        return Sender.Firstname + " " + Sender.Lastname;
    }
    protected string getToMailId(List<Users> ToMailIds)
    {
        return ToMailIds.ToString();
    }

}