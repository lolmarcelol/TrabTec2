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
        public virtual int AulasTeoricas { get; set; }
        public virtual int AulasPraticas { get; set; }
        public virtual int Creditos { get; set; }
        public virtual int TotalHA { get; set; }
        public virtual int TotalHR { get; set; }
    }
}
