using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string userName;
    public string photoPath,theme;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["username"] == null)
            Response.Redirect("Default.aspx");
        Users userLogin=(Users)Session["userLogin"];
        userName = getUserName(userLogin);
        photoPath = (userLogin.PhotoFile.Length > 0) ? userLogin.PhotoFile : "image/account.png";
        theme = userLogin.UserSettings1.Theme;
    }
    protected void btnLogout_click(object sender, EventArgs e) {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected string getUserName(Users userlogin)
    {
        return userlogin.Firstname + " " + userlogin.Lastname;
    }
}
