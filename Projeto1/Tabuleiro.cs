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
    }

}