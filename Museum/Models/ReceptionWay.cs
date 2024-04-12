using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class ReceptionWay : IEntity
    {
        public int Id { get; set; }
        public string NameReceptionWay { get; set; }
    }
}
