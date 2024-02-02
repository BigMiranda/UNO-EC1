using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO_3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region//Variaveis
            string[] cartaID = new string[105];
            string[] cartaNome = new string[105];
            bool[] cartaCompra = new bool[100];
            int[] maoPlayer = new int[100];
            int[] maoBot = new int[100];

            Random gerador = new Random();
            int n = 0, a, i, j = 0, naMesa, cartaEsc = -1, escolha = 0, escolha2 = 0, qntJogadas = 0, z = 0, qntPlayer = 0, qntBot, Cor = 0, validação = 0, entrada, joquempo, joquempo2 = 0;

            int podeJogarP = 0, podeJogarB = 0, prasempre, prasempre2, comboCompra = 0, revide = 0, comprinha = 0;
            //Pode Jogar ( 1 = vez do bot / 0 = pode jogar / - 1 = Tem que comprar / - 2 = pulou a vez)

            //IA do Bot
            int qnt2 = 0, qntC = 0, qntC4 = 0, qntB = 0;
            string[] CorPredo = new string[4];
            int[] corAlguma = new int[4];
            #endregion

            #region//Definindo o ID de cada carta

            //Normal ou Especial
            do
            {
                if (n >= 0 && n <= 75)
                {
                    cartaID[n] = "N";
                }
                else { cartaID[n] = "E"; }
                n++;
            }
            while (n < 105);
            n = 0;

            //0 a 9; B = bloquear; C = Mudad cor; X = +2; Y = +4
            do
            {
                if (n >= 0 && n <= 3) { cartaID[n] += 0; }
                if (n >= 4 && n <= 11) { cartaID[n] += 1; }
                if (n >= 12 && n <= 19) { cartaID[n] += 2; }
                if (n >= 20 && n <= 27) { cartaID[n] += 3; }
                if (n >= 28 && n <= 35) { cartaID[n] += 4; }
                if (n >= 36 && n <= 43) { cartaID[n] += 5; }
                if (n >= 44 && n <= 51) { cartaID[n] += 6; }
                if (n >= 52 && n <= 59) { cartaID[n] += 7; }
                if (n >= 60 && n <= 67) { cartaID[n] += 8; }
                if (n >= 68 && n <= 75) { cartaID[n] += 9; }
                if (n >= 76 && n <= 83) { cartaID[n] += "B"; }
                if (n >= 84 && n <= 91) { cartaID[n] += "X"; }
                if (n >= 92 && n <= 95) { cartaID[n] += "C"; }
                if (n >= 96 && n <= 99) { cartaID[n] += "Y"; }
                if (n >= 101 && n <= 104) { cartaID[n] += "K"; }
                n++;
            }
            while (n < 105);
            n = 0;

            //Cores - R = Vermelho; Y = Amarelo; G = Verde; B = Azul; N = Null
            do
            {   //Vermelho
                cartaID[n] += "R";
                n = n + 4;
            }
            while (n < 89);
            cartaID[101] += "R";

            n = 1;
            do
            {   //Amarelo
                cartaID[n] += "Y";
                n = n + 4;
            }
            while (n < 90);
            cartaID[102] += "Y";

            n = 2;
            do
            {   //Verde
                cartaID[n] += "G";
                n = n + 4;
            }
            while (n < 91);
            cartaID[103] += "G";

            n = 3;
            do
            {   //Azul
                cartaID[n] += "B";
                n = n + 4;
            }
            while (n < 92);
            cartaID[104] += "B";

            n = 92;
            do
            {   //Null
                cartaID[n] += "N";
                n++;
            }
            while (n < 100);
            #endregion           

            #region//Definindo o nome de cada carta.(O que sera exibido para o jogador)

            //Numeros e Funções
            n = 0;

            do
            {
                if (n >= 0 && n <= 3) { cartaNome[n] += 0; }
                if (n >= 4 && n <= 11) { cartaNome[n] += 1; }
                if (n >= 12 && n <= 19) { cartaNome[n] += 2; }
                if (n >= 20 && n <= 27) { cartaNome[n] += 3; }
                if (n >= 28 && n <= 35) { cartaNome[n] += 4; }
                if (n >= 36 && n <= 43) { cartaNome[n] += 5; }
                if (n >= 44 && n <= 51) { cartaNome[n] += 6; }
                if (n >= 52 && n <= 59) { cartaNome[n] += 7; }
                if (n >= 60 && n <= 67) { cartaNome[n] += 8; }
                if (n >= 68 && n <= 75) { cartaNome[n] += 9; }
                if (n >= 76 && n <= 83) { cartaNome[n] += "Bloquear"; }
                if (n >= 84 && n <= 91) { cartaNome[n] += "+2"; }
                if (n >= 92 && n <= 95) { cartaNome[n] += "Mudar Cor"; }
                if (n >= 96 && n <= 99) { cartaNome[n] += "+4"; }

                n++;
            }
            while (n < 100);

            //Cores
            n = 0;
            do
            {
                cartaNome[n] += " Vermelho";
                n = n + 4;
            }
            while (n < 89);
            cartaNome[101] += "Vermelho";

            n = 1;
            do
            {
                cartaNome[n] += " Amarelo";
                n = n + 4;
            }
            while (n < 90);
            cartaNome[102] += "Amarelo";

            n = 2;
            do
            {
                cartaNome[n] += " Verde";
                n = n + 4;
            }
            while (n < 91);
            cartaNome[103] += "Verde";

            n = 3;
            do
            {
                cartaNome[n] += " Azul";
                n = n + 4;
            }
            while (n < 92);
            cartaNome[104] += "Azul";
            n = 0;
            #endregion

            //JOGO
            do
            {
                #region//Tela Inicial
                prasempre = 0;
                prasempre2 = 0;
                string[] LOGO = { "\n",
                              "██╗   ██╗███╗   ██╗ ██████╗ \n"+
                              "██║   ██║████╗  ██║██╔═══██╗\n"+
                              "██║   ██║██╔██╗ ██║██║   ██║\n"+
                              "██║   ██║██║╚██╗██║██║   ██║\n"+
                              "╚██████╔╝██║ ╚████║╚██████╔╝\n"+
                              " ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ \n"};

                LobbyRefresh(LOGO, 3);

                Console.Write("1 - Jogo Solo\n" +
                              "2 - Multiplayer\n" +
                              "3 - Regras\n" +
                              "4 - Créditos\n" +
                              "Digite a opção desejada: ");
                entrada = int.Parse(Console.ReadLine());

                LobbyRefresh(LOGO, 3);
                #endregion

                #region//Mão Player, Mão bot

                for (int x = 0; x < 100; x++)
                {
                    maoPlayer[x] = -1;
                    maoBot[x] = -1;
                }

                #endregion

                #region//Primeiras cartas dadas

                for (i = 0; i < 7; i++)
                {
                    do
                    {
                        a = gerador.Next(0, 100);
                    }
                    while (cartaCompra[a] == true);

                    maoPlayer[i] = a;
                    cartaCompra[a] = true;
                }

                for (i = 0; i < 7; i++)
                {
                    do
                    {
                        a = gerador.Next(0, 100);
                    }
                    while (cartaCompra[a] == true);

                    maoBot[i] = a;
                    cartaCompra[a] = true;
                }

                do
                {
                    a = gerador.Next(0, 76);
                }
                while (cartaCompra[a] == true);
                naMesa = a;
                cartaCompra[a] = true;
                #endregion

                #region//Jokenpo
                if (entrada == 1 || entrada == 2)
                {
                    //Pedra, Papel e Tesoura para quem começa
                    do
                    {
                        LobbyRefresh(LOGO, 1);
                        Console.WriteLine("Jokenpo para ver quem começa!");
                        Console.Write("\n1 - Pedra\n2 - Papel\n3 - Tesoura \nEscolha sua jogada: ");
                        joquempo = int.Parse(Console.ReadLine());
                        if (entrada == 1)
                            joquempo2 = gerador.Next(1, 4);
                        else if (entrada == 2)
                        {
                            LobbyRefresh(LOGO, 2);
                            Console.Write("\n1 - Pedra\n2 - Papel\n3 - Tesoura \nVez do Player 2: ");
                            joquempo2 = int.Parse(Console.ReadLine());
                        }

                        if (joquempo == 1 && joquempo2 == 1) { n = 0; }
                        else if (joquempo == 1 && joquempo2 == 2) { n = 2; }
                        else if (joquempo == 1 && joquempo2 == 3) { n = 1; }
                        else if (joquempo == 2 && joquempo2 == 1) { n = 1; }
                        else if (joquempo == 2 && joquempo2 == 2) { n = 0; }
                        else if (joquempo == 2 && joquempo2 == 3) { n = 2; }
                        else if (joquempo == 3 && joquempo2 == 1) { n = 2; }
                        else if (joquempo == 3 && joquempo2 == 2) { n = 1; }
                        else if (joquempo == 3 && joquempo2 == 3) { n = 0; }

                        Console.WriteLine("{0} vs {1}", joquempo, joquempo2);
                        if (n == 0)
                        {
                            LobbyRefresh(LOGO, 3);
                            Console.WriteLine("Houve um empate! \nDigite algo para jogar novamente...");
                            Console.ReadKey();
                        }
                        else if (n == 1)
                        {
                            LobbyRefresh(LOGO, 1);
                            if (entrada == 1)
                                Console.WriteLine("Você venceu!");
                            else
                                Console.WriteLine("O Player 1 venceu!");
                        }
                        else
                        {
                            LobbyRefresh(LOGO, 2);
                            podeJogarP = 1;
                            podeJogarB = 0;
                            if (entrada == 1)
                                Console.WriteLine("Você perdeu...");
                            else
                                Console.WriteLine("O Player 2 venceu!");
                        }
                    } while (n == 0);
                    n = 0;
                    Console.WriteLine("\nDigite algo para começar a partida!");
                    Console.ReadKey();
                }
                #endregion                

                #region//Modos

                #region//Player vs Player
                if (entrada == 2)
                {
                    do
                    {
                        #region//Jogada do Player 1
                        //Player Jogada
                        escolha = 0;
                        while (podeJogarP == 0) //A vez do player só inicia quando essa variável é 0!
                        {
                            podeJogarB = 0;
                            do
                            {
                                revide = 0;
                                int x = 0;
                                foreach (int valor in maoPlayer) //Contagem de possibilidades de cartas para revidar o combo de compra
                                {
                                    if (valor != -1 &&
                                        cartaID[valor].Substring(0, 2) == "EX")
                                    {
                                        x++;
                                    }
                                }
                                if (x > 0 && comboCompra > 0)  // se há o que revidar e há possibilidade de revidar 
                                {
                                    do
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 0);
                                        Console.Write("\nDeseja revidar a carta de compra? \n1-Sim \n2-Não \nEscolha:");
                                        revide = int.Parse(Console.ReadLine());
                                    } while (revide != 1 && revide != 2);
                                }

                                else if (revide == 1) //Se escolha é SIM
                                {
                                    validação = 0;
                                    do
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.Write("Qual carta quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());
                                        if (maoPlayer[cartaEsc - 1] == -1 ||
                                            cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) != "EX") //Se for escolhida carta invalida para o combo, faz retornar a pergunta anterior
                                        {
                                            Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                            Console.ReadKey();
                                        }
                                        else //Se possivel de combar com a carta escolhida, põe ela na mesa
                                        {
                                            naMesa = maoPlayer[cartaEsc - 1];
                                            comboCompra = comboCompra + int.Parse(cartaNome[maoPlayer[cartaEsc - 1]].Substring(1, 1)); //Soma a qnt de compra pro combo
                                            maoPlayer[cartaEsc - 1] = -1;
                                            maoPlayer = ArrumaMao(maoPlayer);

                                            Console.WriteLine("Você revido! Agora o adversário compra {0}! \nDigite Algo para prosseguir...", comboCompra);
                                            Console.ReadKey();
                                            validação = 1;
                                            podeJogarP = 1;
                                        }
                                    } while (validação == 0);
                                }

                                else if (x == 0 || revide == 2 || comboCompra == 0) //Se não é possível o revidar ou a escolha é NÃO ou nem há o que revidar
                                {
                                    if (comboCompra > 0) //Ve se há combo de compra pendente, se tiver bota na mão do Player
                                    {
                                        int qntde = 0;
                                        qntde = qntFalse(cartaCompra);
                                        if (qntde > 0)
                                        {
                                            qntPlayer = qntMao(maoPlayer);
                                            for (i = qntPlayer; i < qntPlayer + comboCompra; i++)
                                            {
                                                do
                                                {
                                                    a = gerador.Next(0, 100);
                                                } while (cartaCompra[a] == true);

                                                maoPlayer[i] = a;
                                                cartaCompra[a] = true;
                                            }
                                            comboCompra = 0;
                                        }
                                        else { FimDoJogo(); }
                                    }
                                    //Inicia a jogada
                                    qntJogadas = RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 0);      //Imprime a quantidade de cartas do bot, a carta da mesa e a mão do player                                      
                                    Console.WriteLine("\n\nAções possíveis:");                                              //Apresenta as ações possíveis
                                    if (qntJogadas > 0)
                                        Console.WriteLine("1- Jogar");                                   //Limitando ações impossíveis
                                    Console.WriteLine("2- Comprar");
                                    if (qntJogadas > 0)
                                        Console.WriteLine("3- Falar UNO e jogar");

                                    Console.Write("Digite sua ação (apenas o numero): ");
                                    escolha = int.Parse(Console.ReadLine());
                                    if ((escolha == 1 || escolha == 3) && qntJogadas != 0) //Permite sair do loop contanto que seja uma compra ou q vc tenha a possibilidade de jogar alguma carta
                                        validação++;
                                    else if (escolha == 2)
                                        validação++;
                                    else
                                        validação = 0;

                                }

                            } while (validação == 0);
                            validação = 0;

                            //Jogar
                            qntPlayer = qntMao(maoPlayer);

                            if (escolha == 1 || escolha == 3) //caso seja uma escolha que vá jogar uma carta na mesa
                            {
                                if (qntPlayer == 2 && escolha == 1) //Analisa se a escolha foi 1 no momento de falar UNO e da penalidade
                                {
                                    int qntde = 0;
                                    qntde = qntFalse(cartaCompra);
                                    if (qntde > 0)
                                    {
                                        Console.WriteLine("Você não deu UNO! \nRecebe +1");

                                        for (i = qntPlayer; i < qntPlayer + 1; i++) //Dá mais uma carta(não repetida) pela pela penalidade
                                        {
                                            do
                                            {
                                                a = gerador.Next(0, 100);
                                            } while (cartaCompra[a] == true);

                                            maoPlayer[i] = a;
                                            cartaCompra[a] = true;
                                        }
                                    }
                                    else { FimDoJogo(); }
                                } //Não deu UNO
                                else if (qntPlayer != 2 && escolha == 3) //Analisa se a escolha foi 3 no momento errado
                                {
                                    int qntde = 0;
                                    qntde = qntFalse(cartaCompra);
                                    if (qntde > 0)
                                    {
                                        Console.WriteLine("Você falou UNO na hora errada! \nRecebe +1");
                                        for (i = qntPlayer; i < qntPlayer + 1; i++) //Dá mais uma carta(não repetida) pela pela penalidade
                                        {
                                            do
                                            {
                                                a = gerador.Next(0, 100);
                                            } while (cartaCompra[a] == true);

                                            maoPlayer[i] = a;
                                            cartaCompra[a] = true;
                                        }
                                    }
                                    else { FimDoJogo(); }
                                    Console.WriteLine("Pressione qualquer tecla para continuar ...");
                                    Console.ReadKey();
                                } //Deu UNO antes da hora
                                else //Se não foi barrado por nenhuma oposição antes, permite continuar!
                                {
                                    do //Estrutura de ação
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        validação = 0;

                                        Console.Write("\nQual carta você quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());
                                        int x = 0;
                                        if (maoPlayer[cartaEsc - 1] != -1)
                                        {
                                            if (cartaID[maoPlayer[cartaEsc - 1]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) == "EC" ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) == "EY") //Verifica se é uma jogada possível
                                            {
                                                naMesa = maoPlayer[cartaEsc - 1];                                   //Torna a carta jogada como a carta na mesa
                                                maoPlayer[cartaEsc - 1] = -1;                                       //Torna o espaço da carta jogada vazio
                                                maoPlayer = ArrumaMao(maoPlayer);                                   //Arruma a mão do player após haver um descarte comum

                                                foreach (int valor in maoPlayer) //Contagem de possibilidades de cartas a serem jogadas para combar
                                                {
                                                    if (valor != -1 && (cartaID[valor].Substring(0, 2) == cartaID[naMesa].Substring(0, 2)))
                                                    {
                                                        x++;
                                                    }
                                                }

                                                if (x > 0) //Estrutura do combo
                                                {
                                                    while (x > 0) //Combo possivel
                                                    {
                                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);

                                                        Console.WriteLine("\nVocê tem {0} cartas com o mesmo numero. Quer jogar elas para combar?", x);
                                                        Console.Write("1- Jogar \n2- Não jogar \nEscolha: ");
                                                        escolha2 = int.Parse(Console.ReadLine());
                                                        if (escolha2 == 1)
                                                        {
                                                            Console.Write("Qual carta quer jogar: ");
                                                            cartaEsc = int.Parse(Console.ReadLine());
                                                            if (maoPlayer[cartaEsc - 1] == -1 || cartaID[maoPlayer[cartaEsc - 1]].Substring(1, 1) != cartaID[naMesa].Substring(1, 1)) //Se for escolhida carta invalida para o combo, faz retornar a pergunta anterior
                                                            {
                                                                Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                                                Console.ReadKey();
                                                            }
                                                            else //Se possivel de combar com a carta escolhida, põe ela na mesa
                                                            {
                                                                naMesa = maoPlayer[cartaEsc - 1];
                                                                maoPlayer[cartaEsc - 1] = -1;

                                                                for (n = 0; n < 97; n++) //Arruma mão do player
                                                                {
                                                                    if (maoPlayer[n] == -1)
                                                                    {
                                                                        maoPlayer[n] = maoPlayer[n + 1];
                                                                        maoPlayer[n + 1] = -1;
                                                                    }
                                                                }
                                                                x--; //Tira uma possibilidade de jogar
                                                                validação++;
                                                            }
                                                        }
                                                        else if (escolha2 == 2) // Sai do combo
                                                        {
                                                            validação++;
                                                            x = 0;
                                                        }
                                                    }
                                                }
                                                else //Sai da ação de jogada
                                                { validação++; }
                                            }
                                        }
                                    } while (validação == 0); // Condição para ficar dentro da ação de jogada
                                    RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);

                                    //Cartas especiais
                                    if (cartaID[naMesa].Substring(1, 1) == "B") //Ação da carta de Block
                                    {
                                        podeJogarB = 1;
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nVocê bloqueou o Player 2");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "X") //Ação da carta +2 Carta
                                    {
                                        comboCompra = comboCompra + 2;
                                        podeJogarB = 0;
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nVocê fez o PLayer 2 comprar cartas!");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "C" || cartaID[naMesa].Substring(1, 1) == "Y") //Ação da carta Coringa
                                    {
                                        Console.Write("\n1 - Vermelho" + "\n2 - Amarelo" + "\n3 - Verde" + "\n4 - Azul" + "\nDigite a nova cor:");
                                        Cor = int.Parse(Console.ReadLine());

                                        if (cartaID[naMesa].Substring(1, 1) == "Y") //Ação da carta Coringa +4
                                        {
                                            int qntde = 0;
                                            qntde = qntFalse(cartaCompra);
                                            if (qntde > 0)
                                            {
                                                qntBot = qntMao(maoBot);
                                                for (i = qntBot; i < qntBot + 4; i++)
                                                {
                                                    do
                                                    {
                                                        a = gerador.Next(0, 100);
                                                    } while (cartaCompra[a] == true);

                                                    maoBot[i] = a;
                                                    cartaCompra[a] = true;
                                                }
                                            }
                                            else { FimDoJogo(); }
                                        }
                                        naMesa = 100 + Cor; //As cartas de cor estão após o 100
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nNova cor na mesa: {0}", cartaNome[naMesa]);
                                    }

                                    Console.Write("\n\nVocê terminou sua jogada! Aperte algo para continuar...");
                                    Console.ReadKey();

                                    if (podeJogarB == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        Console.WriteLine("Vez do proximo jogador! \n\nDigite algo para jogar Player 1...");
                                        Console.ReadKey();
                                    }

                                    podeJogarP = 1;
                                } //Jogada Comum
                            }

                            else if (escolha == 2) //Ação de Compra
                            {
                                int qntde = 0;
                                qntde = qntFalse(cartaCompra);
                                if (qntde > 0)
                                {
                                    for (i = qntPlayer; i < qntPlayer + 1; i++)
                                    {
                                        do
                                        {
                                            a = gerador.Next(0, 100);
                                        } while (cartaCompra[a] == true);

                                        maoPlayer[i] = a;
                                        cartaCompra[a] = true;
                                    }
                                    podeJogarP = 0;
                                }
                                else { FimDoJogo(); }
                            }
                        }
                        //Fim da jogada do Player 1
                        podeJogarP = 0;
                        #endregion

                        #region//Jogada do Player 2
                        //Jogada do PLAYER 2
                        escolha = 0;
                        qntJogadas = 0;
                        while (podeJogarB == 0)
                        {
                            podeJogarP = 0;
                            do
                            {
                                revide = 0;
                                int x = 0;
                                foreach (int valor in maoBot) //Contagem de possibilidades de cartas para revidar o combo de compra
                                {
                                    if (valor != -1 &&
                                        cartaID[valor].Substring(0, 2) == "EX")
                                    {
                                        x++;
                                    }
                                }
                                if (x > 0 && comboCompra > 0) // se há o que revidar ou se há possibilidade de revidar
                                {
                                    do
                                    {
                                        RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 0);
                                        Console.Write("\nDeseja revidar a carta de compra? \n1-Sim \n2-Não \nEscolha:");
                                        revide = int.Parse(Console.ReadLine());

                                    } while (revide != 1 && revide != 2);
                                }
                                else if (revide == 1) //Se escolha é SIM
                                {
                                    validação = 0;
                                    do
                                    {
                                        RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 1);
                                        Console.Write("Qual carta quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());
                                        if (maoBot[cartaEsc - 1] == -1 ||
                                            cartaID[maoBot[cartaEsc - 1]].Substring(0, 2) != "EX") //Se for escolhida carta invalida para o combo, faz retornar a pergunta anterior
                                        {
                                            Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                            Console.ReadKey();
                                        }
                                        else //Se possivel de combar com a carta escolhida, põe ela na mesa
                                        {
                                            naMesa = maoBot[cartaEsc - 1];
                                            comboCompra = comboCompra + int.Parse(cartaNome[maoBot[cartaEsc - 1]].Substring(1, 1)); //Soma a qnt de compra pro combo
                                            maoBot[cartaEsc - 1] = -1;
                                            maoBot = ArrumaMao(maoBot);

                                            Console.WriteLine("Você revido! Agora o adversário compra {0}! \nDigite Algo para prosseguir...", comboCompra);
                                            Console.ReadKey();
                                            validação = 1;
                                            podeJogarB = 1;
                                        }
                                    } while (validação == 0);
                                }
                                else if (x == 0 || revide == 2 || comboCompra == 0) //Se não é possível o revidar ou a escolha é NÃO ou nem há o que revidar
                                {
                                    if (comboCompra > 0) //Ve se há combo de compra pendente, se tiver bota na mão do Bot
                                    {
                                        int qntde = 0;
                                        qntde = qntFalse(cartaCompra);
                                        if (qntde > 0)
                                        {
                                            qntBot = qntMao(maoBot);
                                            for (i = qntBot; i < qntBot + comboCompra; i++)
                                            {
                                                do
                                                {
                                                    a = gerador.Next(0, 100);
                                                } while (cartaCompra[a] == true);

                                                maoBot[i] = a;
                                                cartaCompra[a] = true;
                                            }
                                            comboCompra = 0;
                                        }
                                        else { FimDoJogo(); }
                                    }
                                    //Inicia a jogada
                                    qntJogadas = RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 0);      //Imprime a quantidade de cartas do bot, a carta da mesa e a mão do player                                      
                                    Console.WriteLine("\n\nAções possíveis:");                                              //Apresenta as ações possíveis
                                    if (qntJogadas > 0)
                                        Console.WriteLine("1- Jogar");                                   //Limitando ações impossíveis
                                    Console.WriteLine("2- Comprar");
                                    if (qntJogadas > 0)
                                        Console.WriteLine("3- Falar UNO e jogar");

                                    Console.Write("Digite sua ação (apenas o numero): ");
                                    escolha = int.Parse(Console.ReadLine());
                                    if ((escolha == 1 || escolha == 3) && qntJogadas != 0) //Permite sair do loop contanto que seja uma compra ou q vc tenha a possibilidade de jogar alguma carta
                                        validação++;
                                    else if (escolha == 2)
                                        validação++;
                                    else
                                        validação = 0;

                                }

                            } while (validação == 0);
                            validação = 0;

                            //Jogar
                            qntBot = qntMao(maoBot);

                            if (escolha == 1 || escolha == 3)
                            {
                                if (qntBot == 2 && escolha == 1 || qntBot != 2 && escolha == 3)
                                {
                                    if (qntBot == 2)
                                        Console.WriteLine("Você não deu UNO! \nRecebe +1");
                                    else
                                        Console.WriteLine("Você falou UNO na hora errada! \nRecebe +1");
                                    int qntde = 0;
                                    qntde = qntFalse(cartaCompra);
                                    if (qntde > 0)
                                    {
                                        for (i = qntBot; i < qntBot + 1; i++)
                                        {
                                            do
                                            {
                                                a = gerador.Next(0, 100);
                                            } while (cartaCompra[a] == true);

                                            maoBot[i] = a;
                                            cartaCompra[a] = true;
                                        }
                                    }
                                    else { FimDoJogo(); }

                                    Console.WriteLine("Pressione qualquer tecla para continuar ...");
                                    Console.ReadKey();
                                }//Falha no UNO
                                else
                                {
                                    do
                                    {
                                        RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 1);
                                        validação = 0;

                                        Console.Write("\nQual carta você quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());

                                        int x = 0;
                                        if (maoBot[cartaEsc - 1] != -1)
                                        {
                                            if (cartaID[maoBot[cartaEsc - 1]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                               cartaID[maoBot[cartaEsc - 1]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) ||
                                               cartaID[maoBot[cartaEsc - 1]].Substring(0, 2) == "EC" ||
                                               cartaID[maoBot[cartaEsc - 1]].Substring(0, 2) == "EY")
                                            {
                                                naMesa = maoBot[cartaEsc - 1];                                   //Torna a carta jogada como a carta na mesa
                                                maoBot[cartaEsc - 1] = -1;                                       //Torna o espaço da carta jogada vazio
                                                maoBot = ArrumaMao(maoBot);                                      //Arruma a mão do player após haver um descarte comum

                                                foreach (int valor in maoBot)
                                                {
                                                    if (valor != -1 && (cartaID[valor].Substring(0, 2) == cartaID[naMesa].Substring(0, 2)))
                                                    {
                                                        x++;
                                                    }
                                                }

                                                if (x > 0)
                                                {
                                                    while (x > 0)
                                                    {
                                                        RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 1);

                                                        Console.WriteLine("\nVocê tem {0} cartas com o mesmo numero. Quer jogar elas para combar?", x);
                                                        Console.Write("1- Jogar \n2- Não jogar \nEscolha: ");
                                                        escolha2 = int.Parse(Console.ReadLine());
                                                        if (escolha2 == 1)
                                                        {
                                                            Console.Write("Qual carta quer jogar: ");
                                                            cartaEsc = int.Parse(Console.ReadLine());
                                                            if (maoBot[cartaEsc - 1] == -1 || cartaID[maoBot[cartaEsc - 1]].Substring(1, 1) != cartaID[naMesa].Substring(1, 1))
                                                            {
                                                                Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                                                Console.ReadKey();
                                                            }
                                                            else
                                                            {
                                                                naMesa = maoBot[cartaEsc - 1];
                                                                maoBot[cartaEsc - 1] = -1;

                                                                for (n = 0; n < 97; n++)
                                                                {
                                                                    if (maoBot[n] == -1)
                                                                    {
                                                                        maoBot[n] = maoBot[n + 1];
                                                                        maoBot[n + 1] = -1;
                                                                    }
                                                                }
                                                                x--;
                                                                validação++;
                                                            }
                                                        }
                                                        else if (escolha2 == 2)
                                                        {
                                                            validação++;
                                                            x = 0;
                                                        }
                                                    }
                                                }
                                                else if (x == 0) //Se não tiver + cartas jogaveis, validação++ e sai
                                                { validação++; }
                                            }
                                        }
                                    } while (validação == 0);
                                    RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 1);

                                    if (cartaID[naMesa].Substring(1, 1) == "B")
                                    {
                                        podeJogarP = 1;
                                        RefreshMesa(maoPlayer, maoBot, cartaNome, naMesa, cartaID, "TELA PLAYER 2", 1);
                                        Console.WriteLine("\nVocê bloqueou o Player 1!");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "X")
                                    {
                                        comboCompra = comboCompra + 2;
                                        Console.WriteLine("\nVocê fez o Player 1 comprar cartas!");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "C" || cartaID[naMesa].Substring(1, 1) == "Y")
                                    {
                                        Console.Write("\n1 - Vermelho" + "\n2 - Amarelo" + "\n3 - Verde" + "\n4 - Azul" + "\nDigite a nova cor:");
                                        Cor = int.Parse(Console.ReadLine());

                                        if (cartaID[naMesa].Substring(1, 1) == "Y")
                                        {
                                            int qntde = 0;
                                            qntde = qntFalse(cartaCompra);
                                            if (qntde > 0)
                                            {
                                                qntPlayer = qntMao(maoPlayer);
                                                for (i = qntPlayer; i < qntPlayer + 4; i++)
                                                {
                                                    do
                                                    {
                                                        a = gerador.Next(0, 100);
                                                    } while (cartaCompra[a] == true);

                                                    maoPlayer[i] = a;
                                                    cartaCompra[a] = true;
                                                }
                                            }
                                            else { FimDoJogo(); }
                                        }
                                        naMesa = 100 + Cor;
                                        Console.WriteLine("Nova cor na mesa: {0} ", cartaNome[naMesa]);
                                    }

                                    Console.Write("\n\nVocê terminou sua jogada! Aperte algo para continuar...");
                                    Console.ReadKey();

                                    if (podeJogarB == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.Clear();
                                        Console.WriteLine("Vez do proximo jogador! \n\nDigite algo para jogar Player 1...");
                                        Console.ReadKey();
                                    }

                                    podeJogarB = 1;
                                }

                            }
                            //Comprar
                            else if (escolha == 2)
                            {
                                int qntde = 0;
                                qntde = qntFalse(cartaCompra);
                                if (qntde > 0)
                                {
                                    for (i = qntBot; i < qntBot + 1; i++)
                                    {
                                        do
                                        {
                                            a = gerador.Next(0, 100);
                                        } while (cartaCompra[a] == true);

                                        maoBot[i] = a;
                                        cartaCompra[a] = true;
                                    }
                                    podeJogarB = 0;
                                }
                                else { FimDoJogo(); }
                            }
                        }
                        podeJogarB = 0;
                        //Fim Jogada do Bot
                        #endregion

                        #region//FIM
                        qntPlayer = qntMao(maoPlayer);
                        qntBot = qntMao(maoBot);
                        if (qntPlayer == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                            Console.WriteLine("PLAYER 1 VENCEU!!!\nPARABENS!!!\nPEGUE SEU PRÊMIO NO CURRAL MAIS PRÓXIMO!!!");
                            Console.ReadKey();
                            prasempre = 1;
                            entrada = 0;
                        }
                        else if (qntBot == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Clear();
                            Console.WriteLine("PLAYER 2 VENCEU!!!\nPARABENS!!!\nPEGUE SEU PRÊMIO NO CURRAL MAIS PRÓXIMO!!!");
                            Console.ReadKey();
                            prasempre = 1;
                            entrada = 0;
                        }
                        #endregion
                    }
                    while (prasempre == 0);
                }
                #endregion

                #region//Player vs BOT
                else if (entrada == 1)
                {
                    do
                    {
                        #region//Jogada do Player
                        podeJogarB = 0;
                        escolha = 0;
                        while (podeJogarP == 0) //A vez do player só inicia quando essa variável é 0!
                        {
                            do
                            {
                                revide = 0;
                                int x = 0;
                                foreach (int valor in maoPlayer) //Contagem de possibilidades de cartas para revidar o combo de compra
                                {
                                    if (valor != -1 &&
                                        cartaID[valor].Substring(0, 2) == "EX")
                                    {
                                        x++;
                                    }
                                }
                                if (x > 0 && comboCompra > 0)  // se há o que revidar e há possibilidade de revidar 
                                {
                                    do
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 0);
                                        Console.Write("\nDeseja revidar a carta de compra? \n1-Sim \n2-Não \nEscolha:");
                                        revide = int.Parse(Console.ReadLine());
                                    } while (revide != 1 && revide != 2);
                                }

                                if (revide == 1) //Se escolha é SIM
                                {
                                    validação = 0;
                                    do
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.Write("Qual carta quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());
                                        if (maoPlayer[cartaEsc - 1] == -1 ||
                                            cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) != "EX") //Se for escolhida carta invalida para o combo, faz retornar a pergunta anterior
                                        {
                                            Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                            Console.ReadKey();
                                        }
                                        else //Se possivel de combar com a carta escolhida, põe ela na mesa
                                        {
                                            naMesa = maoPlayer[cartaEsc - 1];
                                            comboCompra = comboCompra + int.Parse(cartaNome[maoPlayer[cartaEsc - 1]].Substring(1, 1)); //Soma a qnt de compra pro combo
                                            maoPlayer[cartaEsc - 1] = -1;
                                            maoPlayer = ArrumaMao(maoPlayer);

                                            Console.WriteLine("Você revidou! Agora o adversário compra {0}! \nDigite Algo para prosseguir...", comboCompra);
                                            Console.ReadKey();
                                            validação = 1;
                                            podeJogarP = 1;
                                        }
                                    } while (validação == 0);
                                }

                                else if (x == 0 || revide == 2 || comboCompra == 0) //Se não é possível o revidar ou a escolha é NÃO ou nem há o que revidar
                                {
                                    if (comboCompra > 0) //Ve se há combo de compra pendente, se tiver bota na mão do Player
                                    {
                                        int qntde = 0;
                                        qntde = qntFalse(cartaCompra);
                                        if (qntde > 0)
                                        {
                                            qntPlayer = qntMao(maoPlayer);
                                            for (i = qntPlayer; i < qntPlayer + comboCompra; i++)
                                            {
                                                do
                                                {
                                                    a = gerador.Next(0, 100);
                                                } while (cartaCompra[a] == true);

                                                maoPlayer[i] = a;
                                                cartaCompra[a] = true;
                                            }
                                            comboCompra = 0;
                                        }
                                        else { FimDoJogo(); }
                                    }
                                    //Inicia a jogada
                                    qntJogadas = RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 0);      //Imprime a quantidade de cartas do bot, a carta da mesa e a mão do player                                      
                                    Console.WriteLine("\n\nAções possíveis:");                                              //Apresenta as ações possíveis
                                    if (qntJogadas > 0)
                                        Console.WriteLine("1- Jogar");                                   //Limitando ações impossíveis
                                    Console.WriteLine("2- Comprar");
                                    if (qntJogadas > 0)
                                        Console.WriteLine("3- Falar UNO e jogar");

                                    Console.Write("Digite sua ação (apenas o numero): ");
                                    escolha = int.Parse(Console.ReadLine());
                                    if ((escolha == 1 || escolha == 3) && qntJogadas != 0) //Permite sair do loop contanto que seja uma compra ou q vc tenha a possibilidade de jogar alguma carta
                                        validação++;
                                    else if (escolha == 2)
                                        validação++;
                                    else
                                        validação = 0;
                                }

                            } while (validação == 0);
                            validação = 0;

                            //Jogar
                            qntPlayer = qntMao(maoPlayer);

                            if (escolha == 1 || escolha == 3) //caso seja uma escolha que vá jogar uma carta na mesa
                            {
                                if (qntPlayer == 2 && escolha == 1) //Analisa se a escolha foi 1 no momento de falar UNO e da penalidade
                                {
                                    int qntde = 0;
                                    qntde = qntFalse(cartaCompra);
                                    if (qntde > 0)
                                    {
                                        Console.WriteLine("\nVocê não deu UNO!!! \nRecebe +1!");
                                        Console.ReadKey();
                                        for (i = qntPlayer; i < qntPlayer + 1; i++) //Dá mais uma carta(não repetida) pela pela penalidade
                                        {
                                            do
                                            {
                                                a = gerador.Next(0, 100);
                                            } while (cartaCompra[a] == true);

                                            maoPlayer[i] = a;
                                            cartaCompra[a] = true;
                                        }
                                    }
                                    else
                                    {
                                        FimDoJogo();
                                    }
                                } //Não deu UNO
                                else if (qntPlayer != 2 && escolha == 3) //Analisa se a escolha foi 3 no momento errado
                                {
                                    int qntde = 0;
                                    qntde = qntFalse(cartaCompra);
                                    if (qntde > 0)
                                    {
                                        Console.WriteLine("\nVocê falou UNO na hora errada!!! \nRecebe +1!");
                                        Console.ReadKey();
                                        for (i = qntPlayer; i < qntPlayer + 1; i++) //Dá mais uma carta(não repetida) pela pela penalidade
                                        {
                                            do
                                            {
                                                a = gerador.Next(0, 100);
                                            } while (cartaCompra[a] == true);

                                            maoPlayer[i] = a;
                                            cartaCompra[a] = true;

                                        }
                                    }
                                    else
                                    {
                                        FimDoJogo();
                                    }
                                    Console.WriteLine("Pressione qualquer tecla para continuar ...");
                                    Console.ReadKey();
                                } //Deu UNO antes da hora
                                else //Se não foi barrado por nenhuma oposição antes, permite continuar!
                                {
                                    do //Estrutura de ação
                                    {
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        validação = 0;

                                        Console.Write("\nQual carta você quer jogar: ");
                                        cartaEsc = int.Parse(Console.ReadLine());
                                        int x = 0;
                                        if (maoPlayer[cartaEsc - 1] != -1)
                                        {
                                            if (cartaID[maoPlayer[cartaEsc - 1]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) == "EC" ||
                                              cartaID[maoPlayer[cartaEsc - 1]].Substring(0, 2) == "EY") //Verifica se é uma jogada possível
                                            {
                                                naMesa = maoPlayer[cartaEsc - 1];                                   //Torna a carta jogada como a carta na mesa
                                                maoPlayer[cartaEsc - 1] = -1;                                       //Torna o espaço da carta jogada vazio
                                                maoPlayer = ArrumaMao(maoPlayer);                                   //Arruma a mão do player após haver um descarte comum

                                                foreach (int valor in maoPlayer) //Contagem de possibilidades de cartas a serem jogadas para combar
                                                {
                                                    if (valor != -1 && (cartaID[valor].Substring(0, 2) == cartaID[naMesa].Substring(0, 2)))
                                                    {
                                                        x++;
                                                    }
                                                }

                                                if (x > 0) //Estrutura do combo
                                                {
                                                    while (x > 0) //Combo possivel
                                                    {
                                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);

                                                        Console.WriteLine("\nVocê tem {0} cartas com o mesmo numero. Quer jogar elas para combar?", x);
                                                        Console.Write("1- Jogar \n2- Não jogar \nEscolha: ");
                                                        escolha2 = int.Parse(Console.ReadLine());
                                                        if (escolha2 == 1)
                                                        {
                                                            Console.Write("Qual carta quer jogar: ");
                                                            cartaEsc = int.Parse(Console.ReadLine());
                                                            if (maoPlayer[cartaEsc - 1] == -1 || cartaID[maoPlayer[cartaEsc - 1]].Substring(1, 1) != cartaID[naMesa].Substring(1, 1)) //Se for escolhida carta invalida para o combo, faz retornar a pergunta anterior
                                                            {
                                                                Console.WriteLine("Opção invalida, aperte qualquer tecla para continuar.");
                                                                Console.ReadKey();
                                                            }
                                                            else //Se possivel de combar com a carta escolhida, põe ela na mesa
                                                            {
                                                                naMesa = maoPlayer[cartaEsc - 1];
                                                                maoPlayer[cartaEsc - 1] = -1;

                                                                for (n = 0; n < 97; n++) //Arruma mão do player
                                                                {
                                                                    if (maoPlayer[n] == -1)
                                                                    {
                                                                        maoPlayer[n] = maoPlayer[n + 1];
                                                                        maoPlayer[n + 1] = -1;
                                                                    }
                                                                }
                                                                x--; //Tira uma possibilidade de jogar
                                                                validação++;
                                                            }
                                                        }
                                                        else if (escolha2 == 2) // Sai do combo
                                                        {
                                                            validação++;
                                                            x = 0;
                                                        }
                                                    }
                                                }
                                                else //Sai da ação de jogada
                                                { validação++; }
                                            }
                                        }
                                    } while (validação == 0); // Condição para ficar dentro da ação de jogada
                                    RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);

                                    //Cartas especiais
                                    if (cartaID[naMesa].Substring(1, 1) == "B") //Ação da carta de Block
                                    {
                                        podeJogarB = 1;
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nVocê bloqueou o Bot");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "X") //Ação da carta +2 Carta
                                    {
                                        comboCompra = comboCompra + 2;
                                        podeJogarB = 0;
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nVocê fez o Bot comprar cartas!");
                                    }
                                    else if (cartaID[naMesa].Substring(1, 1) == "C" || cartaID[naMesa].Substring(1, 1) == "Y") //Ação da carta Coringa
                                    {
                                        Console.Write("\n1 - Vermelho" + "\n2 - Amarelo" + "\n3 - Verde" + "\n4 - Azul" + "\nDigite a nova cor:");
                                        Cor = int.Parse(Console.ReadLine());

                                        if (cartaID[naMesa].Substring(1, 1) == "Y") //Ação da carta Coringa +4
                                        {
                                            int qntde = 0;
                                            qntde = qntFalse(cartaCompra);
                                            if (qntde > 0)
                                            {
                                                qntBot = qntMao(maoBot);
                                                for (i = qntBot; i < qntBot + 4; i++)
                                                {
                                                    do
                                                    {
                                                        a = gerador.Next(0, 100);
                                                    } while (cartaCompra[a] == true);

                                                    maoBot[i] = a;
                                                    cartaCompra[a] = true;
                                                }
                                            }
                                            else
                                            {
                                                FimDoJogo();
                                            }
                                        }
                                        naMesa = 100 + Cor; //As cartas de cor estão após o 100
                                        RefreshMesa(maoBot, maoPlayer, cartaNome, naMesa, cartaID, "TELA PLAYER 1", 1);
                                        Console.WriteLine("\nNova cor na mesa: {0}", cartaNome[naMesa]);
                                    }

                                    Console.Write("\nDigite algo para finalizar a jogada...");
                                    Console.ReadKey();

                                    podeJogarP = 1;
                                } //Jogada Comum
                            }

                            else if (escolha == 2) //Ação de Compra
                            {
                                int qntde = 0;
                                qntde = qntFalse(cartaCompra);
                                if (qntde > 0)
                                {
                                    for (i = qntPlayer; i < qntPlayer + 1; i++)
                                    {
                                        do
                                        {
                                            a = gerador.Next(0, 100);
                                        } while (cartaCompra[a] == true);

                                        maoPlayer[i] = a;
                                        cartaCompra[a] = true;
                                    }
                                    podeJogarP = 0;
                                }
                                else
                                {
                                    FimDoJogo();
                                }
                            }
                        }
                        //Fim da jogada do Player
                        #endregion

                        #region//Jogada do Bot
                        podeJogarP = 0;
                        escolha = 0;
                        //Inteligência Artificial do Computador
                        qntJogadas = 0;
                        while (podeJogarB == 0)
                        {
                            //Inicio do Histórico de ações do Bot!
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();

                            Console.WriteLine("AÇÕES DO BOT \n");

                            #region//enchendo os vetores de predominância
                            validação = 0;
                            qnt2 = 0; qntC = 0; qntC4 = 0; qntB = 0;
                            for (i = 0; i < 4; i++)
                            {
                                CorPredo[i] = "z";
                            }
                            #endregion

                            #region//Organização da predominância
                            foreach (int valor in maoBot)
                            {
                                if (valor != -1)
                                {
                                    #region//Contadores de Predominâcia de cor
                                    if (cartaID[valor].Substring(2, 1) == "R")//ve se é Vermelha
                                    {
                                        corAlguma[0]++;
                                        CorPredo[0] = "R" + Convert.ToString(corAlguma[0]);
                                    }
                                    if (cartaID[valor].Substring(2, 1) == "B")//ve se é Azul
                                    {
                                        corAlguma[1]++;
                                        CorPredo[1] = "B" + Convert.ToString(corAlguma[1]);
                                    }
                                    if (cartaID[valor].Substring(2, 1) == "Y")//ve se é Amarelo
                                    {
                                        corAlguma[2]++;
                                        CorPredo[2] = "Y" + Convert.ToString(corAlguma[2]);
                                    }
                                    if (cartaID[valor].Substring(2, 1) == "G")//ve se é Verde
                                    {
                                        corAlguma[3]++;
                                        CorPredo[3] = "G" + Convert.ToString(corAlguma[3]);
                                    }
                                    #endregion

                                    #region//Contador de cartas especiais
                                    if (cartaID[valor].Substring(0, 2) == "EX")//ve se é Compra +2
                                    {
                                        qnt2++;
                                    }
                                    if (cartaID[valor].Substring(0, 2) == "EC")//ve se é Coringa
                                    {
                                        qntC++;
                                    }
                                    if (cartaID[valor].Substring(0, 2) == "EY")//ve se é Coringa +4
                                    {
                                        qntC4++;
                                    }
                                    if (cartaID[valor].Substring(0, 2) == "EB")//ve se é Bloqueio
                                    {
                                        qntB++;
                                    }
                                    #endregion
                                }
                            }
                            #region//Organização da predominância das cores
                            int[] ordemDecrescenteCor = corAlguma.OrderByDescending(s => s).ToArray();
                            for (i = 0; i < 4; i++)
                            {
                                for (j = 0; j < 4; j++)
                                {
                                    if (CorPredo[j] != "z")
                                    {
                                        if (ordemDecrescenteCor[i] == int.Parse(CorPredo[j].Substring(1, 1)) && CorPredo[j].Length == 2)
                                        {
                                            CorPredo[j] = CorPredo[j] + Convert.ToString((i + 1)); //[0] = Cor, [1] = Quantidade, [2] = Colocação (decrescente)
                                        }
                                    }
                                }
                            }
                            #endregion
                            #endregion


                            #region//Opção de revidar & Escolha da ação inicial
                            do
                            {
                                //Se tem um combo pendente e você pode revidá-lo
                                if (qnt2 > 0 && comboCompra > 0)
                                {
                                    qntBot = qntMao(maoBot);

                                    for (i = 0; i < 5; i++) //da os valores das colocações, de 1ºLugar ao 4ºLugar
                                    {
                                        foreach (string aux in CorPredo) //faz pesquisa na CorPredo
                                        {
                                            if (aux != "z")
                                            {
                                                if (aux.Substring(2, 1) == Convert.ToString(i + 1) && aux != "z") //Se encontrar a cor da colocação i
                                                {
                                                    for (j = 0; j < qntBot; j++) //passa pela mão do bot olhando
                                                    {
                                                        if (maoBot[j] != -1)
                                                        {
                                                            if (cartaID[maoBot[j]].Substring(2, 1) == aux.Substring(0, 1) &&
                                                                cartaID[maoBot[j]].Substring(2, 1) == "EX")//se encontrar uma carta com a mesma cor da colocação i
                                                            {
                                                                naMesa = maoBot[j]; //bota na mesa
                                                                Console.WriteLine("• Revidou com um {0}!;\n", maoBot[j]);
                                                                comboCompra = comboCompra + int.Parse(cartaNome[maoBot[j]].Substring(1, 1));// Soma a qnt de compra pro combo
                                                                maoBot[j] = -1; //tira da mão
                                                                maoBot = ArrumaMao(maoBot); //Arruma a mão do bot
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    validação++;
                                    podeJogarB = 1;
                                }

                                //Se não for possível revidar ou não há combo
                                else if (qnt2 == 0 || comboCompra == 0)
                                {
                                    //Se há um combo pendente e não há como revidar, ele coloca na mão do bot
                                    if (comboCompra > 0)
                                    {
                                        int qntde = 0;
                                        qntde = qntFalse(cartaCompra);
                                        if (qntde > 0)
                                        {
                                            qntBot = qntMao(maoBot);
                                            for (i = qntBot; i < qntBot + comboCompra; i++)
                                            {
                                                do
                                                {
                                                    a = gerador.Next(0, 100);
                                                } while (cartaCompra[a] == true);

                                                maoBot[i] = a;
                                                cartaCompra[a] = true;
                                            }
                                            comboCompra = 0;
                                        }
                                        else { FimDoJogo(); }
                                    }

                                    #region//Escolha da ação inicial
                                    qntBot = qntMao(maoBot); //qnt de cartas do Bot
                                    qntPlayer = qntMao(maoPlayer); //qnt de cartas do Player


                                    z = 0; //variavel que tem a qnt de cartas possiveis do Bot jogar (de mesma cor ou número)
                                    foreach (int valor in maoBot)
                                    {
                                        if (valor != -1)
                                        {
                                            if (cartaID[valor].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                          cartaID[valor].Substring(2, 1) == cartaID[naMesa].Substring(2, 1))
                                            {
                                                z++;
                                            }

                                        }
                                        else
                                            break;
                                    }

                                    //Se há possibilidade de jogar (msm cor ou numero)
                                    if (z > 0)
                                    {
                                        if (qntBot == 2) //Falar UNO
                                        {
                                            escolha = 3;
                                            Console.WriteLine("• Falou UNO;\n");
                                        }
                                        else //Jogar normal
                                        { escolha = 1; }
                                        validação++;
                                    }

                                    //Se não há possibilidade de jogar (msm cor ou numero)
                                    else if (z == 0)
                                    {
                                        if ((qntC4 + qntC) > 0) //Se há possibilidade de jogar coringa, ele joga
                                        {
                                            if (qntBot == 2) //Impede o bot de errar o UNO
                                            {
                                                escolha = 3;
                                                Console.WriteLine("• Falou UNO;\n");
                                            }
                                            else
                                            { escolha = 1; }
                                            validação++;

                                        }
                                        else //Se não tiver nenhuma possibilidade, ele compra
                                            escolha = 2;
                                        validação++;

                                    }
                                    #endregion
                                }

                            } while (validação == 0);
                            validação = 0;
                            #endregion

                            qntBot = qntMao(maoBot); //qnt de cartas do Bot

                            //VAI JOGAR
                            if (escolha == 1 || escolha == 3)
                            {
                                if (comprinha > 0)
                                    Console.WriteLine("• Comprou {0} cartas;\n", comprinha);

                                do
                                {
                                    #region//Ações
                                    //Jogadas finais para ganhar
                                    if (qntBot < 3 && (z > 0 || qntC > 0 || qntC4 > 0))
                                    {
                                        for (i = 0; i < qntBot; i++)
                                        {
                                            if (cartaID[maoBot[i]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                                cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) ||
                                                cartaID[maoBot[i]].Substring(0, 2) == "EC" ||
                                                cartaID[maoBot[i]].Substring(0, 2) == "EY")
                                            {
                                                naMesa = maoBot[i]; //bota na mesa
                                                Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                maoBot[i] = -1; //tira da mão 
                                                maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                i = qntBot;
                                            }
                                        }
                                    }

                                    //Se o player estiver ganhando, jogar cartas de compra
                                    else if (qntPlayer < 3 && (qnt2 > 0 || qntC4 > 0))
                                    {
                                        if (qnt2 > 0)
                                        {
                                            for (i = 0; i < qntBot; i++)
                                            {
                                                if (maoBot[i] != -1)
                                                {
                                                    if (cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) &&
                                                      (cartaID[maoBot[i]].Substring(0, 2) == "EX")) //Verifica se tem carta +2 de mesma cor da mesa
                                                    {
                                                        naMesa = maoBot[i]; //bota na mesa
                                                        Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                        maoBot[i] = -1; //tira da mão 
                                                        maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                        i = qntBot;
                                                    }
                                                    else if (qntC4 > 0) //Verifica se tem +4
                                                    {
                                                        for (i = 0; i < qntBot; i++)
                                                        {
                                                            if (maoBot[i] != -1)
                                                            {
                                                                if (cartaID[maoBot[i]].Substring(0, 2) == "EY")
                                                                {
                                                                    naMesa = maoBot[i]; //bota na mesa
                                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                                    maoBot[i] = -1; //tira da mão 
                                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                                    i = qntBot;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else//Se não atender nenhuma das respostas anteriores
                                                    {
                                                        for (i = 0; i < qntBot; i++)
                                                        {
                                                            if (maoBot[i] != -1)
                                                            {
                                                                if (cartaID[maoBot[i]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                                                 cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1))
                                                                {
                                                                    naMesa = maoBot[i]; //bota na mesa
                                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                                    maoBot[i] = -1; //tira da mão 
                                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                                    i = qntBot;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    //Sempre jogar cartas de bloqueio havendo uma carta que se possa jogar em seguida
                                    else if (qntB > 0 && z > 0)
                                    {
                                        for (i = 0; i < qntBot; i++)
                                        {
                                            if (maoBot[i] != -1)
                                            {
                                                if (cartaID[maoBot[i]].Substring(0, 2) == "EB" &&
                                                  cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1))
                                                {
                                                    naMesa = maoBot[i]; //bota na mesa
                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                    maoBot[i] = -1; //tira da mão 
                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                    i = qntBot;
                                                }
                                                else if (cartaID[maoBot[i]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                                        cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1))
                                                {
                                                    naMesa = maoBot[i]; //bota na mesa
                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                    maoBot[i] = -1; //tira da mão 
                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                    i = qntBot;
                                                }
                                            }
                                        }
                                    }

                                    //Jogar coringa (caso tenha) se não há possibilidade de jogar
                                    else if ((qntC + qntC4) > 0 && z == 0)
                                    {
                                        //Se a haver uma carta Coringa normal
                                        if (qntC > 0)
                                        {
                                            for (i = 0; i < qntBot; i++) //Pesquisa e põe a carta Coringa
                                            {
                                                if (maoBot[i] != -1 && cartaID[maoBot[i]].Substring(0, 2) == "EC")
                                                {
                                                    naMesa = maoBot[i]; //bota na mesa
                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                    maoBot[i] = -1; //tira da mão 
                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                    i = qntBot;
                                                }
                                            }
                                        }
                                        //Se não ela joga a +4
                                        else
                                        {
                                            for (i = 0; i < qntBot; i++) //Pesquisa e põe a carta Coringa +4
                                            {
                                                if (maoBot[i] != -1 && cartaID[maoBot[i]].Substring(0, 2) == "EY")
                                                {
                                                    naMesa = maoBot[i]; //bota na mesa
                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                    maoBot[i] = -1; //tira da mão 
                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                    i = qntBot;
                                                }
                                            }
                                        }
                                    }

                                    //Jogada normal
                                    else
                                    {
                                        for (i = 0; i < qntBot; i++)
                                        {
                                            if (maoBot[i] != -1)
                                            {
                                                if (cartaID[maoBot[i]].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                                                 cartaID[maoBot[i]].Substring(2, 1) == cartaID[naMesa].Substring(2, 1))
                                                {
                                                    naMesa = maoBot[i]; //bota na mesa
                                                    Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                    maoBot[i] = -1; //tira da mão 
                                                    maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                    i = qntBot;
                                                }
                                            }
                                        }
                                    }
                                    #endregion

                                    #region//Sequencia
                                    int x = 0;
                                    foreach (int valor in maoBot) //pesquisa para sequencia
                                    {
                                        if (valor != -1 && (cartaID[valor].Substring(0, 2) == cartaID[naMesa].Substring(0, 2)))
                                        {
                                            x++;
                                        }
                                    }
                                    int sequencia = 0;
                                    if (x > 0)//se sequencia possivel
                                    {
                                        while (x > 0)
                                        {
                                            for (i = 0; i < qntBot; i++)
                                            {
                                                if (maoBot[i] != -1)
                                                {
                                                    if (cartaID[maoBot[i]].Substring(0, 2) == cartaID[naMesa].Substring(0, 2))
                                                    {
                                                        naMesa = maoBot[i]; //bota na mesa
                                                        Console.WriteLine("• Jogou a carta: {0};\n", cartaNome[maoBot[i]]);
                                                        maoBot[i] = -1; //tira da mão 
                                                        maoBot = ArrumaMao(maoBot);//arruma mão do bot
                                                        x--;
                                                        i = qntBot;
                                                        sequencia++;
                                                    }
                                                }
                                            }
                                        }
                                        Console.WriteLine("Foi uma sequencia de {0} cartas!", sequencia + 1);
                                        sequencia = 0;
                                        validação++;
                                    }
                                    else
                                    {
                                        validação++;
                                    }
                                    #endregion

                                } while (validação == 0);

                                #region//Verificações de cartas especiais na mesa
                                //Block
                                if (cartaID[naMesa].Substring(1, 1) == "B")
                                {
                                    podeJogarP = 1;
                                    Console.WriteLine(" -> Você foi bloqueado! <- \n");
                                }

                                //Compra +2
                                else if (cartaID[naMesa].Substring(1, 1) == "X")
                                {
                                    comboCompra = comboCompra + 2;
                                }

                                //CORINGAS
                                else if (cartaID[naMesa].Substring(1, 1) == "C" || cartaID[naMesa].Substring(1, 1) == "Y")
                                {
                                    for (i = 1; i < 5; i++)
                                    {
                                        foreach (string aux in CorPredo) //faz pesquisa na CorPredo
                                        {
                                            if (aux != "z")
                                            {
                                                if (aux.Substring(2, 1) == Convert.ToString(i)) //Se encontrar a cor da colocação 1
                                                {
                                                    if (aux.Substring(0, 1) == "R")
                                                    {
                                                        Cor = 1;
                                                        i = 5;
                                                        break;
                                                    }
                                                    if (aux.Substring(0, 1) == "Y")
                                                    {
                                                        Cor = 2;
                                                        i = 5;
                                                        break;
                                                    }
                                                    if (aux.Substring(0, 1) == "G")
                                                    {
                                                        Cor = 3;
                                                        i = 5;
                                                        break;
                                                    }
                                                    if (aux.Substring(0, 1) == "B")
                                                    {
                                                        Cor = 4;
                                                        i = 5;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //+4
                                    if (cartaID[naMesa].Substring(1, 1) == "Y")
                                    {
                                        int qntde = 0;
                                        qntde = qntFalse(cartaCompra);
                                        if (qntde > 0)
                                        {
                                            qntPlayer = qntMao(maoPlayer);
                                            for (i = qntPlayer; i < qntPlayer + 4; i++)
                                            {
                                                do
                                                {
                                                    a = gerador.Next(0, 100);
                                                } while (cartaCompra[a] == true);

                                                maoPlayer[i] = a;
                                                cartaCompra[a] = true;
                                            }
                                            Console.WriteLine(" -> Você comprou 4! <- \n");
                                        }
                                        else { FimDoJogo(); }
                                    }
                                    naMesa = 100 + Cor;
                                    Console.WriteLine(" -> Ele escolheu a cor {0}! <- \n", cartaNome[naMesa]);
                                }
                                #endregion

                                Console.WriteLine("\nDigite algo para prosseguir com a rodada...");
                                Console.ReadKey();
                                comprinha = 0;
                                podeJogarB = 1;

                            }

                            //VAI COMPRAR
                            else if (escolha == 2)
                            {
                                int qntde = 0;
                                qntde = qntFalse(cartaCompra);
                                if (qntde > 0)
                                {
                                    for (i = qntBot; i < qntBot + 1; i++)
                                    {
                                        do
                                        {
                                            a = gerador.Next(0, 100);
                                        } while (cartaCompra[a] == true);

                                        comprinha++;
                                        maoBot[i] = a;
                                        cartaCompra[a] = true;
                                    }
                                    podeJogarB = 0;
                                }
                                else { FimDoJogo(); }
                            }
                        }

                        podeJogarB = 0;
                        //Fim Jogada do Bot
                        #endregion

                        #region//FIM
                        qntPlayer = qntMao(maoPlayer);
                        qntBot = qntMao(maoBot);
                        if (qntPlayer == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                            Console.WriteLine("VOCÊ VENCEU!!!\nPARABENS!!!\nPEGUE SEU PRÊMIO NO CURRAL MAIS PRÓXIMO!!!");
                            Console.ReadKey();
                            prasempre2 = 1;
                            entrada = 0;
                        }
                        else if (qntBot == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Clear();
                            Console.Write("\n@@@@@@@&&&&&&&&&&&&&&&&&&&&&&&@@@@@@(####%%%%&&@@@@@@@@@@@&#((%&@@@@@@@@@@@@@@@@"
                                        + "\n@@@@@@@@@@@@@@@@@@&&&&&&&&&&&&&&&&&@(####%%&@@@@@@@@@@@&&&%%#%%&@@@@@@@@@@@@@@@@"
                                        + "\n@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@@@@@(#%##%%%@@@@@&&@@@@@@@@@&&&@@@@@@@@@@@@@@@@&"
                                        + "\n@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@@@@@#&&&&&&&@@@@@@@@@@@@@&&&&&&&@@@@@@@@@@@@@@@@"
                                        + "\n@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@&/###%#@&&&&&&&&@@&&&&%%%%%&&&&&@@@@@@@@@@@@"
                                        + "\n*/&@@@@@@@@@@@@@@@&%@@@@@@@@@@@@@@@@&/###%#@@@@@@&&@@@@@@@@&&%&&&&&&&&&&&@@@@@@&"
                                        + "\n#((*/@@@@@@@@@@%//((#&@@@@@&&@@@@@@@&/###%#@@@@&&&&@&&&&@@@&(((/#@@@@&@@@@@@&**/"
                                        + "\n####((/#@@@@&//(##%%%&@@@@&&&@@@@@@@&/###%#@@@@&&&&@&&&&&&&#####((/#&@@@@@(*/(##"
                                        + "\n@&%###&@@@@((##%%%&@@@@@@@&&&@@@@@@@%/###%#@@@@&&&&@&&&&&&&&&&&#####((@@@@%##%%%"
                                        + "\n@@@@@@@@@@@%%%&&@@@@@@@@@@&@@@@@@@@@&/###%#@@@@&&&&@&&&&&&&&&&&&@%####@@@@@@&@@@"
                                        + "\n@@@@@@%#(#%@@@@@@@@@@@@@@@@@@@@@@@@@&%%%%&&@@@@@@&&@&&&&&&&&&@@@@@@@@@%%%@@@@@@@"
                                        + "\n&&&&&/(##%%@@@@@@@@@@@@@@@@@@@&&@@@@(((####&@@@@@@@@@@@@@&&&@@@@@@@@@@%###(&@@@@"
                                        + "\n&&&&((#&&%&&&&&&&&&&&&&&&&&&&&@%/,,,,,,,,,,/@@((((&@@&@@@@&&&&@@@@@@@@&%&&#(%@@@"
                                        + "\n@@&/(#@@@@@@@@@@@@@&@&&&&&&&/,/#(((###(###(#(@####((*%@@@@@&&&&&&&&&&&&&@@@(#%&&"
                                        + "\n@@((#@@@@@@@@@@@@@&&&&@@&%*/#(###########(##@@##(#####(/@@&&&&&@&@@@@@@@@@@&((&@"
                                        + "\n&#((&@@@@@@@@@@@@@@&&&@&//#(##########%%%%#%@&#(########(#@@#(((((((((((((&@%#(/"
                                        + "\n%&@@@@@@@@@@@@@@@@@@@@&//#########%%%#&&&&&%%%%%#########((@#(((((((((((((#@@@&("
                                        + "\n%&@@@@@@@@@@@@@@@@@@@@(/#########%%&&%%%%%%%&&&%#((#######(%#///(((((((((((&@@@#"
                                        + "\n#@@##/&&&&&&@@@@@@@@@&/(########%%&&&%%%%%%%%%&&##/(#########*///////((((((&@@@%"
                                        + "\n#&@#%(&&&&&&&&&&&@@@@@/(#######(#%&&&%%%%%%%%&&&%#/(########%****//////////%&&@%"
                                        + "\n#&@#%(&@@@@@@@@@@@@@@@#(#######(/#%&&&&%%%%&&&&%#//########%@%#(//////////(/(#@#"
                                        + "\n(%@%###@@@@@@@@@@@@@@@&((########/*/%%%&&@&&%%(**(########%@@@@@@@@@@@@@@@#/(%@("
                                        + "\n#(((##/&@@@@@@@@@&&&&&&&((##########(/*,,*/%%/(##########%@@@@@@@@@@@@@@@&/(#@%/"
                                        + "\n##(####(@&%####%%%%%%%&&&##################&%##########%&@@@@@&@@@@@@@@@@/((%&(/"
                                        + "\n###(###(*((#(#######%&@@@@&%%#############%##########%@@@@@@@&#(((//#&@&*(###(//"
                                        + "\n####(####*(#%%%%@%((##%&@@@@&((#%%%%######&@%###%%&@@@@@@@@@&%(####(/**/(##%(///"
                                        + "\n#####(###(&@@@@@#((/(((((##&&&(((((%@@@@&@@@@@@@@&&&@@@@@@@&&&@@%&%#(*/(##%/*///"
                                        + "\n####(%@@@%%@@@@%(((//////(/((((((((%@@@@@@%&@@@@@&%&@@@@@@@@&((@@@@@@((#%#,,////"
                                        + "\n&%#%%(&@@@&#(#*&&&&&&&&&&&&&&&#/((#&@@@@@@%/,#&@@&%&@@@@@@@&&#/#@@@@&#@@@&&&&&@&"
                                        + "\n#@@@@@(#%%##%@&&&@@@@@@@@@@&&@&@@@&@@@@@@@&/**#&&&%&@@@@@@@&&##&/(##&@@@#(##&@@@"
                                        + "\n@%%&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&@@@@@@@@%#(&@@&&&@@&&%&&&&@@@@&%%@@((#####((&"
                                        + "\n%&@@@@@@@@@@@@@@@@@@#//*,(&@@@@@@&@@@@@@@@@&#%@@@&&&@@%*,&@@@@@@@@@&@@@@%#######"
                                        + "\n@@@@@@@@@@@@@@@@@@@%%####((//,,*/#%&@@@@@@@@&%%#/*,,*/((#(%@@@@@@@@@@@@@@@@%####"
                                        + "\n@@@@@@@@@@@@@@@@@@@@@@@@%%######((((/@@@@(/((((((####%%%%&&&&@@@@@@@@@@@@@@@@@%#"
                                        + "\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&%%%%%&@@@@%%%%%%%%#########(((((((((((((((((((((("
                                        + "\n##########(#((((((((((((((((((((((((#@@@%((/((//////////////////////************"
                                        + "\n////////////////////////////********/(((#*****************,,,,**,,***,,*********");
                            Console.WriteLine("\n\nO COMPUTADOR VENCEU!!!\nEstá um passo mais próximo da dominação mundial..."); Console.ReadKey();
                            prasempre2 = 1;
                            entrada = 0;
                        }
                        #endregion

                    } while (prasempre2 == 0);
                }
                #endregion

                #region//Regras
                else if (entrada == 3)
                {
                    do
                    {
                        LobbyRefresh(LOGO, 3);
                        int perg;
                        Console.Write("1 - Como Joga?\n" +
                                  "2 - Quais são as funções das cartas especiais?\n" +
                                  "3 - O que é revidar?\n" +
                                  "4 - Como funciona uma sequencia?\n" +
                                  "5 - Voltar ao menu principal\n" +
                                  "Digite a opção desejada: ");
                        perg = int.Parse(Console.ReadLine());
                        #region//Perguntas
                        if (perg == 1)
                        {
                            LobbyRefresh(LOGO, 3);
                            Console.WriteLine("No uno você tem cartas com uma cor e um numero ou ação\n" +
                                              "O jogo inicia com cada jogador recebendo 7 cartas e 1 na mesa\n" +
                                              "Deve-se colocar uma carta com o mesmo numero ou cor (Salvo as coringas) na mesa\n" +
                                              "Quando o jogador tiver 2 cartas, antes de jogar a carta na mesa, ele deve falar UNO!\n" +
                                              "O jogo termina quando algum jogador tiver 0 cartas\n" +
                                              "Digite algo para prosseguir...\n");
                            Console.ReadKey();
                        }
                        else if (perg == 2)
                        {
                            LobbyRefresh(LOGO, 3);
                            Console.WriteLine("• Carta de Bloqueio:\n" +
                                "   Bloqueia o próximo jogador de jogar\n\n" +
                                "• Carta +2:\n" +
                                "   Faz com que o próximo jogador compre +2 cartas\n" +
                                "   Esta carta pode ser Revidada\n\n" +
                                "• Carta Coringa:\n" +
                                "   Faz com que o jogador escolha a nova cor da mesa\n\n" +
                                "• Carta Coringa +4:\n" +
                                "   Faz com que o jogador escolha a nova cor da mesa e faz com que o adversário compra +4 cartas\n" +
                                "   Essa carta não pode ser revidada, como a carta +2\n\n" +
                                "Digite algo para prosseguir...\n");
                            Console.ReadKey();
                        }
                        else if (perg == 3)
                        {
                            LobbyRefresh(LOGO, 3);
                            Console.WriteLine("• Revidar:\n\n" +
                                              "É quando você joga uma carta +2 seguida da do seu oponente\n" +
                                              "Se isso ocorrer, os valores de cartas a serem compradas se somam\n" +
                                              "O próximo jogador depois de uma jogada revidada irá comprar essas cartas\n" +
                                              "A não ser que ele tenha como revidar\n" +
                                              "• EX:\n" +
                                              "  PLAYER 1 jogou uma carta +2 azul\n" +
                                              "  PLAYER 2 jogou uma carta +2 verde\n" +
                                              "  PLAYER 1 jogou uma carta +2 vermelho\n" +
                                              "  PLAYER 2 não tinha como revidar, comprou 6 cartas!\n" +
                                              "Digite algo para prosseguir...");
                            Console.ReadKey();
                        }
                        else if (perg == 4)
                        {
                            LobbyRefresh(LOGO, 3);
                            Console.WriteLine("• Sequencia:\n\n" +
                                              "Quando você joga alguma carta na mesa, se em sua mão tiver outra carta de mesmo numero\n" +
                                              "ou simbolo, você pode joga-las na mesa em se quencia, seja ela quantas for!\n" +
                                              "Porem se for cartas especiais, elas não acumulam suas habilidades, ou seja:\n" +
                                              "  •Cartas de compra não se somam\n" +
                                              "  •Você não bloqueia o inimigo mais de uma vez\n" +
                                              "  •Você não escolhe mais de uma vez a cor da mesa\n");
                            Console.ReadKey();

                        }
                        else if (perg == 5)
                        {
                            escolha = 1;
                            entrada = 0;
                        }
                        #endregion
                    } while (escolha == 0);
                }
                #endregion

                #region//Créditos
                else if (entrada == 4)
                {
                    LobbyRefresh(LOGO, 3);
                    Console.WriteLine("\nCriado por:\n\n" +
                                       "Gabriel Nunes Alves dos Santos RA: 081200038\n\n" +
                                       "Lucas Alves Silva RA: 081200031\n\n" +
                                       "Luiza Leal RA: 081200036\n\n" +
                                       "Matheus Vinicius Miranda Brito RA: 081200024\n\n" +
                                       "Vitor Henrique Carvalho Silva RA: 081200030\n" +
                                       "Digite algo para continuar...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n\nNunca digite 666 no menu...");

                    Console.ReadKey();
                    entrada = 0;
                }

                #endregion

                #endregion
            } while (entrada != 666);

            #region//EASTEREGG
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {
                Console.WriteLine("OLHE PARA ATRÁS");
            } while (prasempre == 0);
            #endregion
        }
        #region\\Funções
        static int[] ArrumaMao(int[] maoEsc)
        {
            int n = 0;
            for (n = 0; n < 97; n++) //Puxa a carta seguinte para a posição vazia
            {
                if (maoEsc[n] == -1)
                {
                    maoEsc[n] = maoEsc[n + 1];
                    maoEsc[n + 1] = -1;

                    if (maoEsc[n] == maoEsc[n + 1])
                        break;
                }
            }
            return maoEsc;
        }
        static int RefreshMesa(int[] maoqnt, int[] mao1, string[] cartaNome, int naMesa, string[] cartaID, string texto, int OcultaCarta)
        {
            Console.Clear();
            if (texto == "TELA PLAYER 1")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (texto == "TELA PLAYER 2")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            Console.Clear();
            int n = 0, y = 0;
            foreach (int valor in maoqnt)
            {
                if (valor != -1)
                {
                    n++;
                }
            }
            Console.WriteLine(texto + "\n");

            Console.WriteLine("Quantidade de cartas do inimigo: {0}\n", n);

            Console.WriteLine("Carta na mesa: {0}\n", cartaNome[naMesa]);

            Console.WriteLine("Suas cartas:");
            n = 0;
            y = 0;
            foreach (int valor in mao1)
            {
                if (valor != -1)
                {
                    n++;
                    if (OcultaCarta == 1)
                        Console.WriteLine("Carta {0}: {1}", n, cartaNome[valor]);
                    else
                        Console.Write("{0} / ", cartaNome[valor]);
                    if (cartaID[valor].Substring(1, 1) == cartaID[naMesa].Substring(1, 1) ||
                        cartaID[valor].Substring(2, 1) == cartaID[naMesa].Substring(2, 1) ||
                        cartaID[valor].Substring(0, 2) == "EC" ||
                        cartaID[valor].Substring(0, 2) == "EY")
                        y++;
                }
            }
            Console.WriteLine("\n {0} possibilidades de jogada", y);
            return y;
        }
        static int qntMao(int[] mao)
        {
            int numero = 0;
            foreach (int x in mao)
            {
                if (x != -1)
                {
                    numero++;
                }
            }
            return numero;
        }
        static void LobbyRefresh(string[] LOGO, int player)
        {
            if (player == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                foreach (string aux in LOGO)
                    Console.Write(aux);
            }
            else if (player == 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                foreach (string aux in LOGO)
                    Console.Write(aux);
            }
            else if (player == 3)
            {
                Console.Clear();
                Random gerador = new Random();
                int a;

                a = gerador.Next(1, 5);
                if (a == 1)
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (a == 2)
                    Console.ForegroundColor = ConsoleColor.Red;
                if (a == 3)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                if (a == 4)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                foreach (string aux in LOGO)
                    Console.Write(aux);
            }
        }
        static int qntFalse(bool[] jauso)
        {
            int qntde = 0;
            foreach (bool u in jauso)
            {
                if (u == false)
                    qntde++;
            }
            return qntde;
        }
        static void FimDoJogo()
        {
            int infinito = 0;
            while (infinito == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("\nEMPATE \nO jogo acabou pois já utilizaram todas as cartas \nPortantovoce não conseguiu vencer o bot a tempo...");
                Console.WriteLine("\n\n Reinicie o jogo e tente novamente!");
                Console.ReadKey();
            }
        }
        #endregion
    }
}