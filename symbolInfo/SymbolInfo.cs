using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.symbolInfo
{
    public class SymbolInfo
    {
        public string symbolNameString { get;  }
        public SymbolInfoInt intSymbolInfo { get; }
        public SymbolInfoString stringSymbolInfo { get; }
        public SymbolInfoDouble doubleSymbolInfo { get; }
        public SymbolInfo(string symbolName, MtApi5Client mt)
        {
            symbolNameString = symbolName.Clone() as string;
            intSymbolInfo = new SymbolInfoInt(symbolName, mt);
            stringSymbolInfo = new SymbolInfoString(symbolName, mt);
            doubleSymbolInfo = new SymbolInfoDouble(symbolName, mt);
        }
    }
   
}
