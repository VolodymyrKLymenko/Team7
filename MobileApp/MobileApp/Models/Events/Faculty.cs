using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models.Events
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
