using Flunt.Notifications;
using Flunt.Validations;

public class DeleteCommand : Command
{
    public int Id { get; set; }

    public override void Validate()
    {
        AddNotifications(
            new Contract<Notification>().IsGreaterThan(Id, 0, "Id")
        );
    }
}