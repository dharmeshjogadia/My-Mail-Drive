using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
public enum Gender
{
    MALE, FEMALE
}
public enum LoginStatus
{
    ONLINE, OFFLINE
}
public enum AccountStatus
{
    BLOCKED, SUSPENDED, ACTIVE
}

public class Users
{
    private string username;
    private string password;
    private string firstname;
    private string lastName;
    private bool gender;
    private DateTime dateOfBirth = new DateTime(1992, 1, 1);
    private string photoFile;
    public Users() { }
    public Users(string uid) { username = uid; }
    public string PhotoFile
    {
        get { return photoFile; }
        set { photoFile = value; }
    }
    private String phoneNumber; //
    private string securityQuestion;
    private string answer;
    private Boolean loginStatus; //
    private Boolean astatus; //
    private MailSetting UserSettings;

    public MailSetting UserSettings1
    {
        get { return UserSettings; }
        set { UserSettings = value; }
    }
    public Boolean Astatus
    {
        get { return astatus; }
        set { astatus = value; }
    }
    private List<Contact> contacts;
    private Privilege privilege; //        
    public string Username
    {
        get
        {
            return this.username;
        }
        set
        {
            this.username = value;
        }
    }
    public string Password
    {
        set
        {
            this.password = value;
        }
        get
        {
            return this.password;
        }
    }
    public string Firstname
    {
        get
        {
            return this.firstname;
        }
        set
        {
            this.firstname = value;
        }
    }
    public string Lastname
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }
    public bool Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
        }
    }
    public Boolean LStatus
    {
        set
        {
            loginStatus = value;
        }
        get
        {
            return loginStatus;
        }
    }
    public string SecurityQuestion
    {
        get
        {
            return securityQuestion;
        }
        set
        {
            securityQuestion = value;
        }
    }
    public DateTime DateOfBirth
    {
        get
        {
            return dateOfBirth;
        }
        set
        {
            dateOfBirth = value;
        }
    }
    public string Answer
    {
        get
        {
            return answer;
        }
        set
        {
            answer = value;
        }
    }
    public String PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            phoneNumber = value;
        }
    }
    public List<Contact> UserContacts
    {
        get
        {
            return contacts;
        }
        set
        {
            contacts = value;
        }
    }
    public Privilege UserPrivilege
    {
        get
        {
            return privilege;
        }
        set
        {
            privilege = value;
        }
    }
    public static bool authenticateUser(string username, string password)
    {
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "select * from [User] where userId='" + username + "' and password='" + password + "'";
        DataSet ds = new DataSet();
        ds = x.search(str);
        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }
    public bool createUser()
    {
        ConnectionMyMail x = new ConnectionMyMail();
        String str = "insert into [User] values('" + this.username + "','" + this.password + "','" + this.firstname + "','" + this.lastName + "','" + this.gender + "',Convert(DATETIME,'" + this.dateOfBirth + "',103),'" + this.photoFile + "','" + this.phoneNumber + "','" + this.securityQuestion + "','" + this.answer + "',";
        str += (this.loginStatus) ? "1" : "0" + ",";
        str += (this.astatus) ? "1" : "0";
        str += ")";
        x.exec(str);
        this.UserSettings1.UserId = this.Username;
        this.UserSettings1.insertMailSetting();
        return true;
    }
    public bool updateUserDetails()
    {
        try
        {
            string str = "update [User] set password='" + this.password + "',firstName='" + this.firstname + "',lastName='" + this.lastName + "',gender='" + this.gender + "',dateOfBirth=Convert(DATETIME,'" + this.dateOfBirth + "',103),photoFile='" + this.photoFile + "',phoneNumber='" + this.phoneNumber + "',securityQuestion='" + this.securityQuestion + "',answer='" + this.answer + "',loginStatus='" + this.loginStatus + "',accountStatus='" + this.astatus + "' where userId='" + this.username + "'";
            ConnectionMyMail x = new ConnectionMyMail();
            x.exec(str);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }


    }
    public void AddContact(Contact c)
    {
        c.addContact(this.username);
    }

    public static Users getUserDetails(string username)
    {
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "select * from [User] where userId='" + username + "'";
        DataSet ds = new DataSet();
        ds = x.search(str);
        Users u = new Users();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //set the values according to the database
            u.Username = ds.Tables[0].Rows[0]["userId"].ToString();
            u.Firstname = ds.Tables[0].Rows[0]["firstName"].ToString();
            u.Lastname = ds.Tables[0].Rows[0]["lastName"].ToString();
            u.Password = ds.Tables[0].Rows[0]["password"].ToString();
            if (!Convert.IsDBNull(ds.Tables[0].Rows[0]["dateOfBirth"]))
                u.DateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[0]["dateOfBirth"].ToString());

            u.PhotoFile = ds.Tables[0].Rows[0]["photoFile"].ToString();
            u.PhoneNumber = ds.Tables[0].Rows[0]["phoneNumber"].ToString();
            u.Answer = ds.Tables[0].Rows[0]["answer"].ToString();
            u.Astatus = Convert.ToBoolean(ds.Tables[0].Rows[0]["accountStatus"]);
            u.SecurityQuestion = ds.Tables[0].Rows[0]["securityQuestion"].ToString();
            //set the rest of fields

            str = "select * from MailSetting where userId='" + username + "'";
            ds = new DataSet();
            ds = x.search(str);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                u.UserSettings = new MailSetting();
                u.UserSettings.MaxPageSize = (int)ds.Tables[0].Rows[0]["maxPageSize"];
                u.UserSettings.Notification = ((Boolean)ds.Tables[0].Rows[0]["notification"]);
                u.UserSettings.Signature = ds.Tables[0].Rows[0]["signature"].ToString();
                u.UserSettings.AutoCreateContact = ((Boolean)ds.Tables[0].Rows[0]["autoCreateContact"]);
                u.UserSettings.Theme = ds.Tables[0].Rows[0]["theme"].ToString();
            }
            return u;
        }
        return null;
    }
    public static List<Users> getallUserDetails()
    {
        List<Users> users = new List<Users>();
        ConnectionMyMail x = new ConnectionMyMail();
        string str = "select * from [User]";
        DataSet ds = new DataSet();
        ds = x.search(str);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Users u = new Users();
            u.Username = ds.Tables[0].Rows[i]["userId"].ToString();
            u.Firstname = ds.Tables[0].Rows[i]["firstName"].ToString();
            u.Lastname = ds.Tables[0].Rows[i]["lastName"].ToString();
            u.Password = ds.Tables[0].Rows[i]["password"].ToString();
            if (!Convert.IsDBNull(ds.Tables[0].Rows[i]["dateOfBirth"]))
                u.DateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[i]["dateOfBirth"].ToString());

            u.PhotoFile = ds.Tables[0].Rows[i]["photoFile"].ToString();
            u.PhoneNumber = ds.Tables[0].Rows[i]["phoneNumber"].ToString();
            u.Answer = ds.Tables[0].Rows[i]["answer"].ToString();
            //u.Astatus = Convert.ToBoolean(ds.Tables[0].Rows[i]["accountStatus"]);
            u.SecurityQuestion = ds.Tables[0].Rows[i]["securityQuestion"].ToString();
            users.Add(u);
        }
        return users;

    }

}

