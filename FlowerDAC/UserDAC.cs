using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerVO;
using System.Data;
using System.Windows.Forms;


namespace FlowerDAC
{
    public class UserDAC
    {
        SqlConnection conn;


        public UserDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<UserVO> GetUserAllList()
        {
            string sql = "select UserID,UserPwd,UserPwdDetail,UserName,Zipcode,Address1,Address2,UserEmail,UserBirth,UserGender,UserPhone from [User]";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }


        public UserVO GetUserInfo(string usID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"select UserID,UserPwd,UserPwdDetail,UserName,Zipcode,Address1,Address2,UserEmail,UserBirth,UserGender,UserPhone from [User] where UserID = @UserID";
                cmd.Parameters.AddWithValue("@UserID", usID);

                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());

                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;
            }
        }

        public UserVO Login(string uID, string uPWD)
        {
            string sql = "select UserID,UserPwd,UserPwdDetail,UserName,Zipcode,Address1,Address2,UserEmail,UserBirth,UserGender,UserPhone from [User] where UserID=@UserID and UserPwd=@UserPwd";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserID", uID);
            cmd.Parameters.AddWithValue("@UserPwd", uPWD);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                UserVO loginUser = new UserVO();
                loginUser.UserID = reader["UserID"].ToString();
                loginUser.UserPwd = reader["UserPwd"].ToString();
                loginUser.UserName = reader["UserName"].ToString();
                loginUser.Zipcode = reader["ZipCode"].ToString();
                loginUser.Address1 = reader["Address1"].ToString();
                loginUser.Address2 = reader["Address2"].ToString();
                loginUser.UserEmail = reader["UserEmail"].ToString();
                loginUser.UserBirth = Convert.ToDateTime(reader["UserBirth"]);
                loginUser.UserGender = reader["UserGender"].ToString();
                loginUser.UserPhone = reader["UserPhone"].ToString();

                return loginUser;
            }
            else
            {
                return null;
            }
        }

        public int InsertUser(UserVO us)
        {
            string sql = @"insert into [User] (UserID, UserPwd, UserPwdDetail, UserName, ZipCode, Address1, Address2, UserEmail, UserBirth, UserGender, UserPhone)
values(@UserID, @UserPwd, @UserPwdDetail, @UserName, @ZipCode, @Address1, @Address2, @UserEmail, @UserBirth, @UserGender, @UserPhone)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", us.UserID);
                cmd.Parameters.AddWithValue("@UserPwd", us.UserPwd);
                cmd.Parameters.AddWithValue("@UserPwdDetail", us.UserPwdDetail);
                cmd.Parameters.AddWithValue("@userName", us.UserName);
                cmd.Parameters.AddWithValue("@Zipcode", us.Zipcode);
                cmd.Parameters.AddWithValue("@Address1", us.Address1);
                cmd.Parameters.AddWithValue("@Address2", us.Address2);
                cmd.Parameters.AddWithValue("@UserEmail", us.UserEmail);
                cmd.Parameters.AddWithValue("@UserBirth", us.UserBirth);
                cmd.Parameters.AddWithValue("@UserGender", us.UserGender);
                cmd.Parameters.AddWithValue("@UserPhone", us.UserPhone);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return -1;
            }
        }

        public int CheckUserID(string userID)
        {
            string sql = "select count(*) from [User] where UserID = '@User'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt;
        }

        public bool ConfirmUser(string id, string name, string email)
        {
            string sql = "select count(*) from [User] where UserID=@UserID and UserName=@UserName and UserEmail=@UserEmail";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserID", id);
            cmd.Parameters.AddWithValue("@UserName", name);
            cmd.Parameters.AddWithValue("@UserEmail", email);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return (cnt > 0);
        }

        public bool UpdatePwd(string uid, string newPwd)
        {
            string sql = "update [User] set UserPwd = @UserPwd where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserPwd", newPwd);
            cmd.Parameters.AddWithValue("@UserID", uid);
            int iRowsAffect = cmd.ExecuteNonQuery();
            return (iRowsAffect > 0);
        }

        public bool InsertMembers(UserVO mem)
        {
            try
            {
                string sql = @"insert into [User] (UserID, UserPwd, UserName, ZipCode, Address1, Address2, UserEmail, UserBirth, UserGender, UserPhone)
values (@UserID, @UserPwd, @UserName, @ZipCode, @Address1, @Address2, @UserEmail, @UserBirth, @UserGender, @UserPhone)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@UserID", mem.UserID);
                cmd.Parameters.AddWithValue("@UserPwd", mem.UserPwd);
                cmd.Parameters.AddWithValue("@userName", mem.UserName);
                cmd.Parameters.AddWithValue("@Zipcode", mem.Zipcode);
                cmd.Parameters.AddWithValue("@Address1", mem.Address1);
                cmd.Parameters.AddWithValue("@Address2", mem.Address2);
                cmd.Parameters.AddWithValue("@UserEmail", mem.UserEmail);
                cmd.Parameters.AddWithValue("@UserBirth", mem.UserBirth);
                cmd.Parameters.AddWithValue("@UserGender", mem.UserGender);
                cmd.Parameters.AddWithValue("@UserPhone", mem.UserPhone);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool UpdateMembers(UserVO mem)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"UPDATE [User] SET UserID=@UserID, UserPwd=@UserPwd, UserName=@UserName, ZipCode=@ZipCode, Address1=@Address1, Address2=@Address2, UserEmail=@UserEmail, UserBirth=@UserBirth, UserGender=@UserGender, UserPhone=@UserPhone WHERE UserID=@UserID";

                cmd.Parameters.AddWithValue("@UserID", mem.UserID);
                cmd.Parameters.AddWithValue("@UserPwd", mem.UserPwd);
                cmd.Parameters.AddWithValue("@userName", mem.UserName);
                cmd.Parameters.AddWithValue("@Zipcode", mem.Zipcode);
                cmd.Parameters.AddWithValue("@Address1", mem.Address1);
                cmd.Parameters.AddWithValue("@Address2", mem.Address2);
                cmd.Parameters.AddWithValue("@UserEmail", mem.UserEmail);
                cmd.Parameters.AddWithValue("@UserBirth", mem.UserBirth);
                cmd.Parameters.AddWithValue("@UserGender", mem.UserGender);
                cmd.Parameters.AddWithValue("@UserPhone", mem.UserPhone);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteMembers(string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"DELETE from [User] WHERE UserID=@UserID";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}