using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Group
    {
        public GroupType GroupType { get; set; }
        public int score { get; set; }
        public List<string> GroupMembers { get; set; }
        public List<string> QuidditchPlayers { get; set; }
    }
}
