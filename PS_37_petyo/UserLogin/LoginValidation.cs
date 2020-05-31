using System;
using System.Collections.Generic;
using System.IO;

namespace UserLogin
{
    public class LoginValidation
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public static string currentUserUsername { get; private set; }

        public static UserRoles currentUserRole { get; private set; }


        public delegate void ActionOnError(string errorMessage);

        private ActionOnError _errorFunc;

        public LoginValidation(string username, string password, ActionOnError errorFunc)
        {
            _username = username;
            _password = password;
            _errorFunc = errorFunc;
        }

        public bool ValidateUserInput(ref User user)
        {
            bool emptyUserName;
            emptyUserName = _username.Equals(string.Empty);
            if (emptyUserName == true)
            {
                _errorMessage = "Username not entered";
                _errorFunc(_errorMessage);
                currentUserUsername = _username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (_username.Length < 5)
            {
                _errorMessage = "Username must be more than 5 symbols";
                _errorFunc(_errorMessage);
                currentUserUsername = _username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            bool emptyPassword;
            emptyPassword = _password.Equals(string.Empty);
            if (emptyPassword == true)
            {
                _errorMessage = "Password is not entered";
                _errorFunc(_errorMessage);
                currentUserUsername = _username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (_password.Length < 5)
            {
                _errorMessage = "Password must be more than 5 symbols";
                _errorFunc(_errorMessage);
                currentUserUsername = _username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(_username, _password);
            if (user != null)
            {
                currentUserUsername = user.Username;
                currentUserRole = (UserRoles) Enum.Parse(typeof(UserRoles), user.Role);
                getLastLogin(user.Username);
                Logger.Logger.Instance.LogActivity(LoginValidation.currentUserUsername, LoginValidation.currentUserRole.ToString(),"Success Login");
                return true;
            }
            else
            {
                _errorMessage = "User not found";
                _errorFunc(_errorMessage);
                currentUserUsername = _username;
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
        }

        private void getLastLogin(string username)
        {
            List<string> list = new List<string>();
            list.AddRange(File.ReadAllText(Logger.FileLogger.FileName).Split('\n'));

            string lastLog = list.FindLast(s => s != "" && s.Split(';')[1] == username);

            if (lastLog != null)
            {
                DateTime lastTime = DateTime.Parse(lastLog.Split(';')[0]);
                DateTime now = DateTime.Now;

                TimeSpan span = now - lastTime;

                Console.WriteLine("last login before {0} hours, {1} minutes, {2} seconds", span.Hours, span.Minutes,
                    span.Seconds);
            }
            else
            {
                Console.WriteLine("Hello new user");
            }
        }
    }
}