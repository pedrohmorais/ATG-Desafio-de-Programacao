using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_1
{
    /// <summary>
    ///     Escreva um programa que receba um número e
    ///     depois uma lista circularmente ordenada(sem repetições)
    ///     separada por virgula e responda, o mais rápido possível,
    ///     se um número pertence ou não à lista
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey tecla;
            //cria um while para permitir varias operacoes
            while (true) { 
                operacao();
                Console.WriteLine("Pressione a tecla \"Esc\" para fechar o programa ou \"Enter\" para voltar ao início:");
                do
                {
                    tecla = Console.ReadKey(true).Key;
                    if (tecla == ConsoleKey.Escape)
                        Environment.Exit(0);
                } while (tecla != ConsoleKey.Enter);

            }

        }

        static void operacao()
        {
            string sNumero;
            string sLista;
            int numero;
            bool result;
            List<int> lista = new List<int>();
            //recebe o número e verifica se é inteiro
            do
            {
                Console.WriteLine("Entre com um número inteiro:");
                sNumero = Console.ReadLine();
                result = Int32.TryParse(sNumero, out numero);
                if (!result)
                    Console.WriteLine("Número inválido!");

            } while (!result);

            //recebe a lista
            result = false;
            do
            {
                Console.WriteLine("Entre com uma lista circularmente ordenada:");
                sLista = Console.ReadLine();
                try
                {
                    lista = sLista.Split(',').Select(Int32.Parse).ToList();
                    result = true;
                    if (lista.GroupBy(n => n).Any(c => c.Count() > 1))
                    {
                        Console.WriteLine("Existem valores duplicados na lista, digite \"S\" caso queira que o sistema tira os valores duplicados automaticamente:");
                        string decisao = Console.ReadLine();
                        if (decisao.ToLower().Equals("s"))
                        {
                            lista = lista.Distinct().ToList();
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }

            } while (!result);

            //verifica se numero existe
            string resposta = lista.Any(x => x.Equals(numero)) ? "sim" : "não";
            //Console.WriteLine(string.Format("O número {0}{1} pertense à lista!",numero,resposta));

            Console.WriteLine(resposta);
        }
    }
}
