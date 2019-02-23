using MusicCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCore
{
    class Artist : IInformational
    {
        public int id { get; set; }

        public String name { get; set; }
        public String description { get; set; }
        public DateTime startingDate { get; set; }
        public DateTime? endingDate { get; set; }

    }
}
