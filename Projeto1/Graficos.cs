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
                Console.Write("                    ");
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
            Console.WriteLine("PlayerA Score: " + playerA.getScore() + "                 PlayerB Score: " + playerB.getScore());
        }

        public void Menu()
        {
            Console.WriteLine("Bem vindo ao jogo Royal Game Of Ur\n (1)---------Iniciar Novo Jogo \n (2)---------Regras (3)---------Quit");
        }


        public void Regras()
        {
            Console.WriteLine("Regra1: O jogo Royal Game of Ur é jogado num tabuleiro 3 por 8.\n Regra2: O jogo é jogado por dois jogadores onde cada jogador tem 7 peças cada.\n Regra3: O objectivo do jogo é conseguir com que todas as peças cheguem ao fim do tabuleiro.\n Regra4: A cada turno o jogador lança 1 dado numerado de 0 a 4.\n Regra5:O jogador avança uma peça, ou mete em jogo uma nova peça, e avança o número de espaços que este obteve no lançamento dos dados.\n Regra6:Para chegar ao fim o jogador tem que obter exatamente o mesmo valor de espaços em falta nos dados.");
        }
    }


}