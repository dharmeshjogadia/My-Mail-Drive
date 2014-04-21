using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

 public   class ConnectionMyMail
    {
        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter adp = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public ConnectionMyMail()
        {
            cn = new SqlConnection("Data Source=.;Initial Catalog=myMail;User ID=sa");
            if (cn.State == ConnectionState.Broken)
            {
                cn.Open();
            }
            else if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public void exec(string qry)
        {
            cmd = new SqlCommand(qry, cn);
            cmd.ExecuteNonQuery();
        }
        public DataSet search(string qry)
        {
            ds = new DataSet();
            adp = new SqlDataAdapter(qry, cn);
            adp.Fill(ds);
            return ds;
        }
        public DataSet schema(string qry)
        {
            ds = new DataSet();
            adp = new SqlDataAdapter("select * from " + qry + "", cn);
            adp.FillSchema(ds, SchemaType.Mapped);
            return ds;
        }

    }

