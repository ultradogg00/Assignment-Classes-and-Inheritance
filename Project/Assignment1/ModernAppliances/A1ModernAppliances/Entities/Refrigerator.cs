using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities
{
    /// <summary>
    /// Represents a refrigerator
    /// </summary>
    internal class Refrigerator : Appliance
    {
        /// Field that holds number of fridge doors
        private readonly short _doors;
        
        /// Width of fridge
        private readonly int _width;
        
        /// Height of fridge
        private readonly int _height;

        /// Property for doors
        public short Doors { get { return _doors; } }

        /// Property for width
        public int Width { get { return _width; } }

        /// Property for height
        public int Height { get { return _height; } }

        /// Constructs Refrigerator object
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="doors">Number of doors</param>
        /// <param name="width">Fridge width</param>
        /// <param name="height">Fridge height</param>
        public Refrigerator(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, short doors, int width, int height) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._doors = doors;
            this._width = width;
            this._height = height;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Doors, Width, Height);

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
                string.Format("Doors: {0}", Doors) + "\n" +
                string.Format("Width: {0}", Width) + "\n" +
                string.Format("Height: {0}", Height);

                return display;
        }
    }
}
