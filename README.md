# Лабораторная работа №5. Коллекции И Сериализация. Вариант 13
Решение всех задач оформить в виде одного класса со статическими методами, решающими
поставленные задачи. В классе могут присутствовать методы со спецификатором доступа private
вспомогательного характера.
Необходимо решить по 1 задаче из каждого задания согласно вашему варианту. Задания 1 – 4
оценивается по 1 баллу, задания 5 и 6 – по 2 балла. Максимально за лабораторную работу можно
получить 10 баллов (8 баллов за решение задач + 2 балла за оформление отчета).

Задание 2. Решить задачу, используя класс LinkedList
Составить программу, которая формирует список L включив в него по одному разу элементы,
которые входят в один из списков L1 и L2, но в то же время не входит в другой из них

Задание 2. Работа с двумерными массивами
удалить все элементы между минимальным и максимальным элементами;

Задание3. Решить задачу, используя класс HashSet
Есть перечень названий телевизионных шоу. Определить для каждого наименования шоу, какие
из них нравятся всем n телезрителям, какие — некоторым из телезрителей, и какие — никому из
телезрителей.

Задание 4. Решить задачу, используя класс HashSet
Дан текстовый файл. Обработать содержимое файла с использованием HashSet.
Файл содержит текст на русском языке. Какие цифры встречаются в тексте?

Задание 5. Решить задачу, используя класс Dictionary (или класс SortedList)
Решить текстовую задачу с использованием словаря (входные данные читать из текстового файла)
Имеется список людей с указанием их фамилии, имени и даты рождения. Напишите программу,
которая будет определять самого старшего человека из этого списка и выводить его фамилию и
имя, а если имеется несколько самых старших людей с одинаковой датой рождения, то
определять их количество.
На вход программе в первой строке подается количество людей в списке N. В каждой из
последующих N строк находится информация в следующем формате:
<p align="center">
  <Фамилия> <Имя> <Дата рождения>
</p>
где <Фамилия> – строка, состоящая не более, чем из 20 символов без пробелов, <Имя> – строка,
состоящая не более, чем из 20 символов без пробелов, <Дата рождения> – строка, имеющая вид
ДД.ММ.ГГГГ, где ДД – двузначное число от 01 до 31, ММ – двузначное число от 01 до 12, ГГГГ –
четырехзначное число от 1800 до 2100.
Пример входной строки:
<p align="center">
  Иванов Сергей 27.03.1993
</p>
Программа должна вывести фамилию и имя самого старшего человека в списке.
Пример выходных данных:
<p align="center">
  Иванов Сергей
</p>
Если таких людей, несколько, то программа должна вывести их количество. 
Пример вывода в
этом случае:
<p align="center">
  3
</p>

## Статичный Класс Lab5
## Структуры
```c#
[Serializable]
public struct Toy
{
    public string name;
    public int price;
    public int minAge;
    public int maxAge;
}
```

## Методы
```c#
// Ex 1
public static List<T> SymmetricalDifference<T>(List<T> L1, List<T> L2) {...}

// Ex2
public static LinkedList<T> DeleteAllBetweenMinMax<T>(LinkedList<T> L) where T : IComparable {...}

// Ex3
public static HashSet<HashSet<string>> CreateShowStat(string path, int showCount) {...}
public static string DouHashSetToString(HashSet<HashSet<string>> dHashSet) {...}
public static string ShowRating(string path, HashSet<HashSet<string>> statistics) {...}

// Ex4
public static HashSet<char> DigintsInText(string path) {...}

// Ex5
public static string GetOldestHuman(string path) {...}

// Ex6
public static void CreateToysFile(params string[] toysNames) {...}
public static string RichestToyForKids() {...}

// Others
public static T FileToValue<T>(string path) {...}
```

## Тест задания 1

# Пользователь успешно ввел значения
![image](https://github.com/user-attachments/assets/df89f2b7-ebc6-49eb-ac3f-f5625de9753c)

## Тест задания 2
# Если пользователь успешно ввел значения
![image](https://github.com/user-attachments/assets/41c3da40-618d-4716-819b-d0ee84d52bf9)

## Тест задания 3
# Если пользователь успешно ввел значение
![image](https://github.com/user-attachments/assets/a1ae640d-50d8-4f99-a32b-71c21f2df454)
![image](https://github.com/user-attachments/assets/0625170d-a7fd-4110-82db-4cc2a4336161)

## Тест задания 4
# Текстовый файл
![image](https://github.com/user-attachments/assets/a4000625-9bd7-43b2-9aea-c3f86f406e72)
# Вывод
![image](https://github.com/user-attachments/assets/d9e03f49-6ce4-4f44-a5b0-d3a9cbbeec61)

## Тест задания 5
# Текстовый файл при условии, что самый старший лишь один
![image](https://github.com/user-attachments/assets/2011a4a7-b319-4be4-9c54-ef83f46c0645)
# Вывод
![image](https://github.com/user-attachments/assets/dca28173-7b7c-4aad-b973-3e065e7f300f)
# Текстовый файл при условии, что самых старших несколько
![image](https://github.com/user-attachments/assets/f6d3b021-bfb8-4d01-8fd9-bc7115714819)
# Вывод
![image](https://github.com/user-attachments/assets/c122c5ce-e304-496f-aa5c-9fc30e8112c7)

## Тест задания 6
# Случайно сгенерированный xml файл
![image](https://github.com/user-attachments/assets/dbec0d7a-7808-4d1a-9a14-5efa33e32d7e)
# Вывод
![image](https://github.com/user-attachments/assets/e8c1fe8e-7dd3-4216-a292-5a1439aa5dcc)
