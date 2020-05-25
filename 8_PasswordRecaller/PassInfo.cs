using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _8_PasswordRecaller
{
    class PassInfo
    {
        public string Description { get; set; }
        public string HashPass { get; set; }

        
        private string Hash(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hash;
            }
        }

        public int CheckPass(string password)
        {
            int res = 0;

            if (this.HashPass == Hash(password))
            {
                Console.WriteLine("\n\n\n\tSUCCESS !!");
                Console.WriteLine($"\t\"{password}\" is your password for this description : \"{this.Description}\"");
                Console.WriteLine("\tDon't foget it next time\n\n");
            }
            else
            {
                Console.WriteLine($"\n\"{password}\" is not your password for this description : \"{this.Description}\"");
                Console.WriteLine("Do you want to try again ?\n1 - Yes\n0 - No\nYour choise : ");
                res = Convert.ToInt32(Console.ReadLine());
            }

            return res;
        }


        public PassInfo()
        {

        }
        public PassInfo(string pass, string description)
        {
            this.HashPass = Hash(pass);
            this.Description = description;

        }
    }
}
