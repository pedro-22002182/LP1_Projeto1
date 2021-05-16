# Projeto 1 de Linguagens de Programção | 2020/2021 

## Autoria:
 - Pedro Passos 22002182
 - Pedro Ferreira 22006045
 - Hugo Martins 21701372

##### Desenvolvimento do projeto
É bastante complicado especificar quem fez o quê, uma vez que, o trabalho foi feito de inicio ao fim com os 3 membros em chamada e partilha de discord, onde discutiamos diferentes ideias e abordagens aos problemas que fomos tendo ao longo do desenvolvimento do projeto. Os commits foram variando entre membros no entanto o densenvolvimento por trás dos mesmo foi na sua grande maioria feita em grupo(exceto coisas pequenas como alguns comentários e afins).

##### Repositório git utilizado 
Para desenvolvimento cooperativo deste projeto utilizamos maioritariamente o gitHub Desktop e todos os commits e informaçoês estão presentes aqui: https://github.com/VideojogosLusofona/lp1_2020_p1.

## Arquitetura da Solução:
##### Breve explicação do código
O código para a criação do jogo é constituído por 5 classes.
A classe Peca, é onde existem as características da peca, desde a sua posição e a qual jogador pertence, e os seus métodos, desde a definir ou mudar posição, comer peca, e movimentar a peça.
A classe Player, é responsável por guardar os pontos do jogador e tem um método que observa se o jogador ganhou ou não.
A classe Tabuleiro é responsável por definir o mapa de jogo através de um array bidimensional, com posições em x e y. Para além disso, possui um array com todas as peças do jogo. No construtor da classe, para além de se criar o tabuleiro existe também, a criação das peças para cada um dos jogadores. Como métodos existe o atualizar o mapa, pegar a peça na posição pretendida, verificar se existe casas especiais e, movimentar uma peça na posição pretendida.
A classe Graficos, é responsável pelos prints principais do jogo, desde mostrar o mapa, os pontos de cada jogador, o menu principal bem como os controles e regras, essenciais para o percebimento do jogo.
Para finalizar, existe a classe Program que é responsável por juntar as classes todas e possuir o game loop do jogo. Para tal, existe um loop inicial, onde o jogador permanece no menu e quando faz o input certo entra no loop do jogo. Neste loop basicamente é mostrado sempre o tabuleiro e os pontos de cada jogador e, à vez, cada jogador joga, lançando os dados (função da classe program) e mexendo a peça pretendida.


[UML](uml.png)

##### Referencias
Não sentimos necessidade de recorrer a referências externas, como tal, apenas fomos discutindo entre nós diferentes maneiras de obter os resultados pretendidos, e de resolver problemas e bugs que tivemos durante o processo.
