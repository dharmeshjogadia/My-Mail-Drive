using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MailDriveClassLibrary;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userLogin"] != null)
                Response.Redirect("Inbox.aspx");

        }
        catch (Exception)
        {
            if (Session["userLogin"] != null)
                Response.Redirect("Inbox.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {

            bool isvalid = Users.authenticateUser(txtUserName.Text, txtPwd.Text);

            if (isvalid)
            {
                Session["username"] = txtUserName.Text;
                Session["password"] = txtPwd.Text;
                Users userLogin = Users.getUserDetails(txtUserName.Text);

                Session["userLogin"] = userLogin;
                Msg.Text = utility.SuccessMsg("Invalid User Name or Password");
                Msg.CssClass += " show msg";
                Response.Redirect("Inbox.aspx");

            }
            else
            {
                Msg.Text = utility.ErrorMsg("Invalid User Name or Password");
                Msg.CssClass += " show msg";
            }
 
        }
        catch (Exception)
        {
            if (Session["userLogin"] != null)
                Response.Redirect("Inbox.aspx");
        }

   }
}