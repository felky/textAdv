using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextAdventure_PrisonBreak
{
    class Program
    {
        enum locations { Cell, Cafeteria, Yard, Reception, Staffroom, ChiefsRoom, ParkingLot, LockerRoom};

        static void Main(string[] args)
        {
            // Declare variables 

            locations location = new locations();
            const int maxInventroySpace = 4;
            const string searchString = "search";
            const string inventoryString = "inv";
            const string helpString = "help";
            string[] inventory = new string[maxInventroySpace];
            bool hasEscaped = false;

            location = locations.Cell;

            Introduction();

            // While player has not escaped, run this main game loop.
            while (!hasEscaped)
            {
                Console.Clear();
                Console.WriteLine($"\nWrite [{searchString}] to search room.\n\nWrite [{inventoryString}] to open inventory and write item name to use it.\n");
                Console.WriteLine("------------------------------------------");

                switch (location)
                {
                    case locations.Cell:
                        CellEvent();
                        break;
                    case locations.Cafeteria:
                        CafeteriaEvent();
                        break;
                    case locations.Yard:
                        YardEvent();
                        break;
                    case locations.LockerRoom:
                        LockerroomEvent();
                        break;
                    case locations.ParkingLot:
                        ParkinglotEvent();
                        Console.ReadLine();
                        break;
                    default:
                        Console.ReadLine();
                        break;
                }
            }

            Console.Clear();
            PrintText("Congratulations, you won the game!\nPress any key to exit.");
            Console.ReadKey();
            Environment.Exit(1);

            void Introduction()
            {
                PrintText("\nYou wake up on your old prison bed.\n\nTired and frustrated you decide that today is the day you leave this place!");
            }

            void CellEvent()
            {
                Console.Clear();

                bool isPaperclipUsed = false;
                string playerAction = "";
                while (!isPaperclipUsed)
                {
                    Console.Clear();
                    Console.WriteLine($"You are in your prison cell.\nWrite [{helpString}] for help.\n");
                    playerAction = Console.ReadLine().ToLower();
                    switch (playerAction)
                    {
                        case searchString:
                            PrintText("You search the prison cell and found an old paperclip lying under your bed.");
                            inventory[0] = "paperclip";
                            break;
                        case inventoryString:
                            string item = useInventoryItems();
                            if(item.Contains("paperclip"))
                            {
                                PrintText("You use the paperclip to unlock the prison door!");
                                isPaperclipUsed = true;
                                location = locations.Cafeteria;
                            } else
                            {
                                PrintText("That does not work.");
                            }
                            break;
                        case helpString:
                            helpMenu();
                            break;
                        default:
                            Console.WriteLine("That is not correct.");
                            break;

                    }
                    
                }

            }

            void CafeteriaEvent()
            {
                Console.Clear();

                bool hasLeftCafeteria = false;
                string playerAction = "";
                while (!hasLeftCafeteria)
                {
                    Console.Clear();
                    Console.WriteLine($"You are now in the prison cafeteria, do you wish to go to the yard or to the reception.\nWrite [{helpString}] for help.\n");
                    playerAction = Console.ReadLine().ToLower();
                    switch (playerAction)
                    {
                        case "yard":
                            PrintText("You leave the cafeteria and enter the prison yard");
                            location = locations.Yard;
                            hasLeftCafeteria = true;
                            break;
                        case "reception":
                            loseGame();
                            break;
                        case searchString:
                            PrintText("There is nothing to be found here.");
                            break;
                        case inventoryString:
                            string item = useInventoryItems();
                            if (item.Length > 0)
                            {
                                PrintText("That cannot be used here");
                            }
                            break;
                        case helpString:
                            helpMenu();
                            break;
                        default:
                            Console.WriteLine("That is not correct.");
                            break;

                    }

                }

            }

            void YardEvent()
            {
                Console.Clear();

                bool hasLeftYard = false;
                string playerAction = "";
                while (!hasLeftYard)
                {
                    Console.Clear();
                    Console.WriteLine($"You are now in the prison yard.\nWrite [{helpString}] for help.\n");
                    playerAction = Console.ReadLine().ToLower();
                    switch (playerAction)
                    {
                        case searchString:
                            PrintText("You search the yard and found one of the guards dropped passcards, lucky!");
                            inventory[1] = "passcard";
                            break;
                        case inventoryString:
                            string item = useInventoryItems();
                            if (item.Contains("passcard"))
                            {
                                string nextLocation = "";
                                PrintText("You use the passcard to unlock the open the staffroom door!\nDo you wish to enter the Lockerroom or the ChiefsOffice");
                                bool hasChosenNextLocation = false;        
                                while (!hasChosenNextLocation)
                                {
                                    nextLocation = Console.ReadLine().ToLower();
                                    if(nextLocation == "lockerroom")
                                    {
                                        PrintText("You enter the lockerroom");
                                        location = locations.LockerRoom;
                                        hasChosenNextLocation = true;
                                        hasLeftYard = true;
                                    } else if (nextLocation == "chiefsoffice")
                                    {
                                        loseGame();
                                    } else
                                    {
                                        Console.WriteLine("Please enter a correct answer\n");
                                    }
                                }

                            }
                            else
                            {
                                PrintText("That does not work.");
                            }
                            break;
                        case helpString:
                            helpMenu();
                            break;
                        default:
                            Console.WriteLine("That is not correct.");
                            break;

                    }

                }

            }

            void LockerroomEvent()
            {
                Console.Clear();

                bool hasLeftBuilding = false;
                string playerAction = "";
                while (!hasLeftBuilding)
                {
                    Console.Clear();
                    Console.WriteLine($"You are at the locker rooms.\nWrite [{helpString}] for help.\n");
                    playerAction = Console.ReadLine().ToLower();
                    switch (playerAction)
                    {
                        case searchString:
                            PrintText("You find a police uniform in the locker room.");
                            inventory[2] = "police uniform";
                            break;
                        case inventoryString:
                            string item = useInventoryItems();
                            if (item.Contains("police uniform"))
                            {
                                PrintText("You put on the police uniform and leaves through the reception.");
                                hasLeftBuilding = true;
                                location = locations.ParkingLot;
                            }
                            else
                            {
                                PrintText("That does not work.");
                            }
                            break;
                        case helpString:
                            helpMenu();
                            break;
                        default:
                            Console.WriteLine("That is not correct.");
                            break;

                    }

                }

            }

            void ParkinglotEvent()
            {
                Console.Clear();

                bool hasLeftLot = false;
                string playerAction = "";
                while (!hasLeftLot)
                {
                    Console.Clear();
                    Console.WriteLine($"You are at the parking lot.\nWrite [{helpString}] for help.\n");
                    playerAction = Console.ReadLine().ToLower();
                    switch (playerAction)
                    {
                        case searchString:
                            PrintText("You find some old car keys.");
                            inventory[3] = "car key";
                            break;
                        case inventoryString:
                            string item = useInventoryItems();
                            if (item.Contains("car key"))
                            {
                                PrintText("You click the unlock button to find the car, you enter the car and turn the ignition.\nFinally. You leave this place.\n\nThe End.");
                                hasLeftLot = true;
                                hasEscaped = true;
                            }
                            else
                            {
                                PrintText("That does not work.");
                            }
                            break;
                        case helpString:
                            helpMenu();
                            break;
                        default:
                            Console.WriteLine("That is not correct.");
                            break;

                    }

                }

            }

            void PrintText(string textToPrint)
            {
                char[] textCharArr = textToPrint.ToCharArray();

                for (int i = 0; i < textCharArr.Length; i++)
                {
                    Console.Write(textCharArr[i]);
                    Thread.Sleep(1);
                }

                Console.WriteLine();
                Console.ReadKey();
            }

            string useInventoryItems()
            {
                foreach (string s in inventory)
                {
                    Console.WriteLine("Item: " + s);
                }
                string itemToBeUsed = Console.ReadLine();

                if (inventory.Contains(itemToBeUsed))
                {
                    return itemToBeUsed;
                } else
                {
                    return "none";
                }
            }

            void helpMenu()
            {
                Console.WriteLine($"\nWrite [{searchString}] to search room.\n\nWrite [{inventoryString}] to open inventory and write item name to use it.\n");
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
            }

            void loseGame()
            {
                PrintText("The guards found you and put you back in the cell.\n Press any key to exit game.");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}

