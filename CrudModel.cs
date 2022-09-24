namespace WebApplication1
{


    using System.Data;
    using Microsoft.Data.SqlClient;

   
        public class CRUDModel
        {
            /// <summary>    
            /// Get all records from the DB    
            /// </summary>    
            /// <returns>Datatable</returns>    
            public DataTable GetAllStudents()
            {
                DataTable dt = new DataTable();
                string strConString = @"Data Source=WELCOME-PC\SQLSERVER2008;Initial Catalog=MyDB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblStudent", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }

            /// <summary>    
            /// Get student detail by Student id    
            /// </summary>    
            /// <param name="intStudentID"></param>    
            /// <returns></returns>    
            public DataTable GetStudentByID(int intStudentID)
            {
                DataTable dt = new DataTable();

                string strConString = @"Data Source=WELCOME-PC\SQLSERVER2008;Initial Catalog=MyDB;User Id=myUsername;Password=myPassword;";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblStudent where student_id=" + intStudentID, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }

            /// <summary>    
            /// Update the student details    
            /// </summary>    
            /// <param name="intStudentID"></param>    
            /// <param name="strStudentName"></param>    
            /// <param name="strGender"></param>    
            /// <param name="intAge"></param>    
            /// <returns></returns>    
            public int UpdateStudent(int intStudentID, string strStudentName, string strGender, int intAge)
            {
                string strConString = @"Data Source=WELCOME-PC\SQLSERVER2008;Initial Catalog=MyDB;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = String.Format("Update tblStudent SET student_name={0}, student_age={1} , student_gender={2} where student_id={3}","test1","test2","test3");
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@studname", strStudentName);
                    //cmd.Parameters.AddWithValue("@studage", intAge);
                    //cmd.Parameters.AddWithValue("@gender", strGender);
                    //cmd.Parameters.AddWithValue("@studid", intStudentID);
                    return cmd.ExecuteNonQuery();
                }
            }

            /// <summary>    
            /// Insert Student record into DB    
            /// </summary>    
            /// <param name="strStudentName"></param>    
            /// <param name="strGender"></param>    
            /// <param name="intAge"></param>    
            /// <returns></returns>    
            public int InsertStudent(string strStudentName, string strGender, int intAge)
            {
                string strConString = @"Data Source=WELCOME-PC\SQLSERVER2008;Initial Catalog=MyDB;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = "Insert into tblStudent (student_name, student_age,student_gender) values(@studname, @studage , @gender)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studname", strStudentName);
                    cmd.Parameters.AddWithValue("@studage", intAge);
                    cmd.Parameters.AddWithValue("@gender", strGender);
                    return cmd.ExecuteNonQuery();
                }
            }

            /// <summary>    
            /// Delete student based on ID    
            /// </summary>    
            /// <param name="intStudentID"></param>    
            /// <returns></returns>    
            public int DeleteStudent(int intStudentID)
            {
                string strConString = @"Data Source=WELCOME-PC\SQLSERVER2008;Initial Catalog=MyDB;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = "Delete from tblStudent where student_id=@studid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studid", intStudentID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }



