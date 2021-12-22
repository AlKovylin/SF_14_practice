using System;
using System.Collections.Generic;
using System.Linq;

namespace SF_14_practice
{
    class Program
    {
        private const int RangePage = 20;

        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            Table table = new Table(RangePage);

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
                var KeyCode = Console.ReadKey().Key;

                if (KeyCode == ConsoleKey.End)
                    break;

                Console.Clear();

                switch (KeyCode)
                {
                    //стрелка влево
                    case ConsoleKey.LeftArrow:
                        pageCounter = GetPageCounter(PhoneBook, --pageCounter);
                        table.Show(GetPage(PhoneBook, pageCounter), pageCounter);
                        break;
                    //стрелка вправо
                    case ConsoleKey.RightArrow:
                        pageCounter = GetPageCounter(PhoneBook, ++pageCounter);
                        table.Show(GetPage(PhoneBook, pageCounter), pageCounter);
                        break;                        
                    default:
                        table.Err();
                        break;                        
                }
            }
        }   
                
        static int GetPageCounter(IEnumerable<Contact> contacts, int pageCounter)
        {
            if (pageCounter < 1)
                return 1;

            double CalcPageCount = contacts.Count() / pageCounter;

            if (pageCounter > 0 && pageCounter < Math.Ceiling(CalcPageCount))
                return pageCounter;
            else
                return (int)Math.Ceiling(CalcPageCount);
        }

        static IEnumerable<Contact> GetPage(IEnumerable<Contact> contacts, int pageCounter)
        {
            if (pageCounter == 1)
                return contacts.Take(RangePage);
            else
                return contacts.Skip(RangePage * (pageCounter - 1)).Take(RangePage);
        }
    }
}