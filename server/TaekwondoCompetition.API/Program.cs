using TaekwondoCompetition.API.Extensions;

const string CORS_POLICY = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddSwagger()
    .AddCorsPolicy(CORS_POLICY)
    .AddPresentationLayer()
    .AddApplicationLayer()
    .AddPersistenceLayer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseCors(CORS_POLICY);

app.MapControllers();

app.Run();
