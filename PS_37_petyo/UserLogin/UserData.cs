using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        private static List<User> _testUsers => UserContext.Instance.Users.ToList();

        public static List<User> TestUsers => _testUsers;

        public static void ResetTestUserData()
        {
            var userContext = UserContext.Instance;
            if (userContext.Users.Count() > 0)
            {
                return;
            }

            userContext.Users.Add(new User
            {
                Username = "admin",
                Password = "admin",
                FacNumber = "123456789",
                Role = UserRoles.ADMIN.ToString(),
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });
            userContext.Users.Add(new User
            {
                Username = "student1",
                Password = "student1",
                FacNumber = "11111",
                Role = UserRoles.STUDENT.ToString(),
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });
            userContext.Users.Add(new User
            {
                Username = "student2",
                Password = "student2",
                FacNumber = "22222",
                Role = UserRoles.STUDENT.ToString(),
                Created = DateTime.Now,
                ActiveTo = DateTime.MaxValue
            });
            userContext.SaveChanges();
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach (var user in TestUsers)
                if (user.Username.Equals(username) && user.Password.Equals(password))
                    return user;
            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach (var user in TestUsers)
                if (user.Username.Equals(username))
                {
                    user.ActiveTo = activeTo;
                    Logger.Logger.Instance.LogActivity(LoginValidation.currentUserUsername, LoginValidation.currentUserRole.ToString(), "Update activity to " + username);
                    break;
                }
        }

        public static void AssignUserRole(int userId, UserRoles role)
        {
            User userObject = UserContext.Instance.Users
                .First(user => user.UserId == userId);
            userObject.Role = role.ToString();
            UserContext.Instance.SaveChanges();
        }
    }
}