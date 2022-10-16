using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Exerc_Avaliação_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Output para aparecer o caracter "€"
            Console.OutputEncoding = Encoding.UTF8;

            // Declarar as variáveis existentes
            float peso, aux = 0, pMedio, cont = 1;
            bool valido;
            char escolha;

            // Pedir o peso dos artigos e se quer add mais produtos
            do
            {
                // Validar a entrada e pedido dos pesos dos produtos
                do
                {
                    Console.Write($"\n\tDigite o peso da {cont}º carga em (kg):   ");
                    if ((valido = float.TryParse(Console.ReadLine(), out peso)) == false || peso < 0)
                        Console.WriteLine("\n\tPeso inválido, digite novamente!");
                } while (valido == false || peso < 0);
                cont++;         // Add contador para cada produto
                aux += peso;    // Faz a soma do peso de cada produto

                // Validar se quer add mais produtos
                do
                {
                    Console.Write("\n\tQuer adicionar mais uma carga?  \n\t[S] - SIM       \n\t[N] - NÃO   \n\t» ");
                    if ((valido = char.TryParse(Console.ReadLine().ToUpper(), out escolha)) == false || (escolha != 'N' && escolha != 'S'))
                        Console.WriteLine("\n\tEscolha inválida, digite novamente!");
                } while (valido == false && (escolha != 'N' && escolha != 'S'));
            } while ((escolha == 'S'));

            // Fazer o cálculo do peso médio dos produtos
            pMedio = aux / (cont-1);
            Console.WriteLine($"\n\tO peso médio dos produtos é de {pMedio:0.00} kg.");

            // Declarar a variável do peso superior
            float pesoSuperior;
            pesoSuperior = aux - 500; // Peso superio/excedente é igual ao peso total - (500 que é o peso máximo permitido)

            // Se peso superior maior que zero e menor ou igaul a 100
            if (pesoSuperior > 0 && pesoSuperior <= 100)
            {
                Console.WriteLine($"\n\tO peso superior é de {pesoSuperior}kg.");
                Console.WriteLine($"\tSerá necessário pagar 5€ a mais por cada quilo, total de = {pesoSuperior * 5}€");
            }

            // Se peso superior maior que zero e menor ou igual a 300
            else if(pesoSuperior > 0 && pesoSuperior <= 300)
            {
                Console.WriteLine($"\n\tO peso superior é de {pesoSuperior}kg.");
                Console.WriteLine($"\tSerá necessário pagar 8€ a mais por cada quilo, total de = {pesoSuperior * 8}€");
            }

            //Se peso superior maior que zero e menor ou igual a 500
            else if(pesoSuperior > 0 && pesoSuperior <= 500)
            {
                Console.WriteLine($"\n\tO peso superior é de {pesoSuperior}kg.");
                Console.WriteLine($"\tSerá necessário pagar 10€ a mais por cada quilo, total de = {pesoSuperior * 10}€");
            }

            // Se peso superior maior que zero e maior que 500
            else if (pesoSuperior > 0 && pesoSuperior > 500)
            {
                Console.WriteLine($"\n\tO peso superior é de {pesoSuperior}kg.");
                Console.WriteLine($"\tSerá necessário pagar 15€ a mais por cada quilo, total de = {pesoSuperior * 15}€");
            }

            // Se o peso total for menor ou igual a zero
            else if(pesoSuperior <= 0)
            {
                Console.WriteLine($"\n\tSem multa por peso excedente!");
            }
        }
    }
}
