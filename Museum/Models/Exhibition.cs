using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class Exhibition : IEntity
    {
        public int Id { get; set; }
        public string NameExhibition { get; set; }
        public string Arranger { get; set; }
        public DateOnly DateOpen { get; set; }
        public DateOnly DateClose { get; set; }
    }
}
