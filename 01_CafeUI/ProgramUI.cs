using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        protected readonly MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            SeedMenu();
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show full menu \n" +
                    "2. Add new menu item \n" +
                    "3. Remove menu item \n" +
                    "4. Exit \n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowFullMenu();
                        break;
                    case "2":
                        AddNewItem();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4");
                        PressKey();
                        break;
                }
            }
        }
        private void AddNewItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Meal Number: ");
            int meal_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Meal Name: ");
            string meal_name = Console.ReadLine();
            Console.WriteLine("Please enter the Meal Description: ");
            string meal_descrition = Console.ReadLine();
            Console.WriteLine("Please enter the Ingredients in a list separated by commas: ");
            string ingredients = Console.ReadLine();
            Console.WriteLine("Please enter the Meal Price: ");
            double meal_price = double.Parse(Console.ReadLine());
            Menu item = new Menu(meal_number, meal_name, meal_descrition, ingredients, meal_price);
            _menuRepo.AddItemToMenu(item);
        }
        private void ShowFullMenu()
        {
            Console.Clear();
            List<Menu> listofMenuItems = _menuRepo.GetMenu();
            foreach (Menu item in listofMenuItems)
            {
                DisplayMenu(item);
            }
            PressKey();
        }
        private void DisplayMenu(Menu item)
        {
            Console.WriteLine($"Meal Number: {item.Meal_Number}\n" +
                $"Meal Name: {item.Meal_Name}\n" +
                $"Meal Description: {item.Meal_Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Meal Price: ${item.Price}\n");
        }
        private void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("What Meal would you like to Remove?");
            int count = 0;
            List<Menu> menuList = _menuRepo.GetMenu();
            foreach (Menu item in menuList)
            {
                count++;
                Console.WriteLine($"{count}. Number: {item.Meal_Number} Name: {item.Meal_Name}");
            }
            int userInputDelete = int.Parse(Console.ReadLine());
            int targetIndexDelete = userInputDelete - 1;
            if (targetIndexDelete >= 0 && targetIndexDelete <= menuList.Count())
            {
                Menu targetItem = menuList[targetIndexDelete];
                if (_menuRepo.DeleteMenuItem(targetItem))
                {
                    Console.WriteLine($"{targetItem.Meal_Name} has been successfully removed from the Menu");
                }
                else
                {
                    Console.WriteLine("The item was not able to be removed");
                }
            }
            else
            {
                Console.WriteLine("Invalid Menu Item");
            }
            PressKey();
        }
        private void SeedMenu()
        {
            Menu bigMac = new Menu(1, "Big Mac", "over 14 billion sold", "hamburger, onion, lettuce, pickle, tomato", 3.95);
            Menu chicken = new Menu(2, "Chicken Sandwich", "Eat Mor Chiken", "chicken, pickles, cheese, ranch", 4.95);
            Menu gyro = new Menu(3, "Gyro", "food of the Greek gods", "pita, lamb, gyro sause, peppers", 6.95);
            _menuRepo.AddItemToMenu(bigMac);
            _menuRepo.AddItemToMenu(chicken);
            _menuRepo.AddItemToMenu(gyro);
        }
        private void PressKey()
        {
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadKey();
        }
    }
}
