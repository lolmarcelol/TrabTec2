using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TrabTecprog2.Class
{
    class FileHandler
    {
        /// <summary>
        /// Transforma um txt para xml, função do tde1
        /// </summary>
        /// <param name="caminho do arquivo txt"></param>
        /// <param name="caminho do arquivo xml"></param>
        /// <param name="nome raiz do xml, ou nome do curso"></param>
        /// <returns></returns>
        public bool txtToXml(string parametro1, string parametro2, string parametro3)
        {
            
            if (!File.Exists(parametro1))
            {
                
                Console.WriteLine("Erro: " + "especifique aqui o erro");
                return false;
            }
            
            StreamReader leitor = new StreamReader(parametro1, Encoding.Default);

            
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("Curso");
            raiz.SetAttribute("nome", parametro3);
            documento.AppendChild(raiz);

            
            string linha = null;
            string[] atributos = null;
            XmlElement elementoPeriodo = null;

            
            while ((linha = leitor.ReadLine()) != null)
            {
                string valor = linha.Trim();
                if (valor.EndsWith("Período"))
                {
                    elementoPeriodo = documento.CreateElement("periodo");
                    valor = valor.Replace("Período", "");
                    valor = valor.Trim();
                    elementoPeriodo.SetAttribute("numero", valor);
                    raiz.AppendChild(elementoPeriodo);
                }
                else if (valor.StartsWith("Ordem"))
                {
                    
                    atributos = linha.Split('\t');
                }
                else if (valor.StartsWith("Total"))
                {
                    
                    string[] colunas = valor.Split('\t');
                    
                    int indiceInicial = 3;
                    foreach (string coluna in colunas)
                    {
                        try
                        {
                            
                            int numero = Convert.ToInt32(coluna.Trim());
                            
                            elementoPeriodo.SetAttribute(atributos[indiceInicial].Trim(), numero.ToString());
                            indiceInicial++;
                        }
                        catch
                        {
                            
                        }
                    }
                }
                else if (valor.Length > 0)
                {
                    
                    string[] valores = valor.Split('\t');
                    XmlElement elementoDisciplina = documento.CreateElement("disciplina");
                    for (int i = 0; i < valores.Length && i < atributos.Length; i++)
                    {
                        
                        elementoDisciplina.SetAttribute(atributos[i].Trim(), valores[i].Trim());
                    }
                    
                    elementoPeriodo.AppendChild(elementoDisciplina);
                }
            }

            documento.Save(parametro2);
            Console.WriteLine("Operação realizada com sucesso!");
            return true;
        }



    }
}
