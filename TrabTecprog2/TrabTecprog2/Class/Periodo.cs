using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class Periodo : Aulas, IImpressao
    {
        public Periodo(int id, int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR)
            : base(aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR)
        {
            Id = id;
        }
        public int Id { get; set; }
        private IEnumerable<Disciplina> _Disciplinas;
        public IEnumerable<Disciplina> Disciplinas
        {
            get
            {
                return this._Disciplinas;
            }
            set
            {
                this._Disciplinas = value;
                foreach (Disciplina d in value)
                {
                    AulasPraticas += d.AulasPraticas;
                    AulasTeoricas += d.AulasTeoricas;
                    Creditos += d.Creditos;
                    TotalHA += d.TotalHA;
                    TotalHR += d.TotalHR;
                }
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
                    Console.WriteLine("_____ DISCIPLINAS E SEUS PRÉ REQUISITOS _____");
                    d.Imprimir();
                }
                Console.WriteLine("_____ FIM DAS DISCIPLINAS _____");
            }
        }
    }
}
