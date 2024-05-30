using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public class E_Book: Book
    {
        public string Format { get; set; }
        public int Size { get; set; }

        public override string GetDetails()
        {
            return $"{Title}\t{Author}\t{Category}\t{Type}\t{Format}\t{Size} ";
        }
    }
}
