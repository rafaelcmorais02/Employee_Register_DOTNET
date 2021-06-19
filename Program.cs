using System;

namespace DIO.Registro
{
    class Program
    {
        static ColaboradorRepositorio repositorio = new ColaboradorRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 01 - Dio Innovation");
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listaColaboradores();
                        break;
                    case "2":
                        InsereColaboradores();
                        break;
                    case "3":
                        AtualizaColaboradores();
                        break;
                    case "4":
                        ExcluiColaboradores();
                        break;
                    case "5":
                        VisualizaColaboradores();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizaColaboradores()
        {
            Console.WriteLine("Visualiza Colaboradores:");
            Console.WriteLine("Digite o ID do colaborador a ser visualizado:");
            int indicaSerie = int.Parse(Console.ReadLine());
            var visualisa = repositorio.RetornaPorId(indicaSerie);
            Console.WriteLine(visualisa.ToString());
        }
        private static void ExcluiColaboradores()
        {
            Console.WriteLine("Exclui Colaborador:");
            Console.WriteLine("Digite o ID do colaborador a ser excluído:");
            int indicaSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(id: indicaSerie);
        }
        private static void AtualizaColaboradores()
        {
            Console.WriteLine("Atualiza Colaboradores:");
            Console.WriteLine("Digite o ID do colaborador:");
            int indicaColaborador = int.Parse(Console.ReadLine());

            Console.WriteLine("Tipo de contratos:");
            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo),i));
            }
            Console.WriteLine("Digite o contrato dentro das opções acima:");
            int entradaTipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do colaborador:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do colaborador:");
            int entradaMatricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o departamento do colaborador:");
            string entradaSetor = Console.ReadLine();

            Colaborador atualizaColaborador = new Colaborador(id: indicaColaborador, 
            contrato: (Tipo)entradaTipo,
            nome: entradaNome,
            setor: entradaSetor,
            matricula: entradaMatricula
            );
            repositorio.Atualiza(id:indicaColaborador, entidade: atualizaColaborador);
        }
       private static void listaColaboradores()
        {
            Console.WriteLine("Listar de colaboradores:");
            var lista = repositorio.Lista();
            if(lista.Count==0)
            {
                 Console.WriteLine("Sem colaboradores cadastrados");
                 return;
            } 
            foreach (var colaborador in lista)
            {
                Console.WriteLine("#ID {0}: - {1} - Demitido?: {2}", colaborador.RetornaId(), colaborador.RetornaNome(), colaborador.RetornaStatus());
            }

        }

        private static void InsereColaboradores()
        {
            Console.WriteLine("Inserir Colaborador:");
            
            Console.WriteLine("Tipo de contratos:");
            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo),i));
            }
            Console.WriteLine("Digite o contrato dentro das opções acima:");
            int entradaTipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do colaborador:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite a matrícula do colaborador:");
            int entradaMatricula = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o departamento do colaborador:");
            string entradaSetor = Console.ReadLine();

            Colaborador novoColaborador = new Colaborador(id: repositorio.ProximoId(), 
            contrato: (Tipo)entradaTipo,
            nome: entradaNome,
            setor: entradaSetor,
            matricula: entradaMatricula
            );
            repositorio.Insere(novoColaborador);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Registro de Colaboradores!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar colaboradores");
            Console.WriteLine("2 - Inserir colaborador");
            Console.WriteLine("3 - Atualizar cadastro de colaborador");
            Console.WriteLine("4 - Excluir colaborador");
            Console.WriteLine("5 - Visualizar colaborador");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
