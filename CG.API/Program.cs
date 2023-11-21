using CG.API.Mappers;
using CG.BL.Repositorys;
using CG.DL.Data;
using CG.DL.Mappers;
using CG.DL.Repositorys;
using CollectAndGO.Application;

namespace Project_Collect_and_Go_t5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IRecipeRepository,RecipeRepository>();
            builder.Services.AddSingleton<ITimingRepository, TimingRepository>();
            builder.Services.AddSingleton<MapFromEntity>();
            builder.Services.AddSingleton<MapToEntity>();
            builder.Services.AddSingleton<MapFromDTO>();
            builder.Services.AddSingleton<MapToDTO>();
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