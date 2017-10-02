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
            Periodos = new List<Periodo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public void AssinanteHR(object remetente, EventArgs valores)
        {
            if (valores is HREventArgs)
            {
                HREventArgs arg = (HREventArgs)valores;
                //“A disciplina XXXXX teve sua carga horária modificada de Y para Z”
                Console.WriteLine("A disciplina " + arg.nome + " teve sua carga horária modificada de " + arg.hrAntes + " para " + arg.hrDepois);
            }
        }

        public override int AulasPraticas
        {
            get
            {
                int somatorio = 0;
                foreach (Periodo p in Periodos)
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
                foreach (Periodo p in Periodos)
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
                foreach (Periodo p in Periodos)
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
                foreach (Periodo p in Periodos)
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
                foreach (Periodo p in Periodos)
                {
                    somatorio += p.TotalHR;
                }
                return somatorio;
            }

        }

        public List<Periodo> Periodos { get; set; }

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
                    Console.WriteLine("_____ PERÍODOS COM MATERIAS E SEUS PRE REQUISITOS _____\n");
                    d.Imprimir();
                }
                Console.WriteLine("_____ FIM DOS PERIODOS COM MATERIAS E SEUS PRE REQUISITOS _____\n");

            }
        }
    }
}
