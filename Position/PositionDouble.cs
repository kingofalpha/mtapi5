using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Position
{
   public class PositionDouble
    {
        private MtApi5Client mt;
        private int index;
        public PositionDouble(MtApi5Client mt, int index)
        {
            this.mt = mt;
            this.index = index;
            RefreshFix();
        }

        private double getDouble(ENUM_POSITION_PROPERTY_DOUBLE e)
        {
           return mt.PositionGetDouble(e);
        }

        private async Task<double> getDoublex(ENUM_POSITION_PROPERTY_DOUBLE e)
        {
            
            return await Task<double>.Run(()=> {
                selectTick();
                return getDouble(e);
            });
        }


        private void selectTick()
        {
            mt.PositionSelectByTicket(mt.PositionGetTicket(index));
        }

        private void RefreshFix()
        {
            selectTick();
            VOLUME = getDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME); 
        }

        public double VOLUME { get; private set; }//方位成交量
        public Task<double> PRICE_OPEN { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN); } }//方位开盘价格
        public Task<double> SL { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SL); } }//开仓止损水平
        public Task<double> TP { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_TP); } }//开仓获利水平

        public Task<double> PRICE_CURRENT { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT); } }//开仓当前价位
        public Task<double> SWAP { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SWAP); } }//积累交换
        public Task<double> PROFIT { get { return getDoublex(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PROFIT); } }//当前利润


    }
}
