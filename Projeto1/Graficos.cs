using System;
namespace Projeto1
{

    /// <summary>
    /// Função responsável pelos prints do jogo
    /// </summary>
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

        //Imprimir o mapa, consoante as peças e casas especiais
        public void showMap()
        {
            Console.WriteLine("-----------------------------------------------");


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
                    //Casas com flor
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
            Console.WriteLine();
        }


        //Mostrar o Score
        public void showScore()
        {
            Console.WriteLine("PlayerA Score: " + playerA.getScore() + "                 PlayerB Score: " + playerB.getScore());
        }


        //Imprimir Menu
        public void Menu()
        {
            Console.WriteLine("Bem vindo ao jogo Royal Game Of Ur\n (1)---------Iniciar Novo Jogo \n (2)---------Regras \n (3)---------Controles \n (4)---------Quit");
            Console.WriteLine();
        }


        //Imprimir Regras
        public void Regras()
        {
            Console.WriteLine("REGRAS:");
            Console.WriteLine(" - O jogo Royal Game of Ur é jogado num tabuleiro 3 por 8.\n - O jogo é jogado por dois jogadores, jogadorA e jogadorB, onde cada um possui 7 peças.\n - O objectivo de cada jogador é conseguir fazer com que todas as suas peças cheguem ao fim do tabuleiro.\n - A cada turno, o jogador lança 1 dado numerado de 0 a 4.\n - O jogador avança uma peça, ou mete em jogo uma nova peça, e avança o número de espaços que este obteve no lançamento dos dados.\n - Para chegar a peça efetuar um ponto e chegar ao fim do tabuleiro, o jogador tem que obter exatamente o mesmo valor de espaços em falta nos dados.");
            Console.WriteLine();
        }
        
        
        //Imprimir Controles
        public void Controles()
        {
            Console.WriteLine("CONTROLES:");
            Console.WriteLine(" - Caso seja a tua vez, primeiro terás de lançar o dado, carregando no enter;");
            Console.WriteLine(" - Consoante o valor calhado terás de escolher a peça a ser mexida;");
            Console.WriteLine(" - Para tal, poderás colocar as coordenas da casa onde está uma peça tua (ex: 1_2)");
            Console.WriteLine(" - Ou podes colocar apenas um espaço para mexer instantaneamente uma peca da base!");
            Console.WriteLine(" - Identificação das peças:\n       * - representa uma casa com flor\n       1 - representa uma casa com uma peça do Player A\n       2 - representa uma casa com uma peça do Player B\n");
        }
    }


}