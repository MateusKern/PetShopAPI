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

    public static Contract<Notification> ValidateListCommand(List<Command> listCommand, string key)
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
}