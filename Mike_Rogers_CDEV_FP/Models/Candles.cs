using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Mike_Rogers_CDEV_FP.Models
{
    public class Candles
    {
        public int Id { get; set; }
        
        [Required]
        [Candles_EnsureCorrectType]
        public string? Type { get; set; }

        [Required]
        public int? Size { get; set; }

        [Required]
        public string? Scent { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public double? Price { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var candleJson = File.ReadAllText("CandleDB.json");

            Candles? candles = JsonSerializer.Deserialize<Candles>(candleJson);
            
        }
    }


}
