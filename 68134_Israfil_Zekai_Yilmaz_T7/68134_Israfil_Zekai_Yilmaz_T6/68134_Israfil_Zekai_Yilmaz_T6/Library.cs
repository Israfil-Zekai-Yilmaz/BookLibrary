using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public class Library
    {
        public List<Book> books = new List<Book>();
        public static string FileName = "Library.txt";

        public List<Book> GetAllBook() 
        { 
            return books;
        }

        private void SaveBooks()
        {
            FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write);
             StreamWriter sw = new StreamWriter(fs);
            {
                foreach (var book in books)
                {
                    var line = $"{book.Type}\t{book.Title}\t{book.Author}\t{book.Category}\t{GetBooksDetails(book)}";
                    sw.WriteLine(line);
                }
            }
            sw.Close();
            fs.Close();
            
        }
        public int CountLines (string FileName)
        {
            int count = 0;
            using(StreamReader sr = new StreamReader(FileName))

            while(sr.ReadLine() != null)
            {
                count++;
            }
            return count;
           
        }
        public void AddBook(Book book)
        {
            books.Add( book );
            SaveBooks();
        }
        public string GetBooksDetails(Book book)
        {
            switch ( book )
            {
                case PaperBook paperBook:
                    return $"{paperBook.ISBN}\t{paperBook.Pages}";
                case E_Book eBook:
                    return $"{eBook.Format}\t{eBook.Size}";
                case AudioBook audioBook:
                    return $"{audioBook.Narrator}\t{audioBook.Duration}";
                default:
                    throw new Exception("Please enter valid Book type ");
            }
        }



        
    }
}
