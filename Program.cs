using dio.livros.Classes;
using dio.livros.Enum;

class program 
{
    public static LivroRepositorio repositorio = new LivroRepositorio();
    
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcapUsuario();

        while (opcaoUsuario.ToUpper() != "x")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarLivro();
                    break;
                case "2":
                    InserirLivro();
                    break;
                case "3":
                    AtualizarLivro();
                    break;
                case "4":
                    ExcluirLivro();
                    break;
                case "5":
                    VisualizarLivro();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcapUsuario();

        }

        //Metodos
        static string ObterOpcapUsuario()
        {
            Console.WriteLine();
            System.Console.WriteLine("Livros que li esse ano!");
            System.Console.WriteLine("Informe uma opção:");

            System.Console.WriteLine("1 - Listar livros");
            System.Console.WriteLine("2 - Inserir novo livro");
            System.Console.WriteLine("3 - Atualizar livro");
            System.Console.WriteLine("4 - Excluir livro");
            System.Console.WriteLine("5 - Visualizar  livro");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }

        static void ListarLivro()
        {
            System.Console.WriteLine("Listar livros");
            
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum livro encontrado.");
                return;
            }

            foreach (var livro in lista)
            {
                var excluido = livro.retornaExcluido;
                System.Console.WriteLine("ID: {0} = {1}", livro.retornaId(), livro.retornaTitulo());
            }
        }

        static void InserirLivro()
        {
            System.Console.WriteLine("Inserir novo livro:"); 
            System.Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero:");
            int entradaGenero = int.Parse(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Digite o nome:");
            string entradaTitulo = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Dê uma descrição:");
            string entradaDescricao = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Digite o ano:");
            int entradaAno = int.Parse(Console.ReadLine().ToUpper());

            Livros novoLivro = new Livros ( id: repositorio.ProximoId(),
                                            genero: (Genero) entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno);

            repositorio.Insere(novoLivro);
        }

        static void AtualizarLivro()
            {
                System.Console.WriteLine("Digite o id que quer alterar:");
                int indiceLivro = int.Parse(Console.ReadLine().ToUpper());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero:");
            int entradaGenero = int.Parse(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Digite o nome:");
            string entradaTitulo = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Dê uma descrição:");
            string entradaDescricao = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Digite o ano:");
            int entradaAno = int.Parse(Console.ReadLine().ToUpper());

            Livros atualizaLivro = new Livros ( id: indiceLivro,
                                            genero: (Genero) entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno);

            repositorio.Atualiza(indiceLivro, atualizaLivro);
            }
        
        static void ExcluirLivro()
        {
            System.Console.WriteLine("Digite o id para excluir:");
            int indiceLivro = int.Parse(Console.ReadLine().ToUpper());

            repositorio.Exclui(indiceLivro);
        }

        static void VisualizarLivro()
        {
            System.Console.WriteLine("Digite o id que deseja ver:");
            int indiceLivro = int.Parse(Console.ReadLine().ToUpper());

            var livro = repositorio.RetornaPorId(indiceLivro);
            System.Console.WriteLine(livro);
        }

    }
}
