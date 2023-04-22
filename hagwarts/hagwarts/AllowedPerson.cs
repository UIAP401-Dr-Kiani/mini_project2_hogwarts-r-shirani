using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class AllowedPerson:Person
    {
        public string Curriculum { get; set; }
        public Pet Pet { get; set; }
        public bool Baggage { get; set; }
        public Role Role { get; set; }
        public string ReceivedLetter { get; set; }
        public Group GroupName { get; set; }
    }
}
