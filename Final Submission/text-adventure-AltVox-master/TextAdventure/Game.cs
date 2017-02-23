using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;

namespace TextAdventure
{
	class Game
	{
		Location currentLocation; //This allows the Game class to refer to the Location class in order to gain information required for the getTitle function and getDiscription function. 

        public string playerName = "Chris"; //This string functions acts as a record keeper of the players name. 
      
        public bool isRunning = true;//If isRunning is true, it allows the game to run, when the quit function is uses, it turns this statement to false and stops the game runnning.

        public int KeyCardsUsed = 0;// This int is used to count the amount of Keycards that have been used by the player.

        private List<Item> inventory;

        public Game()
        {
            inventory = new List<Item>();


            
            //===========OPENING MENU===============
        
            //This array of numbers ranging from 0-4 creates the opening image for my title screen.
            int[,] initialboard = {
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 3, 3, 3, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 0, 0, 0, 0, 3, 3, 3, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 0, 0, 2, 0, 3, 3, 3, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 0, 2, 2, 2, 3, 3, 3, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 1, 1, 2, 2, 2, 3, 3, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 4, 1, 1, 1, 1, 2, 2, 2, 3, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 3, 1, 1, 1, 1, 1, 1, 2, 2, 2, 4, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
            };

            //This forloop counts the length and height of the grid and creates the image seen on my titlescreen.
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 34; j++)
                {
                    //If 0 is inputted in the grid, then it creates an empty cell.
                    if (initialboard[i, j] == 0)
                        Console.Write(" ");
                    //If anything else is inputted into the grid as seen below, it fill it in with the colour that is within the else if statments. 
                    else if (initialboard[i, j] == 1)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Blue; //This line of code allows the foreground of the text to be coloured, in this case blue. 
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (initialboard[i, j] == 2)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (initialboard[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (initialboard[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (initialboard[i, j] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("#");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();

            }

            Console.Write("PRESS ENTER T0 START".PadLeft("n".Length + 21) + "\n" + "VALHALLA.".PadLeft("n".Length + 15)); //This line of text includes padding, which can push the text left or right. In this case I push the text left to inline with the image.
            Console.ReadLine();
            
            
      //=============END OF OPENING MENU================



      //=============CHARACTER CREATION==================

            Console.Clear();
            
            //This segment was made to add a feel of customization to my text adventure by using Thread.Sleep to create the boot up screen effect and using my playerName string for the name input.

            Console.WriteLine("BOOTING VALHALLA OS...");
            Thread.Sleep(1000); //Using, System.Thread, I was able to use the function Thread.Sleep, which works similar to a count-down or a delay function, allowing me to create a loading like effect by it working as a count-down or delay. 
            Console.WriteLine("\n" + "V:/>V:/VOS/CYBERDOC.EXE /X");
            Thread.Sleep(1000);
            Console.WriteLine("\n<5%>REQUIRING SYSTEM CHECKS");
            Thread.Sleep(1000);
            Console.WriteLine("<10%>SYSTEM CHECKS REQUIRED");
            Console.WriteLine("<15%>SYSTEM CHECKING NEURO LINKS");
            Thread.Sleep(2000);//Here I up the waiting time to allow the player to read what is going on in the background of the game. 
            Console.WriteLine("<25%>NEURO LINK CHECK COMPLETE" + "\n<50%>SYSTEM CHECKING DIGITAL MOLECULAR STRUCTURE");
            Thread.Sleep(2000);
            Console.WriteLine("<75%>SYSTEM CHECKING DIGITAL MOLECULAR STRUCTURE COMPLETE");
            Thread.Sleep(2000);
            Console.WriteLine("\n<100%>SYSTEM CHECKS COMPLETE");
            Thread.Sleep(2000);
            Console.WriteLine("\n\n<V:>NEW USER DETECTED");
            Thread.Sleep(1000);
            Console.WriteLine("\n<V:>INITALIZING NEW USER PROGRAM");
            Thread.Sleep(2000);

            Console.Clear();//Here I clear the consoles, Originally I did not, but in playtesting, it felt as if it was taking up to much space on the screen. 

            Console.WriteLine("<V:>USER CREATION");
            Console.WriteLine("\nA new user has been decteced, in order to proceed into Valhalla it is " + "\nrquired that you have a USER IDENTIFACTION NAME or simply a USER ID.");
            Console.Write("\nPlease enter yout USER ID:");
            playerName = Console.ReadLine();//Here is where the player will input their chosen name, the playerName string will be or equals what the player will enter in the console, by using the Console.Readline function. Because the string being global it can be refered to throughout the Game Class.

            Console.WriteLine("\nYour USER ID is being registered to our databanks." + "\nPlease wait...");
            Thread.Sleep(2500);
            Console.WriteLine("\n<Accessing Databank>");
            Console.WriteLine("<Resigstering ID to Databank>");
            Thread.Sleep(1000);
            Console.WriteLine("\n" + "User ID:" + playerName + " Has been registered.");//Here is the playerName function being used, this is to show that the players input is being regonised and to slowly introduce the typing mechanic of the game. 

            Console.WriteLine("\nThank you for your cooperation, thoughout Valhalla you will be known as" + " " + playerName + "\n We here at UoS Entertainment, hope you enjoy your time in Valhalla.");
            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
            Console.Clear();

            //==============END OF CHARACTER CREATION==================

            //==============GAMES OBJECTIVE======================

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nValhalla Mission guide:\n\n" + playerName + " Your objective is simple, collect all Anti-Virus key cards\nAnd slot them into the memory bank, centered in the white hall.\n\nPress Enter to continue");
            Console.ResetColor(); 
            Console.ReadLine();
            Console.Clear(); 
            //=============END OF GAMES OBJECTIVE===============



            //==============CODE FOR MAP BUILDING=====================

            //This is the base source code that we were given in order to create our map e.g. Rooms, items and exits. 


            //How the following lines of code work below is by referring to the Location class, and the second Location function, by pulling over the strings within to create the tite of the room, the discription of the room, the exit list which has been created in the exit class which has also been brought over from the location class and the same with the item class, using the item construct create within the item class. 
                Location L1 = new Location("Valhalla Guiding System: White Hall", "You find yourself suddenly standing in a plan white room, there appears to be\nno indication where the floor ends, the walls begins or the ceilling starts. It\nLooks as if the room has no end.\n\nLingering in what you assume is the centre of the room is a wide, clean cut\nObsidian like obelisk. That remsembles somewhat of computer memory bank.\nOn each face is a coloured keycard slot a red, blue, green and yellow.\n\nSurrounding the obelisk and yourself are four doors. Each door appears to be\nColoured similar to the keycard slots, there is a red, blue, green and yellow. ");

                Location L2 = new Location("Valhalla Guiding System: Blue Room", "As you enter the blue room you're strucked by intensity of the neo-blue LEDs.\nYou get a strange feeling of relaxtion and relife, as if the room itself is \nadmitting a Soothing aura.\n\nAs you look around the blue room, you notice a small footlocker within the far\nright corner.\n\nWhat do you do?");
                Item RedKeyCard = new Item("red keycard", L1);//Example of the item being collectable, due to the item construct, which is being brought through in Location class. 
                L2.addItem(RedKeyCard);

                Location L3 = new Location("Valhalla Guiding System: Red Room", "As you enter the red room, you're thrown off by the sight of an empty chair \nThat has been placed within the center of the room, facing in your direction.\nYou can hear faint whispers of "+ playerName + ". You can't but help feel slightly \nunsettled at the sight of this, as if the Room itself is watching you.\n\nPlaced on the chair is what appears to be a blue keycard, what do you do?");
                Item BlueKeyCard = new Item("blue keycard", L1); 
                L3.addItem(BlueKeyCard);

                Location L4 = new Location("Valhalla Guiding System: Green Room", "As you enter the green room, you're overwhelmed by the sight of what appears\nTo be low-poly digitize Locus.They don't seem to be bothered by your apperance.\nBut the even though they are not real, abormal amount makes you feel somewhat\nuneasy.\n\nAs you slowly make your through the room, crushing the fake locus you notice a\nIt appears you may have to search the room in order to find what you are \nLooking for.");
                Item YellowKeyCard = new Item("yellow keycard", L1);
                L4.addItem(YellowKeyCard);

                Location L5 = new Location("Valhalla Guiding System: Yellow Room", "As you enter the yellow room, you're surprised by the sight of digitize wheat\nThat stands looking over you. You feel somewhat anxious, heading into the \nfield of wheat, not knowing what awaits you ahead.\n\nRemeber to type help, for a list commands to enter.");
                Item GreenKeyCard = new Item("green keycard", L1);
                L5.addItem(GreenKeyCard);

            //The following lines of code below creates exits for each loaction that lead to another location, how this works for example is that by using addExit will adding/creating a new exit in a direction listed in the public enum Directions, in the exit class which if enter into the console will lead the player to following local listen locations. 
            L1.addExit(new Exit(Exit.Directions.West, L2));
                L1.addExit(new Exit(Exit.Directions.East, L3));
                L1.addExit(new Exit(Exit.Directions.South, L4));
                L1.addExit(new Exit(Exit.Directions.North, L5)); 

                L2.addExit(new Exit(Exit.Directions.East, L1));
                L3.addExit(new Exit(Exit.Directions.West, L1));
                L4.addExit(new Exit(Exit.Directions.North, L1));
                L5.addExit(new Exit(Exit.Directions.South, L1)); 
                currentLocation = L1;
                showLocation();
            }

        //==============END CODE FOR MAP BUILDING===============
        

        //==============BASE SEARCH FUNCTIONS=================

        public void showLocation() //This void function, showLocation. Gets the players current location and displays it on the console. 
		{
			Console.WriteLine("\n" + currentLocation.getTitle() + "\n");//By using the currentLocation which is delcared after the map is being built, it finds the current locations title, with the getTitle function, to display the title. 
			Console.WriteLine(currentLocation.getDescription());//Similarly to getting the title of the room, this line of code displays the rooms discription, it does so by using the getDestrciption, due to being able to refer to the first location function, in the location class. 
	
			Console.WriteLine("\nAvailable Exits: \n");

			foreach (Exit exit in currentLocation.getExits() ) //This foreach loop displays a list of exits according to the exits that have been listen within a location. 
			{
				Console.WriteLine(exit.getDirection());
			}

			Console.WriteLine();
		}

        public void SearchRoom()//The public void, SearchRoom. Was create so I could create a input for the player to search the room to display the contents of the room. 
        {
            if (currentLocation.getInventory().Count > 0) //This line of code means that if the item count is greater then 0 within in a location, it will display a list of items that have listed within the location. 
            {
                Console.WriteLine("\nYou search the room to find:\n");


                foreach(Item i in currentLocation.getInventory()) //This foreach loop, lists each item that is listed below the location where the map has been built, "i" being the var representing the item in the location while "itemName" being the actually items name. 
                {
                    Console.WriteLine(i.itemName + "\n");
                }

            }

            if (currentLocation.getInventory().Count <= 0)// This if statement is the oppisite of the first if statement, the item count is less than or equal to zero, then this if statement is true. 
            {
                Console.WriteLine("\nYou seach the room and found nothing.\n");
            }

        }

        //==============END SEARCH FUNCTIONS=================



        //==============INVENTORY SYSTEM===================
        
       
        public void addToInventory()//This public void, addToInventory was created to create a function that would add my items in game into the player inventory. 
        {
            string a; //this local string functions as an input to allow the player to pick up items. 
            do //This doloop allows the player to pick up item of their choice. 
            {
                Console.WriteLine("What item do you want to take?");

                a = Console.ReadLine();
            } while (a == null); //Although once the doloop has activated, this whileloop also activates. which neglects following lines of code within this doloop if the input does not equal an item listed within the room.

            Item toAdd = null; 

            foreach (Item i in currentLocation.getInventory()) //This foreach loop gets the item that is in the current location, by using the currentLocation.getInventory function. 
            {
                if (i.itemName == a) //The following if statment means if the item that has been entered into the console input is true, and is the currently an item in the room. The following if statment plays out.
                {
                    toAdd = i;
                    break; //Eventrually returning the back to the start of this function, so it can be used again. 
                }
            }

            if (toAdd != null)//This if function not only adds the item to the player's inventory but also removes the item from the room, not allowing the player to duplicate the item.
            {
                inventory.Add(toAdd);//Inventory.Add calls to the ToAdd item function, added whatever the item as been listed as, within the item class of building map functions. 
                Console.WriteLine("You picked up the " + toAdd.itemName); 
                currentLocation.removeItem(toAdd); //It calls to the location class, to use the remove function within, removing it from the game's inventory, once it is in the player's inventory.   
            }
            else
            {
                Console.WriteLine("That item isn't in this room.");//If the player inputs an item that is not listed within the current location, this line of text will appear. 
            }

            

        }

        private void showInventory() //This private void, showInventory. allows the player to view their inventory.  
        {
            if (inventory.Count > 0)// The following if statment if the player's inventory count is greater than 0 is true, the message below will appear, displaying a items that have been added to the list <items>Inventory. 
            {
                Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in inventory)
                {
                    Console.WriteLine(item.itemName);
                }
            }
            else // If the player's inventory count is greater than 0 is false, then following message will display instead. 
            {
                Console.WriteLine("Your bag is empty.");
            }

            Console.WriteLine("");
        }

        //==============END INVENTORY SYSTEM===================



        //==============COMMAND SYSTEM=================

        
        public void doAction(string command) //The following public void, doAction. controls the inputs that the player can enter. 
		{
           
            
            switch (command.ToLower())// The following switch functions allow the commands below to be entered and have the following functions. 
            {

                case "search room"://This case function allows the player to type the following command, onced entered will run the searchRoom function. 
                    SearchRoom(); 
                    break;

                case "take item"://This case function allows the player to type the following command, onced entered will run the AddToInventory function. 
                    addToInventory();
                    break;

                case "use item"://This case function allows the player to type the following command, onced entered will run the useitem function.
                    UseItem();
                    break;

                case "check bag"://This case function allows the player to type the following command, onced entered will run the checkbag function.
                    showInventory();
                    break; 

                case "walk north"://This case function allows the player to type the following command, onced entered will run the following function.

                    foreach (Exit exit in currentLocation.getExits())//This foreach loop checks the exits of the currentlocation. 
                    {
                        if ( exit.getDirection() == Exit.Directions.North )//If the currentlocation has an exit listed as north, this if statement will change the currentlocation to location that exit leads to. 
                        {
                            currentLocation = exit.getLeadsTo();
                            break;
                        }
                    }

                    Console.Clear(); 
                    showLocation(); 
                    break;

                    //The following three case functions below work all the same as te above case function, just with different directions. 
                case "walk south":
                    foreach (Exit exit in currentLocation.getExits())
                    {
                        if (exit.getDirection() == Exit.Directions.South)
                        {
                            currentLocation = exit.getLeadsTo();
                            break;
                        }
                    }

                    Console.Clear();
                    showLocation();
                    break;

                case "walk east":
                    foreach (Exit exit in currentLocation.getExits())
                    {
                        if (exit.getDirection() == Exit.Directions.East)
                        {
                            currentLocation = exit.getLeadsTo();
                            break;
                        }
                    }

                    Console.Clear();
                    showLocation();
                    break;

                case "walk west":
                    foreach (Exit exit in currentLocation.getExits())
                    {
                        if (exit.getDirection() == Exit.Directions.West)
                        {
                            currentLocation = exit.getLeadsTo();
                            break;
                        }
                    }

                    Console.Clear();
                    showLocation();
                    break;
                    

                case "clear"://This case function, if inputted it allows the player to clear the screen of privious text that has been enter apart from their currentlocation. This is so the game does not become a mess of text on screen.
                    Console.Clear();
                    showLocation(); 
                    break;

                case "help"://This case function promts the help text which lists all the commands that can be enter on screen. 
                    HelpMenu();
                    break;

                case "mission brief"://This case function, if entered allows the player to double check their objective. 
                    MissionBreif();
                    break; 

                default://If a case function is not regonised, this defualt function will activate and display the text below. 
                    Console.WriteLine("I don't quite understand"); 
                    break; 

            }


		}


		public void Update()
		{
			string currentCommand = Console.ReadLine().ToLower();

			// instantly check for a quit
			if (currentCommand == "quit" || currentCommand == "q")
			{
				isRunning = false;
				return;
			}
				
			// otherwise, process commands.
			doAction(currentCommand);
		}

   //================END COMMAND SYSTEM===================



        public void HelpMenu()//This public void is being called in the case function Help, it contains all the lines of text to help the player. 
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("\nWelcome to the Valhalla's Control guide:\n\nType Walk north, to travel North.\nType Walk South, to travel South.\nType Walk east, to travel East\nType Walk West, to travel West");
            Console.WriteLine("\nType Search room, to locate items within rooms.\nType Take item, to take the item in the room.\nType Check bag, to check your inventory");
            Console.WriteLine("\nType Mission Breifing, to check your objective");
            Console.WriteLine("\nType Quit, to quit the game.\nType Clear, to clear the console."); 
            Console.ResetColor(); 
        }


        public void MissionBreif()//This public void is being called in the case function mission breif, it contains the lines of text are displayed on screen.
        {
            Console.WriteLine("\nValhalla Mission guide:\n\n"+playerName+" Your objective is simple, collect all Anti-Virus key cards\nAnd slot them into the memory bank, centered in the white hall.");




        }

        public void UseItem()//This public void, UseItem was created to create a function that would allow the player to use the obtainable items. 
        {
            string a; //this local string functions acts as an input to allow the player to use items from their inventory. 
            do //This doloop allows the player to use items of their choice. 
            {
                Console.WriteLine("What item do you want to use?");

                a = Console.ReadLine();
            } while (a == null); //Although once the doloop has activated, this whileloop also activates. which neglects following lines of code within this doloop if the input does not equal an item listed within the players inventory.

            Item Remove = null;

            foreach (Item i in inventory) //This foreach loop gets the item that is in the player's inventory, by using the List<Item>inventory function. 
            {
                if (i.itemName == a) //The following if statment registered the amount of items that have been used.
                {
                    Remove = i;//By simply removing the item that was that entered. 
                    if(i.itemName == "red keycard" || i.itemName == "blue keycard" || i.itemName == "green keycard" || i.itemName == "yellow keycard")//Then if the items name matches one of the following name, within this if statment.
                    {
                        KeyCardsUsed++;//If true, the KeyCardUsed function is plused by each KeyCard that the player has used. 
                    }
                    break; //Eventrually returning the back to the start of this function, so it can be used again. 
                }
            }

            if ( KeyCardsUsed >= 4)//This if statement counts the amount of Keycards that have been used, if the amout is equal or greater then four, it loads the EndGame screen.
            {
                EndGame();
                return;
            }

            if (Remove != null)//This if statement contains two if statements that allow the KeyCards to be removed from the inventory when being used as well can only be used within a certain location.  
            {
                if ( Remove.Uselocation != null )
                {
                    if ( Remove.Uselocation != currentLocation)//This if statement checks if the current location, is the right location to use the obtainable items in. 
                    {
                        Console.WriteLine("You cannot use that here");
                        return;
                    } 
                }
                //If the location is the right location for the item to be used then the follow lines of code take place.
                inventory.Remove(Remove);//By using the similar code to remove items from a room, it does the same for removing items for the player's inventory.
                Console.WriteLine("You used " + Remove.itemName);//This line of code alearts the player that they have used the following item that have entered into the console.
                currentLocation.removeItem(Remove);//The following item is then removed from the player's inventory, using the similar function that the item removed . 
            }
        



        }

        public void EndGame()//This public void is being called when the KeyCardUse function has equaled or reached 4. 
        {
            Console.Clear(); 
            Console.WriteLine("Valhalla Mission Guide: UPDATE\n\n"+playerName+" Well done on completing your mission, you no longer need to be in Valhalla. Logout when you're ready.\n\nPress Enter to continue.");
            Console.ReadLine();
            Console.Write("\nThank for playing Valhalla, see you next mission.");
            Console.ReadLine();  

        }


    }
     

}
