using System;

namespace Projeto1
{

    public class Peca
    {
        private int posX, posY;

        private bool player; //se true então pertecen ao jogador A, se false pertence B

        
        public Peca(bool player)
        {
            //posicao inical da peca ("fora tabuleiro")
            if(player == true)
            {
                this.posX = 0;
                this.posY = 4;
            }
            else if(player == false)
            {
                this.posX = 2;
                this.posY = 4;
            }
            

            //pertence ao jogadorA?? B?
            this.player = player;
        }
        
        //Move a peça em direçao x y + ou - dependendo da casa em que passar
        public void SetPos(int novoX, int novoY)
        {
            posX = novoX;
            posY = novoY;
        }
            


        public int[] GetPos()
        {
            int[] pos = new int[]{posX, posY};
            return pos;
        }

        public bool GetPlayer()
        {
            return player;
        }


        public void ComerPeça()
        {
            if(player == true)
            {
                posX = 0;
                posY = 4;
            }
            else if (player == false)
            {
                posX = 2;
                posY = 4;
            }
        }

    
        public int[] GetPreviewsPos(int passos, Player jogador)
        {

            //se já tiverem feito ponto
            if(posX == 0 && posY == 5 || posX == 2 && posY == 5)
            {
                int[] pecaPonto = new int[]{posX, posY};
                return pecaPonto;
            }


            int xnovo = posX;
            int ynovo = posY;

            for(int i = passos; i > 0; i--)
            {
                //se jogadorA
                if(player == true)
                {                
                    //Orientaçao das pecas no board
                    if(xnovo == 0 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }
                    else if(xnovo == 0 && ynovo == 0)
                    {
                        xnovo += 1;
                    }
                    else if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }
                    else if(xnovo == 1 && ynovo == 7)
                    {
                       xnovo-= 1;
                    }

                    //check vitoria Peca
                    if(xnovo == 0 && ynovo == 5)
                    {
                        //ponto DO
                        if(i == 1)
                        {
                            jogador.plusPontos();
                            Console.WriteLine("\n Fizeste um ponto!");
                            break;
                        }
                        else
                        {
                            //retorna à posicao onde foram lancados os dados
                            xnovo = posX;
                            ynovo = posY;
                            Console.WriteLine("\n Não é possível o movimento");
                            break;
                        }
                    }
                }
                //se jogadorB
                else if(player == false)
                {
                    //Orientaçao das pecas no board
                    if(xnovo == 2 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }
                    else if(xnovo == 2 && ynovo == 0)
                    {
                        xnovo -= 1;
                    }
                    else if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }
                    else if(xnovo == 1 && ynovo == 7)
                    {
                       xnovo += 1;
                    }

                    //check vitoria Peca
                    if(xnovo == 2 && ynovo == 5)
                    {
                        //ponto DO
                        if(i == 1)
                        {
                            jogador.plusPontos();
                            Console.WriteLine("\n Fizeste um ponto!");
                            break;
                        }
                        else
                        {
                            //retorna à posicao onde forma lancados os dados
                            xnovo = posX;
                            ynovo = posY;
                            Console.WriteLine("\n Não é possível o movimento");
                            break;
                        }
                    }
                }
            }

            int[] posPreview = new int[]{xnovo, ynovo};
            return posPreview;
        }
        
    }
}