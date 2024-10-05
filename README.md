# ООП. Лабораторная работа №3. перегрузка операций, вариант 13
## Постановка задачи
Задание 1. Реализовать определение класса (поля, свойства,
конструкторы, перегрузка метода ToString() для вывода полей, заданный
метод согласно варианту). Протестировать все методы, включая
конструкторы, не забывайте проверять вводимые пользователем данные
на корректность!

Задание 2. Добавить к реализованному в первом задании классу
указанные в варианте перегруженные операции. Протестировать все
методы

## Класс Money
## Поля
Класс содержит поля:
```c#
private uint rubles;
private byte kopeks;
```

## Конструкторы
Конструктор **по умолчанию** инициализирует пустой кошелек:

```c#
public Money() // Конструктор по умолчанию
{
    rubles = 0;
    kopeks = 0;
}
```

Конструктор **с параметрами** инициализирует кошелек с переданными значениями:

```c#
public Money(uint rubles, byte kopeks)
{
    this.rubles = rubles;
    this.kopeks = kopeks;
}
```

**конструктор копирования**:

```c#
public Money(Money money) // Конструктор копирования
{
    rubles = money.rubles;
    kopeks = money.kopeks;
}
```

## Методы

Ниже преставлены реализованные **методы** класса **Money**:

```c#
public override string ToString() {...}; //перегруженный ToString(), возвращает рубли и копейки

//перегрузка оператора вычитания, возвращает объект типа Money
public static Money operator -(Money money, uint kopeks) {...};
public static Money operator -(uint kopeks, Money money) {...};
public static Money operator -(Money money1, Money money2) {...};

//перегрузка оператора сложения, возвращает объект типа Money
public static Money operator +(Money money, uint kopeks) {...};

//перегрузка унарных операторов -- и ++, возвращает объект типа Money
public static Money operator --(Money money) {...};
public static Money operator ++(Money money) {...};

public static Money operator --(Money money) {...}; //явное преобразование в тип uint, возвращает рубли
public static Money operator ++(Money money) {...}; //неявное преобразование в тип bool, вовзращает true если деньги есть

// Геттеры
public uint Rubles {...};
public byte Kopeks {...};
```

## Тесты
# Если пользователь успешно ввел значение рублей и копеек, то продолжаем, иначе выдаем сообщение о некорректном вводе
```c#
Money money = new Money(uint.Parse(userValue1.Text), byte.Parse(userValue2.Text)); //создаем объект класса Money со значениями введеными пользователем
resultLabel.Content = "ToString: " + money.ToString(); //вывод денег на экран

// выводим все перегрузки
resultLabel.Content += "\noverload '+': " + (money + uint.Parse(userValue3.Text)).ToString();
resultLabel.Content += "\noverload '-' (Money - m): " + (money - uint.Parse(userValue3.Text)).ToString();
resultLabel.Content += "\noverload '-' (m - Money): " + (uint.Parse(userValue3.Text) - money).ToString();
{
    Random rand = new Random();
    Money money2 = new Money((uint)rand.Next(0, 100), (byte)rand.Next(0, 99));
    resultLabel.Content += $"\noverload '-' (Money1 - Money2({money2.Rubles}, {money2.Kopeks})): " + (money - money2).ToString();
}                        
resultLabel.Content += "\noverload '++': " + (++money).ToString();
resultLabel.Content += "\noverload '--': " + (--money).ToString();
resultLabel.Content += "\nexplicit uint: " + ((uint)money).ToString();
resultLabel.Content += "\nimplicit bool: " + (money == true).ToString();
```

*Вывод:*
![image](https://github.com/user-attachments/assets/41497791-dab3-48e2-8ea5-46e34eacb4ad)
