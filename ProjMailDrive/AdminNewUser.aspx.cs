using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the list of all users(if required)
        if (!IsPostBack)
        {
            fillUserList();
        }

    }
    void fillUserList()
    {
        List<Users> users = Users.getallUserDetails();
        gvUserList.DataSource = users;
        gvUserList.DataBind();
    }
    protected String GetSenderName(Users Sender)
    {
        return Sender.Firstname + " " + Sender.Lastname;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {



            //intially set the password as the username
            Users user = new Users();
            MailSetting s = new MailSetting();
            s.Signature = "";
            s.Theme = "";//set default theme
            s.Notification = false;
            s.AutoCreateContact = false;
            s.MaxPageSize = 10;
            user.UserSettings1 = s;

            Privilege p = new Privilege();
            p.Role = Role.USER;
            p.ViewPassword = false;
            p.ViewSpamFilter = false;
            p.Modifypassword = false;
            p.ModifySpamFilter = false;
            user.UserPrivilege = p;

            user.Firstname = txtFName.Text;
            user.Lastname = txtLName.Text;
            user.Username = txtEmailId.Text;
            user.Password = txtEmailId.Text;
            user.SecurityQuestion = "";
            user.Answer = "";
            if (rbtnActive.Checked)
                user.Astatus = true;
            else
                user.Astatus = false;
            if (rbtnMale.Checked)
                user.Gender = true;
            else
                user.Gender = false;
            user.PhoneNumber = txtPhoneNo.Text;
            user.Password = txtEmailId.Text.Substring(0, txtEmailId.Text.LastIndexOf("@"));
            user.PhotoFile = "image/Account.png";//intially the photo file is empty
            user.UserSettings1.Theme = "bootstrap.min.css";
            bool result = user.createUser();

            if (result)
            {
                //creating a new directory for a user
                string path = Server.MapPath("Drive") + "\\" + txtEmailId.Text.Substring(0, txtEmailId.Text.IndexOf("@"));
                DirectoryInfo ObjSearchDir = new DirectoryInfo(path);
                if (!ObjSearchDir.Exists)
                {
                    ObjSearchDir.Create();
                }
                //creating a new directory for attachments
                path += "//" + "Attachment";
                ObjSearchDir = new DirectoryInfo(path);
                if (!ObjSearchDir.Exists)
                {
                    ObjSearchDir.Create();
                }
            }
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.SuccessMsg("User Save Successfully");
            lblMsg.CssClass += " msg show";
            fillUserList();
        }
        catch (Exception )
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";
        }
    }
}