using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Position
{
   public class MangerPosition
    {
        Dictionary<ulong, PoisitionInfo> positions = new Dictionary<ulong, PoisitionInfo>();
        public MangerPosition(MtApi5Client mt)
        {
            int totalPostions = mt.PositionsTotal();
            for(int i =0; i < totalPostions; i++)
            {
                ulong tick = mt.PositionGetTicket(i);
                positions.Add(tick, new PoisitionInfo(mt, i));
            }
        }
    }
}
