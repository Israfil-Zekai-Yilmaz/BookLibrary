using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68134_Israfil_Zekai_Yilmaz_T6
{
    public class AudioBook : Book
    {
        public string Narrator {  get; set; }
        public int Duration { get; set; }

        public override string GetDetails()
        {
            return $"{Title}\t{Author}\t{Category}\t{Type}\t{Narrator}\t{Duration} ";
        }
    }
}
