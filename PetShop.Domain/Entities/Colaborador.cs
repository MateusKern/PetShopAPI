﻿public class Colaborador : EntityBase
{
    private Colaborador(int id, string nome, DateTime? dataNascimento, string email)
    {
        Id = id;
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
    }

    public Colaborador(string nome, DateTime? dataNascimento, string email, List<ETipoAcesso> acessos)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        Usuario = new Usuario(email, acessos);
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public string Email { get; private set; }
    public Usuario Usuario { get; private set; }

    public void EditarColaborador(string nome, DateTime? dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }
}