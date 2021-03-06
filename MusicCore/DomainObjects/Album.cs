﻿using MusicCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCore
{
    public class Album : IPurchasable
    {
        public int id { get; set; }
        public List<int> songIDs { get; set; }

        public String name { get; set; }
        public DateTime? releaseDate { get; set; }
        public String coverImagePath { get; set; }
    }
}
