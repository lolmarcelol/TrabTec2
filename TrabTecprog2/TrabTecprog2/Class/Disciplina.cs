using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabTecprog2.Class
{
    class Disciplina : Aulas,IImpressao
    {
        public Disciplina(int codigo, string nome,int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR)
            :base(aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> PreRequisitos { get; set; }

        //codigo, nome,aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR
        public void Imprimir()
        {
            Console.WriteLine("_____ DISCIPLINA _____");
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Aulas Praticas: " + AulasPraticas);
            Console.WriteLine("Aulas Teóricas: " + AulasTeoricas);
            Console.WriteLine("Créditos: " + Creditos);
            Console.WriteLine("Total Horas Aula" + TotalHA);
            Console.WriteLine("Total Horas Relógio" + TotalHR);
            if (PreRequisitos == null)
            {
                Console.WriteLine("Não há pré requisitos");
            }else
            {
            foreach (Disciplina d in PreRequisitos)
                {
                    Console.WriteLine("_____PRÉ REQUISITOS _____");
                    d.Imprimir();
                }
                Console.WriteLine("_____ FIM DOS PRÉ REQUISITOS _____");

            }

        }
    }
}
