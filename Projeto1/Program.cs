using System;

namespace Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates board
            Tabuleiro tabuleiro = new Tabuleiro();

            //cria dois jogadores e chama graficos com info tabuleiro e players A e B
            Player playerA = new Player();
            Player playerB = new Player();
            Graficos graficos = new Graficos(tabuleiro, playerA, playerB);


            graficos.regras();

            //Game loop
            bool acabou = false;
            
            //Quando é true é o playerA a jogar e quando é false é o playerB
            bool turno = true;

            
            

            while (acabou == false)
            {
                //mostrar tabuleiro
                graficos.showMap();

                //mostrar de quem é a vez
                if(turno == true) 
                    Console.WriteLine("É a vez do playerA");
                else
                    Console.WriteLine("É a vez do playerB");


                //Lancar os dados de forma automatica
                Console.WriteLine("Para lançar os dados clica no enter");
                Console.ReadLine();
                int numeroPassos = lancarDados();
                

                bool acaoCorreta = false;

                while(acaoCorreta == false)
                {
                    //pedir acao ao jogador
                    Console.WriteLine("Coloca coordenas (ex: 1_2) da peça a ser mexida ou, mexer nova peça espaço");
                    string escolha = Console.ReadLine();
                    char[] escolhaArray = escolha.ToCharArray();

                    //caso mexer peca na base
                    if(escolha == " ")
                    {
                        if(turno == true)
                        {
                            if(tabuleiro.getMap()[0,4] == 1)
                            {
                                Peca pecaMexer = tabuleiro.pegaPeca(0,4);
                                int posX = pecaMexer.GetPos()[0];
                                int posY = pecaMexer.GetPos()[1];

                                tabuleiro.moverPeca(pecaMexer, numeroPassos, playerA); 

                                //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                                if(posX != pecaMexer.GetPos()[0] && posY != pecaMexer.GetPos()[1])
                                {
                                    acaoCorreta = true;
                                }
                                //caso contrario dizer e voltar ciclo
                                else
                                {
                                    Console.WriteLine("Posicao Inválida");
                                }
                                
                            }
                        }
                        else
                        {
                            if(tabuleiro.getMap()[2,4] == 1)
                            {
                                Peca pecaMexer = tabuleiro.pegaPeca(2,4);
                                int posX = pecaMexer.GetPos()[0];
                                int posY = pecaMexer.GetPos()[1];

                                tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB);
                                //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                                if(posX != pecaMexer.GetPos()[0] && posY != pecaMexer.GetPos()[1])
                                {
                                    acaoCorreta = true;
                                }
                                //caso contrario dizer e voltar ciclo
                                else
                                {
                                    Console.WriteLine("Posicao Inválida");
                                }
                            }
                        }
                    }
                    else
                    {
                        //verificar se o input dado tem dois numeros like "1_2"
                        bool primIsNumero = false;
                        bool segIsNumero = false;

                        for(int i = 0; i <= 9; i++)
                        {
                            if(escolhaArray[0] == (char)i)
                            {
                                primIsNumero = true;
                            }

                            if(escolhaArray[2] == (char)i)
                            {
                                segIsNumero = true;
                            }
                        }

                        //se os dois forem numeros
                        if(segIsNumero == true && primIsNumero == true)
                        {
                            //verificar posicao se existe peca
                            //verificar se pode mexer

                            //se tudo bem, entao a peca mexe, verifica se há ponto e troca jogador e o ciclo volta atras


                        }
                        //se naõ forem, pedir dados novamente (criar ciclo while nisto)
                        else
                        {

                        }
                    }
                    //verificar se alguem vence
                }

        
            }
            
        }

        static int lancarDados()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0,5);

            Console.WriteLine($" O numero é {valorInteiro}");
            return valorInteiro;
        }



    }
}
