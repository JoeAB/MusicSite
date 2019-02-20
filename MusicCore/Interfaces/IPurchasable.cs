using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCore.Interfaces
{
    public interface IPurchasable
    {
        Decimal price
        {
            get;
            set;
        }
    }
}
