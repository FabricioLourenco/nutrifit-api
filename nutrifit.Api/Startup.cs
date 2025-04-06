using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nutrifit.Infra.CrossCutting.Ioc;
using Nutrifit.Api.Filters;
using Nutrifit.Domain.Common;

namespace Nutrifit.Api
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
            services.AddControllers(options =>
            {
                options.Filters.Add<QResultActionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }).AddMvc()
              .AddApiExplorer(
                    options =>
                    {
                        options.GroupNameFormat = "'v'VVV";
                        options.SubstituteApiVersionInUrl = true;
                    });


            services.AddSwaggerGen();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddApplicationContext(Configuration.GetValue<string>("ConnectionStrings:Nutrifit"));

            services.AddApplicationAuthentication(Configuration);

            services.AddApplicationCollections(Configuration);

            //services.AddScoped<QResultActionFilter>();

            MapperConfiguration mapperConfiguration = new(mapperConfig => { mapperConfig.AddMaps(new[] { "Nutrifit.Service" }); });

            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.Configure<AppSettings>(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });


            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nutrifit v1"));
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Register();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            Math.Min(Environment.ProcessorCount * 5, 20);
        }
    }
}
