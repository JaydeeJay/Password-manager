using System;
using System.Collections.Generic;
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
namespace CSC317PassManagerP2Starter.Modules.Models
{
    public class User
    {

        //Implement the User Model here.
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] Key { get; set; } = Array.Empty<byte>();
        public byte[] IV { get; set; } = Array.Empty<byte>();
        
    }
}
