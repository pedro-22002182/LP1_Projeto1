using System;

namespace Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            Player playerA = new Player();
            Player playerB = new Player();
            Graficos graficos = new Graficos(tabuleiro, playerA, playerB);


            Console.WriteLine($" {graficos.showMap()}");

            
            
        }
    }
}
