using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    public class Crop : Entity
    {
        public string CropType {  get; set; }
        private int Quantity { get; set; } 

        private static int nextCropID = 1;


        public Crop(string cropType, int quantity) : base(cropType, nextCropID)
        {
            CropType = cropType;
            Quantity = quantity;
            nextCropID++;
        }


        public override string GetDescription()
        {
            return $"Crop type: {Name}, remaining amount: {Quantity} ID: {Id}";
        }


        public int AddCrops()
        {
            Console.WriteLine("Enter the amount you'd like to add: ");
            int addQuantity = int.Parse(Console.ReadLine());
            Quantity += addQuantity;
            Console.WriteLine($"New quantity is {Quantity}");
            return Quantity;
        }


        public bool TakeCrop(int amoutToRemove)
        {
            if (Quantity < amoutToRemove)
            {
                return false;
            }
            else
            {
                Quantity -= amoutToRemove;
                Console.WriteLine($"New quantity is: {Quantity}");
                return true;
            }
        }
    }
}
