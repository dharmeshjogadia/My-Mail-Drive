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

            //get all contacts of particular user and display in grid
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                FillContacts();

            }
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

       

    }
    public void FillContacts()
    {
        List<Contact> contacts = Contact.getcontactsByUser("201312021@daiict.ac.in");
    
        if (contacts.Count > 0)
            gvContacts.DataSource = contacts;
        gvContacts.DataBind();
    
    }
    public void Clear()
    {

        txtEmailId.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        txtOrgnization.Text = "";
        txtPhoneNo.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Contact c = new Contact();
            c.EmailId = txtEmailId.Text;
            c.Firstname = txtFName.Text;
            c.LastName = txtLName.Text;
            c.Organization = txtOrgnization.Text;
            c.PhoneNumber = txtPhoneNo.Text;
            c.addContact("201312021@daiict.ac.in");
            Clear();
            FillContacts();
        }
        catch
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
}