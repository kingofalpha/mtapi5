using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Position
{
   public class PoisitionInfo
    {
        public PositionDouble doubleInfo { get; }
        public PositionInt intInfo { get; }
        public PositionString stringInfo { get; }

        public PoisitionInfo( MtApi5Client mt,int index)
        {
            doubleInfo = new PositionDouble(mt, index);
            intInfo = new PositionInt(mt, index);
            stringInfo = new PositionString(mt, index);
        }
    }
}
