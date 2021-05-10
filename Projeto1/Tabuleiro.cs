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
    }

}