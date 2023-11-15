using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Farm
    {
        AnimalManager animalManager = new AnimalManager();
        CropManager cropManager = new CropManager();
        public void Run()
        {
            bool showMenu = true;
            while (showMenu)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1" or "animal":
                        Console.Clear();
                        animalManager.Run(cropManager.GetCropList());
                        break;
                    case "2" or "crop":
                        Console.Clear();
                        cropManager.CropmanagerMenu();
                        break;
                    case "9" or "quit":
                        Console.Clear();
                        showMenu = false;
                         break;
                    default:
                        break;
                }
            }


            static void DisplayMenu()
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Animal Manager Menu.");
                Console.WriteLine("2. Crop Manager Menu.");;
                Console.WriteLine("9. Quit");
                Console.Write("Enter your choice: ");
            }
        }

    }
}
