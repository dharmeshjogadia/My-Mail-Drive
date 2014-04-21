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
            // all inbox mails for a user
            if (!IsPostBack)
                FillInbox();
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }


    }
    protected void FillInbox()
    {

        List<Mail> mails = Mail.getSpamMail(Session["username"].ToString());
        gvSent.DataSource = mails;
        gvSent.DataBind();
    }
    protected String GetSenderName(Users Receiver)
    {
        try
        {
            if (Receiver != null)
                return Receiver.Firstname + " " + Receiver.Lastname + ",";
            else
                return "";
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }
        return null;
    }
    protected String GetSenderName(List<Users> Receiver)
    {
        try
        {
            if (Receiver != null)
                return Receiver[0].Firstname + " " + Receiver[0].Lastname + ",";
            else
                return "";
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";
            return null;
        }
        
    }
    protected void gvInbox_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GridViewRow row = gvSent.Rows[e.NewSelectedIndex];
            HiddenField ComposeId = (HiddenField)row.FindControl("hdfComposeId");

            Session["ComposeId"] = ComposeId.Value;
            Response.Redirect("MailDetail.aspx");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }

}