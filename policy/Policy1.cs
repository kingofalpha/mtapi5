using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtApi5;
using test.policy;
using test.symbolInfo;

namespace test
{
    public class Policy1 :PolicyInterface
    {
        private Dictionary<string, Mt5Quote> mapQuotes = new Dictionary<string, Mt5Quote>();
        private Dictionary<string, List<Mt5Quote>> mapHistoryQuotes = new Dictionary<string, List<Mt5Quote>>();

        private const int listHistoryQuotesMinSize = 200;

        SymbolInfo s = null;

        public void mMtApiClient_QuoteUpdate( object sender,  Mt5QuoteEventArgs e,  MtApi5Client mt)
        {

          
           

            if (!mapHistoryQuotes.Keys.Contains(e.Quote.Instrument))
            {
                mapHistoryQuotes.Add(e.Quote.Instrument, new List<Mt5Quote>());
               
            }
            mapHistoryQuotes[e.Quote.Instrument].Add(e.Quote);

            var dig = mt.SymbolInfoInteger(e.Quote.Instrument, ENUM_SYMBOL_INFO_INTEGER.SYMBOL_SPREAD_FLOAT);
            if (null == s) {
                 s  = new SymbolInfo(e.Quote.Instrument, mt);
            }


            Console.WriteLine(s.stringSymbolInfo.PAGE);


        }

        public void mMtApiClient_OnTradeTransaction( object sender,   Mt5TradeTransactionEventArgs e,  MtApi5Client mt)
        {
            
        }

        public void _mtApiClient_OnBookEvent( object sender,   Mt5BookEventArgs e,  MtApi5Client mt)
        {
           
        }

        public void _mtApiClient_OnLastTimeBar( object sender,  Mt5TimeBarArgs e,  MtApi5Client mt)
        {
            
        }

        public void _mtApiClient_OnLockTicks( object sender,   Mt5LockTicksEventArgs e,  MtApi5Client mt)
        {
           
        }

        public void mMtApiClient_QuoteRemoved(object sender, Mt5QuoteEventArgs e, MtApi5Client mt)
        {
            if (mapQuotes.Keys.Contains(e.Quote.Instrument))
            {
                mapQuotes.Remove(e.Quote.Instrument);
            }
        }

        public void mMtApiClient_QuoteAdded( object sender,  Mt5QuoteEventArgs e,  MtApi5Client mt)
        {
           
        }

        public void mMtApiClient_ConnectionStateChanged( object sender,   Mt5ConnectionEventArgs e,   MtApi5Client mt)
        {
            if(mt.ConnectionState == Mt5ConnectionState.Connected)
            {
                
            }
        }

       
    }
}
