using ContainerFlow.API.Data;
using ContainerFlow.API.Data.Repositories;
using ContainerFlow.API.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContainerFlow.Contracts;
using ContainerFlow.Vendas.Propostas;
using ContainerFlow.Vendas.Locacoes;
using ContainerFlow.Clientes.Cadastro;
using ContainerFlow.Engenharia.Containers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB"));
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("ContainerFlowDB"));
});

builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<PedidoLocacao>, SolicitacaoRepository>();
builder.Services.AddScoped<IRepository<Proposta>, PropostaRepository>();
builder.Services.AddScoped<IRepository<Locacao>, LocacaoRepository>();
builder.Services.AddScoped<IRepository<Conteiner>, ConteinerRepository>();

builder.Services
    .AddIdentityApiEndpoints<AppUser>(options => options.SignIn.RequireConfirmedEmail = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserIdClaimType = "ClienteId";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app
    .MapIdentityEndpoints()
    .MapClientesEndpoints()
    .MapAprovacaoClientesEndpoints()
    .MapSolicitacoesEndpoints()
    .MapPropostasEndpoints()
    .MapLocacoesEndpoints()
    .MapConteineresEndpoints();

app.Run();