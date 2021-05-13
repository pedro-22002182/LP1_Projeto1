using System;

namespace Projeto1
{
    public class Tabuleiro
    {
        private int[,] tabuleiro; 

        private Peca[] pecas;

        public Tabuleiro()
        {
            this.tabuleiro = new int [3,8];
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

            atualizarMap();
        }

        public void moverPeca (Peca peca,int passos, Player jogador) 
        {
            int xnovo = peca.GetPos()[0];
            int ynovo = peca.GetPos()[1];

            for(int i = 0; i < passos; i++)
            {
                //se jogadorA
                if(peca.GetPlayer() == true)
                {
                    //check vitoria Peca
                    if(xnovo == 0 && ynovo == 5)
                    {
                        //ponto DO
                        if(passos == 0)
                        {
                            jogador.plusPontos();
                        }
                        else
                        {
                            //retorna à posicao onde forma lancados os dados
                            xnovo = peca.GetPos()[0];
                            ynovo = peca.GetPos()[1];
                        }
                    }
                    
                    //Orientaçao das pecas no board
                    if(xnovo == 0 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }
                    else if(xnovo == 0 && ynovo == 0)
                    {
                        xnovo += 1;
                    }
                    else if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }
                    else if(xnovo == 1 && ynovo == 7)
                    {
                       xnovo-= 1;
                    }
                }
                
                //se jogadorB
                if(peca.GetPlayer() == false)
                {
                    //check vitoria Peca
                    if(xnovo == 2 && ynovo == 5)
                    {
                        //ponto DO
                        if(passos == 0)
                        {
                            jogador.plusPontos();
                        }
                        else
                        {
                            //retorna à posicao onde forma lancados os dados
                            xnovo = peca.GetPos()[0];
                            ynovo = peca.GetPos()[1];
                        }
                    }

                    //terceira linha até chegar ao topo
                    if(xnovo == 2 && ynovo > 0)
                    {
                        ynovo -= 1;
                    }

                    //se tiver no canto direito superior
                    else if(xnovo == 2 && ynovo == 0)
                    {
                        xnovo -= 1;
                    }

                    //se tiver linha meio
                    else if(xnovo == 1 && ynovo < 7)
                    {
                        ynovo += 1;
                    }

                    //se tiver linha meio e na casa 7
                    else if(xnovo == 1 && ynovo == 7)
                    {
                        xnovo += 1;
                    }
                }
            }

            if(pegaPeca(xnovo, ynovo) == null)
            {
                peca.SetPos(xnovo, ynovo);
            }       
            else
            {
                Peca pecaNoLocal = pegaPeca(xnovo, ynovo);


                if(pecaNoLocal.GetPlayer() != peca.GetPlayer())
                {
                    if(CheckFlower(pecaNoLocal.GetPos()[0], pecaNoLocal.GetPos()[1]) == false)
                    {
                        pecaNoLocal.ComerPeça();
                        peca.SetPos(xnovo, ynovo);
                    }
                    else
                    {
                        Console.WriteLine("A peça inimiga está numa posição protegida");
                    }
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

        public int[,] getMap()
        {
            return tabuleiro;
        }

        public Peca pegaPeca(int x, int y)
        {
            for(int i = 0; i < pecas.Length; i++)
            {
                if(pecas[i].GetPos()[0] == x && pecas[i].GetPos()[1] == y)
                {
                    return pecas[i];
                }
            }

            return null;
        }


        public void atualizarMap()
        {
            for(int x = 0; x < tabuleiro.GetLength(0); x++)
            {
                for(int y = 0; y < tabuleiro.GetLength(1); y++)
                {
                    //Casa Vazia
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