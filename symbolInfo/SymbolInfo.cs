using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.symbolInfo
{

    public enum AT_MATURE_MODLE // 到期模式
    {
        SYMBOL_EXPIRATION_GTC = 1,//该订单永久有效，直到它被明确取消
        SYMBOL_EXPIRATION_DAY =2, //订单在交易日当天有效
        SYMBOL_EXPIRATION_SPECIFIED =4,//订单中指定的到期时间
        SYMBOL_EXPIRATION_SPECIFIED_DAY = 8,//订单中指定的到期日期

    }


  public  class SymbolInfo
    {
        private MtApi5Client mt { get; }
        public SymbolInfo(string symbolName,MtApi5Client mt)
        {
            this.mt = mt;
            this.symbolName = symbolName.Clone() as string;
            RefreshFix();
           
        }



        private long getInt(ENUM_SYMBOL_INFO_INTEGER e)
        {
            return mt.SymbolInfoInteger(symbolName, e);
        }

        private double getDouble(ENUM_SYMBOL_INFO_DOUBLE e)
        {
            return mt.SymbolInfoDouble(symbolName, e);
        }

        public string symbolName { get; } // 品种名 usdchn
        public long SYMBOL_DIGITS { get; private set; } // 一个品种后面表示的价格位示 0。65414
        public double TRADE_CONTRACT_SIZE { get; private set; } //交易合约大小 就是ipad mt 里看到的10000
        public bool SPREAD_FLOAT { get; private set; } //是不是浮动点

        public long SPREAD { get; private set; } // 相关传播值
        public ENUM_SYMBOL_TRADE_MODE TRADE_MODE { get; private set; }//订单执行类型 ENUM_SYMBOL_TRADE_MODE
        public ENUM_SYMBOL_CALC_MODE TRADE_CALC_MODE { get; private set; }//合约价格计算方式 ENUM_SYMBOL_CALC_MODE
        public long START_TIME { get; private set; } // 交易品种交易开始日期（通常用于期货）
        public long EXPIRATION_TIME { get; private set; } // 交易品种交易结束日期（通常用于期货）

        public ENUM_SYMBOL_TRADE_EXECUTION TRADE_EXEMODE { get; private set; }//订单执行方式 ENUM_SYMBOL_TRADE_EXECUTION

        public long SWAP_MODE { get; private set; } //交易计算模式 	ENUM_SYMBOL_SWAP_MODE
        public long SWAP_ROLLOVER3DAYS { get; private set; }//	 ENUM_DAY_OF_WEEK
        public bool MARGIN_HEDGED_USE_LEG { get; private set; } // 计算锁仓预付款只收取单边交易手数大的（买入或卖出）
        public AT_MATURE_MODLE EXPIRATION_MODE { get; private set; } //	 到期模式 允许命令标志
        public ENUM_ORDER_TYPE_FILLING FILLING_MODE { get; private set; } // 允许的标识 订单类型
        public ENUM_ORDER_TYPE ORDER_MODE { get; private set; }//允许的标识 订单类型
        public ENUM_SYMBOL_ORDER_GTC_MODE ORDER_GTC_MODE { get; private set; }//止损和盈利订单到期模式，如果SYMBOL_EXPIRATION_MODE=SYMBOL_EXPIRATION_GTC（有效直至被取消）	ENUM_SYMBOL_ORDER_GTC_MODE
        public ENUM_SYMBOL_OPTION_MODE OPTION_MODE { get; private set; } // 期权类型
        public ENUM_SYMBOL_OPTION_RIGHT OPTION_RIGHT { get; private set; } //期权权限(看涨/看跌)
        private void RefreshFix()
        {
            SYMBOL_DIGITS = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_DIGITS);
            TRADE_CONTRACT_SIZE = getDouble(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_CONTRACT_SIZE);
            SPREAD_FLOAT = (getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SPREAD_FLOAT) == 1);
            if (SPREAD_FLOAT)
            {
                SPREAD = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SPREAD);
            }
            else
            {
                SPREAD = -1;
            }

            TRADE_MODE =(ENUM_SYMBOL_TRADE_MODE) getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TRADE_MODE) ;
            TRADE_CALC_MODE = (ENUM_SYMBOL_CALC_MODE)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TRADE_CALC_MODE);
            START_TIME = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_START_TIME);
            EXPIRATION_TIME = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_EXPIRATION_TIME);
            TRADE_EXEMODE = (ENUM_SYMBOL_TRADE_EXECUTION)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TRADE_EXEMODE);
            SWAP_MODE = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SWAP_MODE);
            SWAP_ROLLOVER3DAYS = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SWAP_ROLLOVER3DAYS);
            MARGIN_HEDGED_USE_LEG = getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_MARGIN_HEDGED_USE_LEG) == 1;
            EXPIRATION_MODE =(AT_MATURE_MODLE) getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_EXPIRATION_MODE);
            FILLING_MODE = (ENUM_ORDER_TYPE_FILLING)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_FILLING_MODE);
            ORDER_MODE =(ENUM_ORDER_TYPE) getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_ORDER_MODE);
            ORDER_GTC_MODE = (ENUM_SYMBOL_ORDER_GTC_MODE)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_ORDER_GTC_MODE);
            OPTION_MODE = (ENUM_SYMBOL_OPTION_MODE)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_OPTION_MODE);
            OPTION_RIGHT = (ENUM_SYMBOL_OPTION_RIGHT)getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_OPTION_RIGHT);
        }






        public long SESSION_DEALS { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SESSION_DEALS); } }//当前时期的交易数量
        public long SESSION_BUY_ORDERS { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SESSION_BUY_ORDERS); } }//	当时的买入订单数量
        public long SESSION_SELL_ORDERS { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SESSION_SELL_ORDERS); } } //当时的卖出订单数量
        public long SYMBOL_VOLUME { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_VOLUME); } }//最后订单成交量
        public long VOLUMEHIGH { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_VOLUMEHIGH); } }//当天最大订单

        public long VOLUMELOW { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_VOLUMELOW); } } //当天最小订单
        public long TIME { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TIME); } } // 最后报价时间
        public long TICKS_BOOKDEPTH { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TICKS_BOOKDEPTH); } } // 显示在市场深度要求中的最大数量，交易品种无队列要求，值是0

        public long TRADE_STOPS_LEVEL { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TRADE_STOPS_LEVEL); } } // 止蚀盘当前收盘价格的最小空间
        public long TRADE_FREEZE_LEVEL { get { return getInt(ENUM_SYMBOL_INFO_INTEGER.SYMBOL_TRADE_FREEZE_LEVEL); } } //凝结交易操作的距离
        


    }
}
