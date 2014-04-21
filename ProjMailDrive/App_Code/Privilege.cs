using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  public enum Role
    {
        ADMIN,USER
    }
    public class Privilege
    {
        private Role role;
        private bool modifypassword;
        private bool viewPassword;
        private bool viewSpamFilter;
        private bool modifySpamFilter;

        public bool ModifySpamFilter
        {
            get { return modifySpamFilter; }
            set { modifySpamFilter = value; }
        }
        public bool ViewSpamFilter
        {
            get { return viewSpamFilter; }
            set { viewSpamFilter = value; }
        }
        
        public bool ViewPassword
        {
            get { return viewPassword; }
            set { viewPassword = value; }
        }
        public bool Modifypassword
        {
            get { return modifypassword; }
            set { modifypassword = value; }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        } 
    }

