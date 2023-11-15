using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    public class CropManager
    {
        public List<Crop> cropList = new List<Crop>();

        public CropManager()
        {
            cropList.Add(new Crop("Grass", 100));
            cropList.Add(new Crop("Hay", 200));
        }


        public List<Crop> GetCropList() 
        {  
            return cropList; 
        }
    
        public void CropmanagerMenu()
        {
            bool showMenu = true;

            while (showMenu)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCrop();
                        break;
                    case "2":
                        Console.Clear();
                        RemoveCrop();
                        break;
                    case "3":
                        Console.Clear();
                        ViewCrops();
                        break;
                    case "9":
                        Console.Clear();
                        showMenu = false;
                        break;
                    default:
                        break;
                }
            }

            static void DisplayMenu()
            {
                Console.WriteLine("Crop manager menu.");
                Console.WriteLine("1. Add crop.");
                Console.WriteLine("2. Remove crop.");
                Console.WriteLine("3. View crops.");
                Console.WriteLine("4. Get crops.");
                Console.WriteLine("9. Go back to main menu");
                Console.Write("Enter your choice: ");
            }
        }


        private void ViewCrops()
        {
            foreach (Crop crop in cropList)
            {
                Console.WriteLine(crop.GetDescription());
            }
            Console.WriteLine("\n");
        }


        private void AddCrop()
        {
            Console.WriteLine("Would you like to add quantity or a new crop?");
            string choice = Console.ReadLine();
            if (choice == "quantity")
            {
                ViewCrops();
                Console.WriteLine("Please enter ID of the crop you want to add more of: ");
                int pickID = int.Parse(Console.ReadLine());
                bool cropFound = false;
                foreach (Crop crop in cropList)
                {
                    if (pickID == crop.Id)
                    {   
                        crop.AddCrops();
                        cropFound = true;
                    }
                }
                if(!cropFound)
                {
                    Console.WriteLine("Invalid ID! Going back to menu");
                }
            }
            else if (choice == "new")
            {
                Console.WriteLine("Enter the Crop Type: ");
                string inputType = Console.ReadLine();
                Console.WriteLine("Enter quantity to crop: ");
                int inputQuantity = int.Parse(Console.ReadLine());
                Crop newCrop = new Crop(inputType, inputQuantity);
                cropList.Add(newCrop);
                Console.Clear();
                Console.WriteLine($"{newCrop} has been added!\n");
                ViewCrops();
            }
            else
            {
                Console.WriteLine("Invalid choice! Going back to menu");
            }
        }


        private void RemoveCrop()
        {
            ViewCrops();
            Console.WriteLine("Enter the ID of the crop you want to remove!");
            int input = Convert.ToInt32(Console.ReadLine());

            Crop cropToRemove = cropList.FirstOrDefault(crop => crop.Id == input);

            if (cropToRemove != null)
            {
                cropList.Remove(cropToRemove);
                Console.WriteLine($"Crop with ID {input} has been removed.");
            }
            else
            {
                Console.WriteLine("No crop found with ID " + input);
            }
        }
    }
}
