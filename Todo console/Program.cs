int listLength = 1;
int numberOfStroke = 0;
List list_1 = new List();
list_1._list = new string[1];

//Каталог для записи файла настроек
string path = @"C:\Prog and games\НА ноут\Тестовая папка";

DirectoryInfo dirInf = new DirectoryInfo(path);

if (!dirInf.Exists)
    dirInf.Create();

const string TEMPFILE = "ЗАМЕНИТЬ ФАЙЛ";
//Конец создания файла

//Запись файла
using (FileStream fstream = new FileStream($"{path}\note.txt", FileMode.OpenOrCreate))
{
    byte[] savingArray = System.Text.Encoding.Default.GetBytes(TEMPFILE); //заменить темп файл на нужные
    await fstream.WriteAsync(savingArray, 0, savingArray.Length);
    Console.WriteLine("Сохранено!");
}

//Чтение файла
using (FileStream fstream = File.OpenRead($"{path}\note.txt"));
{
    byte readingArray = new byte[FileStream.]
}

MainMenu();

void MainMenu()
{
    for (; ; )
    {
        Console.Clear();
        Console.WriteLine("Что вы хотите сделать?"
            + "\n1. Ввести задачу"
            + "\n2. Отобразить задачи"
            + "\n3. Выйти");

        switch (Console.ReadLine())
        {
            default:
                Console.WriteLine("Непонятная команда, попробуйте еще раз");
                break;

            case "1":
                Console.WriteLine("Введите задачу");
                string task = Console.ReadLine();

                InitTask(task);
                break;

            case "2":
                Console.Clear();
                list_1.ShowList();
                InitChoiseMenu();
                break;

            case "3":
                Environment.Exit(0);
                break;
        }
    }
}

void InitChoiseMenu()
{
    for (; ; )
    {
        Console.WriteLine("Что вы хотите сделать?"
            + "\n1. Удалить запись"
            + "\n2. Найти запись"
            + "\n3. Вернуться назад");

        switch (Console.ReadLine())
        {
            default:
                Console.WriteLine("Непонятная команда, попробуйте еще раз");
                break;

            case "1":
                ArrayException(list_1._list);
                DeleteTask();
                break;

            case "2":
                ArrayException(list_1._list);
                SearchTask();
                break;

            case "3":
                MainMenu();
                break;
        }
    }
}

void InitTask(string task)
{
    task = task.Trim();

    Array.Resize(ref list_1._list, listLength);
    list_1._list[numberOfStroke] = task;
    listLength++;
    numberOfStroke++;

    Console.Clear();
}

void DeleteTask()
{
    int choice;
    Console.WriteLine("Введите номер записи, которую хотите удалить. Если хотите вернуться, введите -1");
    choice = int.Parse(Console.ReadLine());

    if (choice == -1)
        MainMenu();

    ChoiceException(choice);

    list_1._list[choice] = "";

    for (int i = 0; i < list_1._list.Length; i++)
    {
        if (list_1._list[i] == "")
        {
            Array.Sort(list_1._list);
        }
    }

    list_1.ShowList();
}

void SearchTask()
{
    Console.Clear();
    Console.WriteLine("Введите что-нибудь для поиска... Если хотите вернуться, введите -1");

    byte countOfSearched = 0;
    string initSearch = Console.ReadLine();
    bool searched = false;
    string[] tempList = new string[list_1._list.Length];

    if (initSearch == "-1")
        MainMenu();

    StringException(initSearch);

    initSearch = initSearch.Trim();
    initSearch = initSearch.ToLower();

    for (int i = 0; i < list_1._list.Length; i++)
    {
        tempList[i] = list_1._list[i].ToLower();
    }

    for (int i = 0; i < list_1._list.Length; i++)
    {
        if (tempList[i].Contains(initSearch))
        {
            countOfSearched++;
            searched = true;
            Console.WriteLine($"{i + 1}. {list_1._list[i]}");
        }
    }
    countOfSearched = 0;

    if (!searched)
        Console.WriteLine("Ничего не найдено");
    searched = false;
}

//Обработчики ошибок
void ChoiceException(int choice)
{
    if (choice > list_1._list.Length || choice <= 0)
    {
        Console.WriteLine("Кажется, вы допустили ошибку. Попробуйте еще раз");
        DeleteTask();
    }
}

void StringException(string choice)
{
    if (choice == "" || choice == null)
    {
        Console.WriteLine("Кажется, вы допустили ошибку. Попробуйте еще раз");
        Console.ReadKey();
        MainMenu();
    }
}

void ArrayException(string[] Array)
{
    if (Array.Length == 0 || Array.Length == 1)
    {
        Console.WriteLine("Записей слишком мало для поиска");
        Console.ReadKey();
        MainMenu();
    }
}
//Конец обработчиков

class List
{
    public string[] _list;

    public void ShowList()
    {
        for (int j = 0; j < 10; j++)
        {
            Console.Write("_");
        }
        Console.WriteLine();

        for (int i = 0; i < _list.Length; i++)
            Console.WriteLine($"{i + 1}. {_list[i]}");

        for (int j = 0; j < 10; j++)
        {
            Console.Write("_");
        }
        Console.WriteLine("\n");
    }
}