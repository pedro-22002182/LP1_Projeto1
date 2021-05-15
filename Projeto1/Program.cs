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


            //Game loop
            bool jogoAcabou = false;

            //responsavel ver turno, se true é playerA a jogar, se false é o playerB
            bool turno = true;

            //Introducao loop
            bool introducaoJogo = true;

            graficos.Menu();

            while(introducaoJogo == true)
            {
                
                string escolha = Console.ReadLine();

                if(escolha == "1")
                {
                    introducaoJogo = false;
                }
                else if(escolha == "2")
                {
                    graficos.Regras();
                }
                else if(escolha == "3")
                {
                    graficos.Controles();
                }
                else if(escolha == "4")
                {
                    System.Environment.Exit(1);
                }
            }
            

            

            while (jogoAcabou == false)
            {
                //mostrar tabuleiro
                graficos.showScore();
                graficos.showMap();

                //mostrar de quem é a vez
                if(turno == true) 
                    Console.WriteLine("É a vez do playerA jogar! \n");
                else
                    Console.WriteLine("É a vez do playerB jogar! \n");


                //Lancar os dados de forma automatica
                Console.WriteLine("Para lançar os dados clica no enter");
                Console.ReadLine();
                int numeroPassos = lancarDados();


                int xFinalPecaMove = -1;
                int yFinalPecaMove = -1;
                bool acaoCorreta = false;

                if(numeroPassos == 0)
                {
                    Console.WriteLine("Opps tives-te azar..");
                    acaoCorreta = true;
                }
                
            

                while(acaoCorreta == false)
                {
                    //pedir acao ao jogador
                    Console.WriteLine("Coloca as coordenas da casa (ex: 1_2) da peça a ser mexida!");
                    Console.WriteLine("Ou podes coloca espaço para mexer instantaneamente uma peca da base!");

                    string escolha = Console.ReadLine();
                    char[] escolhaArray = escolha.ToCharArray();

                    //caso mexer peca na base
                    if(escolha == " ")
                    {

                        if(tabuleiro.getMap()[0,4] == 1 || tabuleiro.getMap()[0,4] == 2)
                        {

                            Peca pecaMexer;

                            if(turno == true)
                                pecaMexer = tabuleiro.pegaPeca(0,4);
                            else
                                pecaMexer = tabuleiro.pegaPeca(2,4);

                            int posX = pecaMexer.GetPos()[0];
                            int posY = pecaMexer.GetPos()[1];

                            if(turno == true)
                                tabuleiro.moverPeca(pecaMexer, numeroPassos, playerA); 
                            else
                                tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB); 

                            //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                            if(posX == pecaMexer.GetPos()[0] && posY == pecaMexer.GetPos()[1])
                            {
                                Console.WriteLine("Posição Inválida \n");
                            }
                            //caso contrario dizer e voltar ciclo
                            else
                            {
                                acaoCorreta = true;
                                xFinalPecaMove = pecaMexer.GetPos()[0];
                                yFinalPecaMove = pecaMexer.GetPos()[1];
                            }
                        }
                    }
                    else if(escolhaArray.Length >= 3 || escolhaArray[0] != '\0' || escolhaArray[2] != '\0') 
                    {
                        //verificar se o input dado tem dois numeros like "1_2"
                        bool primIsNumero = false;
                        bool segIsNumero = false;

                        for(int i = 0; i <= 9; i++)
                        {
                            int val = escolhaArray[0] - '0';
                            if(val == i)
                            {
                                primIsNumero = true;
                            }

                            int val2 = escolhaArray[2] - '0';
                            if(val2 == i)
                            {
                                segIsNumero = true;
                            }
                        }

                        //se os dois forem numeros
                        if(segIsNumero == true && primIsNumero == true)
                        {
                            int coordX = escolhaArray[0] - '0';
                            int coordY = escolhaArray[2] - '0';

                            //verificar se existe peca na posicao
                            if(tabuleiro.pegaPeca(coordX, coordY) != null)
                            {
                               
                                Peca pecaMexer = tabuleiro.pegaPeca(coordX, coordY);

                                //verficar se peca pertence ao atual jogador
                                if(pecaMexer.GetPlayer() == turno)
                                {
                                    int posX = pecaMexer.GetPos()[0];
                                    int posY = pecaMexer.GetPos()[1];

                                    if(turno == true)
                                        tabuleiro.moverPeca(pecaMexer, numeroPassos, playerA); 
                                    else
                                        tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB); 
                                    
                                    //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                                    if(posX == pecaMexer.GetPos()[0] && posY == pecaMexer.GetPos()[1])
                                    {
                                        Console.WriteLine("Posicao Inválida \n");
                                    }
                                    //caso contrario dizer e voltar ciclo
                                    else
                                    {
                                        acaoCorreta = true;
                                        xFinalPecaMove = pecaMexer.GetPos()[0];
                                        yFinalPecaMove = pecaMexer.GetPos()[1];
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nao existe nenhuma peça aí.. \n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Caracteres inválidos.. \n");
                        }
                    }
                }

                //atualizar o Mapa
                tabuleiro.atualizarMap();
                

                //verificar Vitorias - se true jogo acaba
                if(playerA.CheckVitória() == true)
                {
                    Console.WriteLine("PARABENS JOGADOR A GANHAS-TE!!!");
                    jogoAcabou = true;
                }
                if(playerB.CheckVitória() == true )
                {
                    Console.WriteLine("PARABENS JOGADOR B GANHAS-TE!!!");
                    jogoAcabou = true;
                }

                //Checkar se existe flor na casa em que peca ficou - se sim jogador joga again
                if(tabuleiro.CheckFlower(xFinalPecaMove, yFinalPecaMove))
                {
                    Console.WriteLine("Estás numa casa segura e podes jogar novamente! \n");
                }
                else //se nao, troca turno
                {
                    turno = !turno;
                }
            }
        }

        static int lancarDados()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0,5);

            Console.WriteLine($" Calhou-te ... {valorInteiro} ! \n");
            return valorInteiro;
        }
    }
}
