using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen
{
    public class AnimalManager
    {
        public List<AnimalManager> CropList = new List<AnimalManager>();

        public List<Animal> animalList = new List<Animal>();

        public AnimalManager()
        {
            animalList.Add(new Animal("Kajsa", "Cow"));
            animalList.Add(new Animal("Lisa", "Cow"));
            animalList.Add(new Animal("Maja", "Cow"));
            animalList.Add(new Animal("Rosa", "Cow"));
            animalList.Add(new Animal("Jenny", "Cow"));
        }


        public AnimalManager(List<AnimalManager> cropList, List<Animal> animalList) //lista av crops
        {
            CropList = cropList;
            this.animalList = animalList;
        }


        public void Run(List<Crop> cropList)

        {
            bool showMenu = true;

            while (showMenu)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddAnimals();
                        break;
                    case "2":
                        Console.Clear();
                        RemoveAnimal();
                        break;
                    case "3":
                        Console.Clear();
                        ViewAnimals();
                        break;
                    case "4":
                        Console.Clear();
                        FeedAnimals(cropList);
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
                Console.WriteLine("Animal manager menu.");
                Console.WriteLine("1. Add animal.");
                Console.WriteLine("2. Remove animal.");
                Console.WriteLine("3. View animals.");
                Console.WriteLine("4. Feed animals");
                Console.WriteLine("9. Go back to main menu");
                Console.Write("Enter your choice: ");
            }
        }


        private void FeedAnimals(List<Crop> cropList)
        {
            Console.WriteLine("Ah so you want to feed the animals, how brave!");
            ViewAnimals();
            Console.WriteLine("Which animal would you like to feed?\nEnter animal ID");
            string animalToFeed = Console.ReadLine();

            Console.WriteLine("What type of crop, grass or hay?");
            string input = Console.ReadLine();
            string lowerCaseInput = input.ToLower();
            Console.Clear();

            int eatingamount = 20;

            Crop selectedCrop = null;
            foreach (Crop crop in cropList)
            {
                if (crop.CropType.ToLower() == lowerCaseInput)
                {
                    selectedCrop = crop;
                    break;
                }
            }
            if (selectedCrop != null)
            {
                if (selectedCrop.TakeCrop(eatingamount))
                {
                    Console.WriteLine($"The animal ate {eatingamount} {lowerCaseInput}\n");
                }
                else
                {
                    Console.WriteLine("NOT ENOUGH!");
                }
            }
            else
            {
                Console.WriteLine("Invalid crop type.");
            }
        }


        private void ViewAnimals()
        {
            Console.WriteLine("Current animals owned:");
            foreach (Animal animals in animalList)
            {
                Console.WriteLine(animals.GetDescription());
            }
            Console.WriteLine("\n");
        }


        private void RemoveAnimal()
        {
            ViewAnimals();
            Console.WriteLine("Enter the ID of the animal you want to remove!");
            int input = Convert.ToInt32(Console.ReadLine());

            Animal animalToRemove = animalList.FirstOrDefault(animal => animal.Id == input);

            if (animalToRemove != null)
            {
                animalList.Remove(animalToRemove);
                ViewAnimals();
                Console.WriteLine($"Animal with ID {input} has been removed.\n");
            }
            else
            {
                Console.WriteLine("No animal found with ID " + input);
            }
        }


        private void AddAnimals()
        {
            int amountToAdd;

            do
            {
                Console.WriteLine("How many animals do you want to add?");
                if (!int.TryParse(Console.ReadLine(), out amountToAdd))
                {
                    Console.WriteLine("Invalid input for the number of animals. Please enter a valid number.");
                }
            } while (amountToAdd <= 0);

            for (int i = 0; i < amountToAdd; i++)
            {
                Console.WriteLine("Enter Animal name: ");
                string inputName = Console.ReadLine();

                Console.WriteLine("Enter Animal species: ");
                string inputSpecies = Console.ReadLine();

                Animal newAnimal = new Animal(inputName, inputSpecies);
                animalList.Add(newAnimal);
                Console.Clear();
                Console.WriteLine($"{newAnimal} har been added!\n");
                ViewAnimals();
            }
        }

    }
}
        



