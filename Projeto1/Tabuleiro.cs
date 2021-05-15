using System;

namespace Projeto1
{   
    /// <summary>
    /// Classe responsável por definir e editar o mapa de jogo
    /// </summary>
    public class Tabuleiro
    {
        private int[,] tabuleiro; 

        private Peca[] pecas;


        // Nesta funçâo criamos o tabuleiro e as peças
        public Tabuleiro()
        {
            this.tabuleiro = new int [3,8];
            this.pecas = new Peca[14];

            //construçaõ das peças todas
            for(int i = 0; i < pecas.Length; i++)
            {
                if(i <= 6)
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
            atualizarMap();
        }

        /* Aqui pegamos as coordenadas da peça, o numero calhado nos dados e a quem pertence a peça
         para fazer o movimento da mesma */
        public void moverPeca (Peca peca,int passos, Player jogador) 
        {
            //coordenas novas que simulam a posição futura da peça
            int xnovo , ynovo;
            int[] valores = peca.GetPreviewsPos(passos, jogador);
            
            xnovo = valores[0];
            ynovo = valores[1];


            //se a poisicao futura estiver vazia podemos mover
            if(pegaPeca(xnovo, ynovo) == null)
            {
                peca.SetPos(xnovo, ynovo);
            }       
            //caso contrário, poderemos comer ou não mover peça
            else
            {
                Peca pecaNoLocal = pegaPeca(xnovo, ynovo);

                //caso seja peça inimiga no local
                if(pecaNoLocal.GetPlayer() != peca.GetPlayer())
                {

                    //Se não estiver numa casa especial comemos e movemos
                    if(CheckFlower(pecaNoLocal.GetPos()[0], pecaNoLocal.GetPos()[1]) == false)
                    {
                        pecaNoLocal.serComida();
                        peca.SetPos(xnovo, ynovo);
                    }
                    else
                    {
                        Console.WriteLine("A peça inimiga está numa posição protegida");
                    }
                }
            }
        }
        
        // Aqui estabeleçemos as coordenadas que têm uma flor
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

        //obter mapa
        public int[,] getMap()
        {
            return tabuleiro;
        }

        //Pegar coordenadas da peça, se nao existir return null
        public Peca pegaPeca(int x, int y)
        {
            //percorrer array das peças todas
            for(int i = 0; i < pecas.Length; i++)
            {
                if(pecas[i].GetPos()[0] == x && pecas[i].GetPos()[1] == y)
                {
                    
                    return pecas[i];
                }
            }

            return null;
        }


        //atualizar o mapa lendo as peças e as suas posiçoes
        public void atualizarMap()
        {

            //for para percorrer array2D do mapa
            for(int x = 0; x < tabuleiro.GetLength(0); x++)
            {
                for(int y = 0; y < tabuleiro.GetLength(1); y++)
                {
                    //Casa Vazia estabelecida
                    tabuleiro[x,y] = 0;

                    //Existe flor?
                    if(CheckFlower(x,y) == true)
                    {
                        tabuleiro[x,y] = 3;
                    }

                    //Existe Jogador
                    for(int p = 0; p < pecas.Length; p++)
                    {
                        if(pecas[p].GetPos()[0] == x && pecas[p].GetPos()[1] == y)
                        {   
                            //de qual jogador pertence
                            if(pecas[p].GetPlayer() == true)
                            {
                                tabuleiro[x,y] = 1;
                            }
                            else
                            {
                                tabuleiro[x,y] = 2;
                            }
                        }
                    }
                }
            }
        }       
        
        //Verificar as casas vazias
        public bool checkCasasVazias(int x, int y)
        {
            if((x == 0 && y == 4) || (x == 0 && y == 5) || (x == 2 && y == 4) || (x == 2 && y == 5))
            {
                return true;
            }

            return false;
        }
    }
}