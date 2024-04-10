using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Interfaces
{
    public interface IMine
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
