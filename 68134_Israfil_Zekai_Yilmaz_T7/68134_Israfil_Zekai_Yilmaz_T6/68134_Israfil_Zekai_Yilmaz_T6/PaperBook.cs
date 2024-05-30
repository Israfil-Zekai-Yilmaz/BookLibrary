using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public class PaperBook : Book
    {
        public string ISBN { get; set; }
        public int Pages { get; set; }

        public override string GetDetails()
        {
            return $"{Title}\t{Author}\t{Category}\t{Type}\t{ISBN}\t{Pages} ";
        }
    }
}
