using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerc_Avaliação_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char escolha;
            bool valido;
            int ano = DateTime.Now.Year;
            int numEmp, anoNasc, anoEmpresa, idade, tempoTrab = 0, anoMin = 0;

            do
            {

                // Pedido e validação do número do empregado.
                do
                {
                    Console.Write("\n\tDigite o número do empregado:   ");
                    if ((valido = int.TryParse(Console.ReadLine(), out numEmp)) == false || numEmp > 999)
                        Console.WriteLine("\tNúmero inválido, digite novamente!");
                } while (valido == false || numEmp > 999);

                // Pedido e validação do ano que nasceu.
                do
                {
                    Console.Write("\tDigite o ano em que nasceu:   ");
                    if ((valido = int.TryParse(Console.ReadLine(), out anoNasc)) == false || anoNasc > ano || anoNasc < 1920)
                        Console.WriteLine("\n\tAno de nascimento inválido, digite novamente!");
                } while (valido == false || anoNasc > ano || anoNasc < 1920);

                // Se ano de nasc for inferior ou igaul a 1974 validar a idade mínima de trabalho
                if (anoNasc <= 1962)
                    anoMin = anoNasc + 12;

                // Se ano de nasc for maior que 1974 validar a idade minima de trabalho
                if (anoNasc > 1962)
                    anoMin = anoNasc + 16;

                // Pedido e validação do ingresso na empresa com a validação da idade mínima para trabalhar
                do
                {
                    Console.Write("\n\tDigite o ano em que ingressou na empresa:   ");
                    if ((valido = int.TryParse(Console.ReadLine(), out anoEmpresa)) == false || anoEmpresa > ano || anoEmpresa < anoMin || anoEmpresa >= 1974 && anoEmpresa < anoNasc +16)
                        Console.WriteLine("\tAno de ingresso inválido, digite novamente!");
                } while (valido == false || anoEmpresa > ano || anoEmpresa < anoMin || anoEmpresa >= 1974 && anoEmpresa < anoNasc + 16);

                // Calcular idade do empregado
                idade = ano - anoNasc;

                // Calcular tempo de empresa do empregado já com a validação mínima de trabalho
                tempoTrab = ano - anoEmpresa;

                // Condição para obter a reforma
                if (idade >= 65)
                {
                    Console.WriteLine($"\n\tO empregado nº{numEmp} tem {idade} anos.");
                    Console.WriteLine("\tO empregado esta apto para pedir a reforma!");
                }

                // Condição para obter a reforma
                else if (tempoTrab >= 30)
                {
                    Console.WriteLine($"\n\tO empregado nº{numEmp} tem {idade} anos e {tempoTrab} anos de trabalho.");
                    Console.WriteLine("\tO empregado esta apto para pedir a reforma!");
                }

                // Condição para obter a reforma
                else if (idade >= 60 && tempoTrab >= 25)
                {
                    Console.WriteLine($"\n\tO empregado nº{numEmp} tem {idade} anos e {tempoTrab} anos de trabalho.");
                    Console.WriteLine("\tO empregado esta apto para pedir a reforma!");
                }

                // Se não preencher nenhuma condição...
                else
                {
                    Console.WriteLine($"\n\tO empregado nº{numEmp} tem {idade} anos e {tempoTrab} anos de trabalho.");
                    Console.WriteLine("\tO empregado não esta apto para pedir a reforma!");
                }

                // Perguntar se quer introduzir mais dados.
                do
                {
                    Console.Write("\n\tGostaria de verificar mais um colaborador?  \n\t[S] - SIM       \n\t[N] - NÃO   \n\t» ");
                    if ((valido = char.TryParse(Console.ReadLine().ToUpper(), out escolha)) == false || (escolha != 'N' && escolha != 'S'))
                        Console.WriteLine("\n\tEscolha inválida, digite novamente!");
                } while (valido == false && (escolha != 'N' && escolha != 'S'));
            } while ((escolha == 'S'));
        }
    }
}
