using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SF_14_practice
{
    class Program
    {
        /// <summary>
        /// Количество строк на странице.
        /// </summary>
        private const int RangePage = 17;

        private static PhoneBook phoneBook = new PhoneBook();
        private static Table table = new Table(RangePage);

        static void Main(string[] args)
        {            
            if (!phoneBook.IsFile())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл книги не обнаружен.");
            }

            List<Contact> PhoneBook_ = phoneBook.GetPhoneBook();
            var PhoneBook = PhoneBook_.OrderBy(pb => pb.LastName).ThenBy(pb => pb.FirstName);

            int pageCounter = 1;

            table.Show(GetPage(PhoneBook, pageCounter), pageCounter);

            while (true)
            {
                var Key = Console.ReadKey();

                var KeyCode = Key.Key;

                if (KeyCode == ConsoleKey.End)
                    break;

                if (char.IsLetter(Key.KeyChar))
                    LetterSelection(Key.KeyChar, PhoneBook);
                

                /*if(Regex.IsMatch(Key.KeyChar.ToString(), @"[А-Я]+$"))
                    LetterSelection(Key.KeyChar, PhoneBook);*/


                //Console.Clear();

                /*switch (KeyCode)
                {
                    //стрелка влево
                    case ConsoleKey.LeftArrow:
                        pageCounter = GetPageCounter(PhoneBook.Count(), --pageCounter);
                        table.Show(GetPage(PhoneBook, pageCounter), pageCounter);
                        break;
                    //стрелка вправо
                    case ConsoleKey.RightArrow:
                        pageCounter = GetPageCounter(PhoneBook.Count(), ++pageCounter);
                        table.Show(GetPage(PhoneBook, pageCounter), pageCounter);
                        break;                        
                    default:
                        table.Err();
                        break;                        
                }*/
            }
        }

        /// <summary>
        /// Производит выборку записей по первой букве фамилии.
        /// </summary>
        /// <param name="keyChar"></param>
        private static void LetterSelection(char keyChar, IEnumerable<Contact> contacts)
        {
            List<Contact> selectLet = new List<Contact>();

            foreach(var contact in contacts)
            {
                if (contact.LastName.StartsWith(keyChar))
                    selectLet.Add(contact);
            }

            if (selectLet.Count > 0)
                table.Show(selectLet, 1);
            else
                Console.WriteLine("Список не содержит записей на указанную букву.");
        }

        /// <summary>
        /// Ограничивает количество отображаемых страниц в соотвествии с размером списка контактов
        /// и заданным количеством строк на одной странице.
        /// </summary>
        /// <param name="contactsCount"></param>
        /// <param name="pageCounter"></param>
        /// <returns>Номер страницы.</returns>
        static int GetPageCounter(int contactsCount, int pageCounter)
        {
            if (pageCounter < 1)
                return 1;

            if (pageCounter > 0 && pageCounter * RangePage < contactsCount + RangePage)
                return pageCounter;
            else
                return pageCounter - 1;
        }

        /// <summary>
        /// Выполняет выборку данных из списка контактов в соответствии с номером страницы.
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="pageCounter"></param>
        /// <returns>Список контактов для данной страницы.</returns>
        static IEnumerable<Contact> GetPage(IEnumerable<Contact> contacts, int pageCounter)
        {
            if (pageCounter == 1)
                return contacts.Take(RangePage);

            if (contacts.Count() - RangePage * (pageCounter -1) < RangePage)//если RangePage не кратна размеру списка контактов
                return contacts.Skip(RangePage * (pageCounter -1));
            else
                return contacts.Skip(RangePage * (pageCounter - 1)).Take(RangePage);                                   
        }
    }
}