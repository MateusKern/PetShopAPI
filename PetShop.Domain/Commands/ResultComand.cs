using Flunt.Notifications;

public class ResultComand : Notifiable<Notification>
{
    public ResultComand()
    {
        PreencherRetorno(null);
    }

    public ResultComand(object retorno)
    {
        PreencherRetorno(retorno);
    }

    public object Retorno { get; private set; }

    public void PreencherRetorno(object retorno)
    {
        Retorno = retorno;
    }
}