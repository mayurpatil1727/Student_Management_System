using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App1_withMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace App1_withMVC.Models
{
    public class StudentDAL
    {
        public static string connectionString = "Data Source=172.16.18.15; Initial Catalog=TestingDB; Integrated Security=False; User ID=mayur; Password=mayur@hbits;";

        public static string E_ID;
        public static string P_WD;
        //method to save data from regestration form to database 
        public void SaveData(string FirstName, string LastName, string StudentEmail, string StudentPassword, string Sque, string Sans, int lockstatusbit, string CreatedBy, string Time, int CountStatus)
        {
            DataTable studentTable = new DataTable();
            studentTable.Columns.Add("FirstName", typeof(string));
            studentTable.Columns.Add("LastName", typeof(string));
            studentTable.Columns.Add("StudentEmail", typeof(string));
            studentTable.Columns.Add("StudentPassword", typeof(string));
            studentTable.Columns.Add("Sque", typeof(string));
            studentTable.Columns.Add("Sans", typeof(string));
            studentTable.Columns.Add("Lockstatus", typeof(int));
            studentTable.Columns.Add("CreatedBy", typeof(string));
            studentTable.Columns.Add("Time", typeof(DateTime));
            studentTable.Columns.Add("CountStatus", typeof(int));

            studentTable.Rows.Add(
                FirstName,
                LastName,
                StudentEmail,
                StudentPassword,
                Sque,
                Sans,
                lockstatusbit,
                CreatedBy,
                DateTime.Parse(Time),
                CountStatus
            );

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertStudentStaticInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = cmd.Parameters.AddWithValue("@StudentInfo", studentTable);
                parameter.SqlDbType = SqlDbType.Structured;

                cmd.ExecuteNonQuery();
            }
        }



        //public void SaveEditedData(int id, string FirstName, string LastName, string StudentEmail, string StudentPassword, string Sque, string Sans, string Qualification, string InstName, int PassYear, int Score)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand("SaveEditedData", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ID", id);
        //            cmd.Parameters.AddWithValue("@FirstName", FirstName);
        //            cmd.Parameters.AddWithValue("@LastName", LastName);
        //            cmd.Parameters.AddWithValue("@StudentEmail", StudentEmail);
        //            cmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
        //            cmd.Parameters.AddWithValue("@Sque", Sque);
        //            cmd.Parameters.AddWithValue("@Sans", Sans);
        //            cmd.Parameters.AddWithValue("@Qualification", Qualification);
        //            cmd.Parameters.AddWithValue("@InstName", InstName);
        //            cmd.Parameters.AddWithValue("@PassYear", PassYear);
        //            cmd.Parameters.AddWithValue("@Score", Score);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}



        // method to validate user whether entered credentials are correct
        public bool ValidateUser(string E_ID, string P_WD, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("ValidateUser", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentEmail", E_ID);
                    command.Parameters.AddWithValue("@StudentPassword", P_WD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }


        public DataSet GetAllStudents()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("GetAllStudentsFromDB", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            return ds;
        }


        public string GetIPAddress()
        {
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address =>
            address.AddressFamily == AddressFamily.InterNetwork).First();
            string ipadd = ip.ToString();
            return ipadd;
        }

        public bool getBitValuefromDB(string E_ID, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("GetLockStatus", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentEmail", E_ID);

                    bool lockStatus = (bool)command.ExecuteScalar();
                    return lockStatus;
                }
            }
        }



        public void insertLoginStatus_pass_IpAddress(string E_ID, string P_WD)
        {
            int LoginStatus = 1;
            string IPaddress = GetIPAddress();
            DateTime Time = DateTime.Now;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string LoginDetailsSP = "InsertLoginStatus";

                SqlCommand cmd = new SqlCommand(LoginDetailsSP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", E_ID);
                cmd.Parameters.AddWithValue("@Password", P_WD);
                cmd.Parameters.AddWithValue("@LoginStatus", LoginStatus);
                cmd.Parameters.AddWithValue("@IPaddress", IPaddress);
                cmd.Parameters.AddWithValue("@Time", Time);

                cmd.ExecuteNonQuery();
            }
        }


        public void insertLoginStatus_fail_IpAddress(string E_ID, string P_WD)
        {
            int LoginStatus = 0;
            string IPaddress = GetIPAddress();
            DateTime Time = DateTime.Now;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string LoginDetailsSP = "InsertLoginStatus";

                SqlCommand cmd = new SqlCommand(LoginDetailsSP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", E_ID);
                cmd.Parameters.AddWithValue("@Password", P_WD);
                cmd.Parameters.AddWithValue("@LoginStatus", LoginStatus);
                cmd.Parameters.AddWithValue("@IPaddress", IPaddress);
                cmd.Parameters.AddWithValue("@Time", Time);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCount(string E_ID, string P_WD)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateCountStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", E_ID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int getCountStatusValuefromDB(string E_ID, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("GetCountStatus", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentEmail", E_ID);

                    int countStatus = (int)command.ExecuteScalar();
                    return countStatus;
                }
            }
        }

        public void updateLockStatus(string E_ID, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("UpdateLockStatus", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentEmail", E_ID);

                    command.ExecuteNonQuery();
                }
            }
        }



        public void deleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DeleteUserfromDB", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public StudentModel getProfile(string E_ID)
        {
            StudentModel mod1 = new StudentModel(); // object of model class
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentProfileStaticInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentEmail", E_ID);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        mod1.StudentID = (int)dr["StudentID"];
                        mod1.FirstName = dr["FirstName"].ToString();
                        mod1.LastName = dr["LastName"].ToString();
                        mod1.StudentEmail = dr["StudentEmail"].ToString();
                        mod1.StudentPassword = dr["StudentPassword"].ToString();
                        mod1.Sque = dr["Sque"].ToString();
                        mod1.Sans = dr["Sans"].ToString();
                    }

                    con.Close();
                }
            }

            return mod1;
        }

        public StudentModel getSecurityQueForEdit(int id)
        {
            StudentModel mod1 = new StudentModel(); // object of model class
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getSecurityQueForEdit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", id);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        mod1.Sque = dr["Sque"].ToString();
                    }

                    con.Close();
                }
            }

            return mod1;
        }

        public StudentModel getProfilebyID(int id, string connectionString)
        {
            StudentModel mod1 = new StudentModel(); // object of model class
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // logic to select data of the entered email id user 
                con.Open();
                using (SqlCommand command = new SqlCommand("GetProfileByID", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", id);

                    // logic to read the data of the entered email id user and store it in the object of the model class
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mod1.StudentID = (int)reader["StudentID"];
                            mod1.FirstName = reader["FirstName"].ToString();
                            mod1.LastName = reader["LastName"].ToString();
                            mod1.StudentEmail = reader["StudentEmail"].ToString();
                            mod1.StudentPassword = reader["StudentPassword"].ToString();
                            mod1.Sque = reader["Sque"].ToString();
                            mod1.Sans = reader["Sans"].ToString();
                        }
                    }
                }
            }

            return mod1;
        }



        public Object ListOfAllUsers()
        {
            StudentDAL objdal = new StudentDAL();  // object of dal class
            DataSet ds = new DataSet();  // object of dataset
            ds = objdal.GetAllStudents();  // with DAL class object calling method of DAL class
            List<StudentModel> lst = new List<StudentModel>();  // made a new empty list having datatype as StudentModel
            StudentModel objmodel = new StudentModel(); // made object of StudentModel
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                // made an Object of model class and and passing values from data set to model class properties with the help of model class object
                StudentModel obj = new StudentModel();
                obj.StudentID = (int)ds.Tables[0].Rows[i]["StudentID"];
                obj.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                obj.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                obj.StudentEmail = ds.Tables[0].Rows[i]["StudentEmail"].ToString();
                obj.StudentPassword = ds.Tables[0].Rows[i]["StudentPassword"].ToString();
                obj.Sque = ds.Tables[0].Rows[i]["Sque"].ToString();
                obj.Sans = ds.Tables[0].Rows[i]["Sans"].ToString();
              //  obj.Qualification = ds.Tables[0].Rows[i]["Qualification"].ToString();
              //  obj.InstName = ds.Tables[0].Rows[i]["InstName"].ToString();
              //  obj.PassYear = (int)ds.Tables[0].Rows[i]["PassYear"];
              //  obj.Score = (int)ds.Tables[0].Rows[i]["Score"];
                lst.Add(obj);   // lastly adding the object which has all the values ino the list 
            }
            objmodel.lststud = lst;  // assigning the list to the list defined in model class
            return objmodel;
        }

        public StudentModel editSelectedProfile(int id)
        {
            StudentModel mod1 = new StudentModel(); // object of studentmodel

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // logic to select the data of the user whose edit method is clicked by referring id
                con.Open();

                using (SqlCommand cmd = new SqlCommand("GetSelectedProfileDetailsForEdit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            mod1.StudentID = (int)dr["StudentID"];
                            mod1.FirstName = dr["FirstName"].ToString();
                            mod1.LastName = dr["LastName"].ToString();
                            mod1.StudentEmail = dr["StudentEmail"].ToString();
                            mod1.StudentPassword = dr["StudentPassword"].ToString();
                            mod1.Sque = dr["Sque"].ToString();
                            mod1.Sans = dr["Sans"].ToString();
                        }
                    }
                }

                con.Close();
            }

            return mod1;
        }

        public StudentModel getDetailsOf_SelectedProfile(int id)
        {
            StudentModel mod1 = new StudentModel(); // object of model class

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("GetSelectedProfileDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            mod1.StudentID = (int)dr["StudentID"];
                            mod1.FirstName = dr["FirstName"].ToString();
                            mod1.LastName = dr["LastName"].ToString();
                            mod1.StudentEmail = dr["StudentEmail"].ToString();
                            mod1.StudentPassword = dr["StudentPassword"].ToString();
                            mod1.Sque = dr["Sque"].ToString();
                            mod1.Sans = dr["Sans"].ToString();
                        }
                    }
                }

                con.Close();
            }

            return mod1;
        }



        public List<QualificationModel> getQualification(string connectionString)
        {
            List<QualificationModel> QualObj = new List<QualificationModel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlcomm = new SqlCommand("GetQualification", sqlcon))
                {
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    using (SqlDataReader sdr = sqlcomm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            QualificationModel Qmodel = new QualificationModel();
                            Qmodel.Qid = (int)sdr["Qid"];
                            Qmodel.Qname = sdr["Qname"].ToString();
                            QualObj.Add(Qmodel);
                        }
                    }
                }
            }

            return QualObj;
        }


        public List<QualificationModel> getSecurityQuestion(string connectionString)
        {
            List<QualificationModel> QualObj2 = new List<QualificationModel>();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlcomm = new SqlCommand("GetSecurityQuestion", sqlcon))
                {
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    using (SqlDataReader sdr = sqlcomm.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            QualificationModel Qmodel2 = new QualificationModel();
                            Qmodel2.Qid = (int)sdr["Sid"];
                            Qmodel2.SecurityQue = sdr["Sname"].ToString();
                            QualObj2.Add(Qmodel2);
                        }
                    }
                }
            }

            return QualObj2;
        }


        public List<DynamicQualification> QualOfUser(string connectionString, int b)
        {
            List<DynamicQualification> QualObj = new List<DynamicQualification>();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlcomm = new SqlCommand("GetStudentProfileDynamicInfo", sqlcon))
                {
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlcomm.Parameters.AddWithValue("@StudentID", b);

                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlcomm))
                    {
                        sqlcon.Open();
                        SqlDataReader sdr = sqlcomm.ExecuteReader();
                        while (sdr.Read())
                        {
                            DynamicQualification Qmodel = new DynamicQualification();
                            Qmodel.Qualification = sdr["Qualification"].ToString();
                            Qmodel.InstName = sdr["InstName"].ToString();
                            Qmodel.PassYear = (int)sdr["PassYear"];
                            Qmodel.Score = (int)sdr["Score"];
                            QualObj.Add(Qmodel);
                        }
                    }
                    return QualObj;
                }
            }
        }

        public void modificationByandOnDAL(string emailOfLoggedUser, int id, string a, string connectionString)
        {
            int editorName = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudentIDByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentEmail", a);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                editorName = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            string time = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateDynamicQualification", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EditorName", editorName);
                    command.Parameters.AddWithValue("@Time", DateTime.Parse(time));
                    command.Parameters.AddWithValue("@StudentID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void modificationByandOnMasterTableDAL(string emailOfLoggedUser, int id, string a, string connectionString)
        {
            int editorName = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudentIDByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentEmail", a);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                editorName = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }

            string time = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateStudentMasterTable", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EditorName", editorName);
                    command.Parameters.AddWithValue("@Time", DateTime.Parse(time));
                    command.Parameters.AddWithValue("@StudentID", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        static int x = 0;
        public void InsertDynamicInfoDAL(string[] formData, string FirstName)
        {
            x++;
            if (x == 1)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StudID", typeof(int));
                dataTable.Columns.Add("Qualification", typeof(string));
                dataTable.Columns.Add("InstName", typeof(string));
                dataTable.Columns.Add("PassYear", typeof(int));
                dataTable.Columns.Add("Score", typeof(int));
                dataTable.Columns.Add("Cby", typeof(string));
                dataTable.Columns.Add("Con", typeof(DateTime));
                dataTable.Columns.Add("UniqueRef", typeof(int));

                int lastInsertedValue = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Call the GetLastInsertedStudentID stored procedure
                    using (SqlCommand command = new SqlCommand("GetLastInsertedStudentID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        lastInsertedValue = (int)command.ExecuteScalar();
                    }
                }

                lastInsertedValue = lastInsertedValue + 1;

                int numIterations = formData.Length / 4;

                for (int i = 0; i < numIterations; i++)
                {
                    string a = FirstName;
                    string b = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                    dataTable.Rows.Add(
                        lastInsertedValue,
                        formData[i * 4],
                        formData[(i * 4) + 1],
                        formData[(i * 4) + 2],
                        int.Parse(formData[(i * 4) + 3]),
                        lastInsertedValue.ToString(),
                        DateTime.Parse(b),
                        i
                    );
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a SqlCommand object with the InsertStudentDynamicInfo stored procedure
                    using (SqlCommand command = new SqlCommand("InsertStudentDynamicInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Create a SqlParameter object for the table-valued parameter
                        SqlParameter parameter = command.Parameters.AddWithValue("@DynamicQualificationTable", dataTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.StudentDynamicInfoType";

                        // Execute the InsertStudentDynamicInfo stored procedure
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

       public void  editProfileLaterDAL(string[] editedData, int StudentID)
       {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Calculate the number of iterations needed based on the array length and desired batch size
                int numIterations = editedData.Length / 4;

                for (int i = 0; i < numIterations; i++)
                {
                    // Calculate the starting index of the current batch
                    int startIndex = i * 4;

                    using (SqlCommand command = new SqlCommand("EditDynamicQualification", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Set the parameter values based on the current batch
                        command.Parameters.AddWithValue("@Qualification", editedData[startIndex]);
                        command.Parameters.AddWithValue("@InstName", editedData[startIndex + 1]);
                        command.Parameters.AddWithValue("@PassYear", Convert.ToInt32(editedData[startIndex + 2]));
                        command.Parameters.AddWithValue("@Score", Convert.ToInt32(editedData[startIndex + 3]));
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        command.Parameters.AddWithValue("@UniqueRef", i);

                        command.ExecuteNonQuery();
                    }
                }
            }
       }

        public void EditedProfDAL(string[] basicInfo, int StudentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Calculate the number of iterations needed based on the array length and desired batch size
                int numIterations = basicInfo.Length / 6;

                for (int i = 0; i < numIterations; i++)
                {
                    // Create the SQL UPDATE statement with placeholders for the values
                    using (SqlCommand command = new SqlCommand("EditStudentProfileStaticInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Set the parameter values based on the current iteration
                        command.Parameters.AddWithValue("@FirstName", basicInfo[i * 6]);
                        command.Parameters.AddWithValue("@LastName", basicInfo[(i * 6) + 1]);
                        command.Parameters.AddWithValue("@StudentEmail", basicInfo[(i * 6) + 2]);
                        command.Parameters.AddWithValue("@StudentPassword", basicInfo[(i * 6) + 3]);
                        command.Parameters.AddWithValue("@Sque", Convert.ToInt32(basicInfo[(i * 6) + 4]));
                        command.Parameters.AddWithValue("@Sans", basicInfo[(i * 6) + 5]);
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}







































































