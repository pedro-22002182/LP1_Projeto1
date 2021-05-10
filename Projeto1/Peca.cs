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

        public int[] GetPos()
        {
            return (posX, posY);
        }

        public bool GetPlayer()
        {
            return player;
        }
        
    }
}