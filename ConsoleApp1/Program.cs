using System;
using System.Text;

namespace Jurnal
{

    class Program
    {
        static string login = "Test";
        static int password = 1234;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var jurnal = new Jurnal();
            jurnal.GroupList();
            jurnal.StudentsList();
            jurnal.SubjectsList();

            var exit = true;
            while (exit)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\tЭлектронный дневник");
                Console.ResetColor();
                Console.WriteLine("\n Авторизация");
                Console.Write("Введите логин: ");
                var enterLogin = Console.ReadLine();
                Console.Write("Введите пароль: ");
                var enterPassword = int.Parse(Console.ReadLine());
                if (enterLogin == login && enterPassword == password)
                {
                    Console.WriteLine("Успешная авторизация\nНажмите на любую кнопку для продолжение");
                    Console.ReadKey();
                    Console.Clear();

                    var exit1 = false;
                    while (!exit1)
                    {
                        Console.WriteLine("\nВыберите действие:");
                        Console.WriteLine("1. Список студентов");
                        Console.WriteLine("2. Список предметов"); 
                        Console.WriteLine("3. Список групп");
                        Console.WriteLine("4. Список оценок всех студентов за все время");
                        Console.WriteLine("5. Список оценок студента");
                        Console.WriteLine("6. Список оценок студента с фильтрацией по времени");
                        Console.WriteLine("7. Добавить студента");
                        Console.WriteLine("8. Добавить предмет");
                        Console.WriteLine("9. Добавить группу");
                        Console.WriteLine("10. Поставить оценку");
                        Console.WriteLine("11. Выйти");
                        var choice = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (choice)
                        {
                            case 1: jurnal.PrintStudent(); break;
                            case 2: jurnal.PrintSubjects(); break;
                            case 3: jurnal.PrintGroup(); break;
                            case 4: jurnal.PrintAllMarks(); break;
                            case 5: jurnal.PrintMarksByStudent(); break;
                            case 6: jurnal.PrintDateMarks(); break;
                            case 7: jurnal.AddStudent(); break;
                            case 8: jurnal.AddSubject(); break;
                            case 9: jurnal.AddGroup(); break;
                            case 10: jurnal.AddMark(); break;
                            case 11: exit1 = true; break;
                        }
                        Console.WriteLine("Нажмите на любую кнопку чтоб продолжить");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Неверный пароль");
                    exit = false;
                }
            }
        }
    }
}




