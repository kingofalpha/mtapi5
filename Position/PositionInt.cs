using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Position
{
   public class PositionInt
    {
        private MtApi5Client mt;
        private int index;

        private void selectTick()
        {
            mt.PositionSelectByTicket(mt.PositionGetTicket(index));
        }
        /*持仓价格。每个新持仓分配唯一的号码通常用于持仓的订单价格是匹配的，除非由于服务器的服务操作而导致价格发生变化，例如，收取重新持仓的库存费时。若要寻找用于持仓的订单，应用POSITION_IDENTIFIER 属性。

         POSITION_TICKET 值相对应MqlTradeRequest::position。*/
        public long TICKET { get; private set; } 
        public long TIME { get; private set; }//开盘时间位置
        public Task<long> TIME_MSC { get { return  getIntx(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_MSC); } } // 以毫秒为单位计算01.01.1970以来持仓的时间
        public Task<long> TIME_UPDATE { get { return getIntx(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE); } }//以秒为单位计算01.01.1970以来持仓更改的时间
        public Task<long> TIME_UPDATE_MSC { get { return getIntx(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_UPDATE_MSC); } }//以毫秒为单位计算01.01.1970以来持仓更改的时间
        public ENUM_POSITION_TYPE TYPE { get; private set; } // 位置类型
        public long MAGIC { get; private set; } // 位置幻数（参看 ORDER_MAGIC ）
        
        /*位置标识符是独一的数字，对于每个新的开仓位来说是制定的且在整个使用期内是不可更改的，翻转位置不能改变它的标识符。
            每个订单(ORDER_POSITION_ID)和每笔交易(DEAL_POSITION_ID) 都会指定用来打开、更改或关闭它的持仓识别器。使用这个属性来搜索持仓相关的订单和交易。
            当单边模式下逆转持仓（使用单进/单出交易）时，POSITION_IDENTIFIER不会改变。但是，POSITION_TICKET会被替换为导致逆转的订单单号。而在锁仓模式下不提供逆转持仓*/
        public long IDENTIFIER { get; private set; }
        public ENUM_POSITION_REASON REASON { get; private set; }//持仓理由

        private long getInt(ENUM_POSITION_PROPERTY_INTEGER e)
        {
            return mt.PositionGetInteger(e);
        }

        private async Task<long> getIntx(ENUM_POSITION_PROPERTY_INTEGER e)
        {
            
            return await Task<long>.Run(()=> {
                selectTick();
                return getInt(e);
            });
        }

        public PositionInt(MtApi5Client mt,int index)
        {
            this.mt = mt;
            this.index = index;
            
            RefreshFix();
        }


        private void RefreshFix()
        {
            selectTick();
            TICKET = getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TICKET);
            TIME = getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME);
            TYPE = (ENUM_POSITION_TYPE)getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE);
            MAGIC = getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_MAGIC);
            IDENTIFIER = getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_IDENTIFIER);
            REASON = (ENUM_POSITION_REASON)getInt(ENUM_POSITION_PROPERTY_INTEGER.POSITION_REASON);
            
        }



    }
}
