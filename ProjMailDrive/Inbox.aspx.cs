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
        // all inbox mails for a user

        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                if (Request.QueryString["success"] != null)
                {
                    if (Request.QueryString["success"].ToString().Length > 0)
                    {
                        Label lblMsg = (Label)Master.FindControl("Msg");
                        lblMsg.Text = utility.SuccessMsg(Request.QueryString["success"].ToString());
                        lblMsg.CssClass += " msg show";
                    }
                }

                FillInbox();
                Users userLogin = Users.getUserDetails(Session["username"].ToString());

            }
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

        List<Mail> mails = Mail.getInbox(Session["username"].ToString());
        //display the mails
        gvInbox.DataSource = mails;
        gvInbox.DataBind();
    }
    protected String GetSenderName(Users Sender)
    {
        return Sender.Firstname + " " + Sender.Lastname;
    }
    protected void gvInbox_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GridViewRow row = gvInbox.Rows[e.NewSelectedIndex];
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