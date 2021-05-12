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
                
                Console.ReadLine();
                int numeroPassos = lancarDados();
                
                Console.WriteLine("Coloca coordenas (ex: 1_2) da peça a ser mexida ou, mexer nova peça espaço");
                string escolha = Console.ReadLine();

                if(escolha == " ")
                {
                    if(turno == true)
                    {
                        if(tabuleiro.getMap()[0,4] == 1)
                        {
                            Peca pecaMexer = tabuleiro.pegaPeca(0,4);
                            tabuleiro.moverPeca(pecaMexer, numeroPassos, playerA);
                        }
                    }
                    else
                    {
                        if(tabuleiro.getMap()[2,4] == 1)
                        {
                            Peca pecaMexer = tabuleiro.pegaPeca(2,4);
                            tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB);
                        }
                    }

                }
        
            }
            
        }

        static int lancarDados()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0,5);

            Console.WriteLine($" O numero é {valorInteiro}");
            return valorInteiro;
        }



    }
}
