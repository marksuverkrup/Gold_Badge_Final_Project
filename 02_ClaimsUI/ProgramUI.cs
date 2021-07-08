using _02_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    class ProgramUI
    {
        protected readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaims();
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Choose a menu item: \n" +
                    "1. Show all claims \n" +
                    "2. Take care of next claim  \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit \n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        RemoveClaim();
                        break;
                    case "3":
                        AddNewClaim();
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
        public void AddNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Please enter the 4 digit Claim ID: ");
            int claimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select the Type of the Claim. ");
            Console.WriteLine(
                    "1: Car \n" +
                    "2: Home \n" +
                    "3. Theft  \n");
            string userInputType = Console.ReadLine();
            ClaimType typeOfClaim = ClaimType.Car;
            switch (userInputType)
            {
                case "1":
                    typeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    typeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    typeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 4");
                    PressKey();
                    break;
            }
            Console.WriteLine("Please enter the Claim Description: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Please enter the Amount of Damage: ");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Date of the Incident, with Year, Month, and Day, sepparated by commas: ");
            DateTime dOI = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the Date of the Claim, with Year, Month, and Day, sepparated by commas: ");
            DateTime dOC = Convert.ToDateTime(Console.ReadLine());
            Claim claim = new Claim(claimID, typeOfClaim, desc, amount, dOI, dOC);
            _claimRepo.AddClaim(claim);
            Console.WriteLine("Your claim has been added to the system.");
            PressKey();
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            List<Claim> listofClaims = _claimRepo.GetClaims();
            Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-10} {4,-20} {5,-20} {6,-10}\n", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            foreach (Claim claim in listofClaims)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-10} {4,-20} {5,-20} {6,-10}", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.Amount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid);
            }
            PressKey();
        }
        private void ClaimsMenu(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                $"Type: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: ${claim.Amount}\n" +
                $"Date of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {claim.IsValid}\n");
        }
        private void RemoveClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next case to be handled:");
            List<Claim> claims = _claimRepo.GetClaims();
            ClaimsMenu(claims[0]);
            Console.WriteLine("Do you want to deal with this claim now(y/n)");
            string remove = Console.ReadLine();
            if (remove == "y")
            {
                _claimRepo.RemoveClaim(claims[0]);
                Console.WriteLine("The claim has been successful dealt with.");
                PressKey();
            }
        }
        public void PressKey()
        {
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadKey();
        }
        public void SeedClaims()
        {
            Claim car = new Claim(6482, ClaimType.Car, "Car runs into wall", 5000, Convert.ToDateTime("2020,5,15"), Convert.ToDateTime("2020/6/5"));
            Claim home = new Claim(9485, ClaimType.Home, "Roof destroyed by hail", 3000, Convert.ToDateTime("2018/2/24"), Convert.ToDateTime("2018/3/22"));
            Claim theft = new Claim(3410, ClaimType.Theft, "Bugelor steals motorcycle", 4000, Convert.ToDateTime("2019/8/11"), Convert.ToDateTime("2019/9/17"));
            _claimRepo.AddClaim(car);
            _claimRepo.AddClaim(home);
            _claimRepo.AddClaim(theft);
        }
    }
}
