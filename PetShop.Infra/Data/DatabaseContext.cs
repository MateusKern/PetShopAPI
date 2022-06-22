using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new CobrancaConfiguration());
        modelBuilder.ApplyConfiguration(new CobrancaItemConfiguration());
        modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new ServicoConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}