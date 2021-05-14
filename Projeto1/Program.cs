﻿using System;

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
                if(numeroPassos == 0)
                {
                    Console.WriteLine("Opps tives-te azar");
                    acaoCorreta = true;

                }
                

                

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
                                if(posX == pecaMexer.GetPos()[0] && posY == pecaMexer.GetPos()[1])
                                {
                                    Console.WriteLine("Posicao Inválida");
                                }
                                //caso contrario dizer e voltar ciclo
                                else
                                {
                                    acaoCorreta = true;
                                }
                                
                            }
                        }
                        else
                        {
                            if(tabuleiro.getMap()[2,4] == 2)
                            {
                                Peca pecaMexer = tabuleiro.pegaPeca(2,4);
                                int posX = pecaMexer.GetPos()[0];
                                int posY = pecaMexer.GetPos()[1];

                                tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB);
                                //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                                if(posX != pecaMexer.GetPos()[0] && posY != pecaMexer.GetPos()[1])
                                {
                                    Console.Write("Já existe uma peça tua neste local");
                                }
                                //caso contrario dizer e voltar ciclo
                                else
                                {
                                    acaoCorreta = true;
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
                            int val = escolhaArray[0] - '0';
                            if(val == i)
                            {
                                primIsNumero = true;
                            }

                            int val2 = escolhaArray[0] - '0';
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
                                    {
                                        tabuleiro.moverPeca(pecaMexer, numeroPassos, playerA); 
                                    }
                                    else
                                    {
                                        tabuleiro.moverPeca(pecaMexer, numeroPassos, playerB); 
                                    }
                                    
                                    //!!!! VERIFICAR SE O MOVE É POSSSIVEL!!!
                                    if(posX == pecaMexer.GetPos()[0] && posY == pecaMexer.GetPos()[1])
                                    {
                                        Console.WriteLine("Posicao Inválida");
                                    }
                                    //caso contrario dizer e voltar ciclo
                                    else
                                    {
                                        acaoCorreta = true;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nao existe peca ai");
                            }
                        }
                        else
                        {
                            Console.WriteLine("caracteres invalidos");
                        }
                    }
                }

                //verificar se alguem vence
                //verificar se peca esta na flor ou nao e consoante isso trcoar de player ou n
                tabuleiro.atualizarMap();

                turno = !turno;

        
            }
            
        }

        static int lancarDados()
        {
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(0,5);

            Console.WriteLine($" O numero é {valorInteiro}");
            return valorInteiro;
        }


            //random teste
    }
}
