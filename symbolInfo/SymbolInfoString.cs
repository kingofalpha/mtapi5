using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.symbolInfo
{
    public class SymbolInfoString
    {
        private string SymbolName { get; }
        MtApi5Client mt { get; }
        public SymbolInfoString(string symbolName, MtApi5Client mt)
        {
            SymbolName = symbolName.Clone() as string;
            this.mt = mt;
            RefreshFix();
        }

        private string getString(ENUM_SYMBOL_INFO_STRING e)
        {
            return mt.SymbolInfoString(SymbolName, e);
        }

        public string BASIS { get; private set; }//基础衍生资产

        public string CURRENCY_BASE { get; private set; }//交易品种基础货币
        public string CURRENCY_PROFIT { get; private set; }//利润货币
        public string CURRENCY_MARGIN { get; private set; }//预付款货币
        public string BANK { get; private set; }//当前报价支线
        public string DESCRIPTION { get; private set; }//交易品种描述

        /*用于自定义交易品种定价的公式 。如果公式中使用的交易品种名称以数字开头或包含特殊字符(">" ", ".", "-", "&", "#")，那么应在交易品种名称外使用引号。

        综合交易品种："@ESU19"/EURCAD
        日历点差："Si-9.13"-"Si-6.13"
        欧元指数：34.38805726 * pow(EURUSD,0.3155) * pow(EURGBP,0.3056) * pow(EURJPY,0.1891) * pow(EURCHF,0.1113) * pow(EURSEK,0.0785)*/
        public string FORMULA { get; private set; }

        /*	
        ISIN系统中交易品种的名称（国际证券识别号码）。国际证券识别号码是一个12位数字字母代码，是证券的唯一识别码。
        交易品种的属性是由交易服务器方面决定的 。*/
        public string ISIN { get; private set; }
        public string PAGE { get; private set; }//包含交易品种信息的网页地址。这个地址将显示为一个链接，用于在程序端中查看交易品种的属性

        public string PATH { get; private set; }// 交易品种树形通路
        private void RefreshFix()
        {
            BASIS = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_BASIS);
           
            CURRENCY_BASE = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_CURRENCY_BASE);
            CURRENCY_PROFIT = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_CURRENCY_PROFIT);
            CURRENCY_MARGIN = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_CURRENCY_MARGIN);
            BANK = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_BANK);
            DESCRIPTION = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_DESCRIPTION);
            FORMULA = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_FORMULA);
            ISIN = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_ISIN);
            PAGE = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_PAGE);
            PATH = getString(ENUM_SYMBOL_INFO_STRING.SYMBOL_PATH);
        }

       
    }
}
