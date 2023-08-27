using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class ServicosBiblioteca
    {
        private List<Pessoa> pessoas;
        private List<Livro> livros;
        private List<Emprestimo> emprestimos;

        public ServicosBiblioteca()
        {
            pessoas = new List<Pessoa>();
            livros = new List<Livro>();
            emprestimos = new List<Emprestimo>();
        }

        public bool CadastrarPessoa(string nome, int idade, string endereco)
        {
            if (string.IsNullOrWhiteSpace(nome) || idade <= 0 || string.IsNullOrWhiteSpace(endereco))
            {
                return false;
            }

            pessoas.Add(new Pessoa(nome, idade, endereco));
            return true;
        }

        public bool CadastrarLivro(string titulo, string autor, int anoPublicacao)
        {
            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || anoPublicacao <= 0)
            {
                return false;
            }

            livros.Add(new Livro(titulo, autor, anoPublicacao));
            return true;
        }

        public bool EmprestarLivro(string tituloLivro, string nomePessoa, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Livro livro = livros.Find(l => l.Titulo == tituloLivro);
            Pessoa pessoa = pessoas.Find(p => p.Nome == nomePessoa);

            if (livro == null || pessoa == null)
            {
                return false;
            }

            if (emprestimos.Exists(e => e.LivroEmprestado == livro))
            {
                return false; // Livro já emprestado
            }

            emprestimos.Add(new Emprestimo(pessoa, livro, dataEmprestimo, dataDevolucao));
            return true;
        }

        public bool DevolverLivro(string tituloLivro)
        {
            Emprestimo emprestimo = emprestimos.Find(e => e.LivroEmprestado.Titulo == tituloLivro);

            if (emprestimo == null)
            {
                return false; // Livro não encontrado em empréstimo
            }

            emprestimos.Remove(emprestimo);
            return true;
        }

        public bool DescadastrarPessoa(string nome)
        {
            Pessoa pessoa = pessoas.Find(p => p.Nome == nome);

            if (pessoa == null)
            {
                return false; // Pessoa não encontrada
            }

            // Remover pessoa e seus empréstimos
            emprestimos.RemoveAll(e => e.PessoaEmprestadora == pessoa);
            pessoas.Remove(pessoa);
            return true;
        }

        public bool DescadastrarLivro(string titulo)
        {
            Livro livro = livros.Find(l => l.Titulo == titulo);

            if (livro == null)
            {
                return false; // Livro não encontrado
            }

            // Remover livro e seus empréstimos
            emprestimos.RemoveAll(e => e.LivroEmprestado == livro);
            livros.Remove(livro);
            return true;
        }

        public void ListarPessoas()
        {
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Endereço: {pessoa.Endereco}");
            }
        }

        public void ListarLivros()
        {
            foreach (Livro livro in livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano de Publicação: {livro.AnoPublicacao}");
            }
        }

        public void ListarLivrosEmprestados()
        {
            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine($"Livro: {emprestimo.LivroEmprestado.Titulo}, Pessoa: {emprestimo.PessoaEmprestadora.Nome}");
            }
        }

        public void ListarPessoasEmprestadoras()
        {
            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine($"Pessoa: {emprestimo.PessoaEmprestadora.Nome}, Livro: {emprestimo.LivroEmprestado.Titulo}");
            }
        }
    }
}
