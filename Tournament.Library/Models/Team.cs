using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Library.Models;

namespace Tournament.Library.Models
{
    public class Team
    {
        public int Id { get; set; }
        public List<Person> TeamMembers { get; set; } = new List<Person>();
        public  string TeamName { get; set; }
    }
}
