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
        
        //TL;DR: move a peça em direçao x y + ou - dependendo da casa em que passar
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
            int xnovo = posX;
            int ynovo = posY;

            for(int i = passos; i > 0; i--)
            {
                //se jogadorA
                if(player == true)
                {
                    //check vitoria Peca
                    if(xnovo == 0 && ynovo == 5)
                    {
                        //ponto DO
                        if(i == 1)
                        {
                            jogador.plusPontos();
                        }
                        else
                        {
                            //retorna à posicao onde forma lancados os dados
                            xnovo = posX;
                            ynovo = posY;
                        }
                    }
                    
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
                }
            }
            int[] posPreview = new int[]{xnovo, ynovo};

            return posPreview;
        }
        
    }
}