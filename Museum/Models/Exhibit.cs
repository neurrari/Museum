using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class Exhibit : IEntity
    {
        public int Id { get; set; }
        public string NameExhibit { get; set; }
        public string Author { get; set; }
        public int DateCreate { get; set; }
        public int IdTechnique { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdStorage { get; set; }
        public int IdReceptionWay { get; set; }
        public int IdTypeOfStoring { get; set; }
    }
}
