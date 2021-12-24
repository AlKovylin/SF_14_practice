using System;
using System.Collections.Generic;

namespace SF_14_practice
{
    public class Table
    {
        private int RangePage { get; }

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
            SetColor.Text();
            Console.WriteLine("\t\t\tТЕЛЕФОННЫЙ СПРАВОЧНИК");
            Console.WriteLine("{0, 66} {1, 2}{2}", "Страница", page, ".");

            SetColor.Border();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("|  ");

            SetColor.Text();
            Console.Write("№");

            SetColor.Border();
            Console.Write("  |                   ");

            SetColor.Text();
            Console.Write("ФИО");

            SetColor.Border();
            Console.Write("                     |      ");

            SetColor.Text();
            Console.Write("Телефон");

            SetColor.Border();
            Console.WriteLine("     |");

            //Console.WriteLine("|  №  |                   ФИО                     |      Телефон     |");

            Console.WriteLine("----------------------------------------------------------------------");

            Console.ResetColor();
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
                SetColor.Border();
                Console.Write("| ");

                SetColor.Text();
                Console.Write("{0, 3}", numFirstStr);

                SetColor.Border();
                Console.Write(" | ");

                SetColor.Text();
                Console.Write("{0, -12} {1, -12} {2, -15}", contact.LastName, contact.FirstName, contact.Patronymic);

                SetColor.Border();
                Console.Write(" | ");

                SetColor.Text();
                Console.Write("{0, -16}", contact.Phone.ToString("+#(###)###-##-##"));

                SetColor.Border();
                Console.WriteLine(" |");

                Console.ResetColor();

                //Console.WriteLine("| {0, 2} | {1, -12} {2, -12} {3, -12} | {4, -16} |", numFirstStr, contact.LastName, contact.FirstName, contact.Patronymic, contact.Phone.ToString("+#(###)###-##-##"));
                numFirstStr++;
            }
        }

        /// <summary>
        /// Выводит на экран завершение таблицы.
        /// </summary>
        private void End()
        {
            SetColor.Border();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит на экран инструкцию пользователя.
        /// </summary>
        private void ControlInfo()
        {
            WriteLine("\n\n\t{=Color1}ИНСТРУКЦИЯ\n");
            WriteLine("1. Перелистывание стрелками: {=Color2}вправо{=Color1}, {=Color2}влево{=Color1}.");
            WriteLine("2. Сортировка по фамилиям стрелками: {=Color3}А-Я {=Color1}- {=Color2}вверх{=Color1}, {=Color3}Я-А {=Color1}- {=Color2}вниз{=Color1}.");
            WriteLine("3. Сортировка по именам: {=Color3}А-Я {=Color1}- {=Color2}page up{=Color1}, {=Color3}Я-А {=Color1}- {=Color2}page down{=Color1}.");
            WriteLine("{=Color1}4. Введите букву для получения списка отфильтрованного по фамилии.");
            WriteLine("{=Color1}5. Для завершения программы нажмите клавишу \"{=Color2}END{=Color1}\".");

            Console.ResetColor();
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
        /// Выводит на экран информационное сообщение.
        /// </summary>
        public void Info(string message, int position, ConsoleColor color)
        {
            Console.SetCursorPosition(0, position);
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
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
            string[] ss = msg.Split('{', '}');

            foreach (var s in ss)
                if (s.StartsWith("="))
                {
                    switch(s)
                    {
                        case "=Color1":
                            SetColor.Text1();
                            break;
                        case "=Color2":
                            SetColor.Text2();
                            break;
                        case "=Color3":
                            SetColor.Text3();
                            break;
                    }
                }
                else
                    Console.Write(s);
            Console.WriteLine();
        }
    }
}