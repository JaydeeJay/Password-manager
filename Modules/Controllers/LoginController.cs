using CSC317PassManagerP2Starter.Modules.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* HEADER COMMENT
Program Author: Joshua Johnston

USM ID: w10153021

Assignment: Password manager 2

Description:

the purpose of this lab was to implement the backend to a password manager app. 
I very much struggled with this assignment, but i managed to complete both of the controllers, models, and part of the password list view backend.
I really would appreciate some grace, and leniency with this assignment, as i struggled with it immensely. I have an incredible amount of work to do, with exams and finals.
I know i didnt do everything, but i hope this will allow me to get a few points.




*/
namespace CSC317PassManagerP2Starter.Modules.Controllers
{
    public enum AuthenticationError { NONE, INVALIDUSERNAME, INVALIDPASSWORD }
    public class LoginController
    {

        /*
         * This class is incomplete.  Fill in the method definitions below.
         */
        private User _user = new User();
        private bool _loggedIn = false;
        public LoginController()
        {

            var keyAndIv = PasswordCrypto.GenKey();

            _user = new User
            {
                Username = "test",
                PasswordHash = PasswordCrypto.GetHash("ab1234"),
                FirstName = "John",
                LastName = "Doe",
                Key = keyAndIv.Item1,
                IV = keyAndIv.Item2
            };
        }
        public User? CurrentUser
        {
            get
            {
                //Returns a copy of the user data.  
                if (_loggedIn)
                {
                    return new User
                    {
                        Username = _user.Username,
                        FirstName = _user.FirstName,
                        LastName = _user.LastName,
                        Key = _user.Key,
                        IV = _user.IV
                    };
                }
                return null;
            }
        }
        public AuthenticationError Authenticate(string username, string password)
        {

            if (!_user.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticationError.INVALIDUSERNAME;
            }


            if (!PasswordCrypto.CompareBytes(_user.PasswordHash, PasswordCrypto.GetHash(password)))
            {
                return AuthenticationError.INVALIDPASSWORD;
            }

            _loggedIn = true;
            return AuthenticationError.NONE;
        }
 
    }

}
