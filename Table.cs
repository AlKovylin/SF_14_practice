using System;
using System.Collections.Generic;

namespace SF_14_practice
{
    public class Table
    {
        private int RangePage { get; set; }

        public Table(int RangePage)
        {
            this.RangePage = RangePage;
        }

        /// <summary>
        /// Выводит на экран заголовок таблицы.
        /// </summary>
        /// <param name="page"></param>
        private void Header(int page)
        {
            Console.WriteLine("\t\t\tТЕЛЕФОННЫЙ СПРАВОЧНИК\n");
            Console.WriteLine("{0, 62} {1, 2}{2}", "Страница", page, ".");
            Console.WriteLine("{0, 62} {1, 2}{2}", "Страница", page, ".");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|  № |                  ФИО                   |      Телефон     |");
            Console.WriteLine("------------------------------------------------------------------");
        }

        /// <summary>
        /// Выводит на экран тело таблицы.
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="page"></param>
        private void Page(IEnumerable<Contact> contacts, int page)
        {
            int numFirstStr = GetNumFirstStr(page);

            foreach (var contact in contacts)
            {
                Console.WriteLine("| {0, 2} | {1, -12} {2, -12} {3, -12} | {4, -16} |", numFirstStr, contact.LastName, contact.FirstName, contact.Patronymic, contact.Phone.ToString("+#(###)###-##-##"));
                numFirstStr++;
            }
        }

        /// <summary>
        /// Выводит на экран завершение таблицы.
        /// </summary>
        private void End()
        {
            Console.WriteLine("------------------------------------------------------------------");           
        }

        /// <summary>
        /// Выводит на экран инструкцию пользователя.
        /// </summary>
        private void ControlInfo()
        {
            WriteLine("\t{=Green}ИНСТРУКЦИЯ");
            WriteLine("1. Перелистывание стрелками: {=Blue}вправо{=Green}, {=Blue}влево{=Green}.");
            WriteLine("2. Сортировка по фамилиям стрелками: {=Red}А-Я {=Green}- {=Blue}вверх{=Green}, {=Red}Я-А {=Green}- {=Blue}вниз{=Green}.");
            Console.WriteLine("3. Сортировка по именам: А-Я - page up, Я-А - page down.");
            Console.WriteLine("4. Введите букву для получения списка отфильтрованного по фамилии.");
            Console.WriteLine("5. Для завершения программы нажмите клавишу \"END\".");
        }

        /// <summary>
        /// Расчитывает номер первой строки на данной странице.
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Номер первой строки.</returns>
        private int GetNumFirstStr(int page)
        {
            return (page - 1) * RangePage + 1;
        }

        /// <summary>
        /// Выводит на экран сообщение об ошибочной команде.
        /// </summary>
        public void Err()
        {
            Console.WriteLine("Команда не зарегистрирована.");
        }

        /// <summary>
        /// Выводит таблицу на экран.
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="pageCounter"></param>
        public void Show(IEnumerable<Contact> contacts, int pageCounter)
        {
            Header(pageCounter);
            Page(contacts, pageCounter);
            End();
            ControlInfo();
        }

        /// <summary>
        /// Выводит строку с учётом цветовых меток.
        /// </summary>
        /// <param name="msg"></param>
        private void WriteLine(string msg)
        {
            //Black, Blue, Cyan, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, 
            //DarkRed, DarkYellow, Gray, Green, Magenta, Red, White, Yellow
            string[] ss = msg.Split('{', '}');
            ConsoleColor c;
            foreach (var s in ss)
                if (s.StartsWith("/"))
                    Console.ResetColor();
                else if (s.StartsWith("=") && Enum.TryParse(s.Substring(1), out c))
                    Console.ForegroundColor = c;
                else
                    Console.Write(s);
            Console.WriteLine();
        }
    }
}