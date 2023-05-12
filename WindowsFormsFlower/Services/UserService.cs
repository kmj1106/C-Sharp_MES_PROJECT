using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class UserService
    {
        public List<UserVO> GetUserAllList()
        {
            UserDAC db = new UserDAC();
            List<UserVO> list = db.GetUserAllList();
            db.Dispose();

            return list;
        }

        public UserVO GetUserInfo(string usID)
        {
            UserDAC db = new UserDAC();
            UserVO usVO = db.GetUserInfo(usID);
            db.Dispose();

            return usVO;
        }

        public int InsertUser(UserVO us)
        {
            UserDAC db = new UserDAC();
            int result = db.InsertUser(us);
            db.Dispose();

            return result;
        }

        public UserVO Login(string uid, string uPWD)
        {
            UserVO login = null;

            UserDAC dac = new UserDAC();
            login = dac.Login(uid, uPWD);
            dac.Dispose();

            return login;
        }

        public int CheckUserID(string userID)
        {
            UserDAC db = new UserDAC();
            int result = db.CheckUserID(userID);
            db.Dispose();

            return result;
        }

        public bool InsertMembers(UserVO mem)
        {
            UserDAC db = new UserDAC();
            bool result = db.InsertMembers(mem);
            db.Dispose();

            return result;
        }

        public bool UpdateMembers(UserVO mem)
        {
            UserDAC db = new UserDAC();
            bool result = db.UpdateMembers(mem);
            db.Dispose();

            return result;
        }

        public bool DeleteMembers(string pID)
        {
            UserDAC db = new UserDAC();
            bool result = db.DeleteMembers(pID);
            db.Dispose();

            return result;
        }
    }
}
