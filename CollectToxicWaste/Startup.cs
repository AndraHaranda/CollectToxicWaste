using Microsoft.OpenApi.Models;

namespace CollectToxicWaste
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CollectWasteToxic",
                        Version = "v1",
                        Description = "Transformando Araxá em lugar melhor!",
                        Contact = new OpenApiContact
                        {
                            Name = "Andraerlem Haranda",
                            Url = new Uri("https://github.com/CabecaDeCenoura")
                        }
                    });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Cors
            app.UseCors("ApiCorsPolicy");

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Collect Waste Toxic");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
