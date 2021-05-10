namespace Projeto1
{

    public class Peca
    {
        private int posX, posY;

        private bool playerA; //se true então pertecen ao jogador A, se false pertence B

        
        public Peca(bool playerA)
        {
            //posicao inical da peca ("fora tabuleiro")
            this.posX = 1;
            this.posY = 5;

            //pertence ao jogadorA?? B?
            this.playerA = playerA;
        }

        public int[] GetPos()
        {
            return (posX, posY);
        }
        
    }
}