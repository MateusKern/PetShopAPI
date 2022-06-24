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
}