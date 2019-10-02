using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.symbolInfo
{
  public  class SymbolInfo
    {
        private MtApi5Client mt { get; }
        public SymbolInfo(string symbolName,MtApi5Client mt)
        {
            this.mt = mt;
            this.symbolName = symbolName.Clone() as string;
            RefreshFix();
           
        }
        public string symbolName { get; } // 品种名 usdchn
        public long SYMBOL_DIGITS { get; private set; } // 一个品种后面表示的价格位示 0。65414
        public double TRADE_CONTRACT_SIZE { get; private set; } //交易合约大小 就是ipad mt 里看到的10000
        public bool SPREAD_FLOAT { get; private set; } //是不是浮动点

        public int SPREAD { get; private set; } // 相关传播值

        public void RefreshFix()
        {
            SYMBOL_DIGITS = mt.SymbolInfoInteger(symbolName, ENUM_SYMBOL_INFO_INTEGER.SYMBOL_DIGITS);
            TRADE_CONTRACT_SIZE = mt.SymbolInfoDouble(symbolName, ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_CONTRACT_SIZE);
            SPREAD_FLOAT = (mt.SymbolInfoInteger(symbolName, ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SPREAD_FLOAT) == 1);

        }

    }
}
