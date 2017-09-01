using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class Aulas
    {
        public Aulas(int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR)
        {
            AulasPraticas = aulasPraticas;
            AulasTeoricas = aulasTeoricas;
            Creditos = creditos;
            TotalHA = totalHA;
            TotalHR = totalHR;
        }
        public int AulasTeoricas { get; set; }
        public int AulasPraticas { get; set; }
        public int Creditos { get; set; }
        public int TotalHA { get; set; }
        public int TotalHR { get; set; }
    }
}
