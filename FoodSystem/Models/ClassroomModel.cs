using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Models
{
    internal class ClassroomModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<ClassroomModel> All { get; set; } = new List<ClassroomModel>
        {
            new ClassroomModel
            {
                Id = Guid.NewGuid(),
                Name= "1А"
            },
            new ClassroomModel
            {
                Id = Guid.NewGuid(),
                Name= "2Б"
            },
            new ClassroomModel
            {
                Id = Guid.NewGuid(),
                Name= "3В"
            }
        };
    }
}
