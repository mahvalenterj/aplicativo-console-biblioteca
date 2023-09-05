using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class ServicosBiblioteca
    {
        private List<Socio> socios;
        private List<Livro> livros;
        private List<Emprestimo> emprestimos;

        public ServicosBiblioteca()
        {
            socios = new List<Socio>();
            livros = new List<Livro>();
            emprestimos = new List<Emprestimo>();
        }

        public bool CadastrarSocio(string nome, int idade, string endereco)
        {
            if (string.IsNullOrWhiteSpace(nome) || idade <= 0 || string.IsNullOrWhiteSpace(endereco))
            {
                return false;
            }

            socios.Add(new Socio(nome, idade, endereco));
            return true;
        }

        public bool CadastrarLivro(string titulo, string autor, string genero, int anoPublicacao)
        {
            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || anoPublicacao <= 0)
            {
                return false;
            }

            livros.Add(new Livro(titulo, autor, genero, anoPublicacao));
            return true;
        }

        public bool EmprestarLivro(string tituloLivro, string nomeSocio, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Livro livro = livros.Find(l => l.Titulo == tituloLivro);
            Socio socio = socios.Find(p => p.Nome == nomeSocio);

            if (livro == null || socio == null)
            {
                return false;
            }

            if (emprestimos.Exists(e => e.LivroEmprestado == livro))
            {
                return false; // Livro já emprestado
            }

            emprestimos.Add(new Emprestimo(socio, livro, dataEmprestimo, dataDevolucao));
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
            Socio socio = socios.Find(p => p.Nome == nome);

            if (socio == null)
            {
                return false; // Socio não encontrada
            }

            // Remover pessoa e seus empréstimos
            emprestimos.RemoveAll(e => e.PessoaEmprestante == socio);
            socios.Remove(socio);
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

        public void ListarSocios()
        {
            foreach (Socio socio in socios)
            {
                Console.WriteLine($"Nome: {socio.Nome}, Idade: {socio.Idade}, Endereço: {socio.Endereco}");
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
                Console.WriteLine($"Livro: {emprestimo.LivroEmprestado.Titulo}, Socio: {emprestimo.PessoaEmprestante.Nome}");
            }
        }

        public void ListarSociosEmprestantes()
        {
            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine($"Socio: {emprestimo.PessoaEmprestante.Nome}, Livro: {emprestimo.LivroEmprestado.Titulo}");
            }
        }
    }
}
