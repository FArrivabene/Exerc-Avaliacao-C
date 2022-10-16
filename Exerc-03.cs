using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerc_Avaliação_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Variáveis declaradas
            bool valido;
            bool inicioLeitura = true;
            int qtdHabit, qtdFilhos, naoFilho = 0, temFilhos = 0, qtdRenMenor = 0;
            float maiorRend = 0, menorRend = 0;
            float rendMensal = 0, auxSomaRend = 0, auxSomaFilho = 0 ;

            // Validação e entrada do número de habitantes que será feito a leitrura
            do
            {
                Console.Write("\n\tDigite o número de habitantes:   ");
                if ((valido = int.TryParse(Console.ReadLine(), out qtdHabit)) == false || qtdHabit < 0)
                    Console.WriteLine("\n\tNúmero inválido, digite novamente!");
            } while (valido == false || qtdHabit < 0);

            // Repetição da pergunta consoante o número de habitantes
            for (int i = 1; i <= qtdHabit; i++)
            {
                // Entrada valor Rendimento
                do
                {
                    Console.Write($"\n\tDigite o rendimento mensal do {i}º agregado:   ");
                    if ((valido = float.TryParse(Console.ReadLine(), out rendMensal)) == false || rendMensal < 0)
                        Console.WriteLine("\n\tValor inválido, digite novamente!");
                } while (valido == false || rendMensal < 0);
                auxSomaRend += rendMensal;

                // Inicio a verificação e atribuição dos valores nas variáveis utilizando um bool
                if (inicioLeitura == true)
                {
                    maiorRend = rendMensal;
                    menorRend = rendMensal;
                }

                // Altero para falso, pois realizou o loop
                inicioLeitura = false;

                // Realizo a comparação MAIOR
                if (rendMensal > maiorRend)
                {
                    maiorRend = rendMensal;
                }

                // Realizo a comparação MENOR
                if (rendMensal < menorRend)
                {
                    menorRend = rendMensal;
                }

                // Se o rendimento menor que 900 guardo essa info
                if (rendMensal < 900)
                    qtdRenMenor++;

                // Validação e entrada do numero de fihlos
                do
                {
                    Console.Write($"\tDigite o número de filhos do {i}º agregado:   ");
                    if ((valido = int.TryParse(Console.ReadLine(), out qtdFilhos)) == false || qtdFilhos < 0)
                        Console.WriteLine("\n\tNúmero inválido, digite novamente!");
                } while (valido == false || qtdFilhos < 0);

                if (qtdFilhos == 0)
                {
                    naoFilho++;
                    auxSomaFilho += qtdFilhos;
                }
                                  
                if(qtdFilhos > 0)
                {
                    temFilhos++;
                    auxSomaFilho += qtdFilhos;
                }                  
            }
            //Apresentação dos resultados
            Console.WriteLine($"\n\tA média de rendimentos dos agregados familiares é de: {auxSomaRend / qtdHabit:0.00}€");
            Console.WriteLine($"\tA média do número de filhos é de: {auxSomaFilho / qtdHabit:0.00}");
            Console.WriteLine($"\tO maior rendimento no total de agregados é de: {maiorRend}");
            Console.WriteLine($"\tO menor rendimento no total de agregados é de: {menorRend}");
            Console.WriteLine($"\tA percentagem de agregados sem filhos é de: {(naoFilho * 100) / qtdHabit:0.00}%");
            Console.WriteLine($"\tA percentagem de agregados com rendimento menor que 900€ é de: {(qtdRenMenor * 100) / qtdHabit:0.00}%");
        }
    }
}
