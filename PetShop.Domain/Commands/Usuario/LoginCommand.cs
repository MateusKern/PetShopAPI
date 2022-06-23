using Flunt.Notifications;
using Flunt.Validations;

public class LoginCommand : Command
{
    public string Login { get; set; }
    public string Senha { get; set; }

    public override void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .IsNotNullOrEmpty(Login, "Login")
                .IsNotNullOrEmpty(Senha, "Senha")
        );
    }
}