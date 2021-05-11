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
        public void movimentoPeca (int passos, Player jogador)
        {
            int xnovo = posX;
            int ynovo = posY;

            for(int i = 0; i < passos; i++)
            {
                //se jogadorA
                if(player == true)
                {
                    //check vitoria Peca
                    if(xnovo == 0 && ynovo == 5)
                    {
                        //ponto DO
                        if(passos == 0)
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

                    if(xnovo == 0 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }

                    if(xnovo == 0 && ynovo == 0)
                    {
                        xnovo += 1;
                    }

                    if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }

                    if(xnovo == 1 && ynovo == 7)
                    {
                       xnovo-= 1;
                    }
                }
                
                //se jogadorB
                if(player == false)
                {
                    //check vitoria Peca
                    if(xnovo == 2 && ynovo == 5)
                    {
                        //ponto DO
                        if(passos == 0)
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

                    //terceira linha até chegar ao topo
                    if(xnovo == 2 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }

                    //se tiver no canto direito superior
                    if(xnovo == 2 && ynovo == 0)
                    {
                        xnovo -= 1;
                    }

                    //se tiver linha meio
                    if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }

                    //se tiver linha meio e na casa 7
                    if(xnovo == 1 && ynovo== 7)
                    {
                        xnovo += 1;
                    }
                }
            }
            posX = xnovo;
            posY = ynovo;
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
        
    }
}