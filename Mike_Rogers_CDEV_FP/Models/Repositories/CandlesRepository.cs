using System.Security.Cryptography.X509Certificates;

namespace Mike_Rogers_CDEV_FP.Models.Repositories
{
    public class CandlesRepository
    {
        private static List<Candles> candles = new List<Candles>()
        {
            new Candles{Id=1, Type="Jar", Size=6, Scent="Vanilla", Color="Ivory", Price=15.00},
            new Candles{Id=2, Type="Jar", Size=10, Scent="Lavandar", Color="Purple", Price=18.00},
            new Candles{Id=3, Type="Jar", Size=12, Scent="Baby Powder", Color="Blue", Price=21.00},
            new Candles{Id=4, Type="Pillar", Size=8, Scent="Vanilla", Color="Ivory", Price=10.00},
            new Candles{Id=5, Type="Pillar", Size=8, Scent="Lavandar", Color="Purple", Price=13.00},
            new Candles{Id=6, Type="Pillar", Size=4, Scent="Baby Powder", Color="Blue", Price=16.00}
        };

        public static List<Candles> GetCandles() 
        { 
            return candles; 
        }

        public static bool CandlesExists(int id) 
        { 
            return candles.Any(x => x.Id == id);
        }

        public static Candles? GetCandlesById(int id)
        {
            return candles.FirstOrDefault(x => x.Id == id);
        }

        public static Candles? GetCandlesByProperties(string? type, int? size, string? scent, string? color, double? price) 
        {
            return candles.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(type) &&
            !string.IsNullOrWhiteSpace(x.Type) &&
            x.Type.Equals(type, StringComparison.OrdinalIgnoreCase) &&

            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value &&

            !string.IsNullOrWhiteSpace(scent) &&
            !string.IsNullOrWhiteSpace(x.Scent) &&
            x.Scent.Equals(scent, StringComparison.OrdinalIgnoreCase) &&

            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            
            price.HasValue &&
            x.Price.HasValue &&
            price.Value == x.Price.Value);

        }
        public static void AddCandle(Candles candle) 
        {
            int maxId = candles.Max(x => x.Id);
            candle.Id = maxId + 1;
            candles.Add(candle);
        }

        public static void UpdateCandles(Candles candle) 
        {
            var candleToUpdate = candles.First(x => x.Id == candle.Id);
            candleToUpdate.Type = candle.Type;
            candleToUpdate.Size = candle.Size;
            candleToUpdate.Scent = candle.Scent;
            candleToUpdate.Color = candle.Color;
            candleToUpdate.Price = candle.Price;
        }

        public static void DeleteCandle(int Id)
        {
            var candle = GetCandlesById(Id);

            if (candle != null)
            {
                candles.Remove(candle);
            }
        }
    }
}
