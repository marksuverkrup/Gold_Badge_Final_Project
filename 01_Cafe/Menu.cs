using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class Menu
    {
        public int Meal_Number { get; set; }
        public string Meal_Name { get; set; }
        public string Meal_Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public Menu() { }
        public Menu(int meal_Number, string meal_Name, string meal_description, string ingredients, double price)
        {
            Meal_Number = meal_Number;
            Meal_Name = meal_Name;
            Meal_Description = meal_description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
