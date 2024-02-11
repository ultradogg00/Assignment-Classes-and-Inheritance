using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities
{
    /// Represents a Vacuum
    internal class Vacuum : Appliance
    {
        /// Field for vacuum grade
        private readonly string _grade;

        /// Field for vacuum battery voltage
        private readonly short _batteryVoltage;

        /// Property for vacuum grade
        public string Grade { get { return _grade; } }

        /// Property for vacuum battery voltage
        public short BatteryVoltage { get { return _batteryVoltage; } }

        /// Constructs Vacuum object
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="grade">Vacuum grade</param>
        /// <param name="batteryVoltage">Battery voltage</param>
        public Vacuum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._grade = grade;
            this._batteryVoltage = batteryVoltage;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Grade, BatteryVoltage);

            return formatted;
        }

        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Grade: {0}", Grade) + "\n" +
                string.Format("Battery Voltage: {0}", BatteryVoltage);

            return display;
        }
    }
}
