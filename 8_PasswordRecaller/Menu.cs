using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _8_PasswordRecaller
{
    class Menu
    {
        private Helper h = new Helper(); 

        public void Greeting()
        {
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
                Console.WriteLine("3 - Editing Menu");
                Console.WriteLine("4 - Delete Menu");
                Console.WriteLine("0 - Exit");
                choiseLvl1 = h.SafeEnter(0, 4);

                switch (choiseLvl1)
                {
                    case 1:
                        h.AddToFile();

                        Console.WriteLine("\nPassInfo saccessfuly added\n");
                        break;
                    case 2:
                        CheckPassMenu();
                        break;
                    case 3:
                        EditingMenu();
                        break;
                    case 4:
                        DeletMenu();
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
                List<PassInfo> oldPasswords = h.LoadFromFile();
                choiseLvl2 = h.ChoosePassInfo(oldPasswords);

                if (choiseLvl2 != 0)
                {
                    Console.WriteLine("\nTry to recall the password");
                    Console.WriteLine($"\"{oldPasswords[choiseLvl2 - 1].Description}\"");
                    int contin = 0;
                    do
                    {
                        contin = oldPasswords[choiseLvl2 - 1].CheckPass(h.GetPassword());

                        
                    }
                    while (contin != 0);
                }
            } 
            while (choiseLvl2 != 0);


        }

        public void EditingMenu()
        {
            int choiseLvl2;

            do
            {
                Console.WriteLine("\nChoose the password you want rewrite");
                List<PassInfo> oldPasswords = h.LoadFromFile();
                choiseLvl2 = h.ChoosePassInfo(oldPasswords);

                if (choiseLvl2 != 0)
                {
                    h.DeletePassInfo(oldPasswords, choiseLvl2);
                    h.AddToFile();

                    Console.WriteLine("\nPassword successfuly rewrited\n\n");
                }
            }
            while (choiseLvl2 != 0);


        }

        public void DeletMenu()
        {
            int choiseLvl2;

            do
            {
                Console.WriteLine("Choose the password you want remove");
                List<PassInfo> oldPasswords = h.LoadFromFile();
                choiseLvl2 = h.ChoosePassInfo(oldPasswords);

                if (choiseLvl2 != 0)
                {
                    h.DeletePassInfo(oldPasswords, choiseLvl2);

                    Console.WriteLine("\nPassword successfuly deleted\n\n");
                }
            }
            while (choiseLvl2 != 0);


        }

    }
}
