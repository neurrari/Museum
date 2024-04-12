using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class MuseumHall : IEntity
    {
        public int Id { get; set; }
        public int AmountOfPlaces { get; set; }
        public int IdEmployee { get; set; }
    }
}
