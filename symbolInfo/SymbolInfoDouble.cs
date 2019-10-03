using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.symbolInfo
{
   public class SymbolInfoDouble
    {
        private string SymbolName { get; }
        MtApi5Client mt { get; }
        public SymbolInfoDouble(string symbolName, MtApi5Client mt)
        {
            SymbolName = symbolName.Clone() as string;
            this.mt = mt;
        }

        private double getDouble(ENUM_SYMBOL_INFO_DOUBLE e)
        {
            return mt.SymbolInfoDouble(SymbolName, e);
        }

        private async Task<double> getDoublex(ENUM_SYMBOL_INFO_DOUBLE e)
        {
            return await Task<double>.Run(()=> {
                return getDouble(e);
            });
        }



        public Task<double> BID //	买价―最佳卖出信息
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_BID);
            }
        }

        public Task<double> BIDHIGH //一天中最高买价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_BIDHIGH);
            }
        }

        public Task<double> BIDLOW //一天中最低买价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_BIDLOW);
            }
        }

        public Task<double> ASK //卖价―最佳买入信息
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_ASK);
            }
        }

        public Task<double> ASKHIGH //一天中最高买价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_ASKHIGH);
            }
        }
        public Task<double> ASKLOW //一天中最高买价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_ASKLOW);
            }
        }

        public Task<double> LAST //最后订单价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_LAST);
            }
        }

        public Task<double> LASTHIGH //一天中最高
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_LASTHIGH);
            }
        }

        public Task<double> LASTLOW //一天中最低
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_LASTLOW);
            }
        }

        public Task<double> VOLUME_REAL //最后订单成交量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_REAL);
            }
        }

        public Task<double> VOLUMEHIGH_REAL //当天最大订单
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUMEHIGH_REAL);
            }
        }

        public Task<double> VOLUMELOW_REAL //当天最小订单
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUMELOW_REAL);
            }
        }

        public Task<double> OPTION_STRIKE //期权的执行价。期权买家可以购买（看涨期权）或出售（看跌期权）基础资产的价格，期权卖家有义务出售或购买基础资产的适当数量。
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_OPTION_STRIKE);
            }
        }

        public Task<double> POINT //交易品种点值
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_POINT);
            }
        }
        
        public Task<double> TRADE_TICK_VALUE //SYMBOL_TRADE_TICK_VALUE_PROFIT的值
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_TICK_VALUE);
            }
        }

        public Task<double> TRADE_TICK_VALUE_PROFIT //为盈利持仓计算报价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_TICK_VALUE_PROFIT);
            }
        }

        public Task<double> TRADE_TICK_VALUE_LOSS //为亏损持仓计算报价
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_TICK_VALUE_LOSS);
            }
        }

        public Task<double> TRADE_TICK_SIZE //	最小价格改变
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_TICK_SIZE);
            }
        }

        public Task<double> TRADE_CONTRACT_SIZE //	交易合约大小
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_CONTRACT_SIZE);
            }
        }

        public Task<double> TRADE_ACCRUED_INTEREST //		应计利息– 累积的票面利率，例如，部分票面利率是按照付息债权发行的天数或最后一次支付票面利率的天数来计算的
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_ACCRUED_INTEREST);
            }
        }

        public Task<double> TRADE_FACE_VALUE //	票面价值 – 发行人设置的初始债券价值
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_FACE_VALUE);
            }
        }

        public Task<double> TRADE_LIQUIDITY_RATE //流动性利率是可用于预付款的资产份额。
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_LIQUIDITY_RATE);
            }
        }

        public Task<double> VOLUME_MIN //一笔订单中的最小成交量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_MIN);
            }
        }

        public Task<double> VOLUME_MAX //一笔订单中的最大成交量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_MAX);
            }
        }

        public Task<double> VOLUME_STEP //交易执行的最小成交量更改步骤
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_STEP);
            }
        }

        /*交易品种单向（单买或单卖）持仓和挂单可允许的最大总容量。例如，5手限定范围内，您可以拥有5手买入持仓交易量和下单5手卖出限价挂单交易量。
         * 但是在这种情况下，你不能下单买入限价挂单（因为单向总交易量将会超出限定范围）或下单超过5手的卖出限价交易量。*/
        public Task<double> VOLUME_LIMIT 
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_LIMIT);
            }
        }

        public Task<double> SWAP_LONG//买入库存费值
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SWAP_LONG);
            }
        }

        public Task<double> SWAP_SHORT//卖出库存费值
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SWAP_SHORT);
            }
        }

        public Task<double> MARGIN_INITIAL//原始预付款表示每一笔预付款开仓成交量的数量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_MARGIN_INITIAL);
            }
        }

        /*维持预付款，在交易品种中建立预付款数量，从一笔订单中获得预付款盈利，当客户账户改变时，使用客户资产检测系统
         * ，如果维持预付款等于，使用原始预付款*/
        public Task<double> MARGIN_MAINTENANCE
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_MARGIN_MAINTENANCE);
            }
        }

        public Task<double> SESSION_VOLUME//当前交易的总交易量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_VOLUME);
            }
        }

        public Task<double> SESSION_TURNOVER//当前的总流通量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_TURNOVER);
            }
        }

        public Task<double> SESSION_INTEREST//总持仓利息
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_INTEREST);
            }
        }

        public Task<double> SESSION_ISESSION_BUY_ORDERS_VOLUMENTEREST//买入订单的当前交易量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_BUY_ORDERS_VOLUME);
            }
        }

        public Task<double> SESSION_SELL_ORDERS_VOLUME//卖出订单的当前交易量
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_SELL_ORDERS_VOLUME);
            }
        }

        public Task<double> SESSION_OPEN//当前持仓价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_OPEN);
            }
        }

        public Task<double> SESSION_CLOSE//当前平仓价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_CLOSE);
            }
        }

        public Task<double> SESSION_AW//当前加权平均价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_AW);
            }
        }

        public Task<double> SESSION_PRICE_SETTLEMENT//当前结算价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_PRICE_SETTLEMENT);
            }
        }

        public Task<double> SESSION_PRICE_LIMIT_MIN//当前最低价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_PRICE_LIMIT_MIN);
            }
        }

        public Task<double> SESSION_PRICE_LIMIT_MAX//当前最高价格
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_SESSION_PRICE_LIMIT_MAX);
            }
        }

        /*
         * 	
        锁仓持仓每手的合约大小或预付款值（一个交易品种的反向持仓）。锁仓持仓可以使用两种预付款计算方式。计算方式由交易商定义。

 
    
        基本计算：
        
        如果一个交易品种指定初始预付款(SYMBOL_MARGIN_INITIAL) ，锁仓预付款被指定为一个绝对值（以货币计算）。
        如果没有指定初始预付款（等于0），SYMBOL_MARGIN_HEDGED 则等于合约大小，这将用来通过恰当公式根据金融工具类型计算预付款(SYMBOL_TRADE_CALC_MODE)。
 

        计算最大持仓：

                SYMBOL_MARGIN_HEDGED 值不被考虑。
        计算交易品种所有卖出和买入持仓的交易量。
        对于每个方向，都会计算加权平均开盘价和入金货币的加权平均转化率。
        下一步，使用根据交易品种类型选定的适当公式(SYMBOL_TRADE_CALC_MODE) 计算卖出和买入持仓预付款。
        最大值用作预付款。
         
             */
        public Task<double> MARGIN_HEDGED
        {
            get
            {
                return getDoublex(ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_MARGIN_HEDGED);
            }
        }
    }
}
