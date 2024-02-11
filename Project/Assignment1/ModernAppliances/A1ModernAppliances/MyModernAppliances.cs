using System.Collections;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// Manager class for Modern Appliances
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// Option 1: Performs a checkout
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            long itemNumber = (long)Convert.ToDouble(Console.ReadLine());

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
                    // Assign appliance in list to foundAppliance variable
                    // Break out of loop (since we found what need to)
            // Test appliance was not found (foundAppliance is null)
                // Write "No appliances found with that item number."
            // Otherwise (appliance was found)
                // Test found appliance is available
                    // Checkout found appliance
                    // Write "Appliance has been checked out."
                // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
            foreach (Appliance appliance in Appliances){ if (appliance.ItemNumber == itemNumber) {foundAppliance = appliance; break;} }
            
            if (foundAppliance == null) {Console.WriteLine("No Appliances found with that item number.");}
            else {
                if (foundAppliance.IsAvailable == true) {Console.WriteLine("Appliance has been checked out.");}
                else {Console.WriteLine("The appliance is not available to be checked out.");}
                }
        }

        /// Option 2: Finds appliances
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for: ");
            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string? itemBrand = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate through loaded appliances
                // Test current appliance brand matches what user entered
                    // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances) {if (appliance.Brand == itemBrand) foundAppliances.Add(appliance);}

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances,0);
        }

        /// Displays Refridgerators
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: \n0 - Any\n2 - Double doors\n3 - Three doors\n4 - Four doors");
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"

            // Write "Enter number of doors: "
            Console.Write("Enter number of doors: ");
            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            // Convert user input from string to int and store as number of doors variable.
            int numOfDoors = Convert.ToInt16(Console.ReadLine());
            
            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate/loop through Appliances
                // Test that current appliance is a refrigerator
                    // Down cast Appliance to Refrigerator
                    // Refrigerator refrigerator = (Refrigerator) appliance;

                    // Test user entered 0 or refrigerator doors equals what user entered.
                        // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances){
                if (appliance.ItemNumber/100000000 == 1){
                    Refrigerator refrigerator = (Refrigerator) appliance;
                    if (numOfDoors == 0 || numOfDoors == refrigerator.Doors) foundAppliances.Add(refrigerator);
                }
            }
            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances,0);
        }
        /// Displays Vacuums
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Posible options: \n0 - Any\n1 - Residential\n2 - Commercial");
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"
            Console.WriteLine("Enger grade: ");
            // Get user input as string and assign to variable
            string? userGrade = Console.ReadLine();
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade;
            switch(userGrade){
                case "0": grade = "Any"; break;
                case "1": grade = "Residential"; break;
                case "2": grade = "Commercial"; break;
                default: Console.WriteLine("Invalid option."); return;
            }
            // Test input is "0"
                // Assign "Any" to grade
            // Test input is "1"
                // Assign "Residential" to grade
            // Test input is "2"
                // Assign "Commercial" to grade
            // Otherwise (input is something else)
                // Write "Invalid option."

                // Return to calling (previous) method
                // return;

            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            Console.WriteLine("Possible options: \n0 - Any\n1 - 18 Volt\n2 - 24 Volt");
            // Write "Enter voltage:"
            Console.WriteLine("Enter voltage: ");
            // Get user input as string
            string? userVoltage = Console.ReadLine();
            // Create variable to hold voltage
            int voltage;

            switch(userVoltage){
                case "0": voltage = 0; break;
                case "1": voltage = 18; break;
                case "2": voltage = 24; break;
                default: Console.WriteLine("Invalid option."); return;
            }
            
            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.
            List<Appliance> foundAppliances = new List<Appliance>();
            // Loop through Appliances
                // Check if current appliance is vacuum
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                        // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances){
                if (appliance.ItemNumber/100000000 == 2){
                    Vacuum vacuum = (Vacuum) appliance;
                    if ((grade == "Any" || grade == vacuum.Grade) & (voltage == 0 || voltage == vacuum.BatteryVoltage)) foundAppliances.Add(vacuum);
                }
            }
            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// Displays microwaves
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: \n0 - Any\n1 - Kitchen\n2 - Work site");
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"
            Console.WriteLine("Enter room type: ");
            // Get user input as string and assign to variable
            string? userRoomType = Console.ReadLine();
            // Create character variable that holds room type
            char roomType;
            // Test input is "0"
                // Assign 'A' to room type variable
            // Test input is "1"
                // Assign 'K' to room type variable
            // Test input is "2"
                // Assign 'W' to room type variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method
                // return;
            
            switch (userRoomType){
                case "0": roomType = 'A'; break;
                case "1": roomType = 'K'; break;
                case "2": roomType = 'W'; break;
                default: Console.WriteLine("Invalid option."); return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> foundAppliances = new List<Appliance>();
            // Loop through Appliances
                // Test current appliance is Microwave
                    // Down cast Appliance to Microwave

                    // Test room type equals 'A' or microwave room type
                        // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances){
                    if (appliance.ItemNumber/100000000 == 3){
                        Microwave microwave = (Microwave) appliance;
                        if (roomType == 'A' || roomType == microwave.RoomType) foundAppliances.Add(microwave);
                    }
                }
            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// Displays dishwashers
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: \n0 - Any\n1 - Quietest\n2 - Quieter\n3 - Quiet\n4 - Moderate");
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"
            Console.WriteLine("Enter sound rating: ");
            // Get user input as string and assign to variable
            string? userSoundRating = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRating;
            switch (userSoundRating){
                case "0": soundRating = "Any"; break;
                case "1": soundRating = "Qt"; break;
                case "2": soundRating = "Qr"; break;
                case "3": soundRating = "Qu"; break;
                case "4": soundRating = "M"; break;
                default: Console.WriteLine("Invalid option."); return;
            }
            // Test input is "0"
                // Assign "Any" to sound rating variable
            // Test input is "1"
                // Assign "Qt" to sound rating variable
            // Test input is "2"
                // Assign "Qr" to sound rating variable
            // Test input is "3"
                // Assign "Qu" to sound rating variable
            // Test input is "4"
                // Assign "M" to sound rating variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method

            // Create variable that holds list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();
            // Loop through Appliances
                // Test if current appliance is dishwasher
                    // Down cast current Appliance to Dishwasher

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                        // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances){
                if (appliance.ItemNumber/100000000 == 5 || appliance.ItemNumber/100000000 == 4){
                    Dishwasher dishwasher = (Dishwasher) appliance;
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating) foundAppliances.Add(dishwasher);
                }
            }
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// Generates random list of appliances
        public override void RandomList()
        {
            // Write "Appliance Types"
            Console.WriteLine("Appliance Types");
            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"
            Console.WriteLine("0 - Any\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwashers");
            // Write "Enter type of appliance:"
            Console.WriteLine("Enter type of appliance: ");
            // Get user input as string and assign to appliance type variable
            string? userApplianceType = Console.ReadLine();
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");
            // Get user input as string and assign to variable
            // Convert user input from string to int
            int userNumOfAppliances = Convert.ToInt32(Console.ReadLine());

            // Create variable to hold list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through appliances
                // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                        // Add current appliance in list to found list
                // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                        // Add current appliance in list to found list
                // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                        // Add current appliance in list to found list
                // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                        // Add current appliance in list to found list

            foreach (Appliance appliance in Appliances){
                switch(userApplianceType){
                    case "0": foundAppliances.Add(appliance); break;
                    case "1": if(appliance.ItemNumber/100000000 == 1){foundAppliances.Add(appliance);} break;
                    case "2": if(appliance.ItemNumber/100000000 == 2){foundAppliances.Add(appliance);} break;
                    case "3": if(appliance.ItemNumber/100000000 == 3){foundAppliances.Add(appliance);} break;
                    case "4": if(appliance.ItemNumber/100000000 == 4 ||appliance.ItemNumber/100000000 == 5){foundAppliances.Add(appliance);} break;
                }
            }

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            foundAppliances.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(foundAppliances, userNumOfAppliances);
        }
    }
}
