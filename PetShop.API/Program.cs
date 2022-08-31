using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => policy.AllowAnyOrigin().AllowAnyHeader()
    );
});

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICobrancaRepository, CobrancaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<ClienteHandler>();
builder.Services.AddScoped<CobrancaHandler>();
builder.Services.AddScoped<ColaboradorHandler>();
builder.Services.AddScoped<ProdutoHandler>();
builder.Services.AddScoped<ServicoHandler>();
builder.Services.AddScoped<UsuarioHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

builder.Services.AddControllers(c => c.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = $"PetShop DogStyle",
            Version = "v1",
            Description = "API Rest relacionada ao PetShop DogStyle",
            Contact = new OpenApiContact
            {
                Name = "Mateus Garrido Kern",
                Url = new Uri("https://github.com/MateusKern/PetShopAPI"),
                Email = "mateus.g.kern@gmail.com"
            }
        });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description =
                "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                "Exemplo (informar sem as aspas): 'Bearer 123456abcdefghijkl'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT"
        });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        }
    );
    }
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"PetShop DogStyle");
    c.RoutePrefix = "documentation";
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();