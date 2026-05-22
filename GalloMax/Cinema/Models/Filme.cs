namespace Cinema.Models;

public class Filme
{
    // Atributos
    private string titulo;
    private string diretor;
    private int duracaoMinutos;
    private string genero;
    private int anoLancamento;
    private string classificacao;

    // Construtor
    public Filme(string titulo, string diretor, int duracaoMinutos,
        string genero, int anoLancamento, string classificacao)
    {
        this.titulo = titulo;
        this.diretor = diretor;
        this.duracaoMinutos = duracaoMinutos;
        this.genero = genero;
        this.anoLancamento = anoLancamento;
        this.classificacao = classificacao;
    }

    // Propriedades (Getters e Setters)
    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Diretor
    {
        get { return diretor; }
        set { diretor = value; }
    }

    public int DuracaoMinutos
    {
        get { return duracaoMinutos; }
        set { duracaoMinutos = value; }
    }

    public string Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    public int AnoLancamento
    {
        get { return anoLancamento; }
        set { anoLancamento = value; }
    }

    public string Classificacao
    {
        get { return classificacao; }
        set { classificacao = value; }
    }

    // Método para obter duração formatada (horas e minutos)
    public string GetDuracaoFormatada()
    {
        int horas = duracaoMinutos / 60;
        int minutos = duracaoMinutos % 60;
        return $"{horas}h{minutos}min";
    }

    // Método para verificar se é maior de idade para a classificacao
    public bool PodeAssistir(int idadeEspectador)
    {
        if (classificacao == "Livre") return true;
        int idadeMinima = int.Parse(classificacao);
        return idadeEspectador >= idadeMinima;
    }

    // Método para exibir informações do filme
    public void ExibirInformacoes()
    {
        Console.WriteLine("\n=== INFORMAÇÕES DO FILME ===");
        Console.WriteLine($"Título: {titulo}");
        Console.WriteLine($"Diretor: {diretor}");
        Console.WriteLine($"Duraçao: {GetDuracaoFormatada()}");
        Console.WriteLine($"Gênero: {genero}");
        Console.WriteLine($"Ano: {anoLancamento}");
        Console.WriteLine($"Classificação: {classificacao}");
    }

}