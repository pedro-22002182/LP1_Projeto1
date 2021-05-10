namespace Projeto1
{
    public class Tabuleiro
    {
        private int[][] tabuleiro; 

        private Peca[] pecas;

        public Tabuleiro()
        {
            this.tabuleiro = new int [2][7];
            this.pecas = new Peca[13];

            for(int i = 0; i < pecas.Length(); i++)
            {
                if(i <= 7)
                {
                    //criacao 7 pecas jogador A
                    pecas[i] = new Peca(true);
                }
                else
                {
                    //criacao 7 pecas jogador B
                    pecas[i] = new Peca(false);
                }
            }

        }


        public bool CheckFlower(int x, int y)
        {
            if(x == 0 && y == 0)
            {
                return true;
            }
            else if(x == 2 && y == 0)
            {
                return true;
            }
            else if(x == 1 && y == 3)
            {
                return true;
            }
            else if(x == 0 && y == 6)
            {
                return true;
            }
            else if(x == 2 && y == 6)
            {
                return true;
            }

            return false;
        }

        public void movimentoPeca(Peca peca, int passos, Player jogador)
        {
            int xPeca = peca.GetPos()[0];
            int yPeca = peca.GetPos()[1];


            for(int i = 0; i < passos; i++)
            {
                //check vitoria Peca
                if(xPeca == 0 && yPeca == 5)
                {
                    //ponto DO
                    if(passos == 0)
                    {
                        jogador.plusPontos();
                    }
                    else
                    {
                        xPeca = peca.GetPos()[0];
                        yPeca = peca.GetPos()[1];
                    }
                }


                if(xPeca == 0 && yPeca > 0)
                {
                    yPeca -= 1;
                }

                if(xPeca == 0 && yPeca == 0)
                {
                    xPeca += 1;
                }

                if(xPeca == 1 && yPeca < 7)
                {
                    yPeca += 1;
                }

                if(xPeca == 1 && yPeca == 7)
                {
                    xPeca -= 1;
                }
            }
        }



        public void checkCasaVazia(int x, int y)
        {


        }
    }

}