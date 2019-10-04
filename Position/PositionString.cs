using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Position
{
    
    public class PositionString
    {

        private MtApi5Client mt;
        private int index;

        public string SYMBOL { get; private set; }//交易品种位置
        public string COMMENT { get; private set; }//方位注释
     

        public PositionString(MtApi5Client mt, int index)
        {
            this.mt = mt;
            this.index = index;
            
            RefreshFix();
        }


        private void selectTick()
        {
            mt.PositionSelectByTicket(mt.PositionGetTicket(index));
        }

        private void RefreshFix()
        {
            selectTick();
            SYMBOL = mt.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL);
            COMMENT = mt.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_COMMENT);
        }
    }

    
}
