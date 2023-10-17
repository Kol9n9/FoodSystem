using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSystem.Models
{
    internal class StudentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ClassroomModel Classroom { get; set; }

        public static IEnumerable<StudentModel> All { get; set; } = new List<StudentModel>
        {
            new StudentModel
            {
                Id = Guid.NewGuid(),
                Name= "Иванов",
                Classroom = ClassroomModel.All.ToList()[0]
            },
            new StudentModel
            {
                Id = Guid.NewGuid(),
                Name= "Петров",
                 Classroom = ClassroomModel.All.ToList()[0]
            },
            new StudentModel
            {
                Id = Guid.NewGuid(),
                Name= "Сидоров",
                Classroom = ClassroomModel.All.ToList()[1]
            }
        };
    }
}
