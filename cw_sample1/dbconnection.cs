using System;
using System.Data.SqlClient;
using System.Data;

namespace cw_sample1
{
    class dbconnection
    {
        SqlConnection con;
        SqlCommand cmd;
   

        public dbconnection()
        {
            con = new SqlConnection("Data Source=DESKTOP-NSTIEA5;Initial Catalog=library;Integrated Security=True");

        }
        public int runcmd(string q)
        {
            con.Open();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Display(string q)
        {
            con.Open();
            SqlDataAdapter Da = new SqlDataAdapter(q, con);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            con.Close();
            return Dt;

        }
        public String GetNextMeid(string q)
        {
            string meid;


            con.Open();
            cmd = new SqlCommand(q, con);
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    double id = Convert.ToDouble(dr[0].ToString()) + 1;
                    meid = id.ToString("0000");
                }
                else if (Convert.IsDBNull(dr)) { meid = ("0001"); }

                else { meid = ("0001"); }
                con.Close();

                return meid;
            }
        }


        public string getData(string a)
        {
            String data = null;
            con.Open();
            cmd = new SqlCommand(a, con);
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    data = (dr[0]).ToString();
                }
            }

            con.Close();
            return data;
        }



        public DateTime getdate(string a)
        {
            
                DateTime data;
                con.Open();
                cmd = new SqlCommand(a, con);
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        data = Convert.ToDateTime(dr[0]);
                    }
                    else
                    {
                        throw new InvalidOperationException ("Reference No. Invalid. please try again");


                    }
                }
            
           
            con.Close();
            return data;
        }









    }
}

