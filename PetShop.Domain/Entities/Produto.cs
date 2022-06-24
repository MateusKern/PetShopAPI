﻿public class Produto : EntityBase
{
    public Produto(int id, string nome, string descricao, decimal preco)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }

    public void EditarProduto(string nome, string descricao, decimal preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
}