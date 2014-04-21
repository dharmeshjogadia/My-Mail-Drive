using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            //load the values
            if (!IsPostBack)
            {
                Users user = (Users)Session["userLogin"];
                MailSetting m = user.UserSettings1;
                CKEditor1.Text = m.Signature.ToString();
                ddlPageSize.SelectedValue = m.MaxPageSize.ToString();
                ddlTheme.SelectedValue = m.Theme;
                if (m.Notification)
                    rbtnON.Checked = true;
                else
                    rbtnOFF.Checked = true;
                if (m.AutoCreateContact)
                    rbtnON1.Checked = true;
                else
                    rbtnOFF1.Checked = true;
            }
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }



    }
    protected void btnSaveGeneral_Click(object sender, EventArgs e)
    {
        try
        {
            //Mailsetting in user class
            Users user = (Users)Session["userLogin"];
            MailSetting m = user.UserSettings1;
            m.MaxPageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
            m.Theme = ddlTheme.SelectedValue.ToString();
            if (rbtnON.Checked)
                m.Notification = true;
            else
                m.Notification = false;
            if (rbtnON1.Checked)
                m.AutoCreateContact = true;
            else
                m.AutoCreateContact = false;
            m.updateMailSetting();
            user.UserSettings1 = m;
            Session["user"] = user;
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }


    }
    //protected void btnSaveSignature_Click(object sender, EventArgs e)
    //{
    //    //Mailsetting in user class
    //    Users user = (Users)Session["userLogin"];
    //     MailSetting m = user.UserSettings1;
    //     m.UserId = Session["username"].ToString();
    //    m.Signature = CKEditor1.Text;
    //    m.updateMailSetting();
    //    user.UserSettings1 = m;
    //    Session["user"] = user;


    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //bool flag = true;
        //Users user = (Users)Session["userLogin"];
        //user.Password = txtNewPwd.Text;
        //user.SecurityQuestion = ddlQuestion.SelectedValue;
        //user.Answer = txtAnswer.Text;
        //if (!txtOldPwd.Text.Equals(user.Password.ToString()))
        //{
        //    //error message
        //    flag = false;
        //}
        //if (!txtNewPwd.Text.Equals(txtConfPwd.Text))
        //{
        //    //error message
        //    flag = false;
        //}
        //if (flag)
        //{
        //    user.updateUserDetails();
        //    Session["userLogin"] = user;
        //}

    }
    protected void btnSaveGeneral_Click1(object sender, EventArgs e)
    {
        try
        {
            MailSetting m = new MailSetting();
            m.Signature = CKEditor1.Text;
            m.UserId = ((Users)Session["userLogin"]).Username;
            m.MaxPageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
            m.Theme = ddlTheme.SelectedValue.ToString();
            if (rbtnOFF.Checked == true)
            {
                m.Notification = false;
            }
            else
                m.Notification = true;
            if (rbtnOFF1.Checked == true)
                m.AutoCreateContact = false;
            else
                m.AutoCreateContact = true;
            m.updateMailSetting();
            Users userLogin = (Users)Session["userLogin"];
            userLogin.UserSettings1 = m;
            Label Msg = (Label)Master.FindControl("Msg");
            Msg.Text = utility.SuccessMsg("General Settings Save Successfully");
            Msg.CssClass += " show msg";
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }

    protected void btnSaveSignature_Click(object sender, EventArgs e)
    {

        try
        {
            MailSetting m = new MailSetting();
            m.Signature = CKEditor1.Text;
            m.UserId = ((Users)Session["userLogin"]).Username;
            m.MaxPageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
            m.Theme = ddlTheme.SelectedValue.ToString();
            if (rbtnOFF.Checked == true)
            {
                m.Notification = false;
            }
            else
                m.Notification = true;
            if (rbtnOFF1.Checked == true)
                m.AutoCreateContact = false;
            else
                m.AutoCreateContact = true;
            m.updateMailSetting();
            Label Msg = (Label)Master.FindControl("Msg");
            Msg.Text = utility.SuccessMsg("Signature Save Successfully");
            Msg.CssClass += " show msg";
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
       
    protected void btnSaveAct_OnClick(object sender, EventArgs e)
    {
        try
        {
            MailSetting m = new MailSetting();

            m.Signature = CKEditor1.Text;
            m.UserId = ((Users)Session["userLogin"]).Username;
            m.MaxPageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
            m.Theme = ddlTheme.SelectedValue.ToString();
            if (rbtnOFF.Checked == true)
            {
                m.Notification = false;
            }
            else
                m.Notification = true;
            if (rbtnOFF1.Checked == true)
                m.AutoCreateContact = false;
            else
                m.AutoCreateContact = true;

            Users user = new Users();
            user = (Users)Session["userLogin"];
            if (txtOldPwd.Text == user.Password.ToString())
            {
                if (txtNewPwd.Text == txtConfPwd.Text)
                {
                    user.Password = txtNewPwd.Text;
                    user.SecurityQuestion = ddlQuestion.SelectedValue.ToString();
                    user.Answer = txtAnswer.Text;
                    user.updateUserDetails();
                    Label Msg = (Label)Master.FindControl("Msg");
                    Msg.Text = utility.SuccessMsg("Password Change Save Successfully");
                    Msg.CssClass += " show msg";
                }
                else
                {
                    //mesage(new pass and cnfrm pass not match)

                }
            }
            else
            {
                // message(old pass wrong)
                Label Msg = (Label)Master.FindControl("Msg");
                Msg.Text = utility.ErrorMsg("Wrong Old Password");
                Msg.CssClass += " show msg";
            }

        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
}