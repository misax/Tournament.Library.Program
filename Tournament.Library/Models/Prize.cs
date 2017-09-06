using System.ComponentModel;

namespace Tournament.Library.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public Prize()
        {
        }

        public Prize(string placeN, string placeNum, string prize, string persentage)
        {
            PlaceName = placeN;
            int placeNumer = 0;

            int.TryParse(placeNum, out placeNumer);
            PlaceNumber = placeNumer;

            decimal prizeValue = 0;
            decimal.TryParse(prize, out prizeValue);
            PrizeAmount = prizeValue;

            double pesentageValue = 0;
            double.TryParse(persentage, out pesentageValue);
            PrizePercentage = pesentageValue;
        }
    }
}