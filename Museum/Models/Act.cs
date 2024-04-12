using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class Act : IEntity
    {
        public int Id { get; set; }
        public DateOnly DateIssuing { get; set; }
        public DateOnly DateAccepting { get; set; }
        public int IdExhibit { get; set; }
        public int IdExhibition { get; set; }
    }
}
