using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;

namespace ModernAppliances
{
    /// Manager class for Modern Appliances
    /// <remarks>Do not modify this file</remarks>
    /// <remarks>Author: Nick Hamnett (nick.hamnett@sait.ca)</remarks>
    /// <remarks>Date: January 17, 2023</remarks>
    internal abstract class ModernAppliances
    {
        /// Location of appliances.txt file
        public const string APPLIANCES_TEXT_FILE = "appliances.txt";

        /// Options user can choose
        public enum Options
        {
            None,
            Checkout = 1,
            Find = 2,
            DisplayType = 3,
            RandomList = 4,
            SaveExit = 5,
        }

        /// Holds list of appliances
        private List<Appliance> appliances;

        /// Provides immutable list of appliances
        public List<Appliance> Appliances { get { return new List<Appliance>(appliances); } }

        /// Called when ModernAppliances instance is created
        public ModernAppliances() { this.appliances = this.ReadAppliances(); }

        /// Displays menu options
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How May We Assist You ?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
        }

        /// Performs a checkout
        public abstract void Checkout();

        /// Finds an appliance
        public abstract void Find();

        /// Displays appliances with type
        public void DisplayType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance:");

            int applianceTypeNum;
            bool parsedApplianceType = int.TryParse(Console.ReadLine(), out applianceTypeNum);

            if (!parsedApplianceType || applianceTypeNum < 0 || applianceTypeNum > 4)
            {
                Console.WriteLine("Invalid appliance type entered.");
                return;
            }

            switch (applianceTypeNum)
            {
                case 1:
                    {
                        this.DisplayRefrigerators();
                        break;
                    }
                case 2:
                    {
                        this.DisplayVacuums();
                        break;
                    }
                case 3:
                    {
                        this.DisplayMicrowaves();
                        break;
                    }
                case 4:
                    {
                        this.DisplayDishwashers();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid appliance type entered.");
                        break;
                    }
            }
        }

        /// Displays refridgerators
        public abstract void DisplayRefrigerators();

        /// Displays vacuums
        public abstract void DisplayVacuums();

        /// Displays microwaves
        public abstract void DisplayMicrowaves();

        /// Displays dishwashers
        public abstract void DisplayDishwashers();

        /// Generates random list of appliances
        public abstract void RandomList();

        /// Saves appliances to text file
        public void Save()
        {
            Console.Write("Saving... ");
            StreamWriter fileStream = File.CreateText(APPLIANCES_TEXT_FILE);
            foreach (var appliance in appliances) fileStream.WriteLine(appliance.FormatForFile());
            fileStream.Close();
            Console.WriteLine("DONE!");
        }

        /// Reads appliances from text file

        /// <returns>List of appliances</returns>
        private List<Appliance> ReadAppliances()
        {
            List<Appliance> appliances = new List<Appliance>();
            string[] lines = File.ReadAllLines(APPLIANCES_TEXT_FILE);

            foreach (string line in lines)
            {
                Appliance? appliance = this.CreateApplianceFromLine(line);

                if (appliance != null) appliances.Add(appliance);
            }
            return appliances;
        }

        /// Creates appliance object from line
        /// <param name="line">Line to parse</param>
        /// <returns>Appliance object (or null if line is invalid)</returns>
        private Appliance? CreateApplianceFromLine(string line)
        {
            string[] parts = line.Split(';');

            string firstDigitStr = line.Substring(0, 1);
            short firstDigit = short.Parse(firstDigitStr);

            Appliance? appliance;

            if (firstDigit == 1)
            {
                // Refrigerator
                appliance = CreateRefrigeratorFromParts(parts);
            }
            else if (firstDigit == 2)
            {
                // Vacuum
                appliance = CreateVacuumFromParts(parts);
            } 
            else if (firstDigit == 3)
            {
                // Microwave
                appliance = CreateMicrowaveFromParts(parts);
            } 
            else if (firstDigit == 4 || firstDigit == 5)
            {
                // Dishwasher
                appliance = CreateDishwasherFromParts(parts);
            }
            else
            {
                appliance = null;
            }

            return appliance;
        }

        /// <summary>
        /// Creates Refrigerator object from parts
        /// </summary>
        /// <param name="parts">Array of strings containing data to create object from</param>
        /// <returns>Refrigerator object (or null if length of parts is wrong)</returns>
        private Refrigerator? CreateRefrigeratorFromParts(string[] parts)
        {
            if (parts.Length != 9)
                return null;

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            short doors = short.Parse(parts[6]);
            int width = int.Parse(parts[7]);
            int height = int.Parse(parts[8]);

            Refrigerator refrigerator = new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, width, height);

            return refrigerator;
        }

        /// Creates Vacuum object from parts
        /// <param name="parts">Array of strings containing data to create object from</param>
        /// <returns>Vacuum object (or null if length of parts is wrong)</returns>
        private Vacuum? CreateVacuumFromParts(string[] parts)
        {
            if (parts.Length != 8)
                return null;

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            string grade = parts[6];
            short batteryVoltage = short.Parse(parts[7]);

            Vacuum vacuum = new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);

            return vacuum;
        }

        /// Creates Microwave object from parts
        /// <param name="parts">Array of strings containing data to create object from</param>
        /// <returns>Microwave object (or null if length of parts is wrong)</returns>
        private Microwave? CreateMicrowaveFromParts(string[] parts)
        {
            if (parts.Length != 8)
                return null;

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            float capacity = float.Parse(parts[6]);
            char roomType = char.Parse(parts[7]);

            Microwave microwave = new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);

            return microwave;
        }

        /// Creates Dishwasher object from parts
        /// <param name="parts">Array of strings containing data to create object from</param>
        /// <returns>Dishwasher object (or null if length of parts is wrong)</returns>
        private Dishwasher? CreateDishwasherFromParts(string[] parts)
        {
            if (parts.Length != 8)
                return null;

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            string feature = parts[6];
            string soundRating = parts[7];

            Dishwasher dishwasher = new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);

            return dishwasher;
        }

        /// Prints out appliances in list
        /// <param name="appliances">List of appliances</param>
        /// <param name="max">Maximum number of appliances to display (0 is unlimited)</param>
        public void DisplayAppliancesFromList(List<Appliance> appliances, int max)
        {
            if (appliances.Count > 0)
            {
                Console.WriteLine("Found appliances:");
                Console.WriteLine();

                // Display found appliances until either end of list is reached or number of appliances requested is shown.
                for (int i = 0; i < appliances.Count && (max == 0 || i < max); i++)
                {
                    Appliance appliance = appliances[i];
                    Console.WriteLine(appliance);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No appliances found.");
            }
            Console.WriteLine();
        }
    }
}
