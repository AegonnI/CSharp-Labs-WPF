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
                return new Money((100 * money.rubles + money.kopeks - kopeks) / 100, 
                           (byte)(100 * LabMath.fraction((decimal)(money.rubles * 100 + money.kopeks - kopeks) / 100)));
            }
            return new Money(0, 0);
        }

        public static Money operator -(uint kopeks, Money money)
        {
            if (money.rubles * 100 + money.kopeks < kopeks)
            {
                return new Money((kopeks - 100 * money.rubles + money.kopeks) / 100,
                           (byte)(100 * LabMath.fraction((decimal)(kopeks - 100 * money.rubles + money.kopeks) / 100)));
            }
            return new Money(0, 0);
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (100 * money1.rubles + money1.kopeks > 100 * money2.rubles + money2.kopeks)
            {
                return new Money((100 * (money1.rubles - money2.rubles) + money1.kopeks - money2.kopeks) / 100,
                           (byte)(100 * LabMath.fraction((decimal)(100 * (money1.rubles - money2.rubles) + money1.kopeks - money2.kopeks) / 100)));
            }
            return new Money(0, 0);
        }

        public static Money operator +(Money money, uint kopeks)
        {
            return new Money((100 * money.rubles + money.kopeks + kopeks) / 100,
                       (byte)(100 * LabMath.fraction((decimal)(money.rubles * 100 + money.kopeks + kopeks) / 100)));
        }

        public static Money operator --(Money money)
        {
            return money - 1;
        }

        public static Money operator ++(Money money)
        {
            return money + 1;
        }

        public static explicit operator uint(Money money)
        {
            return money.rubles;
        }

        public static implicit operator bool(Money money)
        {
            return money.rubles != 0 || money.kopeks != 0;
        }
    }
}
