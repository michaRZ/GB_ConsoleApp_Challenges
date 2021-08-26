using KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();

        public void Run()
        {
            SeedBadges();
            Menu();
        }

        private void SeedBadges()
        {
            List<string> availableDoors = new List<string>()
           {
               "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10",
               "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10",
           };
            int badgeNum1 = 1;
            int badgeNum2 = 12341;

            Badge seedBadge1 = new Badge(badgeNum1, availableDoors);
            Badge seedBadge2 = new Badge(badgeNum2, availableDoors);
            _repo.AddBadgeToDictionary(seedBadge1);
            _repo.AddBadgeToDictionary(seedBadge2);
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                string title = @"
  ___ ___                         __                          
 |   Y   .-----.--------.-----.--|  .-----.                   
 |.  1  /|  _  |        |  _  |  _  |  _  |                   
 |.  _  \|_____|__|__|__|_____|_____|_____|                   
 |:  |   \    _______                       __ __             
 |::.| .  )  |   _   .-----.----.--.--.----|__|  |_.--.--.    
 `--- ---'   |   1___|  -__|  __|  |  |   _|  |   _|  |  |    
             |____   |_____|____|_____|__| |__|____|___  |    
             |:  1   |    _______             __   |_____|    
             |::.. . |   |   _   .-----.-----|  |_.-----.----.
             `-------'   |.  1___|  -__|     |   _|  -__|   _|
                         |.  |___|_____|__|__|____|_____|__|  
                         |:  1   |                            
                         |::.. . |                            
                         `-------'                            
                                                              
";
                Console.WriteLine(title);

                Console.WriteLine("Security Menu: \n" +
                    "1. List all badges\n" +
                    "2. Edit a badge\n" +
                    "3. Add a badge\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "list":
                        // add a new badge
                        DisplayAllBadges();
                        break;
                    case "2":
                    case "edit":
                        // edit an existing badge
                        UpdateBadge();
                        break;
                    case "3":
                    case "add":
                        // display full list via dictionary
                        AddBadge();
                        break;
                    case "4":
                    case "exit":
                        // exit application
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu selection");
                        ContinueMessage();
                        break;
                }
            }
            Console.Clear();
            Console.Write("Securely logging out in 3... ");
            Thread.Sleep(500);
            Console.Write("2... ");
            Thread.Sleep(500);
            Console.Write("1... \n");
            Thread.Sleep(500);
            Console.WriteLine("\nGoodbye!");
            Thread.Sleep(2000);
        }

        // return to main menu message
        private void ReturnToMainMessage()
        {
            Console.WriteLine("\nPress any key to return to the Security Menu...");
            Console.ReadKey();
        }

        // continue message
        private void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // display a badge
        private void DisplayBadge(Badge badge)
        {
            string doorsString = string.Join(",", badge.AccessDoors);
            Console.WriteLine("\nBadge # " + badge.BadgeID + " has access to door(s) " + doorsString);
        }


        // display dictionary
        public void DisplayAllBadges()
        {
            Console.Clear();

            Console.WriteLine("Badge #         Authorised Doors    \n");
            Dictionary<int, List<string>> badgeList = _repo.GetDictionary();

            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                string badgeDoors = string.Join(", ", badge.Value);
                Console.WriteLine("Badge # {0}      {1}\n", badge.Key, badgeDoors);
            }
            ReturnToMainMessage();
        }


        // add new badge
        private void AddBadge()
        {
            Badge newBadge = new Badge();
            List<string> accessDoors = new List<string>();

            Console.WriteLine("\nBadge number: \n");
            int inputNum = int.Parse(Console.ReadLine());
            Badge testBadge = _repo.GetBadgeByNumber(inputNum);

            if (testBadge == null)
            {
                newBadge.BadgeID = inputNum;
                string door = string.Empty;

                bool addAnotherDoor = true;
                while (addAnotherDoor)
                {
                    Console.WriteLine("\nAdd authorised door: \n");
                    accessDoors.Add(Console.ReadLine().ToUpper());

                    Console.WriteLine("\nWould you like to add another door (y/n)");
                    string input = Console.ReadLine().ToLower();
                    if (input == "n" || input == "no")
                    {
                        ReturnToMainMessage();
                        addAnotherDoor = false;
                    }
                }
                newBadge.AccessDoors = accessDoors;
                _repo.AddBadgeToDictionary(newBadge);
                
            }
            else
            {
                Console.WriteLine($"\nBadge # {testBadge.BadgeID} already exists");
                ReturnToMainMessage();
            }
        }


        // update badge - opens new menu
        private void UpdateBadge()
        {
            Console.Clear();

            Console.WriteLine("What is the badge number that needs to be updated?");

            string numString = Console.ReadLine().ToLower();
            int numInt;

            if (int.TryParse(numString, out numInt))
            {
                List<string> currentDoors = new List<string>();

                Badge selectedBadge = _repo.GetBadgeByNumber(numInt);

                if (selectedBadge != null)
                {
                    currentDoors = selectedBadge.AccessDoors;

                    bool continueToUpdate = false;
                    while (!continueToUpdate)
                    {
                        DisplayBadge(selectedBadge);
                        Console.WriteLine("\nUpdate options: \n" +
                            "1. Remove a door\n" +
                            "2. Add a door\n" +
                            "3. Return to main Security menu\n");

                        string userInput = Console.ReadLine().ToLower();
                        switch (userInput)
                        {
                            case "1":
                            case "remove":
                                // remove door from badge
                                Console.WriteLine("\nRemove which door?\n");
                                string byeDoor = Console.ReadLine().ToUpper();
                                currentDoors.Remove(byeDoor);
                                selectedBadge.AccessDoors = currentDoors;
                                ContinueMessage();
                                Console.Clear();
                                break;
                            case "2":
                            case "add":
                                // add door to badge
                                Console.WriteLine("\nAdd which door?\n");
                                string hiDoor = Console.ReadLine().ToUpper();
                                currentDoors.Add(hiDoor);
                                selectedBadge.AccessDoors = currentDoors;
                                ContinueMessage();
                                Console.Clear();
                                break;
                            case "3":
                            case "return":
                                // return to main menu (break while loop, then call Main();
                                Console.WriteLine("\nBadge updated");
                                ReturnToMainMessage();
                                continueToUpdate = false;
                                Menu();
                                break;
                            default:
                                Console.WriteLine("\nPlease enter a valid selection");
                                ContinueMessage();
                                break;
                        }

                        _repo.UpdateExistingBadge(numInt, selectedBadge);
                    }

                }
                else
                {
                    Console.WriteLine("Badge not found in dircectory");
                    ReturnToMainMessage();
                }
            }
            else
            {
                Console.WriteLine("Invalid badge nummber");
                ReturnToMainMessage();
            }
        }
    }
}



