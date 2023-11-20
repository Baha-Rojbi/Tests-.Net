﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ApplicationCore.Domain
{
    public class Activite
    {
        public int ActiviteId { get; set; }
        public Zone Zone { get; set; }

        public double Prix { get; set; }
        public String TypeService { get; set; }
        public virtual IList<Pack> Packs { get; set; }
    }
}
