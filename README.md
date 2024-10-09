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

# Если пользователь успешно ввел значения рублей и копеек

*Вывод:*
![image](https://github.com/user-attachments/assets/e5ba4280-394a-490f-82d6-2da2471ccf0e)


# Если пользователь ввел не корректные значения рублей и копеек

*Вывод:*
![image](https://github.com/user-attachments/assets/a5d1d469-72e1-49d8-8e16-aad8e8e5bf46)

