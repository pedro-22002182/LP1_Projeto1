namespace Projeto1
{
    public class Tabuleiro
    {
        private int[][] tabuleiro; 

        private Peca[] pecas;

        public Tabuleiro()
        {
            this.tabuleiro = new int [3][8];
            this.pecas = new Peca[14];
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

        public void movimentoPeca(Peca peca, int passos)
        {
            int xPeca = peca.GetPos()[0];
            int yPeca = peca.GetPos()[1];

            if(xPeca == 0)
            {

            }
        }



        public void checkCasaVazia(int x, int y)
        {


        }
    }

}