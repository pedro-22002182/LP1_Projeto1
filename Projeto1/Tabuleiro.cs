namespace Projeto1
{
    public class Tabuleiro
    {
        private int[,] tabuleiro; 

        private Peca[] pecas;

        public Tabuleiro()
        {
            this.tabuleiro = new int [2,7];
            this.pecas = new Peca[13];

            for(int i = 0; i < pecas.Length; i++)
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

        public void moverPeca (Peca peca,int passos, Player jogador) 
        {
            peca.movimentoPeca(passos, jogador);
            
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

        



        public void checkCasaVazia(int x, int y)
        {


        }
    }

}