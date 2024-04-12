using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        public string NamePosition { get; set; }
        public int Salary { get; set; }
    }
}
