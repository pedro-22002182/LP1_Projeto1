using System;

namespace Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates board
            Tabuleiro tabuleiro = new Tabuleiro();

            //cria dois jogadores e chama graficos com info tabuleiro e players A e B
            Player playerA = new Player();
            Player playerB = new Player();
            Graficos graficos = new Graficos(tabuleiro, playerA, playerB);

            graficos.printMenu();
            graficos.showMap();

            //Game loop
            bool acabou = false;
            
            //Quando é true é o playerA a jogar e quando é false é o playerB
            bool turno = true;

            
            

            while (acabou == false)
            {
                graficos.showMap();
                if(turno == true) 
                    Console.WriteLine("É a vez do playerA");
                else
                    Console.WriteLine("É a vez do playerB");


                Console.WriteLine("Para lançar os dados clica no enter");
                
                string autorizao = Console.ReadLine();
                
            }
            
        }

        public int LançarDados()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0,5);

            Console.WriteLine($" O numero é {valorInteiro}");
            return valorInteiro;
        }



    }
}
