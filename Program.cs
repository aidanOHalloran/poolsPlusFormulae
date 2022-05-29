namespace DOCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Clear();
            string menuChoice = "";
            MainMenu();
            
        }

        static void MainMenu()
        {
            Console.Clear();
            System.Console.WriteLine("\tPlease make a selection or enter -1 to quit: \n");
            System.Console.WriteLine("1. PhosKlear 4000 Treatment");
            System.Console.WriteLine("2. Salt Testing");
            System.Console.WriteLine("3. Alkalinity Testing");
            System.Console.WriteLine("4. Test Strip Analysis");
            System.Console.WriteLine();

            string menuChoice = Console.ReadLine();

            Route(ref menuChoice);
        }

        static void Route(ref string menuChoice)
        {
            while(menuChoice != "-1")
            {
                if(menuChoice == "1")
                    {
                        PhosKlearTreatment();
                    }
                else if(menuChoice == "2")
                    {
                        SaltLevelCheck();
                    }
                else if(menuChoice == "3")
                    {
                        AlkCheck();
                    }
                else if(menuChoice == "4")
                    {
                        TestStripAnalysis();
                    }
                else
                    {
                        System.Console.WriteLine("Sorry, that is an invalid selection. Press enter to return to main menu: ");
                        Console.ReadKey();
                    }

                 MainMenu();
            }
            if(menuChoice == "-1")
                {
                    Environment.Exit(0);
                }
        }

        static void PhosKlearTreatment()
        {
            Console.Clear();
            string poolGallonSizeString = "";
            double poolGallonSize = 0;
            string lenghtString, widthString, avgDepthString = "";
            System.Console.WriteLine("Enter 1 if you know the gallon size of the pool.\n\nEnter 2 to calculate pool size.\n\n");
            string userChoice = Console.ReadLine();

            if(userChoice == "1" || userChoice == "2")
            {
                if(userChoice == "1")
                    {
                        Console.Clear();
                        System.Console.WriteLine("Enter pool size in gallons: ");
                        poolGallonSizeString = Console.ReadLine();
                        

                        while(!double.TryParse(poolGallonSizeString, out poolGallonSize))
                            {
                                System.Console.WriteLine("Please be sure you enter a number...");
                                poolGallonSizeString = Console.ReadLine();
                            }
                    }
                else if(userChoice == "2")
                    {
                        Console.Clear();
                        System.Console.WriteLine("Enter pool length (feet): ");
                        lenghtString = Console.ReadLine();
                        double length;

                        while(!double.TryParse(lenghtString, out length))
                            {
                                System.Console.WriteLine("Please be sure you enter a number...");
                                lenghtString = Console.ReadLine();
                            }

                        Console.Clear();
                        System.Console.WriteLine("Enter pool width (feet)");
                        widthString = Console.ReadLine();
                        double width;

                        while(!double.TryParse(widthString, out width))
                            {
                                System.Console.WriteLine("Please be sure you enter a number...");
                                widthString = Console.ReadLine();
                            }
                        
                        
                        Console.Clear();
                        System.Console.WriteLine("Enter average depth (feet)");
                        avgDepthString = Console.ReadLine();
                        double avgDepth;

                        while(!double.TryParse(avgDepthString, out avgDepth))
                            {
                                System.Console.WriteLine("Please be sure you enter a number...");
                                avgDepthString = Console.ReadLine();
                            }
                        
                        
                        Console.Clear();
                        poolGallonSize = length * width * avgDepth * 7.5;
                        System.Console.WriteLine($"Pool size is {poolGallonSize} gallons.");
                    }

                System.Console.Write("Enter current phosphate levels (in PPM) closest to reading (hint: use phosphate tests...)");
                System.Console.Write("250, ");
                System.Console.Write("500, ");
                System.Console.Write("1000, ");
                System.Console.Write("2000, ");
                System.Console.Write("3000, \n\n");

                double phosphateLevel = double.Parse(Console.ReadLine());
                Console.Clear();

                double neededCleaner = (8.0e-7 * poolGallonSize) * phosphateLevel;
                Console.Clear();

            
                System.Console.WriteLine($"Needed amount of cleaner is {neededCleaner} oz.\n\nPress any key to continue...");
                Console.ReadKey();
            }
            else
            {
                System.Console.WriteLine("Sorry, that is an invalid selection. Press enter to return to selection: ");
                Console.ReadKey();
                PhosKlearTreatment();
            }

        }

        static void SaltLevelCheck()
        {
            Console.Clear();
            System.Console.WriteLine("Enter salt level in PPM");
            string saltLevelString = Console.ReadLine();
            double saltLevel;

            while(!double.TryParse(saltLevelString, out saltLevel))
                {
                    System.Console.WriteLine("Make sure you enter a number...");
                    saltLevelString = Console.ReadLine();
                }

            System.Console.WriteLine("Enter pool size in gallons: ");
            string poolGallonSizeString = Console.ReadLine();
            double poolGallonSize;
                        

            while(!double.TryParse(poolGallonSizeString, out poolGallonSize))
                    {
                       System.Console.WriteLine("Please be sure you enter a number...");
                       poolGallonSizeString = Console.ReadLine();
                    }

            double saltToAdd = (poolGallonSize * 8.35) * (0.0032 - (saltLevel / 1000000));

            int wholeBags = (int)Math.Round(saltToAdd / 40);
            System.Console.WriteLine($"You need to add {Math.Round(saltToAdd, 2)} lbs of salt, or {wholeBags} bag/bags.\n\nPress any key to continue: ");
            Console.ReadKey();
        }

        static void AlkCheck()
        {
            Console.Clear();
            System.Console.WriteLine("Please enter the current alkalinity level in PPM: ");
            string alkLevelActualString = Console.ReadLine();
            double alkLevelActual;

            while(!double.TryParse(alkLevelActualString, out alkLevelActual))
                {
                    System.Console.WriteLine("Make sure you enter a number...");
                    alkLevelActualString = Console.ReadLine();
                }
            
            Console.Clear();
            System.Console.WriteLine("Please enter the desired alkalinity level in PPM: ");
            string alkLevelDesiredString = Console.ReadLine();
            double alkLevelDesired;

            while(!double.TryParse(alkLevelDesiredString, out alkLevelDesired))
                {
                    System.Console.WriteLine("Make sure you enter a number...");
                    alkLevelDesiredString = Console.ReadLine();
                }

            Console.Clear();
            System.Console.WriteLine("Enter 1 if you know the gallon size of the pool, or 2 if you wish to calculate it: ");
            string userChoiceString = Console.ReadLine();
            int userChoice;

            while(!int.TryParse(userChoiceString, out userChoice))
                {
                    System.Console.WriteLine("Make sure you enter a number...");
                    userChoiceString = Console.ReadLine();
                }
                Console.Clear();
            
            if(userChoice == 1 || userChoice == 2)
                {
                    double poolGallonSize;
                    string lenghtString, widthString, avgDepthString;
                    if(userChoice == 1)
                        {
                            System.Console.WriteLine("enter the amount in gallons: ");
                            string poolGallonSizeString = Console.ReadLine();
                            Console.Clear();
                            

                            while(!double.TryParse(poolGallonSizeString, out poolGallonSize))
                                {
                                    System.Console.WriteLine("Make sure you enter a number...");
                                    poolGallonSizeString = Console.ReadLine();
                                }
                        }
                    else 
                        {
                            Console.Clear();
                            System.Console.WriteLine("Enter pool length (feet): ");
                            lenghtString = Console.ReadLine();
                            double length;

                            while(!double.TryParse(lenghtString, out length))
                                {
                                    System.Console.WriteLine("Please be sure you enter a number...");
                                    lenghtString = Console.ReadLine();
                                }

                            Console.Clear();
                            System.Console.WriteLine("Enter pool width (feet)");
                            widthString = Console.ReadLine();
                            double width;

                            while(!double.TryParse(widthString, out width))
                                {
                                    System.Console.WriteLine("Please be sure you enter a number...");
                                    widthString = Console.ReadLine();
                                }
                        
                        
                            Console.Clear();
                            System.Console.WriteLine("Enter average depth (feet)");
                            avgDepthString = Console.ReadLine();
                            double avgDepth;

                            while(!double.TryParse(avgDepthString, out avgDepth))
                                {
                                    System.Console.WriteLine("Please be sure you enter a number...");
                                    avgDepthString = Console.ReadLine();
                                }
                        
                        
                            Console.Clear();
                            poolGallonSize = length * width * avgDepth * 7.5;
                        }
                        double neededAlk = (alkLevelDesired - alkLevelActual) * (poolGallonSize / 66666.67);
                        double neededAlkRounded = Math.Round(neededAlk, 2);

                        System.Console.WriteLine($"To reach your desired alkalinity level, you must add {neededAlkRounded} lbs. of alkalinty.\nPress any key to return to main menu: ");
                        Console.ReadKey();
                        System.Console.WriteLine();
                        MainMenu();
                }
                System.Console.WriteLine("Sorry, that is an invalid selection. Please be sure to enter an available option: ");
                AlkCheck();
        }

        static void TestStripAnalysis()
        {
            int menuChoice = TestStripMenu();
        }

        static int TestStripMenu()
        {
            Console.Clear();
            string menuChoiceString;
            int menuChoice;

            System.Console.WriteLine("\tPlease make a selection: \n");
            System.Console.WriteLine("1. pH Testing");
            System.Console.WriteLine("2. Toal Chlorine");
            System.Console.WriteLine("3. Free Chlorine");
            System.Console.WriteLine("4. Total Hardness");
            System.Console.WriteLine("5. Cyanuric Acid");

            menuChoiceString = Console.ReadLine();

            if(!int.TryParse(menuChoiceString, out menuChoice))
                {
                    System.Console.WriteLine("Make sure you enter a number...");
                    menuChoiceString = Console.ReadLine();
                }


            return menuChoice;
        }
    }
}
