using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TrabTecprog2.Class;

namespace TrabTecprog2
{
    class Program
    {
        private static List<Disciplina> disciplinas = new List<Disciplina>();
        private static List<Periodo> periodos = new List<Periodo>();
        private static List<Curso> cursos = new List<Curso>();

        public static void escreveOpcoes()
        {
            if (cursos.Count == 0)
            {
                Console.WriteLine("Digite 9 para criar o primeiro curso");
            }else
            {
                Console.WriteLine("Digite 1 para adiconar uma disciplina V");
                Console.WriteLine("Digite 2 para adicionar um periodo V");
                Console.WriteLine("Digite 3 para adicionar um curso V");
                Console.WriteLine("Digite 4 para visualizar a grade a partir dos cursos");
                Console.WriteLine("Digite 5 para visualizar a grade a partir dos periodos");
                Console.WriteLine("Digite 6 para visualizar as disciplinas");
                Console.WriteLine("Digite 7 para adicionar um pre-requisito");
                Console.WriteLine("Digite 8 para modificar a hora relógio de uma disciplina");
                Console.WriteLine("Digite 10 para sair");
            }
        }

        public static Curso findCursobyPeriodo(int periodoId)
        {
            foreach (Curso c in cursos)
            {
                if (c.Periodos != null)
                {
                    foreach (Periodo p in c.Periodos)
                    {
                        if (p.Id == periodoId)
                        {
                            return c;
                        }
                    }
                }else
                {
                    return null;
                }
            }
            return null;
        }

        public static void disciplinaSemCall(int id)
        {
            foreach (Disciplina d in disciplinas)
            {
                if (d.Codigo != id)
                {
                    Console.WriteLine("Nome da disciplina: " + d.Nome + "ID da disciplina: " + d.Codigo);
                }
            }
        }

        public static Disciplina findDisciplinabyId(int id)
        {
            foreach (Disciplina d in disciplinas)
            {
                if (d.Codigo == id)
                {
                    return d;
                }
            }
            return null;
        }

        public static Periodo findPeriodobyId(int id)
        {
            foreach (Periodo p in periodos)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public static Curso findCursobyId(int id)
        {
            foreach (Curso c in cursos)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public static void getCursos()
        {
            foreach (Curso c in cursos)
            {
                Console.WriteLine("Nome do curso: " + c.Nome + "ID do curso: " + c.Id);
            }
        }

        public static void getPeriodos()
        {
            foreach (Periodo p in periodos)
            {
                Curso c = findCursobyPeriodo(p.Id);
 
                    Console.WriteLine("Numero do Periodo: " + p.periodo + "ID do periodo: " + p.Id + "Pertence ao curso: "+c.Nome);
                
            }
        }

        public static void getDisciplinas()
        {
            foreach(Disciplina d in disciplinas)
            {
                Console.WriteLine("Nome da disciplina: " + d.Nome + "ID da disciplina: " + d.Codigo);
            }
        }

        public static bool addCurso()
        {
            Random rd = new Random();
            int codigo = rd.Next(0, 10000);
            Console.WriteLine("Digite o nome do curso");
            string nome = Console.ReadLine();

            Curso c = new Curso(codigo, nome, 0, 0, 0, 0, 0);

            foreach (Curso curso in cursos)
            {
                if (curso.Nome == nome)
                {
                    return false;
                }
            }
            cursos.Add(c);
            return true;
        }

        public static bool addPeriodo()
        {
            int periodo, idCurso;
            Random rd = new Random();
            int codigo = rd.Next(0, 10000);
            Console.WriteLine("Qual o período?");
            string prd = Console.ReadLine();
            if (validaInputInt(prd))
                periodo = Convert.ToInt32(prd);
            else
                return false;

            

            Console.WriteLine("Escreva o id do curso");
            getCursos();
            string aux = Console.ReadLine();
            if (validaInputInt(aux))
                idCurso = Convert.ToInt32(aux);
            else
                return false;

            Curso c = findCursobyId(idCurso);

            foreach (Periodo perd in c.Periodos)
            {
                if (perd.periodo == periodo)
                {
                    return false;
                }
            }
            Periodo p = new Periodo(codigo, 0, 0, 0, 0, 0, periodo);
            periodos.Add(p);
            c.Periodos.Add(p);

            return true;
        }

        // int codigo, string nome,int aulasPraticas, int aulasTeoricas, int creditos, int totalHA, int totalHR
        public static bool addDisciplina()
        {
            int aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR,idPeriodo;
            Random rd = new Random();
            int codigo = rd.Next(0,10000);
            Console.WriteLine("Digite o nome da disciplina");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de aulas praticas");
            string alp = Console.ReadLine();
            if (validaInputInt(alp))
                aulasPraticas = Convert.ToInt32(alp);
            else
                return false;

            Console.WriteLine("Digite a quantidade de aulas teoricas");
            string alt = Console.ReadLine();
            if (validaInputInt(alt))
                aulasTeoricas = Convert.ToInt32(alp);
            else
                return false;

            Console.WriteLine("Digite a quantidade de creditos");
            string crt = Console.ReadLine();
            if (validaInputInt(crt))
                creditos = Convert.ToInt32(alp);
            else
                return false;

            Console.WriteLine("Digite a quantidade TOTALR de horas aula");
            string ttha = Console.ReadLine();
            if (validaInputInt(ttha))
                totalHA = Convert.ToInt32(alp);
            else
                return false;

            Console.WriteLine("Digite a quantidade TOTAL de horas relógio");
            string tthr = Console.ReadLine();
            if (validaInputInt(tthr))
                totalHR = Convert.ToInt32(alp);
            else
                return false;

           

            Console.WriteLine("Escreva o id do periodo");
            getPeriodos();
            string aux = Console.ReadLine();
            if (validaInputInt(aux))
                idPeriodo = Convert.ToInt32(aux);
            else
                return false;

            Periodo p = findPeriodobyId(idPeriodo);
            foreach (Disciplina disc in p.Disciplinas)
            {
                if (disc.Nome == nome)
                {
                    return false;
                }
            }
            Disciplina d = new Disciplina(codigo, nome, aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR);
            disciplinas.Add(d);
            if (p != null)
            {
                p.Disciplinas.Add(d);
                Curso curso = findCursobyPeriodo(p.Id);
                d.HRMudou += curso.AssinanteHR;
            }
            return true;
        }

        public static bool validaInputInt(string input)
        {
            try
            {
                Convert.ToInt16(input);
            }catch (FormatException)
            {
                Console.WriteLine("input inválido");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("input inválido");
                return false;
            }
            return true;
                
        }

        static void Main(string[] args)
        {
            // PARA VER OQ PRECISA FAZER VA E VIEW>TASK LIST OU CRTL+]
            //DONE: LOGICA ENTRE AS CLASSES
            //DONE: LOGICA PARA PEGAR OS VALORES DE PERIODO E CURSO AUTOMATICO -> UTILIZEI OS METODOS SET E GET MESMO !!
            //DONE: LOGICA PARA ADICIONAR AS PARADAS PELO MAIN
            //DONE: EXCEPTIONS PARA TIPO DE DADOS
            //TODO: FAZER AS PARADA DE TXT E XML
            //DONE: Fazer a logica de evento de disciplina

            //codigo, nome,aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR
            // exemplo hard code
            /*Disciplina d = new Disciplina(1,"tecprog1",30,30,20,60,100);
            Disciplina d2 = new Disciplina(2, "tecprog2", 40, 40, 20, 110, 200);
            Disciplina d3 = new Disciplina(3, "calculo1", 5, 60, 10, 110, 200);
            Disciplina d4 = new Disciplina(4, "calculo2", 5, 60, 15, 110, 200);

            Periodo p = new Periodo(1,0,0,0,0,0,1);
            Periodo p2 = new Periodo(2, 0, 0, 0, 0, 0,2);

            Curso c = new Curso(1, "BSI", 0, 0, 0, 0, 0);

            d.HRMudou += c.AssinanteHR;
            d2.HRMudou += c.AssinanteHR;
            d3.HRMudou += c.AssinanteHR; // tem q revisar isso aqui fazer quando vincular o periodo ao curso
            d4.HRMudou += c.AssinanteHR;

            List<Disciplina> pr1 = new List<Disciplina>();
            List<Disciplina> pr2 = new List<Disciplina>();

            disciplinas.Add(d);
            disciplinas.Add(d2);
            disciplinas.Add(d3);
            disciplinas.Add(d4);

            pr1.Add(d);
            pr1.Add(d2);
            pr2.Add(d3);
            pr2.Add(d4);

            p.Disciplinas = pr1;
            p2.Disciplinas = pr2;

            periodos = new List<Periodo>();
            periodos.Add(p);
            c.Periodos = periodos;
            c.Periodos.Add(p2);
            cursos.Add(c);
            //c.Imprimir();
            //d.TotalHR = 20;
            */
            // começo da interface via console
            string aux;
            int aux2;
            int disId;
            string input;
            int inpSwitch = 0;
            
            while (inpSwitch != 10)
            {
                escreveOpcoes();

                input = Console.ReadLine();

                if (validaInputInt(input))
                {
                    inpSwitch = Convert.ToInt16(input);
                    switch (inpSwitch)
                    {
                        case 1:
                            if (cursos.Count>0)
                                if (addDisciplina() == false)
                                {
                                    Console.WriteLine("Disciplina ja existe\n");
                                }

                            else
                            {
                                Console.WriteLine("Para criar disciplina é necessario criar algum curso primeiro\n");
                            }
                            break;
                        
                        case 2:
                            if (cursos.Count >0)
                                if (addPeriodo() == false)
                                {
                                    Console.WriteLine("Periodo ja existe\n");
                                }
                            else
                            {
                                Console.WriteLine("Para criar Periodo é necessario criar algum curso primeiro\n");
                            }
                            break;
                        
                        case 3:
                            if (addCurso() == false)
                                Console.WriteLine("Ja existe um curso com esse nome \n");
                            break;
                        case 4:
                            foreach (Curso curs in cursos)
                            {
                                curs.Imprimir();
                            }
                            break;
                        case 5:
                            foreach (Periodo prdos in periodos)
                            {
                                prdos.Imprimir();
                            }
                            break;
                        case 6:
                            foreach (Disciplina dcn in disciplinas)
                            {
                                dcn.Imprimir();
                            }
                            break;
                        case 7:
                            Console.WriteLine("Escolha a disciplina que voce deseja colocar um pré-requisito\n");
                            getDisciplinas();
                            aux = Console.ReadLine();
                            if (validaInputInt(aux))
                                aux2 = Convert.ToInt32(aux);
                            else
                                break;
                            Console.WriteLine("Escolha o pré-requisito\n");
                            disciplinaSemCall(aux2);
                            aux = Console.ReadLine();
                            if (validaInputInt(aux))
                               disId = Convert.ToInt32(aux);
                            else
                                break;

                            Disciplina disc1 = findDisciplinabyId(aux2);
                            Disciplina disc2 = findDisciplinabyId(disId);

                            disc1.PreRequisitos.Add(disc2);
                            
                            break;

                        case 8:
                            getDisciplinas();
                            Console.WriteLine("Digite o Id da disciplina que desaja modificar a Hora Relógio\n");
                            aux = Console.ReadLine();
                            if (validaInputInt(aux))
                                aux2 = Convert.ToInt32(aux);
                            else
                                break;
                            Disciplina disciplina = findDisciplinabyId(aux2);
                            Console.WriteLine("Digite o novo valor da hora relógio\n");
                            aux = Console.ReadLine();
                            if (validaInputInt(aux))
                                aux2 = Convert.ToInt32(aux);
                            else
                                break;
                            disciplina.TotalHR = aux2;
                            break;

                        case 9:
                            int pp;
                            Random rd = new Random();
                            int codigo = rd.Next(0, 10000);
                            Console.WriteLine("Digite o nome do curso\n");
                            string nome = Console.ReadLine();
                            Curso cur = new Curso(codigo, nome, 0, 0, 0, 0, 0);

                            rd = new Random();
                            codigo = rd.Next(0, 10000);
                            Console.WriteLine("Qual o período?\n");
                            string prd = Console.ReadLine();
                            if (validaInputInt(prd))
                                pp = Convert.ToInt32(prd);
                            else
                                break;

                            Periodo per = new Periodo(codigo, 0, 0, 0, 0, 0, pp);


                            int aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR;
                            rd = new Random();
                            codigo = rd.Next(0, 10000);
                            Console.WriteLine("Digite o nome da disciplina\n");
                            nome = Console.ReadLine();
                            Console.WriteLine("Digite a quantidade de aulas praticas\n");
                            string alp = Console.ReadLine();
                            if (validaInputInt(alp))
                                aulasPraticas = Convert.ToInt32(alp);
                            else
                                break;

                            Console.WriteLine("Digite a quantidade de aulas teoricas\n");
                            string alt = Console.ReadLine();
                            if (validaInputInt(alt))
                                aulasTeoricas = Convert.ToInt32(alt);
                            else
                                break;

                            Console.WriteLine("Digite a quantidade de creditos\n");
                            string crt = Console.ReadLine();
                            if (validaInputInt(crt))
                                creditos = Convert.ToInt32(crt);
                            else
                                break;

                            Console.WriteLine("Digite a quantidade TOTAL de horas aula\n");
                            string ttha = Console.ReadLine();
                            if (validaInputInt(ttha))
                                totalHA = Convert.ToInt32(ttha);
                            else
                                break;

                            Console.WriteLine("Digite a quantidade TOTAL de horas relógio\n");
                            string tthr = Console.ReadLine();
                            if (validaInputInt(tthr))
                                totalHR = Convert.ToInt32(tthr);
                            else
                                break;

                            Disciplina disc = new Disciplina(codigo, nome, aulasPraticas, aulasTeoricas, creditos, totalHA, totalHR);
                            disciplinas.Add(disc);
                            periodos.Add(per);
                            per.Disciplinas.Add(disc);
                            cursos.Add(cur);
                            cur.Periodos.Add(per);
                            disc.HRMudou += cur.AssinanteHR;
                            
                            break;
                        
                        case 10:
                            Console.WriteLine("Tchau foi um prazer te conhecer\n");
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Digite um numero válido\n");
                }
            }
            
            
            

            


        }
    }
}
