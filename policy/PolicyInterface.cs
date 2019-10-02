using MtApi5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.policy
{
   public interface PolicyInterface
    {
        void mMtApiClient_QuoteUpdate(  object sender,  Mt5QuoteEventArgs e,  MtApi5Client mt);
        void mMtApiClient_OnTradeTransaction( object sender,  Mt5TradeTransactionEventArgs e,  MtApi5Client  mt);
        void _mtApiClient_OnBookEvent( object sender,  Mt5BookEventArgs e,  MtApi5Client mt);
        void _mtApiClient_OnLastTimeBar( object sender,  Mt5TimeBarArgs e,  MtApi5Client mt);
        void _mtApiClient_OnLockTicks( object sender,  Mt5LockTicksEventArgs e,  MtApi5Client mt);
        void mMtApiClient_QuoteRemoved( object sender,  Mt5QuoteEventArgs e,  MtApi5Client mt);
        void mMtApiClient_QuoteAdded( object sender,  Mt5QuoteEventArgs e,  MtApi5Client mt);
        void mMtApiClient_ConnectionStateChanged( object sender,   Mt5ConnectionEventArgs e,  MtApi5Client mt);
    }
}
