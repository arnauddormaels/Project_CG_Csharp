using CG.Application.Repositorys;
using CG.Persistence.Repositorys;
using CollectAndGO.Application;

namespace Project_Collect_and_Go_t5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddSingleton<IProductRepository, ProductMapper>();
            builder.Services.AddSingleton<IRecipeRepository,RecipeMapper>();
            builder.Services.AddSingleton<DomainManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder
                        .WithOrigins("http://localhost:5173") // Replace with the origin that needs access
                        .AllowAnyOrigin();
                        
                }); ;
            });

            var app = builder.Build();
            app.UseCors("MyCorsPolicy");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}