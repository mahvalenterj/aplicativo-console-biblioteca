using System;

public class Livro
{
    public string Titulo { get; }
    public string Autor { get; }
    public int AnoPublicacao { get; }

    public Livro(string titulo, string autor, int anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
    }
}
