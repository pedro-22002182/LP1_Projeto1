using System;
namespace Projeto1
{
    public class Interface
    {
        Tabuleiro tabuleiro;
        Player playerA;
        Player playerB;

        public Interface (Tabuleiro tabuleiro, Player playerA ,Player playerB)
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
                for(int y = 0; y < tabuleiro.getMap().GetLength(1); y++)
                {
                    Console.Write(tabuleiro.getMap()[x,y]);
                }
                Console.Write("\n");
            }

            

        }


    }


}