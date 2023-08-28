using System;
using System.IO;



namespace JogoDaVelha
{
    //Classe Torneio da Velha
    public class TorneioDaVelha
    {
        public int pontuacaoPlayer1;
        public int pontuacaoPlayer2;

        public TorneioDaVelha (int pontuacaoPlayer1, int pontuacaoPlayer2)
        {
            this.pontuacaoPlayer1 = pontuacaoPlayer1;
            this.pontuacaoPlayer2 = pontuacaoPlayer2;
        }
        public int getpontuacaoPlayer1()
        {
            return this.pontuacaoPlayer1;
        }
        public int getpontuacaoPlayer2()
        {
            return this.pontuacaoPlayer2;
        }
        public void setpontuacaoPlayer1(int pontuacaoPlayer1)
        {
            this.pontuacaoPlayer1 = pontuacaoPlayer1;
        }
        public void setpontuacaoPlayer2(int pontuacaoPlayer2)
        {
            this.pontuacaoPlayer2 = pontuacaoPlayer2;
        }
    }
    public class PartidaDoTorneio
    {
        public int[] posicaoPlayerX {get; set;}
        public int[] posicaoPlayerO {get; set;}

        public PartidaDoTorneio()
        {
            int[] vetor = {0, 0, 0, 0, 0};
            this.posicaoPlayerX = vetor;
            this.posicaoPlayerO = vetor;
        }
    }

    public class Player
    {
        public string nomeDoPlayer;
        public bool eHVirtual;
        
        public Player(string nomeDoPlayer, bool eHVirtual)
        {
            this.nomeDoPlayer = nomeDoPlayer;
            this.eHVirtual = eHVirtual;
        }
        public string getnomeDoPlayer()
        {
            return this.nomeDoPlayer;
        }
        public bool geteHVirtual()
        {
            return this.eHVirtual;
        }
        public void setnomeDoPlayer(string nomeDoPlayer)
        {
            this.nomeDoPlayer = nomeDoPlayer;
        }
        public void setehVirtual(bool eHVirtual)
        {
            this.eHVirtual = eHVirtual;
        }
    }
    public class Sistema {
	  
	private static readonly Random aleatorio = new Random();

    public static void Main()
    {
      int linha, coluna, tamanho, indice, indice1, indice2, numeroPartidas, turno_X, turno_O, i, j;
	  char simbolo, simbolo1, simbolo2, resposta;
	  string nome1, nome2, arquivoEntrada;
	  bool continuarTorneio, continuarPartida, vezJogador1, vitoria;
	  
	  // Preparar a  lista de nomes dos playeres
      arquivoEntrada = "NomesJogadores.txt";
      string[] ListaJogadores = File.ReadAllLines(arquivoEntrada);
	  tamanho = ListaJogadores.Length;
      
	  // exibir lista de nomes
	  Console.Clear();
      Console.WriteLine("Boas vindas ao Jogo da Velha!");
	  Console.WriteLine("Lista dos jogadores disponíveis:");
	  indice=1;
	  foreach(string nome in ListaJogadores)
      {
		  Console.WriteLine(indice + ". " + nome);
		  indice++;
	  }
	  
	  // Orientar o jogador a escolher o nome ID e símbolo (x;O)
	  indice1 = 0;
	  indice2 = 0;
	  simbolo1 = ' ';
	  simbolo2 = ' ';
	  do
      {
		Console.Write("Informe o número do nome do jogador 1 (você): ");
		indice1 = int.Parse(Console.ReadLine());
	  }while(indice1<1 || indice1>tamanho);
	  nome1 = ListaJogadores[indice1-1];
	  do
      {
		  Console.Write("Informe o seu símbolo (X ou O): ");
		  simbolo1 = char.Parse(Console.ReadLine());
	  }while(simbolo1!='X' && simbolo1!='O');
	  if(simbolo1 == 'X') simbolo2 = 'O';
	  else simbolo2 = 'X';
	  do
      {
	    Console.Write("Informe o número do nome do jogador 2 (CPU): ");
	    indice2 = int.Parse(Console.ReadLine());
	  }while(indice2<1 || indice2>tamanho);
	  nome2 = ListaJogadores[indice2-1];
	  
	  // Começar o torneio e registrar os jogadores do torneio
	  TorneioDaVelha torneio = new TorneioDaVelha(0,0);
	  Player jogador1 = new Player(nome1, false);
	  Player jogador2 = new Player(nome2, true);
	  
	  // Laço do torneio
	  continuarTorneio = true;
	  numeroPartidas = 0;
	  while(continuarTorneio)
      {
		  
		  // Laço da partida
		  numeroPartidas++;
		  Console.Clear();
		  Console.WriteLine("Partida #{0}!", numeroPartidas);
		  continuarPartida = true;
		  vezJogador1 = true;
		  turno_X=0;
		  turno_O=0;
		  
		  // Matriz da partida
		  char[,] matrizPartida = new char[3, 3];
		  for(i=0; i<3; i++)
			for(j=0; j<3; j++)
			  matrizPartida[i, j] = ' ';
		  
		  while(continuarPartida)
          {
			  
			  PartidaDoTorneio partida = new PartidaDoTorneio();
			  
			  // Se for a  vez do jogador 1, pergunta-se onde o player quer marcar o símbolo
			  if(vezJogador1){
				  Console.WriteLine("Informe onde deseja marcar sua jogada.");
				  do
                  {
				      Console.Write("Informe linha: ");
				      linha = int.Parse(Console.ReadLine());
				  }while(linha<1 || linha>3);
				  do
                  {
					  Console.Write("Informe coluna: ");
				      coluna = int.Parse(Console.ReadLine());
				  }while(coluna<1 || coluna>3);
				  matrizPartida[linha-1, coluna-1] = simbolo1;
				  if(simbolo1 == 'X')
                  {
					  partida.posicaoPlayerX[turno_X] = coluna + 3*(linha-1);
					  turno_X++;
				  }
				  else
                  {
					  partida.posicaoPlayerO[turno_O] = coluna + 3*(linha-1);
					  turno_O++;
				  }
			  }
			  
			  // Se for a  vez do jogador 2, a marcação é aleatoriamente
			  else
              {
				  do
                  {
				    linha = aleatorio.Next(1,4);
				    coluna = aleatorio.Next(1,4);
				  }while(matrizPartida[linha-1, coluna-1] != ' ');
				  matrizPartida[linha-1, coluna-1] = simbolo2;
				  if(simbolo2 == 'X')
                  {
					  partida.posicaoPlayerX[turno_X] = coluna + 3*(linha-1);
					  turno_X++;
				  }
				  else
                  {
					  partida.posicaoPlayerO[turno_O] = coluna + 3*(linha-1);
					  turno_O++;
				  }
			  }
			  
			  // Display da partida
			  if(vezJogador1) Console.WriteLine("Jogada de {0}:", jogador1.nomeDoPlayer);
			  else Console.WriteLine("Jogada de {0}:", jogador2.nomeDoPlayer);
			  for(i=0; i<3; i++)
              {
				  for(j=0; j<3; j++)
                  {
					  Console.Write(" {0} ", matrizPartida[i, j]);
					  if(j<2) Console.Write("|");
				  }
				  if(i<2) Console.WriteLine("\n-----------");
				  else Console.Write("\n");
			  }
			  
			  // Checar se algum jogador venceu no torneio
			  continuarPartida = (turno_X + turno_O < 9);
			  vitoria = false;
			  if(vezJogador1) simbolo = simbolo1;
			  else simbolo = simbolo2;
			  if((matrizPartida[0, 0] == simbolo)&&(matrizPartida[0, 1] == simbolo)&&(matrizPartida[0, 2] == simbolo)) vitoria = true;
			  else if((matrizPartida[1, 0] == simbolo)&&(matrizPartida[1, 1] == simbolo)&&(matrizPartida[1, 2] == simbolo)) vitoria = true;
			  else if((matrizPartida[2, 0] == simbolo)&&(matrizPartida[2, 1] == simbolo)&&(matrizPartida[2, 2] == simbolo)) vitoria = true;
			  else if((matrizPartida[0, 0] == simbolo)&&(matrizPartida[1, 0] == simbolo)&&(matrizPartida[2, 0] == simbolo)) vitoria = true;
			  else if((matrizPartida[0, 1] == simbolo)&&(matrizPartida[1, 1] == simbolo)&&(matrizPartida[2, 1] == simbolo)) vitoria = true;
			  else if((matrizPartida[0, 2] == simbolo)&&(matrizPartida[1, 2] == simbolo)&&(matrizPartida[2, 2] == simbolo)) vitoria = true;
			  else if((matrizPartida[0, 0] == simbolo)&&(matrizPartida[1, 1] == simbolo)&&(matrizPartida[2, 2] == simbolo)) vitoria = true;
			  else if((matrizPartida[0, 2] == simbolo)&&(matrizPartida[1, 1] == simbolo)&&(matrizPartida[2, 0] == simbolo)) vitoria = true;
			  continuarPartida = continuarPartida && !vitoria;
			  if(continuarPartida) vezJogador1 = !vezJogador1;
			  else if(vitoria)
              {
				  if(vezJogador1)
                  {
					  Console.WriteLine("Vitória de {0}!", jogador1.nomeDoPlayer);
					  torneio.pontuacaoPlayer1++;
				  }
				  else
                  {
					  Console.WriteLine("Vitória de {0}!", jogador2.nomeDoPlayer);
					  torneio.pontuacaoPlayer2++;
				  }
				  break;
			  }
			  else Console.WriteLine("Empatou!");
		  }
		  
		  // Condição de parada do torneio
		  do
          {
		    Console.Write("Deseja continuar? (S/N): ");
			resposta = char.Parse(Console.ReadLine());
		    if(resposta == 'N') continuarTorneio = false;
		  }while(resposta!='S' && resposta!='N');
	  }
	  
	  if(torneio.pontuacaoPlayer1 > torneio.pontuacaoPlayer2) Console.WriteLine("{0} venceu o torneio!", jogador1.nomeDoPlayer);
	  else if(torneio.pontuacaoPlayer1 < torneio.pontuacaoPlayer2) Console.WriteLine("{0} venceu o torneio!", jogador2.nomeDoPlayer);
	  else Console.WriteLine("O torneio terminou em empate!");
	  
    }
  }
}
