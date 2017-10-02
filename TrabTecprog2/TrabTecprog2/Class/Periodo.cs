using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class Periodo : Aulas, IImpressao
    {
        public Periodo(int id, int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR, int periodo)
            : base(aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR)
        {
            Id = id;
            this.periodo = periodo;
            Disciplinas = new List<Disciplina>();
        }
        public int Id { get; set; }
        public int periodo { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public override int AulasPraticas
        {
            get
            {
                int somatorio = 0;
                foreach (Disciplina p in Disciplinas)
                {
                    somatorio += p.AulasPraticas;
                }
                return somatorio;
            }

        }

        public override int AulasTeoricas
        {
            get
            {
                int somatorio = 0;
                foreach (Disciplina p in Disciplinas)
                {
                    somatorio += p.AulasTeoricas;
                }
                return somatorio;
            }

        }

        public override int Creditos
        {
            get
            {
                int somatorio = 0;
                foreach (Disciplina p in Disciplinas)
                {
                    somatorio += p.Creditos;
                }
                return somatorio;
            }

        }

        public override int TotalHA
        {
            get
            {
                int somatorio = 0;
                foreach (Disciplina p in Disciplinas)
                {
                    somatorio += p.TotalHA;
                }
                return somatorio;
            }

        }
        public override int TotalHR
        {
            get
            {
                int somatorio = 0;
                foreach (Disciplina p in Disciplinas)
                {
                    somatorio += p.TotalHR;
                }
                return somatorio;
            }

        }



        public void Imprimir()
        {
            Console.WriteLine("_____ PERÍODO _____");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Aulas Praticas: " + AulasPraticas);
            Console.WriteLine("Aulas Teóricas: " + AulasTeoricas);
            Console.WriteLine("Créditos: " + Creditos);
            Console.WriteLine("Total Horas Aula" + TotalHA);
            Console.WriteLine("Total Horas Relógio" + TotalHR);
            if (Disciplinas == null)
            {
                Console.WriteLine("Não há pré Disciplinas");
            }
            else
            {
                foreach (Disciplina d in Disciplinas)
                {
                    Console.WriteLine("_____ DISCIPLINAS E SEUS PRÉ REQUISITOS _____\n");
                    d.Imprimir();
                }
                Console.WriteLine("_____ FIM DAS DISCIPLINAS _____\n");
            }
        }
    }
}
