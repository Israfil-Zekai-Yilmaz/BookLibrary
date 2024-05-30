using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }

        public virtual string GetDetails()
        {
            return $"{Title}\t{Author}\t{Category}\t{Type}";
        }
    }
}
