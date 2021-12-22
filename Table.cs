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
            int num = page;

            foreach (var contact in contacts)
            {
                Console.WriteLine("| {0, 2} | {1, -12} {2, -12} {3, -12} | {4, -16} |", num, contact.LastName, contact.FirstName, contact.Patronymic, contact.Phone.ToString("+#(###)###-##-##"));
                num++;
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
            Console.WriteLine("\tИНСТРУКЦИЯ");
            Console.WriteLine("Перелистывание стрелками вправо, влево.");
            Console.WriteLine("Сортировка по фамилиям стрелками: А-Я - вверх, Я-А - вниз.");
            Console.WriteLine("Сортировка по именам: А-Я - page up, Я-А - page down.");
            Console.WriteLine("Введите букву для получения отфильтрованного списка.");
            Console.WriteLine("Для завершения программы нажмите клавишу \"END\".");
        }

        /// <summary>
        /// Выводит на экран сообщение о ошибочной команде.
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
    }
}