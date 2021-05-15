namespace Projeto1
{
    public class Player
    {

        private int score;

        //Função para o score
        public Player()
        {
            this.score = 0;
        }

        //Função para somar pontos ao score
        public void plusPontos()
        {
            score += 1;
        }

        // Verificar vitória
        public bool checkVitoria()
        {
            if(score == 7)
            {
                return true;
            }
            return false;
        }

        public int getScore()
        {
            return score;
        }
    }
}