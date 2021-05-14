using System;
namespace Projeto1
{
    public class Graficos
    {
        Tabuleiro tabuleiro;
        Player playerA;
        Player playerB;

        public Graficos (Tabuleiro tabuleiro, Player playerA ,Player playerB)
        {
            this.tabuleiro = tabuleiro;
            this.playerA = playerA;
            this.playerB = playerB;

        }

        public void showMap()
        {
            //reading x
            for(int x = 0; x < tabuleiro.getMap().GetLength(0); x++)
            {
                Console.Write("                 ");
                //reading y
                for(int y = 0; y < tabuleiro.getMap().GetLength(1); y++)
                {
                    //empty spaces
                    if(tabuleiro.checkCasasVazias(x,y))
                    {
                        Console.Write(" ");
                    } 
                    //Flwoer Tiles
                    else if(tabuleiro.getMap()[x,y] == 3) 
                    {
                        Console.Write("*");
                    }
                    else 
                    {
                        Console.Write(tabuleiro.getMap()[x,y]);
                    }
                    
                }

                Console.Write("\n");
            }
        }

        public void showScore()
        {
            Console.Write("PlayerA Score: " + playerA.getScore() + "                 PlayerB Score: " + playerB.getScore());
        }

        public void Menu()
        {
            Console.WriteLine("Bem vindo ao jogo Royal Game Of Ur\n (1)---------Iniciar Novo Jogo \n (2)---------");
        }

    }


}