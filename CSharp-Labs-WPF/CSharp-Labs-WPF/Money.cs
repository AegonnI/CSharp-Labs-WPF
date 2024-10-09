using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    internal class Money
    {
        private uint rubles;
        private byte kopeks;

        public Money() // Конструктор по умолчанию
        {
            rubles = 0;
            kopeks = 0;
        }

        public Money(uint rubles, byte kopeks)
        {
            //while (kopeks >= 100)
            //{
            //    rubles++;
            //    kopeks -= 100;
            //}
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        public Money(Money money) // Конструктор копирования
        {
            rubles = money.rubles;
            kopeks = money.kopeks;
        }

        public override string ToString() //перегруженный ToString(), возвращает рубли и копейки
        {
            return $"rubles = {rubles}, kopeks = {kopeks}";
        }

        //перегрузка оператора вычитания, возвращает объект типа Money
        public static Money operator -(Money money, uint kopeks)
        {
            if (100 * money.rubles + money.kopeks > kopeks)
            {
                return new Money((100 * money.rubles + money.kopeks - kopeks) / 100, 
                           (byte)(100 * LabMath.fraction((decimal)(money.rubles * 100 + money.kopeks - kopeks) / 100)));
            }
            return new Money(0, 0);
        }
        public static Money operator -(uint kopeks, Money money)
        {
            if (100 * money.rubles + money.kopeks < kopeks)
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
                return new Money(
                    (100 * (money1.rubles - money2.rubles) + money1.kopeks - money2.kopeks) / 100,
                    (byte)(100 * LabMath.fraction(
                        (decimal)(100 * (money1.rubles - money2.rubles) + money1.kopeks - money2.kopeks) / 100)));
            }
            return new Money(0, 0);
        }

        //перегрузка оператора сложения, возвращает объект типа Money
        public static Money operator +(Money money, uint kopeks)
        {
            return new Money((100 * money.rubles + money.kopeks + kopeks) / 100,
                       (byte)(100 * LabMath.fraction((decimal)(money.rubles * 100 + money.kopeks + kopeks) / 100)));
        }

        //перегрузка унарных операторов -- и ++, возвращает объект типа Money
        public static Money operator --(Money money)
        {
            return money - 1;
        }
        public static Money operator ++(Money money)
        {
            return money + 1;
        }

        
        public static explicit operator uint(Money money) //явное преобразование в тип uint, возвращает рубли
        {
            return money.rubles;
        } 
        public static implicit operator bool(Money money) //неявное преобразование в тип bool, вовзращает true если деньги есть
        {
            return money.rubles != 0 || money.kopeks != 0;
        }

        // Геттеры
        public uint Rubles
        {
            get { return rubles; }
        }

        public byte Kopeks
        {
            get { return kopeks; }
        }
    }
}
