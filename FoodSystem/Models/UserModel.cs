using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Models
{
    internal class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public static IEnumerable<UserModel> All { get; set; } = new List<UserModel>
        {
            new UserModel
            {
                Id = Guid.NewGuid(),
                Name= "Test",
                Password = "123456"
            },
            new UserModel
            {
                Id = Guid.NewGuid(),
                Name= "NikolayS",
                Password = "123456"
            },
            new UserModel
            {
                Id = Guid.NewGuid(),
                Name= "Светлана",
                Password = "123456"
            }
        };
    }
}
