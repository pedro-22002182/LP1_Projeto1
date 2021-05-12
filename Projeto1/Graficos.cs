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
                //reading y
                for(int y = 0; y < tabuleiro.getMap().GetLength(1); y++)
                {
                    //empty spaces
                    if(tabuleiro.getMap()[x,y] == 9)
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

        public void printMenu()
        {
            Console.WriteLine("Welcome to Royal Game Of Ur!!");
            Console.WriteLine("Regras:\nO jogo é jogado por dois jogadores onde cada jogador tem 7 peças cada.");
            Console.WriteLine("O objectivo do jogo é conseguir com que todas as peças cheguem ao fim do tabuleiro.");
            Console.WriteLine("A cada turno o jogador lança 1 dado numerado de 0 a 4.");
            Console.WriteLine("O jogador avança uma peça, ou mete em jogo uma nova peça, e avança o número de espaços que este obteve no lançamento dos dados.");
            Console.WriteLine("Para chegar ao fim o jogador tem que obter exatamente o mesmo valor de espaços em falta nos dados.");
            Console.WriteLine("Se a peça do jogador calhar na peça do seu oponente a peça do oponente volta para a mão dele, e a do jogador fica com o espaço, exceto se calhar numa casa com flor(*), pois esta é uma casa segura.");
            
        }
        


    }
}