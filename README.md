## Jogo de Adivinhação 

Jogo de console desenvolvido na Academia do programador para praticar lógica de programação, estruturas de repetição (loops) e manipulação de vetores (arrays).

![Demonstração do Jogo](./docs/gameplay.gif)

## Como funciona o jogo?
O sistema gera um número secreto aleatório e o jogador precisa adivinhar qual é.
* **Fácil:** Número de 1 a 20 (10 tentativas).
* **Médio:** Número de 1 a 50 (5 tentativas).
* **Difícil:** Número de 1 a 100 (3 tentativas).

O jogo possui um sistema de pontuação que diminui conforme a distância do seu erro, e não permite chutar o mesmo número duas vezes na mesma partida.

## Como rodar no seu computador
1. Você precisa ter o .NET SDK instalado.
2. Abra o terminal na pasta do projeto.
3. Digite o comando abaixo e aperte Enter:
   ```bash
   dotnet run
