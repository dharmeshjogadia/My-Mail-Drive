using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    public class Contact
    {
        private string emailId;
        private string firstname;
        private string lastName;
        private string phoneNumber;
        private string organization;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public bool addContact(string userName)
        {
            try
            {
                string str = "insert into Contact values('" + userName + "','" + this.emailId + "','" + this.firstname + "','" + this.lastName + "','" + this.phoneNumber + "','" + this.organization + "')";
                ConnectionMyMail x = new ConnectionMyMail();
                x.exec(str);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool deleteContact(string userName)
        {
            try
            {
                string str = "delete * from Contact where userId='" + userName + "' and emailId='" + this.emailId + "'";
                ConnectionMyMail x = new ConnectionMyMail();
                x.exec(str);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public static List<Contact> getcontactsByUser(string Username)
        {
            List<Contact> contacts = new List<Contact>();
            string str = "Select * from Contact where userId='" + Username + "'";
            ConnectionMyMail x = new ConnectionMyMail();
            DataSet ds = x.search(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Contact tmp = new Contact();
                tmp.Firstname = ds.Tables[0].Rows[i]["firstName"].ToString();
                tmp.LastName = ds.Tables[0].Rows[i]["lastName"].ToString();
                tmp.phoneNumber= ds.Tables[0].Rows[i]["phoneNumber"].ToString();
                tmp.EmailId= ds.Tables[0].Rows[i]["emailId"].ToString();
                tmp.Organization = ds.Tables[0].Rows[i]["organization"].ToString();
                contacts.Add(tmp);
            }
                return contacts;
        }
        public bool updateContact(string userName)
        {
            try
            {
                string str = "update Contact set firstName='" + this.firstname + "',lastName='" + this.lastName + "',phoneNumber='" + this.phoneNumber + "',organization='" + this.organization + "' where userId='" + userName + "' and emailId='" + this.emailId + "'";
                ConnectionMyMail x = new ConnectionMyMail();
                x.exec(str);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
    

