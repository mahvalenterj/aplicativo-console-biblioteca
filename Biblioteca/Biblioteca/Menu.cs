using System;

namespace Biblioteca
{
    public class Menu
    {
        private ServicosBiblioteca servicosBiblioteca;

        public Menu(ServicosBiblioteca servicos)
        {
            servicosBiblioteca = servicos;
        }

        public void BemVindo()
        {
            Console.WriteLine("Bem-vindo à Biblioteca!");

            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Cadastrar Pessoa");
                Console.WriteLine("2. Cadastrar Livro");
                Console.WriteLine("3. Emprestar Livro");
                Console.WriteLine("4. Devolver Livro");
                Console.WriteLine("5. Listar Pessoas");
                Console.WriteLine("6. Listar Livros");
                Console.WriteLine("7. Listar Livros Emprestados");
                Console.WriteLine("8. Listar Pessoas Emprestadoras");
                Console.WriteLine("0. Sair");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Digite um número válido.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarPessoa();
                        break;
                    case 2:
                        CadastrarLivro();
                        break;
                    case 3:
                        EmprestarLivro();
                        break;
                    case 4:
                        DevolverLivro();
                        break;
                    case 5:
                        servicosBiblioteca.ListarPessoas();
                        break;
                    case 6:
                        servicosBiblioteca.ListarLivros();
                        break;
                    case 7:
                        servicosBiblioteca.ListarLivrosEmprestados();
                        break;
                    case 8:
                        servicosBiblioteca.ListarPessoasEmprestadoras();
                        break;
                    case 0:
                        Console.WriteLine("Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Digite um número válido.");
                        break;
                }
            }
        }

        private void CadastrarPessoa()
        {
            Console.Write("Digite o nome da pessoa: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade da pessoa: ");
            int idade;
            if (!int.TryParse(Console.ReadLine(), out idade))
            {
                Console.WriteLine("Idade inválida. Cadastro de pessoa cancelado.");
                return;
            }

            Console.Write("Digite o endereço da pessoa: ");
            string endereco = Console.ReadLine();

            if (servicosBiblioteca.CadastrarPessoa(nome, idade, endereco))
            {
                Console.WriteLine("Pessoa cadastrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar a pessoa. Verifique os dados fornecidos.");
            }
        }

        private void CadastrarLivro()
        {
            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine();

            Console.Write("Digite o ano de publicação do livro: ");
            int anoPublicacao;
            if (!int.TryParse(Console.ReadLine(), out anoPublicacao))
            {
                Console.WriteLine("Ano de publicação inválido. Cadastro de livro cancelado.");
                return;
            }

            if (servicosBiblioteca.CadastrarLivro(titulo, autor, anoPublicacao))
            {
                Console.WriteLine("Livro cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar o livro. Verifique os dados fornecidos.");
            }
        }

        private void EmprestarLivro()
        {
            Console.Write("Digite o título do livro a ser emprestado: ");
            string tituloLivro = Console.ReadLine();

            Console.Write("Digite o nome da pessoa que está emprestando o livro: ");
            string nomePessoa = Console.ReadLine();

            Console.Write("Digite a data de empréstimo (dd/mm/aaaa): ");
            DateTime dataEmprestimo;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEmprestimo))
            {
                Console.WriteLine("Data de empréstimo inválida. Empréstimo cancelado.");
                return;
            }

            Console.Write("Digite a data de devolução (dd/mm/aaaa): ");
            DateTime dataDevolucao;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataDevolucao))
            {
                Console.WriteLine("Data de devolução inválida. Empréstimo cancelado.");
                return;
            }

            if (servicosBiblioteca.EmprestarLivro(tituloLivro, nomePessoa, dataEmprestimo, dataDevolucao))
            {
                Console.WriteLine("Empréstimo realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao realizar o empréstimo. Verifique os dados fornecidos.");
            }
        }

        private void DevolverLivro()
        {
            Console.Write("Digite o título do livro a ser devolvido: ");
            string tituloLivro = Console.ReadLine();

            if (servicosBiblioteca.DevolverLivro(tituloLivro))
            {
                Console.WriteLine("Livro devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao devolver o livro. Verifique o título fornecido.");
            }
        }
    }
}
