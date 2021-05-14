namespace Projeto1
{
    public class Player
    {

        private int score;

        public Player()
        {
            this.score = 0;
        }

        public void plusPontos()
        {
            score += 1;
        }

        public bool CheckVitória()
        {
            if(score == 7)
            {
                return true;
            }
            return false;
        }
    }
}