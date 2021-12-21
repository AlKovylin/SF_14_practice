using System;


namespace SF_14_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookReader PR = new PhoneBookReader();

            try
            {
                PR.CreatPhoneBook();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка открытия файла: " + e.Message);
            }
            //PR.CreatPhoneBook_();
            //PR.ReadBook();
        }
    }
}
