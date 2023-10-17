using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Models
{
    internal class PriceModel
    {
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
        public static IEnumerable<PriceModel> All { get; } = new List<PriceModel>()
        {
            new PriceModel()
            {
                Time = new DateTime(2023,1,1),
                Price = 150
            },
            new PriceModel()
            {
                Time = new DateTime(2023,1,2),
                Price = 120
            },
            new PriceModel()
            {
                Time = new DateTime(2023,1,3),
                Price = 90
            },
            new PriceModel()
            {
                Time = new DateTime(2023,2,1),
                Price = 90
            },
            new PriceModel()
            {
                Time = new DateTime(2023,2,2),
                Price = 150
            }
        };
    }
}
