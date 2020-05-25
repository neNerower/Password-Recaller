using System;
using System.Collections.Generic;
using System.Text;

namespace _8_PasswordRecaller
{
    class Menu
    {
        public void Greeting()
        {
            //приветствие
            Console.WriteLine("Wellcome to the PasswordRecaller !");
            Console.WriteLine("This programm will help you find password in the depths of your mind");
            Console.WriteLine("Are you ready now?\nLet's start it !");
            UserMenu();
        }

        public void UserMenu()
        {            
            int choiseLvl1;

            do
            {
                Console.WriteLine("\n\nNow you are in StartMenu");
                Console.WriteLine("Choose your next step :");
                Console.WriteLine("1 - Add new PassInfo");
                Console.WriteLine("2 - Recall password");
                Console.WriteLine("0 - Exit");
                choiseLvl1 = new Helper().SafeEnter(0, 2);

                switch (choiseLvl1)
                {
                    case 1:
                        //Add PassInfo
                        //
                        Console.WriteLine("\nLet's add your password to the list");

                        new Helper().SaveToFile(new Helper().GetPassInfo());
                        Console.WriteLine("\nPassInfo saccessfuly added\n");
                        break;
                    case 2:
                        //Find password
                        //
                        CheckPassMenu();
                        //Console.WriteLine("\nCongratulations !\nPassword saccessfuly recalled\n");
                        break;
                    case 0:
                        //exit
                        break;

                }
            }
            while (choiseLvl1 != 0);
        }


        public void CheckPassMenu()
        {
            int choiseLvl2;

            do
            {
                //string description = new Helper().GetDescription();
                List<PassInfo> oldPasswords = new Helper().LoadFromFile();
                choiseLvl2 = new Helper().ChoosePassInfo(oldPasswords);

                if (Convert.ToInt32(choiseLvl2) != 0)
                {
                    Console.WriteLine("\nTry to recall the password");
                    Console.WriteLine($"\"{oldPasswords[choiseLvl2 - 1].Description}\"");
                    int contin = 0;
                    do
                    {
                        contin = oldPasswords[choiseLvl2 - 1].CheckPass(new Helper().GetPassword());
                        
                    }
                    while (contin != 0);
                }
            } 
            while (choiseLvl2 != 0);


        }


    }
}
