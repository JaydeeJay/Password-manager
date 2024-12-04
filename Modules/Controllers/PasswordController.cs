using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CSC317PassManagerP2Starter.Modules.Models;
using CSC317PassManagerP2Starter.Modules.Views;
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
    public class PasswordController
    {

        public List<PasswordModel> _passwords = new List<PasswordModel>();
        private int counter = 1;

        /*
         * The following functions need to be completed.
         */

        public void PopulatePasswordView(ObservableCollection<PasswordRow> source, string search_criteria = "")
        {

            source.Clear();

            var filteredPasswords = _passwords
                .Where(p => string.IsNullOrWhiteSpace(search_criteria) ||
                            p.PlatformName.Contains(search_criteria, StringComparison.OrdinalIgnoreCase) ||
                            p.PlatformUserName.Contains(search_criteria, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var password in filteredPasswords)
            {
                source.Add(new PasswordRow(password));
            }
        }

        public void AddPassword(string platform, string username, string password)
        {

            var encryption = PasswordCrypto.GenKey();
            var encryptedPassword = PasswordCrypto.Encrypt(password, encryption.Item1, encryption.Item2, encryption);

            _passwords.Add(new PasswordModel
            {
                ID = counter++,
                PlatformName = platform,
                PlatformUserName = username,
                PasswordText = encryptedPassword
            });
        }

        public PasswordModel? GetPassword(int ID)
        {
            return _passwords.FirstOrDefault(p => p.ID == ID);
        }


        public bool UpdatePassword(PasswordModel changes)
        {
            var existingPassword = _passwords.FirstOrDefault(p => p.ID == changes.ID);
            if (existingPassword == null)
            {
                return false;
            }

            existingPassword.PlatformName = changes.PlatformName;
            existingPassword.PlatformUserName = changes.PlatformUserName;
            existingPassword.PasswordText = changes.PasswordText;

            return true;
        }

        public bool RemovePassword(int ID)
        {
            var passwordToRemove = _passwords.FirstOrDefault(p => p.ID == ID);
            if (passwordToRemove == null)
            {
                return false;
            }

            _passwords.Remove(passwordToRemove);
            return true;
        }

        public void GenTestPasswords()
        {
            AddPassword("Netflix", "Josh_Flix", "JustPirate153");
            AddPassword("Canvas", "w10123450", "SchoolPass");
            AddPassword("Discord", "xx_Joshy_xx", "DiscordPass");
        }
    }
}

