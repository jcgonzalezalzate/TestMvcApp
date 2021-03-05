using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMvcApp.Models
{
    [Table("Teacher")]
    public class TeacherViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public DateTime BirthDate { get; set; }

        public int? Age { get; set; }

    }
}
