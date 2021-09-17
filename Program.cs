using System;
using Dio.Series;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

        string OpcaoUsuario = ObterOpcaoUsuario();
		
		while (OpcaoUsuario.ToUpper() != "X")
		{
		switch (OpcaoUsuario)
			{
		case "1":
		ListarSeries();
		break;
		case "2":
		InserirSerie();
		break;
		case "3":
		AtualizarSerie();
		break;
		case "4":
		ExcluirSerie();
		break;
		case "5":
		VisualizarSerie();
		break;
		case "C":
		Console.Clear();
		break;
		
		default:
		throw new ArgumentOutOfRangeException();
        }

        OpcaoUsuario = ObterOpcaoUsuario();
        }
        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
    }

    private static void ListarSeries()
    {
        Console.WriteLine("Listar Séries.");

        var lista = repositorio.lista();

        if(lista.Count == 0)
        {
            Console.WriteLine("nenhuma Série Encontrada.");
            return;
        }
        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(),(excluido ? "*Excluido*" : ""));
        } 
    }

    private static void InserirSerie()
    {
        Console.WriteLine("Inserir Nova Série.");

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
        }

        Console.Write("Digite o Gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("o Título da Série: ");
        string entradaTitulo = Console.ReadLine();
        
        Console.Write("Digite o Ano de início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        repositorio.Insere(novaSerie);
    }
        private static void AtualizarSerie()
    {
        Console.Write("Digite o Id da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
        }

        Console.Write("Digite o Gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("o Título da Série: ");
        string entradaTitulo = Console.ReadLine();
        
        Console.Write("Digite o Ano de início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o Id da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
        repositorio.Exclui(indiceSerie);
        
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o Id da Série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
        
    }
    private static string ObterOpcaoUsuario()
{
	Console.WriteLine();
	Console.WriteLine("DIO Séries ao seu dispor!");
	Console.WriteLine("Informe a opção Desejada:");
	Console.WriteLine("1- Listar Séries");
	Console.WriteLine("2- Inserir nova Série");
	Console.WriteLine("3- Atualizar Série");
	Console.WriteLine("4- Excluir Série");
	Console.WriteLine("5- Visualizar Série");
	Console.WriteLine("C- Limpar Tela");
	Console.WriteLine("X- Sair");

	string OpcaoUsuario = Console.ReadLine().ToUpper();
	Console.WriteLine();
	return OpcaoUsuario;
		}
    }
}
