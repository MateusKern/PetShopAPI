﻿public class EditColaboradorCommand : Command
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }

    public override void Validate()
    {
        AddNotifications(ColaboradorValidation.Validacao(Nome, DataNascimento));
    }
}