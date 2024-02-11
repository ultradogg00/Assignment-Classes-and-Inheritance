using ModernAppliances.Entities.Abstract;

namespace ModernAppliances.Entities
{
    internal class Dishwasher : Appliance
    {
        /// Constant for quietest sound rating
        public const string SoundRatingQuietest = "Qt";

        /// Constant for quieter sound rating
        public const string SoundRatingQuieter = "Qr";

        /// Constant for quiet sound rating
        public const string SoundRatingQuiet = "Qu";

        /// Constant for moderate sound rating
        public const string SoundRatingModerate = "M";

        /// Field that holds feature
        private string _feature;
        
        /// Field that holds sound rating
        private string _soundRating;

        /// Property for feature
        public string Feature { get { return _feature; } }

        /// Property for sound rating
        public string SoundRating { get { return _soundRating; } }

        /// Property getter for sound rating
        public string SoundRatingDisplay
        {
            get
            {
                switch (_soundRating)
                {
                    case SoundRatingQuietest:
                        return "Quietest";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingModerate:
                        return "Moderate";
                    default:
                        return "(Unknown)";
                }
            }
        }

        /// Constructs Dishwasher instance
        /// <param name="itemNumber">Item number</param>
        /// <param name="brand">Brand</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="wattage">Wattage</param>
        /// <param name="color">Color</param>
        /// <param name="price">Price</param>
        /// <param name="feature">Feature</param>
        /// <param name="soundRating">Sound rating</param>
        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._feature = feature;
            this._soundRating = soundRating;
        }

        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(';', commonFormatted, Feature, SoundRating);

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
                string.Format("Feature: {0}", Feature) + "\n" +
                string.Format("Sound Rating: {0}", SoundRatingDisplay);

            return display;
        }
    }
}
