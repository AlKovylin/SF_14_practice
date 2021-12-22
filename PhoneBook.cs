using System.Collections.Generic;
using System.IO;

namespace SF_14_practice
{
    class PhoneBook
    {
        private readonly string path = "PhoneBook.txt";

        /// <summary>
        /// Проверяет наличие файла.
        /// </summary>
        /// <returns></returns>
        public bool IsFile()
        {
            if (File.Exists(path))
                return true;

            return false;
        }

        /// <summary>
        /// Читает данные из файла.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public List<Contact> GetPhoneBook()
        {
            List<Contact> Contacts = new List<Contact>();

            foreach (var line in File.ReadLines(path))
            {
                string[] temp = line.Split(' ');

                Contacts.Add(new Contact(temp[1], temp[2], temp[0], long.Parse(temp[3])));
            }

            return Contacts;
        }
    }
}