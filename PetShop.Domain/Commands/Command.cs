using Flunt.Notifications;

public abstract class Command : Notifiable<Notification>
{
    public abstract void Validate();
}