using System;

namespace DIOJogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarJogo();
                        break;
                    case "2":
                        InserirJogo();
                        break;
                    case "3":
                        AtualizarJogo();
                        break;
                    case "4":
                        ExcluirJogo();
                        break;
                    case "5":
                        VisualizarJogo();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogo);
        }

        private static void VisualizarJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(indiceJogo);

            Console.WriteLine(jogo);
        }

        private static void AtualizarJogo()
        {
            Console.Write("Digite o id do jogo: ");
            int indiceJogo = int.Parse(Console.ReadLine());

            int entradaGenero;

            do
            {
                Console.WriteLine();
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
            } while (!int.TryParse(Console.ReadLine(), out entradaGenero) ||
                     entradaGenero < 0 ||
                     entradaGenero > 8);

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            int entradaAno;
            do
            {
                Console.WriteLine();
                Console.Write("Digite o Ano de Início da Jogo: ");
            } while (!int.TryParse(Console.ReadLine(), out entradaAno) ||
                    entradaAno <= 0 ||
                    entradaAno > DateTime.Now.Year);

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            decimal entradaMetacritic;
            do
            {
                Console.WriteLine();
                Console.Write("Digite a Avaliação (0 a 5) do Jogo no Metacritic: ");
            } while (!decimal.TryParse(Console.ReadLine(), out entradaMetacritic) ||
                     entradaMetacritic < 0 ||
                     entradaMetacritic > 5);

            Jogo atualizaJogo = new Jogo(id: indiceJogo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        metacritic: entradaMetacritic);

            repositorio.Atualiza(indiceJogo, atualizaJogo);
        }
        private static void ListarJogo()
        {
            Console.WriteLine("Listar jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            foreach (var jogo in lista)
            {
                var excluido = jogo.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirJogo()
        {
            Console.WriteLine("Inserir novo jogo");

            int entradaGenero;

            do
            {
                Console.WriteLine();
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
            } while (!int.TryParse(Console.ReadLine(), out entradaGenero) ||
                     entradaGenero < 0 ||
                     entradaGenero > 8);

            Console.Write("Digite o Título do Jogo: ");
            string entradaTitulo = Console.ReadLine();

            int entradaAno;
            do
            {
                Console.WriteLine();
                Console.Write("Digite o Ano de Início da Jogo: ");
                } while (!int.TryParse(Console.ReadLine(), out entradaAno) ||
                    entradaAno <= 0 ||
                    entradaAno > DateTime.Now.Year);

                Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescricao = Console.ReadLine();

            decimal entradaMetacritic;
            do
            {
                Console.WriteLine();
                Console.Write("Digite a Avaliação (0 a 5) do Jogo no Metacritic: ");
            } while (!decimal.TryParse(Console.ReadLine(), out entradaMetacritic) ||
                     entradaMetacritic < 0 ||
                     entradaMetacritic > 5);


            Jogo novaJogo = new Jogo(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        metacritic: entradaMetacritic);

            repositorio.Insere(novaJogo);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Jogos a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar jogos");
            Console.WriteLine("2- Inserir novo jogo");
            Console.WriteLine("3- Atualizar jogo");
            Console.WriteLine("4- Excluir jogo");
            Console.WriteLine("5- Visualizar jogo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
