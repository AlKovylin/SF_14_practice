using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace SF_14_practice
{
    class PhoneBookReader
    {
        public bool CreatPhoneBook()
        {
            Application excelApp = new Application();

            if (excelApp == null)
                return false;

            //Workbook excelBook = excelApp.Workbooks.Open(@"PhoneBook.xlsx");
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\user\source\repos\SF_14_practice\bin\Debug\netcoreapp3.1\PhoneBook.xlsx");


            Worksheet excelSheet = (Worksheet)excelBook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

            int rowsCount = excelRange.Rows.Count;
            int colsCount = excelRange.Columns.Count;

            for (int i = 1; i <= rowsCount; i++)
            {
                //create new line
                Console.Write("\r\n");
                for (int j = 1; j <= colsCount; j++)
                {

                    //write the console
                    if (excelRange.Cells[i, j] != null)
                        Console.Write(excelRange.Cells[i, j].ToString() + "\t");
                }
            }

            return true;
        }

        public void CreatPhoneBook_()
        {
            string FF = File.ReadAllText(@"PhoneBook.txt");

            //Console.WriteLine(FF);

            string[] gg = FF.Split(' ');

            foreach (var s in gg)
                Console.WriteLine(s);
        }

        public void ReadBook()
        {
            using (FileStream fstream = new FileStream("PhoneBook.txt", FileMode.Open))
            {
                byte[] array = new byte[fstream.Length];               

                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
    }
}