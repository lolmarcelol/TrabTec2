using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabTecprog2.Class;

namespace TrabTecprog2
{
    class Program
    {
        static void Main(string[] args)
        {
            // PARA VER OQ PRECISA FAZER VA E VIEW>TASK LIST OU CRTL+]
            //DONE: LOGICA ENTRE AS CLASSES
            //DONE: LOGICA PARA PEGAR OS VALORES DE PERIODO E CURSO AUTOMATICO -> UTILIZEI OS METODOS SET E GET MESMO !!
            //TODO: LOGICA PARA ADICIONAR AS PARADAS PELO MAIN
            //TODO: EXCEPTIONS PARA TIPO DE DADOS
            //TODO: FAZER AS PARADA DE TXT E XML

            //codigo, nome,aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR
            Disciplina d = new Disciplina(1,"tecprog1",30,30,20,60,100);
            Disciplina d2 = new Disciplina(2, "tecprog2", 40, 40, 20, 110, 200);
            Disciplina d3 = new Disciplina(3, "calculo1", 5, 60, 10, 110, 200);
            Disciplina d4 = new Disciplina(4, "calculo2", 5, 60, 15, 110, 200);

            Periodo p = new Periodo(1,0,0,0,0,0);
            Periodo p2 = new Periodo(2, 0, 0, 0, 0, 0);

            List<Disciplina> pr1 = new List<Disciplina>();
            List<Disciplina> pr2 = new List<Disciplina>();

            pr1.Add(d);
            pr1.Add(d2);
            pr2.Add(d3);
            pr2.Add(d4);

            p.Disciplinas = pr1;
            p2.Disciplinas = pr2;

            List<Periodo> periodos = new List<Periodo>();
            periodos.Add(p);
            Curso c = new Curso(1,"BSI",0,0,0,0,0);
            c.Periodos = periodos;
            c.Imprimir();
            c.Periodos.Add(p2);
            c.Imprimir();

            Console.Read();
        }
    }
}
