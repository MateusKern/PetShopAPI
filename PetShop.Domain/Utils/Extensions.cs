using Flunt.Notifications;
using Flunt.Validations;

public static class Extensions
{
    /// <summary>
    /// Returns string without special characters
    /// </summary>
    public static string RemoveSpecialCharacters(this string content) =>
        string.IsNullOrEmpty(content) ? content : content.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty)
                                                         .Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

    public static Pet ConvertPet(this PetCommand pet) =>
        new Pet(pet.Id, pet.Nome, pet.DataNascimento, pet.Idade, pet.Tipo, pet.Raca, pet.Cor, pet.Porte);

    public static int MaximumNumberPossible(int precision, int scale) =>
        Convert.ToInt32("9".PadRight(precision - scale,'9'));

    public static Contract<Notification> ValidateListCommand<T>(List<T> listCommand, string key) where T : Command
    {
        var contract = new Contract<Notification>();

        if (listCommand is not null)
            for (int i = 0; i < listCommand.Count; i++)
            {
                listCommand[i].Validate();
                foreach (var notification in listCommand[i].Notifications)
                    contract.AddNotification($"{key}.{i}.{notification.Key}", notification.Message);
            }

        return contract;
    }

    public static string ReturnFormattedCpf(this string cpf)
    {
        if (cpf.Length > 3)
            cpf = cpf.Insert(3, ".");

        if (cpf.Length > 7)
            cpf = cpf.Insert(7, ".");

        if (cpf.Length > 11)
            cpf = cpf.Insert(11, "-");

        return cpf;
    }

    public static string ReturnFormattedPhone(this string telefone)
    {
        telefone = telefone.RemoveSpecialCharacters();
        int telefoneLength = telefone.Length;

        switch (telefoneLength)
        {
            case 11:
            case 10:
                telefone = telefone.Insert(0, "(");
                telefone = telefone.Insert(3, ") ");
                telefone = telefone.Insert(telefoneLength - 1, "-");
                break;
            case 9:
            case 8:
                telefone = telefone.Insert(telefoneLength - 4, "-");
                break;
            default:
                break;
        }

        return telefone;
    }
}