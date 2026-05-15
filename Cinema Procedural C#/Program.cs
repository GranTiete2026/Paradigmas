class Program
{
    // Configuração da sala
    const int FILEIRAS = 10;
    const int POLTRONAS = 20;
    const double PRECO = 22.50;

    static readonly char[] LetrasFileira = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J']; 

    static bool[,] sala = new bool[FILEIRAS, POLTRONAS];    

    // Contadores globais
    static double totalIngressos = 0;
    static int     qtdeIngressos  = 0;
    static int     qtdeClientes   = 0;
    static int     qtdeEstudantes = 0;

    static void Main()
    {
        EsvaziarSala();
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("-- CINEMA GALLOMAX --");
            DesenharSala();
            continuar = LerSimNao(
                "Sessão ativa - continuar vendendo ingressos? (S/N): ");
            
            if (continuar)
            {
                Console.Write("Informe a quantidade de ingressos: ");
                int qtde = int.Parse(Console.ReadLine() ?? "0");
                if (qtde > 0) VenderIngressos(qtde);
            }
        } while (continuar);
        RelatorioFinal();
    }

    #region Métodos Utilitários
    // Inicializa todas as poltronas como livres (false)
    static void EsvaziarSala()
    {
        for (int i = 0; i < FILEIRAS; i++)
        {
            for (int j = 0; j < POLTRONAS; j++)
            {
                sala[i, j] = false;
            }
        }
    }

    // Converte a letra da fileira ('A'..'J') para indice (0..9)
    // Retorna -1 se a letra não for valida
    static int  IndiceFileira(char fileira)
    {
        for (int i = 0; i < FILEIRAS; i++)
        {
            if (LetrasFileira[i] == char.ToUpper(fileira))
            {
                return i;
            }
        }
        return -1;
    }

    // Tenta marcar uma poltrona. Retorna true se conseguiu, false se já estava ocupada
    // fileira : letra de A..J
    // poltrona: número digitado pelo usuário (1..20)
    static bool MarcarPoltrona(char fileira, int poltrona)
    {
        int i = IndiceFileira(fileira);
        int j = poltrona - 1;

        // Verificar os limites da sala
        if (i < 0 || j < 0 || j >= POLTRONAS)
            return false;
        // Se a poltrona já estiver marcada
        if (sala[i, j])
            return false;
        sala[i, j] = true;
        return true;
    }
    
    // Exibe uma mensagem e aguardar o usuário pressionar Enter
    static void Pausar(string texto)
    {
        Console.WriteLine(texto);
        Console.Write("Pressione [Enter] para continuar...");
        Console.ReadLine();
    }

    // Exibe uma mensage e aguadar o usuário pressionar S ou N
    static bool LerSimNao(string pergunta)
    {
        while (true)
        {
            Console.Write(pergunta);
            string s = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (s == "S" || s == "SIM")
                return true;
            if (s == "N" || s == "NÃO" || s == "NAO")
                return false;
            
            Console.WriteLine("Resposta inválida. Digite S ou N");
        }
    }

    // Exibe a sala marcando as poltronas já ocupadas
    static void DesenharSala()
    {
        // Cabeçalho de poltronas
        Console.Write("  ");
        for (int i = 1; i <= POLTRONAS; i++)
        {
            if (i <= 9) Console.Write($"[  {i}]");
            else        Console.Write($"[ {i}]");
        }
        Console.WriteLine();

        // Fileiras: letra + poltrona
        for (int i = 0; i < FILEIRAS; i++)
        {
            Console.Write($"{LetrasFileira[i]} ");
            for (int j = 0; j < POLTRONAS; j++)
            {
                Console.Write(sala[i,j] ? "[ X ]" : "[   ]");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    #endregion

    static void VenderIngressos(int qtde)
    {
        double total = 0;
        int marcados = 0;

        qtdeClientes  += 1;
        qtdeIngressos += qtde;

        while (marcados < qtde)
        {
            Console.WriteLine($"Ingresso {marcados + 1}");
            Console.Write("Informe a fileira: ");
            string filStr = Console.ReadLine() ?? "";
            char fil = filStr.Length > 0 ? filStr[0] : '?';

            Console.Write("Informe a poltrona: ");
            int pol = int.Parse(Console.ReadLine() ?? "0");

            if (MarcarPoltrona(fil, pol))
            {
                bool estudante = LerSimNao("Este ingresso é para estudante? (S/N): ");
                if (estudante)
                {
                    total += PRECO / 2.0;
                    qtdeEstudantes += 1;
                }
                else
                {
                    total += PRECO;
                }
                marcados += 1;
                Pausar("Poltrana marcada!");
            }
            else
            {
                Console.WriteLine("A poltrona informada já está marcada, escolha outra!\n");    
            }
        }
        Pausar($"Valor Total a Pagar R$ {total:F2}");
        totalIngressos += total;
    }

    static void RelatorioFinal()
    {
        Console.Clear();
        Console.WriteLine("-- CINEMA GALLOMAX --\n");
        Console.WriteLine($"Total de Clientes Atendidos: {qtdeClientes}");
        Console.WriteLine($"Total de Estudantes........: {qtdeEstudantes}");
        Console.WriteLine($"Total de Ingressos Vendidos: {qtdeIngressos}");
        Console.WriteLine($"Lucro Total................: R$ {totalIngressos:F2}");
    }

}