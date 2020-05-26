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
                Console.WriteLine("3 - Editing Menu");
                Console.WriteLine("4 - Delete Menu");
                Console.WriteLine("0 - Exit");
                choiseLvl1 = h.SafeEnter(0, 4);

                switch (choiseLvl1)
                {
                    case 1:
                        //Add PassInfo
                        //
                        h.AddToFile();

                        Console.WriteLine("\nPassInfo saccessfuly added\n");
                        break;
                    case 2:
                        //Find password
                        //
                        CheckPassMenu();
                        //Console.WriteLine("\nCongratulations !\nPassword saccessfuly recalled\n");
                        break;
                    case 3:
                        //Editin Menu
                        //
                        EditingMenu();
                        break;
                    case 4:
                        //DelMenu
                        //
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
                //string description = new Helper().GetDescription();
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
                Console.WriteLine("Choose the password you want rewrite");
                //string description = new Helper().GetDescription();
                List<PassInfo> oldPasswords = h.LoadFromFile();
                choiseLvl2 = h.ChoosePassInfo(oldPasswords);

                if (choiseLvl2 != 0)
                {
                    h.DeletePassInfo(oldPasswords, choiseLvl2);

                    h.AddToFile();
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
                //string description = new Helper().GetDescription();
                List<PassInfo> oldPasswords = h.LoadFromFile();
                choiseLvl2 = h.ChoosePassInfo(oldPasswords);

                if (choiseLvl2 != 0)
                {
                    h.DeletePassInfo(oldPasswords, choiseLvl2);
                }
            }
            while (choiseLvl2 != 0);


        }

        /*
        public void EditingMenu()
        {
            int choiseLvl2;

            do
            {
                Console.WriteLine("\n\nNow you are in EditingMenu");
                Console.WriteLine("Choose your next step :");
                Console.WriteLine("1 - Rewrite PassInfo");
                Console.WriteLine("2 - Remove PassInfo");
                Console.WriteLine("0 - Exit");
                choiseLvl2 = new Helper().SafeEnter(0, 2);

                switch (choiseLvl2)
                {
                    case 1:
                        //Rewrite PassInfo
                        //
                        //List<PassInfo> oldPasswords = new Helper().LoadFromFile();
                        //int index = new Helper().ChoosePassInfo(oldPasswords);

                        Console.WriteLine("\nChoose PassInfo you want to rewrite");



                        break;
                    case 2:
                        //Remove PassInfo
                        //
                        
                        break;
                    case 0:
                        //exit
                        break;

                }
            }
            while (choiseLvl2 != 0);
        }
        */

    }
}
