using System;

public class Livro
{
    public string Titulo { get; }
    public string Autor { get; }
    public string Genero { get; }
    public int AnoPublicacao { get; }

    public Livro(string titulo, string autor, string genero, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        AnoPublicacao = anoPublicacao;
    }
}
