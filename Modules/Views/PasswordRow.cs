using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC317PassManagerP2Starter.Modules.Models;

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

/* This module contains the class definition for Password Row.
 * 
 * The methods are missing their bodies.  Fill in the method definitions below.
 * 
 */

namespace CSC317PassManagerP2Starter.Modules.Views
{
    public class PasswordRow : BindableObject, INotifyPropertyChanged
    {
        private PasswordModel _pass;
        private bool _isVisible = false;
        private bool _editing = false;

        public PasswordRow(PasswordModel source)
        {
            _pass = source;
        }


        public string PlatformName
        {
            get => _pass.PlatformName; 
            set
            {
                if (_pass.PlatformName != value)
                {
                    _pass.PlatformName = value; 
                    RefreshRow(); 
                }
            }
        }

        public string PlatformUserName
        {
            get => _pass.PlatformUserName;
            set
            {
                if (_pass.PlatformUserName != value)
                {
                    _pass.PlatformUserName = value; 
                    RefreshRow();
                }
            }
        }



       
        public int PasswordID => _pass.ID; 

       
        public bool IsShown
        {
            get => _isVisible; 
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    RefreshRow();
                }
            }
        }


        public bool Editing
        {
            get => _editing; 
            set
            {
                if (_editing != value)
                {
                    _editing = value;
                    RefreshRow();
                }
            }
        }


        private void RefreshRow()
        {
            OnPropertyChanged(nameof(PlatformName));
            OnPropertyChanged(nameof(PlatformUserName));
         //   OnPropertyChanged(nameof(PlatformPassword));
            OnPropertyChanged(nameof(IsShown));
            OnPropertyChanged(nameof(Editing));
        }

        public void SavePassword()
        {


        }
    }
}
