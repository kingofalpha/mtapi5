using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test.policy;

namespace test
{
   public class MTFrame
    {
        private MtApi5Client mt { get; }
        PolicyInterface policyInterface;

        public MTFrame()
        {
            policyInterface = new Policy1();
            mt = new MtApi5Client();
            mt.ConnectionStateChanged += mMtApiClient_ConnectionStateChanged;
            mt.QuoteAdded += mMtApiClient_QuoteAdded;
            mt.QuoteRemoved += mMtApiClient_QuoteRemoved;
            mt.QuoteUpdate += mMtApiClient_QuoteUpdate;
            mt.OnTradeTransaction += mMtApiClient_OnTradeTransaction;
            mt.OnBookEvent += _mtApiClient_OnBookEvent;
            mt.OnLastTimeBar += _mtApiClient_OnLastTimeBar;
            mt.OnLockTicks += _mtApiClient_OnLockTicks;
            mt.BeginConnect("127.0.0.1", 8228);
          
        }

        private void mMtApiClient_ConnectionStateChanged( object sender,   Mt5ConnectionEventArgs e)
        {
            policyInterface.mMtApiClient_ConnectionStateChanged(sender, e, mt);
        }

        private void mMtApiClient_QuoteAdded(object sender, Mt5QuoteEventArgs e)
        {
            policyInterface.mMtApiClient_QuoteAdded(sender, e,  mt);
        }

        private void mMtApiClient_QuoteRemoved(object sender, Mt5QuoteEventArgs e)
        {
            policyInterface.mMtApiClient_QuoteRemoved(sender, e, mt);
        }

        
        private void mMtApiClient_QuoteUpdate(object sender, Mt5QuoteEventArgs e)
        {
            policyInterface.mMtApiClient_QuoteUpdate( sender, e, mt);

        }

        private void mMtApiClient_OnTradeTransaction(object sender, Mt5TradeTransactionEventArgs e)
        {

            policyInterface.mMtApiClient_OnTradeTransaction(sender, e, mt);


        }

        private void _mtApiClient_OnBookEvent(object sender, Mt5BookEventArgs e)
        {
            policyInterface._mtApiClient_OnBookEvent(sender, e, mt);
        }

        private void _mtApiClient_OnLastTimeBar(object sender, Mt5TimeBarArgs e)
        {
            policyInterface._mtApiClient_OnLastTimeBar(sender, e, mt);
        }

        private void _mtApiClient_OnLockTicks(object sender, Mt5LockTicksEventArgs e)
        {
            
        }

    }
}
