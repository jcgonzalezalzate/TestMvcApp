using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestMvcApp.Models
{
    [Table("Student")]
    public class StudentsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
