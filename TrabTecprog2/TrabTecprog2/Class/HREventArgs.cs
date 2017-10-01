using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class HREventArgs : EventArgs
    {
        public int hrDepois { get; set; }
        public int hrAntes { get; set; }
        public string nome { get; set; }
        public HREventArgs(int hrAntes, int hrDepois, string nome)
        {
            this.hrAntes = hrAntes;
            this.hrDepois = hrDepois;
            this.nome = nome;
        }

    }
}
