using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesUI
{
    public class ProgramUI
    {
        protected readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            SeedBadges();
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin, What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge  \n" +
                    "3. List all badges \n" +
                    "4. Exit \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ListAllBadges();
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
        public void AddNewBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge:");
            int badgeID = int.Parse(Console.ReadLine());

            List<string> doorNames = new List<string>();
            Console.WriteLine("List a door that it needs access to:");
            string doorNameOne = Console.ReadLine();
            doorNames.Add(doorNameOne);
            Console.WriteLine("Any other doors(y/n)?");
            string anotherDoor = Console.ReadLine();

            if (anotherDoor == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                string doorNameTwo = Console.ReadLine();
                doorNames.Add(doorNameTwo);

                Console.WriteLine("Any other doors(y/n)?");
                string anotherDoorTwo = Console.ReadLine();

                if (anotherDoorTwo == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                    string doorNameThree = Console.ReadLine();
                    doorNames.Add(doorNameThree);
                }
            }
            Badge newBadge = new Badge(badgeID, doorNames);
            _badgeRepo.AddBadge(newBadge);
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> dictOfBadges = _badgeRepo.GetBadges();

            Console.WriteLine("{0,-6} {1,-20}\n", "Badge#", "Door Access");
            foreach (var badge in dictOfBadges)
            {
                Console.Write(badge.Key + "\t");
                foreach (var value in badge.Value.DoorName)
                {
                    Console.Write(value);
                    Console.Write(",");

                }
                Console.WriteLine();
            }
            PressKey();
        }

        public void UpdateBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you would like to update?");
            int targetBadge = int.Parse(Console.ReadLine());

            Dictionary<int, Badge> dictOfBadges = _badgeRepo.GetBadges();

            foreach (var badge in dictOfBadges)
            {
                if (badge.Key == targetBadge)
                {
                    Console.Write(targetBadge + " has access to doors ");
                    foreach (var value in badge.Value.DoorName)
                    {
                        Console.Write(value);
                        Console.Write(" & ");

                    }
                    Console.WriteLine("\n What would you like to do?\n" +
                    "1. Remove a door \n" +
                    "2. Add a door  \n");

                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string inputRemove = Console.ReadLine();
                            badge.Value.DoorName.Remove(inputRemove);
                            Console.WriteLine("Door Removed.");
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            string inputAdd = Console.ReadLine();
                            badge.Value.DoorName.Add(inputAdd);
                            Console.WriteLine("Door Added.");
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
            PressKey();
        }

        public void PressKey()
        {
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadKey();
        }

        public void SeedBadges()
        {
            Badge firstBadge = new Badge(4688, new List<string> { "A4", "A7" });
            Badge secondBadge = new Badge(4652, new List<string> { "A1", "A3" });
            Badge thirdBadge = new Badge(4649, new List<string> { "A2", "A6" });

            _badgeRepo.AddBadge(firstBadge);
            _badgeRepo.AddBadge(secondBadge);
            _badgeRepo.AddBadge(thirdBadge);
        }
    }
}
