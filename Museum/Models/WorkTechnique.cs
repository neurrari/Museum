﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class WorkTechnique : IEntity
    {
        public int Id { get; set; }
        public string NameTechnique { get; set; }
        public string Material { get; set; }
    }
}
