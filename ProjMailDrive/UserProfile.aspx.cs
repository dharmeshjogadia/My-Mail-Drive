using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class UserProfile : System.Web.UI.Page
{
    string photoPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
                Load_User_Profile(Session["username"].ToString());
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    private void Load_User_Profile(string userName)
    {
        try
        {
            if (!IsPostBack)
            {
                ConnectionMyMail x = new ConnectionMyMail();
                DataSet ds;
                string str = "select * from [User] where userId='" + userName + "'";
                ds = new DataSet();
                ds = x.search(str);
                lblFirstName.Text = ds.Tables[0].Rows[0][2].ToString();
                lblLastName.Text = ds.Tables[0].Rows[0][3].ToString();
                lblEmailId.Text = ds.Tables[0].Rows[0][0].ToString();
                lblGender.Text = ds.Tables[0].Rows[0][4].ToString();
                if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["dateOfBirth"]))
                    lblBirthDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0][5]).ToLongDateString();
                lblMobileNumber.Text = ds.Tables[0].Rows[0][7].ToString();
                txtFName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0][0].ToString();
                txtLName.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPhoneNo.Text = ds.Tables[0].Rows[0][7].ToString();
                photoPath = ds.Tables[0].Rows[0][6].ToString();
                imgProfilePic.ImageUrl = ds.Tables[0].Rows[0][6].ToString();
                imgEditProfile.ImageUrl = ds.Tables[0].Rows[0][6].ToString();

                Users userLogin = Users.getUserDetails(Session["username"].ToString());
                Session["userLogin"] = userLogin;
            }
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ConnectionMyMail x = new ConnectionMyMail();
            string str1 = "update [User] set firstName='" + txtFName.Text + "',lastName='" + txtLName.Text + "',phoneNumber='" + txtPhoneNo.Text + "' where userId='" + Session["username"].ToString() + "'";
            x.exec(str1);
            string fileName = flupPhoto.PostedFile.FileName;
            if (flupPhoto.HasFile == true)
            {
                string postedFileName = Server.MapPath("Drive") + "\\profilePic\\" + fileName;
                if (postedFileName != photoPath)
                {
                    flupPhoto.PostedFile.SaveAs(postedFileName);
                    postedFileName = "Drive/profilePic/" + fileName;
                    imgProfilePic.ImageUrl = postedFileName;
                    imgEditProfile.ImageUrl = postedFileName;
                    string str = "update [User] set photoFile='" + postedFileName + "' where userId='" + Session["username"].ToString() + "'";
                    x.exec(str);
                }
            }

            Response.Redirect("UserProfile.aspx");
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }


    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserProfile.aspx");
    }
}