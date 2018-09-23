using System;

namespace Fakturownik.Logic
{
    internal class CurrencyManager
    {
        internal static decimal GetRate(Currency currency)
        {
            if (currency == Currency.PLN) return 1.0m;
            if (currency == Currency.EUR) return 4.1m;
            return 0.0m;
        }
    }
}