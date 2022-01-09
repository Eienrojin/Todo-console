string[] taskList = new string[1];

//Каталог для записи файла настроек
string path = @"C:\Users\Bugurt\source\repos\Todo-console\Todo console";

DirectoryInfo dirInf = new DirectoryInfo(path);

if (!dirInf.Exists)
    dirInf.Create();

//Конец создания файла

ReadProgram();
MainMenu();

void MainMenu()
{
    for (; ; )
    {
        Console.Clear();
        Console.WriteLine("Что вы хотите сделать?"
            + "\n1. Ввести задачу"
            + "\n2. Отобразить задачи"
            + "\n3. Сохраниться"
            + "\n4. Выйти");

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
                ShowList(taskList);
                InitChoiseMenu();
                break;

            case "3":
                SaveProgram();
                break;

            case "4":
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
                ArrayException(taskList);
                DeleteTask();
                break;

            case "2":
                ArrayException(taskList);
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
    int listLength = taskList.Length + 1;
    int numberOfStroke = taskList.Length;
    task = task.Trim();

    Array.Resize(ref taskList, listLength);
    taskList[numberOfStroke] = task;
    listLength++;
    numberOfStroke++;

    Console.Clear();
}

void DeleteTask()
{
    int choice;
    Console.WriteLine("Введите номер записи, которую хотите удалить. Если хотите вернуться, введите -1");
    choice = int.Parse(Console.ReadLine()) - 1;

    if (choice == -1)
        MainMenu();

    ChoiceException(choice);

    taskList[choice] = "";

    for (int i = 0; i < taskList.Length; i++)
    {
        if (taskList[i] == "")
        {
            Array.Sort(taskList);
        }
    }

    ShowList(taskList);
}

void SearchTask()
{
    Console.Clear();
    Console.WriteLine("Введите что-нибудь для поиска... Если хотите вернуться, введите -1");

    byte countOfSearched = 0;
    string initSearch = Console.ReadLine();
    bool searched = false;
    string[] tempList = new string[taskList.Length];

    if (initSearch == "-1")
        MainMenu();

    StringException(initSearch);

    initSearch = initSearch.Trim();
    initSearch = initSearch.ToLower();

    for (int i = 0; i < taskList.Length; i++)
    {
        tempList[i] = taskList[i].ToLower();
    }

    for (int i = 0; i < taskList.Length; i++)
    {
        if (tempList[i].Contains(initSearch))
        {
            countOfSearched++;
            searched = true;
            Console.WriteLine($"{i + 1}. {taskList[i]}");
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
    if (choice > taskList.Length || choice <= 0)
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

//Запись файла
async void SaveProgram()
{
    {
        await File.WriteAllLinesAsync($"{path}\\note.txt", taskList);
        Console.WriteLine("Сохранено!");
    }
}

//Чтение файла
void ReadProgram()
{
    for (int i = 0; i < taskList.Length; i++)
        taskList = File.ReadAllLines($"{path}\\note.txt");
}

//Вывод полученного списка задач
void ShowList(string[] Array)
{
    for (int j = 0; j < 10; j++)
    {
        Console.Write("_");
    }
    Console.WriteLine();

    for (int i = 0; i < taskList.Length; i++)
        Console.WriteLine($"{i + 1}. {taskList[i]}");

    for (int j = 0; j < 10; j++)
    {
        Console.Write("_");
    }
    Console.WriteLine("\n");
}