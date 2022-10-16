using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Exerc_Avaliação_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
        inicio:
            int voto=1, v1 = 0, v2 = 0, v3 = 0, v4 = 0, vBranco = 0, vNulo = 0;
            bool valido = true;
            char escolha;

            // Cabeçalho para o programa
            Console.WriteLine("\n\t-- ELEIÇÕES 2022 --");

            // Utilizar um loop para os votos 
            while (voto != 0)
            {
                // Validação da entrada para o voto com as condiçoes
                do
                {
                    Console.Write("\tDigite o seu voto:   ");
                    if ((valido = int.TryParse(Console.ReadLine(), out voto)) == false || (voto != 0 && voto != 1 && voto != 2 && voto != 3 && voto != 4 && voto != 5 && !(voto >= 6)))
                        Console.WriteLine("\n\tVoto inválido, digite novamente!");
                } while (valido == false || (voto != 0 && voto != 1 && voto != 2 && voto != 3 && voto != 4 && voto != 5 && !(voto >= 6)));

                //Condições para cada voto

                if (voto == 1)      //Soma +1 para candidato 1
                    v1++;

                if (voto == 2)      //Soma +1 para candidato 2
                    v2++;

                if (voto == 3)      //Soma +1 para candidato 3
                    v3++;

                if (voto == 4)      //Soma +1 para candidato 4
                    v4++;

                if (voto == 5)      //Soma +1 para voto em Branco
                    vBranco++;

                if (voto >= 6)      //Soma +1 para voto Nulo
                    vNulo++;
            }

            // Limpar os votos e apresentar apenas os resultados
            Console.Clear();

            Console.WriteLine($"\n\tTotal votos nulos        = {vNulo} voto(s)");
            Console.WriteLine($"\tVotos em branco          = {vBranco} voto(s)");
            Console.WriteLine($"\tVotos para o Candidato 1 = {v1} voto(s)");
            Console.WriteLine($"\tVotos para o Candidato 2 = {v2} voto(s)");
            Console.WriteLine($"\tVotos para o Candidato 3 = {v3} voto(s)");
            Console.WriteLine($"\tVotos para o Candidato 4 = {v4} voto(s)");

            // Escrita visual
            Console.WriteLine("\n\t     -- RESULTADO DAS ELEIÇÕES --");

            // Verificar qual candidato ganhou || empatou as eleiçoes
            if ((v1 == v2 && v2 == v3 && v3 == v4))
                Console.WriteLine("\n\tOs candidatos obtiveram os mesmos votos!");
            else if (v1 == v2 && v2 == v3 && v3 > v4)
                Console.WriteLine("\n\tOs candidatos 1, 2 e 3 obtiveram os mesmos votos!");
            else if (v1 == v2 && v2 == v4 && v4 > v3)
                Console.WriteLine("\n\tOs candidatos 1, 2 e 4 obtiveram os mesmos votos!");
            else if (v1 == v3 && v3 == v4 && v4 > v2)
                Console.WriteLine("\n\tOs candidatos 1, 3 e 4 obtiveram os mesmos votos!");
            else if (v2 == v3 && v3 == v4 && v4 > v1)
                Console.WriteLine("\n\tOs candidatos 2, 3 e 4 obtiveram os mesmos votos!");
            else if (v1 == v2 && v2 > v3 && v2 > v4)
                Console.WriteLine("\n\tOs candidatos 1 e 2 obtiveram os mesmos votos!");
            else if (v1 == v3 && v3 > v2 && v3 > v4)
                Console.WriteLine("\n\tOs candidatos 1 e 3 obtiveram os mesmos votos!");
            else if (v1 == v4 && v4 > v3 && v4 > v2)
                Console.WriteLine("\n\tOs candidatos 1 e 4 obtiveram os mesmos votos!");
            else if (v2 == v3 && v3 > v1 && v3 > v4)
                Console.WriteLine("\n\tOs candidatos 2 e 3 obtiveram os mesmos votos!");
            else if (v2 == v4 && v4 > v1 && v4 > v3)
                Console.WriteLine("\n\tOs candidatos 2 e 4 obtiveram os mesmos votos!");
            else if (v3 == v4 && v4 > v1 && v4 > v2)
                Console.WriteLine("\n\tOs candidatos 3 e 4 obtiveram os mesmos votos!");
            else if (v1 > v2 && v1 > v3 && v1 > v4)
                Console.WriteLine("\n\tO candidato 1 é o vencedor da eleição!");
            else if (v2 > v3 && v2 > v4)
                Console.WriteLine("\n\tO candidato 2 é o vencedor da eleição!");
            else if (v3 > v4)
                Console.WriteLine("\n\tO candidato 3 é o vencedor da eleição!");
            else
                Console.WriteLine("\n\tO candidato 4 é o vencedor da eleição!");

            // Pergunta para caso queira, realizar uma nova eleição
            do
            {
                Console.Write("\n\tGostaria de realizar mais uma eleição?  \n\t[S] - SIM       \n\t[N] - NÃO   \n\t» ");
                if ((valido = char.TryParse(Console.ReadLine().ToUpper(), out escolha)) == false || (escolha != 'N' && escolha != 'S'))
                    Console.WriteLine("\n\tEscolha inválida, digite novamente!");
            } while (valido == false && (escolha != 'N' && escolha != 'S'));

            // Condição para SIM
            if (escolha == 'S' || escolha == 's')
            {
                // Limpa o console e reinicia a eleição
                Console.Clear();
                goto inicio;
            }
            // Condição para NÃO    
            if (escolha == 'N' || escolha == 'n')
                Console.WriteLine("\n\tObrigado por votar!");
        }
    }
}
