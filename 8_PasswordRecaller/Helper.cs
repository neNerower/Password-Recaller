using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;

namespace _8_PasswordRecaller
{
    class Helper
    {
        public string path = "data.json";


        public PassInfo GetPassInfo()
        {
            string password = GetPassword();
            string description = GetDescription();

            return new PassInfo(password, description);
        }

        public string GetPassword()
        {
            Console.WriteLine("\nEnter your password : ");
            string password = Console.ReadLine();
            return password;
        }
        public string GetDescription()
        {
            Console.WriteLine("\nEnter description of your passworsd : ");
            string description = Console.ReadLine();
            return description;
        }


        public void SaveToFile(PassInfo info)
        {
            List<PassInfo> passwords = LoadFromFile();

            passwords.Add(info);

            File.WriteAllText(path, JsonConvert.SerializeObject(passwords));


            //passwords.Add();
            //passwords.ForEach(x => x.Description = "123");
        }

        public List<PassInfo> LoadFromFile()
        {
            var oldPasswords = new List<PassInfo>();

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(JsonConvert.SerializeObject(oldPasswords));
                }
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string oldstr = sr.ReadToEnd();
                    oldPasswords = JsonConvert.DeserializeObject<List<PassInfo>>(oldstr);
                }
                
            }

            return oldPasswords;
        }


        public int ChoosePassInfo(List<PassInfo> oldPasswords)
        {
            int i = 1;

            Console.WriteLine("\nLet's find your password from the list");
            Console.WriteLine("There are all of your psswords");
            Console.WriteLine("Choose the password you want to recall");

            oldPasswords.ForEach(x =>
            {
                Console.WriteLine($"{i++} - \"{x.Description}\"");
            });

            Console.WriteLine("0 - Exit");
            return new Helper().SafeEnter(0, i-1);
        }

        

        public int SafeEnter(int min, int max)
        {
            bool stay = true;
            int choise = 0;
            Console.WriteLine("Your choise :");

            do
            {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                    
                    if (choise >= min && choise <= max)
                    {
                        stay = false;
                    }
                }
                catch
                {

                }

                if (stay)
                    Console.WriteLine("\nIncorrect input\nTry again :");
            }
            while (stay);

            return choise;
        }




    }
}
