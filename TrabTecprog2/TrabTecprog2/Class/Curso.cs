using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class Curso : Aulas, IImpressao
    {
        public Curso(int id, string nome, int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR)
            : base(aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        // conjunto periodos
        private IEnumerable<Periodo> _Periodos;
        public IEnumerable<Periodo> Periodos
        {
            get
            {
                return this._Periodos;
            }
            set
            {
                this._Periodos = value;
                foreach (Periodo p in value)
                {
                    AulasPraticas += p.AulasPraticas;
                    AulasTeoricas += p.AulasTeoricas;
                    Creditos += p.Creditos;
                    TotalHA += p.TotalHA;
                    TotalHR += p.TotalHR;
                }
            }
        }

        public void Imprimir()
        {
            Console.WriteLine("_____ CURSO _____");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Aulas Praticas: " + AulasPraticas);
            Console.WriteLine("Aulas Teóricas: " + AulasTeoricas);
            Console.WriteLine("Créditos: " + Creditos);
            Console.WriteLine("Total Horas Aula" + TotalHA);
            Console.WriteLine("Total Horas Relógio" + TotalHR);
            if (Periodos == null)
            {
                Console.WriteLine("Não há pré requisitos");
            }
            else
            {
                foreach (Periodo d in Periodos)
                {
                    Console.WriteLine("_____ PERÍODOS COM MATERIAS E SEUS PRE REQUISITOS _____");
                    d.Imprimir();
                }
                Console.WriteLine("_____ FIM DOS PERIODOS COM MATERIAS E SEUS PRE REQUISITOS _____");

            }
        }
    }
}
