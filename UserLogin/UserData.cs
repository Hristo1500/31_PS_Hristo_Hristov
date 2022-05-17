using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData {
        

        private static  UserContext _context = new UserContext();
        static private List<User> _testUsers = _context.Users.ToList();
        public static List<User> TestUsers {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData() {
            if(_testUsers == null) {
                _testUsers = _context.Users.ToList();
              //  _testUsers = new List<User>();

                //User firstUser = new User();
                //firstUser.userName = "Pesho";
                //firstUser.password = "PeshoEQk";
                //firstUser.facNumber = "121219066";
                //firstUser.role = 4;
                //firstUser.created = DateTime.Now;
                //firstUser.activeUntil = DateTime.MaxValue;

                //_testUsers.Add(firstUser);

                //User secondUser = new User();
                //secondUser.userName = "Gosho";
                //secondUser.password = "Koza123";
                //secondUser.facNumber = "121219077";
                //secondUser.role = 4;
                //secondUser.created = DateTime.Now;
                //secondUser.activeUntil = DateTime.MaxValue;

                //_testUsers.Add(secondUser);

                //User adminUser = new User();
                //adminUser.userName = "Admin";
                //adminUser.password = "123123";
                //adminUser.facNumber = "121219010";
                //adminUser.role = 1;
                //adminUser.created = DateTime.Now;
                //adminUser.activeUntil = DateTime.MaxValue;

                //_testUsers.Add(adminUser);

            }
        }

        public static User IsUserPassCorrect(string userName, string pass)
        {
            User user = (from u in _context.Users
                         where u.userName.Equals(userName) && u.password.Equals(pass)
                         select u).FirstOrDefault();

            return user;
        }

        public static void SetUserActiveTo(string userName, DateTime newDate) 
        {
            foreach(User user in TestUsers)
            {
                if (user.userName.Equals(userName))
                {
                    user.activeUntil = newDate;
                }
            }

            Logger.LogActivity("Промяна на активност на " + userName);
        }

        public static void AssignUserRole(string userName, UserRoles role)
        {
            foreach(User user in TestUsers)
            {
                if (user.userName.Equals(userName))
                {
                    user.role = Convert.ToInt32(role);
                }
            }

            Logger.LogActivity("Промяна на роля на " + userName);
        }

        public static void seeAllUsers()
        {
            foreach (User user in _testUsers)
            {
                Console.WriteLine(user.userName);
            }
        }
        public static void insertTestUsers()
        {
            foreach (var user in TestUsers)
            {
                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }
    }
}
