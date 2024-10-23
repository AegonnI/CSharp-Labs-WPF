# ООП. Лабораторная работа №4. Массивы И Файлы
# Часть 1: Матрицы
Задания 1, 2 и 3 выполнить в виде методов одного класса.
Задание 1 реализовать в виде конструкторов (кроме них, могут быть и другие конструкторы). Класс
содержит единственное поле – двумерный массив.
В задании 3 перегрузить необходимые операторы и посчитать значение матричного выражения
(решение без перегрузки не принимается). Перегрузить метод ToString() — сформировать строку из
двумерного массива для отображения его на экране в виде таблицы. Приложить в отчет скриншот
проверки на онлайн-калькуляторе, чтобы показать, что выражение посчитано верно. 

Задание 1. Заполнение двумерных массивов
Первый массив, размерностью n х m, заполняется данными, вводимыми с клавиатуры, так что
заполнение ведется по диагоналям параллельным главной, начиная с левого нижнего угла.
Второй массив, размерностью n х n, заполняется случайными числами так, что в каждой строке
получается убывающая последовательность элементов.
Третий массив, размерностью n х n, заполняется для произвольного n так же, как для n=5:

<p align="center">
  <img src="https://github.com/user-attachments/assets/3f629f98-2f31-4951-90d1-4a37c0b36950" />
</p>

Задание 2. Работа с двумерными массивами
В двумерном массиве содержатся результаты двух голосований п депутатов. При голосовании
требовалось ответить "Да" или "Нет". Подсчитайте каких депутатов больше: тех, кто оба раза
проголосовал одинаково, или тех кто изменил свое решение.

Задание 3. Работа с двумерными массивами как с матрицами
A^т+B-3*C

## Класс Matrix
## Поля
Класс содержит единственное поле – двумерный массив:
```c#
private int[,] matrix;
```

## Конструкторы
Конструктор **по умолчанию** инициализирует матрицу с 0 измерениями:

```c#
public Matrix() // Конструктор по умолчанию
{
    matrix = new int[0,0];
}
```

**конструктор копирования**:

```c#
public Matrix(Matrix M) // Конструтор копирования
{
    matrix = M.matrix;
}
```

**конструтор принимающий матрицу**:

```c#
public Matrix(int[,] M) // Конструтор для присваивания двумерного массива сразу
{
    matrix = M;
}
```

**конструтор ручного ввода**: Первый массив, размерностью n х m, заполняется данными, вводимыми с клавиатуры, так что
заполнение ведется по диагоналям параллельным главной, начиная с левого нижнего угла.

```c#
public Matrix(int n, int m, int[] arr) // конструтор для ручного ввода
{
    if (arr == null) throw new ArgumentNullException();
    if (n <= 0 || m <= 0) throw new Exception("Uncorrect Dimensions");
    if (arr.Length != n*m) throw new Exception("Array Length must be n*m");

    matrix = new int[n, m];

    int i = n - 1, j = 0;
    int si = i, sj = j;
    for (int k = 0; k < arr.Length; k++)
    {
        matrix[i, j] = arr[k];
        if (i + 1 >= n || j + 1 >= m)
        {
            if (si > 0) si--;
            else sj++;
            i = si; j = sj;
        }
        else 
        {
            i++; j++;
        }        
    }
}
```

**Конструтор если известно лишь количество столбцов**: Используется во втором задании

```c#
public Matrix(int[] arr, int m) // Конструтор если известно лишь количество столбцов 
{
    if (arr == null) throw new ArgumentNullException();
    if (m <= 0) throw new Exception();

    matrix = new int[arr.Length/m, m];
    for (int i = 0, k = 0; i < arr.Length / m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            matrix[i, j] = arr[k++];
        }
    }
}
```

**Конструтор для генерации рандомной матрицы**: Второй массив, размерностью n х n, заполняется случайными числами так, что в каждой строке
получается убывающая последовательность элементов.

```c#
public Matrix(int n, int maxValue, int minValue = 0) // Конструтор для генерации рандомной матрицы
{
    if (minValue > maxValue) throw new ArgumentException();
    if (maxValue - minValue + 1 < n) throw new ArgumentException();

    matrix = new int[n, n];
    Random rand = new Random();

    for (int i = 0; i < n; i++)
    {
        matrix[i, 0] = rand.Next(minValue + n - 1, maxValue);
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 1; j < n; j++)
        {
            matrix[i, j] = rand.Next(minValue + n - j - 1, matrix[i, j - 1]);
        }
    }
}
```

**Конструтор для спиральной матрицы**:

```c#    
public Matrix(int n) // Конструтор для спиральной матрицы
{
    matrix = new int[n, n];

    int x = 0, y = 0;
    int dx = 0, dy = 1;
    for (int i = 1; i < n * n + 1; i++)
    {
        matrix[y, x] = i;
        if (x + dx >= n || x + dx < 0 || y + dy >= n || y + dy < 0 || matrix[y + dy, x + dx] != 0)
        {
            (dx, dy) = (dy, -dx);
        }
        x += dx; y += dy;
    }
}
```

## Методы

Ниже преставлены реализованные **методы** класса **Matrix**:

```c#
public static string WhichDeputiesHaveMore(Matrix VotesOfDeputaties) {...}

public static Matrix Transpose(Matrix M) {...}

// Перегрузки операторов
public static Matrix operator +(Matrix A, Matrix B) {...}
public static Matrix operator -(Matrix A, Matrix B) {...}
public static Matrix operator *(int a, Matrix A) {...}

// Метод чтобы выводить любое количество матриц
public static string MatrixOutput(string[] names, params Matrix[] M) {...}

public override string ToString() {...}

// Геттер
public int[,] GetMatrix
```

## Тесты заданий 1, 3

# Пользователь успешно ввел значения для матрицы A, используя ручной ввод
*Вывод:*
![image](https://github.com/user-attachments/assets/dd7d48f7-1301-4abd-9834-4d6a864b7b69)

# Если пользователь успешно ввел значения для матрицы B, используя заполнение рандомом
*Вывод:*
![image](https://github.com/user-attachments/assets/1f8714ac-4159-43d3-8b4f-a6478c199099)

# Если пользователь успешно ввел значения для матрицы С, используя заполнение спиралью
*Вывод:*
![image](https://github.com/user-attachments/assets/3fe40eca-5bb9-4861-a020-402b81b0eaf9)

# Вывод значения выражения при правельно введеных матрицах A^т+B-3*C
*Вывод:*
![image](https://github.com/user-attachments/assets/70cf5f56-bc06-4802-b2f8-93f05b4cabb4)

# Для проверки используем калькулятор матриц https://www.desmos.com/matrix?lang=ru
*Вывод:*
![image](https://github.com/user-attachments/assets/2c2fbe35-55c0-4515-a695-f1fd6d9b6870)

# В случае, если выражение невозможно посчитать
*Вывод:*
![image](https://github.com/user-attachments/assets/199317f5-57a4-41cc-904b-6582602bcf83)

## Тесты задания 2

# Если пользователь верно ввел значения и тех, кто изменил решение больше
*Вывод:*
![image](https://github.com/user-attachments/assets/08fc0119-e8c8-45d1-906d-b4fe422549a8)

# Если пользователь верно ввел значения и тех, кто не изменил решение больше
*Вывод:*
![image](https://github.com/user-attachments/assets/d9f625d8-7688-47dd-bd79-c58262d19863)

# Часть 2: Файлы
Задания 4 – 8 выполнить в виде статических методов одного класса, но отдельно от заданий 1-3.

Задание 4. Бинарные файлы
Из исходного файла получить новый файл, исключив повторные вхождения чисел. Порядок
следования чисел сохранить
В задании 4 бинарные файлы, содержат числовые данные, исходный файл необходимо заполнить
случайными данными, заполнение организовать отдельным методом.

Задание 5. Бинарные файлы и структуры
Файл содержит сведения об игрушках: название игрушки, ее стоимость в рублях и возрастные
границы (например, игрушка может предназначаться для детей от двух до пяти лет). Получить
название самой дорогой игрушки, подходящей детям двух-трех лет.
В задании 5 бинарные файлы содержат величины типа struct, заполнение исходного файла
необходимо организовать отдельным методом.

Задание 6. Текстовые файлы
Найти сумму элементов, оканчивающихся на заданную цифру
В задании 6 в текстовом файле хранятся целые числа по одному в строке, исходный файл
необходимо заполнить случайными данными, заполнение организовать отдельным методом.

Задание 7. Решить задачу с использованием структуры «текстовый
файл» 
Найти разность первого и минимального элементов.
В задании 7 в текстовом файле хранятся целые числа по несколько в строке, исходный файл
необходимо заполнить случайными данными, заполнение организовать отдельным методом.

Задание 8. Текстовый файл
Переписать в другой файл строки, в которых нет знаков препинания.
В задании 8 в текстовом файле хранится текст.
Необходимо решить по 1 задаче из каждого задания согласно вашему варианту. Каждое задание
оценивается по 1 баллу.

## Статический Класс LabFiles

## Структура для задания 5
```c#
struct Toy
{
    public string name;
    public int price;
    public int minAge;
    public int maxAge;
}
```

## Методы

Ниже преставлены реализованные **методы** класса **Matrix**:

```c#

// Files

// Ex8
// Записывает в файл все строки без знаков препирания
public static void WriteWithoutPunctuation(string sourceFilePath, string newFilePath) {...}

// Ex7
// Находит разницу между первым и минимальным
public static int DiffBetweenFirstAndMin(string fileName) {...}

// Ex6
// Находит сумму элементов, оканчивающихся на заданное значение
public static int FindSumOfElemsWithGivenEnding(string fileName, int ending) {...}

// Создает файл с рандомными значениями(по одному в строке)
public static void CreateRandomFile(string fileName, int numbers_count, int maxValue, int minValue = 0) {...}

// Создает файл с рандомными значениями(в строку)
public static void CreateRandomOneLineFile(string fileName, int numbers_count, int maxValue, int minValue = 0) {...}

// Возвращает строку с элементами файла
public static string ReadFile(string fileName, string separator = " ") {...}

// Binary Files
// Ex5
// Находит название игрушки с самой большой ценой из заданного диапазона
public static string MostExpensiveInTheRange(string sourceFilePath) {...}

// Создает файл с игрушками
public static void CreateFileWithToys(string sourceFilePath, string[] toysNames) {...}

// Ex4
// Создает новый бинарный файл без дубликатов исходного файла
public static void RemoveDuplicates(string sourceFilePath, string newFilePath) {...}

// Возвращает строку с элементами бинарного файла
public static string BinaryFileToString(string filePath, string separator, string splitter, params Type[] types) {...}

// Создает бинарный файл с рандомными значениями
public static void CreateBinaryFile(string filePath, int numbers_count, int maxValue, int minValue = 0) {...}
```

## Тесты

# Задание 4

# Пользователь успешно ввел значения
*Вывод:*
![image](https://github.com/user-attachments/assets/4e946e48-330d-4587-98b2-64591999a2ae)

# Задание 5

# Если пользователь успешно ввел значения и он нашел игрушку
*Вывод:*
![image](https://github.com/user-attachments/assets/76f165f5-f88e-4442-b6b2-4fe78278a617)


# Если пользователь успешно ввел значения для матрицы С, используя заполнение спиралью
*Вывод:*
![image](https://github.com/user-attachments/assets/3fe40eca-5bb9-4861-a020-402b81b0eaf9)

# Вывод значения выражения при правельно введеных матрицах A^т+B-3*C
*Вывод:*
![image](https://github.com/user-attachments/assets/70cf5f56-bc06-4802-b2f8-93f05b4cabb4)

# Для проверки используем калькулятор матриц https://www.desmos.com/matrix?lang=ru
*Вывод:*
![image](https://github.com/user-attachments/assets/2c2fbe35-55c0-4515-a695-f1fd6d9b6870)

# В случае, если выражение невозможно посчитать
*Вывод:*
![image](https://github.com/user-attachments/assets/199317f5-57a4-41cc-904b-6582602bcf83)


