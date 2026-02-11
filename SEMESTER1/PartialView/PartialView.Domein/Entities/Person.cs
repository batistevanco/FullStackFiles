using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialView.Domein.Entities
{
    public enum JobType
    {
        Docent,  //0
        Student  //1
    }
    public class Person
    {
        public int Id { get; set; }
        public string? Voornaam { get; set; }
        public string? Naam { get; set; }
        public JobType Job { get; set; }
        public DateTime EnrollDate { get; set; }
        public string? ImagePath { get; set; }
    }
}
