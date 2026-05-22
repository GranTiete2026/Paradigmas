namespace Cinema.Models;

public class Sala
{
    // Atributos
    private int qtdeFileiras;
    private int qtdePoltronasPorFileira;

    //Construtor
    public Sala(int qtdeFileiras, int qtdePoltronasPorFileira)
    {
        this.qtdeFileiras = qtdeFileiras;
        this.qtdePoltronasPorFileira = qtdePoltronasPorFileira;
    }

    public int QtdeFileiras => qtdeFileiras;
    public int QtdePoltronasPorFileira => qtdePoltronasPorFileira;

    // Métodos de mapeamento (sem controle de ocupação)
    public char GetLetraFileira(int indiceFileira)
    {
        return (char)('A' + indiceFileira);
    }

    public int GetIndiceFileira(char letraFileira)
    {
        letraFileira = char.ToUpper(letraFileira);
        return letraFileira - 'A';
    }

    // Valida se a poltrona existe fisicamente
    public bool PoltronaExiste(char fileira, int poltrona)
    {
        int fileiraindex = GetIndiceFileira(fileira);
        return fileiraindex >= 0 && fileiraindex < qtdeFileiras &&
            poltrona >= 0 && poltrona < qtdePoltronasPorFileira;
    }

    public void ExibirMapa(bool[,]? ocupacao)
    {
        Console.WriteLine("\n=== MAPA DA SALA ===");
        Console.Write("    ");
        for (int p = 0; p < qtdePoltronasPorFileira; p++)
        {
            Console.Write($" { p + 1,2} ");
        }
        Console.WriteLine();

        for (int i = 0; i < qtdeFileiras; i++)
        {
            Console.Write($" {GetLetraFileira(i)}  ");
            for (int j = 0; j < qtdePoltronasPorFileira; j++)
            {
                if (ocupacao != null && ocupacao[i, j])
                    Console.Write(" [X] ");
                else
                    Console.Write(" [ ] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Legenda: [ ] = Livre, [X] = Ocupada\n");
    }

    public void ExibirMapa()
    {
        ExibirMapa(null);
    }

}