using Stripe;
using CIPCommerce.Modeles;

namespace CIPCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BdContexteCommerce>();

            
            builder.Services.Configure<ConfigApp>(builder.Configuration.GetSection("ConfigApp"));
            builder.Services.Configure<StripeConfig>(builder.Configuration.GetSection("Stripe"));

            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            // Add services to the container.
            builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseMvc();

            app.MapControllers();

            app.Run();
        }
    }
}
