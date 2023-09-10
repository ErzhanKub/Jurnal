using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jurnal
{
    public class Jurnal
    {
        static List<Student> students = new List<Student>();
        static List<Subject> subjects = new List<Subject>();
        static List<Group> groups = new List<Group>();
        static Dictionary<Student, Dictionary<Subject, List<Mark>>> marks = new Dictionary<Student, Dictionary<Subject, List<Mark>>>();
        public void StudentsList()
        {
            students.Add(new Student("Анна", "Иванова", "Петровна", 32, "anna.ivanova@gmail.com", "124214", groups[0]));
            students.Add(new Student("Максим", "Смирнов ", "Александрович", 25, "maxim.smirnov@mail.ru", "582983", groups[1]));
            students.Add(new Student("Елена", "Козлова", "Викторовна", 41, "elena.kozlova@yandex.ru", "089432", groups[2]));
            students.Add(new Student("Игорь", "Петров", "Николаевич", 38, "igor.petrov@gmail.com", "290543", groups[0]));
            students.Add(new Student("Наталья", "Лебедева", "Владимировна", 29, " natalia.lebedeva@mail.ru", "345267", groups[2]));
            students.Add(new Student("Сергей", "Кузнецов", "Дмитриевич", 47, " sergey.kuznetsov@yandex.ru", "434573", groups[1]));
            students.Add(new Student("Александра", "Сергеева", "Андреевна", 23, "alexandra.sergeeva@gmail.com", "314636", groups[1]));
            students.Add(new Student("Артем", "Григорьев", "Иванович", 31, "artem.grigoryev@mail.ru", "124523", groups[2]));
        }
        public void SubjectsList()
        {
            subjects.Add(new Subject("Объектно-ориентированное программирование (ООП)"));
            subjects.Add(new Subject("База данных и SQL"));
            subjects.Add(new Subject("Химия"));
            subjects.Add(new Subject("Математика"));
            subjects.Add(new Subject("Физика"));
            subjects.Add(new Subject("Анатомия"));
        }
        public void GroupList()
        {
            groups.Add(new Group("CW22"));
            groups.Add(new Group("CW20"));
            groups.Add(new Group("CW24"));
        }



        public void PrintSubjects()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t2. Список предметов");
            Console.ResetColor();
            Console.WriteLine("Результаты:");
            foreach (var subject in subjects)
            {
                Console.WriteLine(subject.Name);
            }
        }
        public void PrintAllMarks()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t4. Список оценок всех студентов за все время");
            Console.ResetColor();
            Console.WriteLine("Результаты:");
            foreach (Student student in students)
            {
                foreach (Subject subject in subjects)
                {
                    if (marks.ContainsKey(student) && marks[student].ContainsKey(subject))
                    {
                        foreach (Mark mark in marks[student][subject])
                        {
                            Console.WriteLine(student.Firstname + " - " + subject.Name + " - " + mark.Drade + " - " + mark.Date);
                        }
                    }
                }
            }
        }
        public void PrintGroup()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t3. Список групп");
            Console.ResetColor();
            Console.WriteLine("Результаты:");
            foreach (var group in groups)
            {
                Console.WriteLine(group.Name + "| Id: " + group.Name);
            }
        }
        public void PrintStudent()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t1. Список студентов");
            Console.ResetColor();
            Console.WriteLine("Результаты:");
            foreach (var student in students)
            {
                Console.WriteLine($"\nИмя: {student.Firstname}" +
                              $"\nФамилия: {student.SecondName}" +
                              $"\nВозраст: {student.Age}" +
                              $"\nГруппа: {student.Group.Name}" +
                              $"\nEmail: {student.Email}" +
                              $"\nТелефонный номер: +996{student.Phone}");
            }
        }
        public void PrintMarksByStudent()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t5. Список оценок студента");
            Console.ResetColor();
            Console.WriteLine("Введите данные : Имя.");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Student student = students.Find(n => n.Firstname.ToLower() == name.ToLower());
            Console.WriteLine("Результаты:");
            foreach (Subject subject in subjects)
            {
                if (marks.ContainsKey(student) && marks[student].ContainsKey(subject))
                {
                    Console.WriteLine(subject.Name + ":");
                    foreach (Mark mark in marks[student][subject])
                    {
                        Console.WriteLine("\t" + mark.Date + " - " + mark.Drade);
                    }
                }
            }
        }
        public void PrintDateMarks()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t6. Список оценок студента с фильтрацией по времени.");
            Console.ResetColor();
            Console.WriteLine("Введите данные : Имя | От(dd.MM.yyyy) | До(dd.MM.yyyy).");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("От: ");
            DateTime fromDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("До: ");
            DateTime toDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Student student = students.Find(n => n.Firstname.ToLower() == name.ToLower());
            if (marks.ContainsKey(student))
            {
                Console.WriteLine("Результаты:");
                Console.WriteLine($"{student.Firstname}:");
                foreach (var subject in marks[student].Keys)
                {
                    Console.WriteLine($"  {subject.Name}:");
                    foreach (var mark in marks[student][subject])
                    {
                        if (mark.Date < fromDate)
                        {
                            continue;
                        }
                        if (mark.Date > toDate)
                        {
                            continue;
                        }
                        Console.WriteLine($"    {mark.Drade}");
                    }
                }
            }
        }


        public void AddStudent()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t7. Добавить студента.");
            Console.ResetColor();
            Console.WriteLine("Введите данные : Имя | Фамилия | Отчество | Возраст | Email | Телефонный номер.");
            Console.Write("Имя: "); var firstName = Console.ReadLine();
            Console.Write("Фамилия: "); var secondName = Console.ReadLine();
            Console.Write("Отчество: "); var midleName = Console.ReadLine();
            Console.Write("Возраст: "); var age = int.Parse(Console.ReadLine());
            Console.Write("Email: "); var email = Console.ReadLine();
            Console.Write("Телефоный номер: +996 "); var phoneNumber = Console.ReadLine();
            PrintGroup();
            Console.Write("Введите название группы: "); var choiceGR = Console.ReadLine();

            var choiceGroup = groups.Find(x => x.Name.ToLower() == choiceGR.ToLower());
            students.Add(new Student(firstName, secondName, midleName, age, email, phoneNumber, choiceGroup));
            Console.WriteLine("Данные успешно добавлены.");
        }
        public void AddGroup()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t9. Добавить группу");
            Console.ResetColor();
            Console.WriteLine("Введите данные : название группы");
            Console.Write("Название: ");
            string name = Console.ReadLine();
            groups.Add(new Group(name));
            Console.WriteLine("Данные успешно добавлены.");
        }
        public void AddSubject()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t8. Добавить предмет");
            Console.ResetColor();
            Console.Write("Название предмета: ");
            string name = Console.ReadLine();

            subjects.Add(new Subject(name));
            Console.WriteLine("Данные успешно добавлены.");
        }
        public void AddMark()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t10. Поставить оценку");
            Console.ResetColor();
            Console.WriteLine("Введите данные : Имя | Предмет | Оценка(5,4,3,2,нб)");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Student student = students.Find(s => s.Firstname.ToLower() == name.ToLower());

            Console.Write("Предмет: ");
            string subjectName = Console.ReadLine();
            Subject subject = subjects.Find(s => s.Name.ToLower() == subjectName.ToLower());

            Console.Write("Оценка: ");
            string grade = Console.ReadLine();

            if (!marks.ContainsKey(student))
            {
                marks[student] = new Dictionary<Subject, List<Mark>>();
            }

            if (!marks[student].ContainsKey(subject))
            {
                marks[student][subject] = new List<Mark>();
            }

            marks[student][subject].Add(new Mark(grade));
            Console.WriteLine("Данные успешно добавлены.");
        }
    }
}
