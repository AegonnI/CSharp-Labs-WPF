using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    internal class Money
    {
        uint rubles;
        byte kopeks;

        public Money()
        {
            rubles = 0;
            kopeks = 0;
        }

        public Money(uint rubles, byte kopeks)
        {
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        public Money(Money money)
        {
            rubles = money.rubles;
            kopeks = money.kopeks;
        }

        public override string ToString()
        {
            return $"rubles = {rubles}, kopeks = {kopeks}";
        }

        public static Money operator -(Money money, uint kopeks)
        {
            if (money.rubles * 100 + money.kopeks > kopeks)
            {
                double d = (money.rubles * 100 + money.kopeks - kopeks) / 100;
                return new Money((uint)Math.Floor(d), (byte)(d - Math.Floor(d)));
            }
            return new Money(money.rubles, money.kopeks);
        }
    }
}
