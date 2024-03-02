using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShopEva.API.AutoMapper;
using ShopEva.Data.Contexts;
using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Repositories;
using ShopEva.Services.IServices;
using ShopEva.Services.Services;

namespace ShopEva.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(p => p.AddPolicy("ShopEvaAPIPolicy",
                build =>
                {
                    build.WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                }));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShopEvaApi",
                    Description = "Đây là ShopEvaApi",
                });
            });

            //builder.Services.AddDbContext<ShopEvaDbContext>(option =>
            //{
            //    option.UseNpgsql(builder.Configuration.GetConnectionString("ShopEvaDbContext"));
            //});

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);


            #region AddScoped
            builder.Services.AddScoped<IDbFactory, DbFactory>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IErrorRepository, ErrorRepository>();
            builder.Services.AddScoped<IErrorService, ErrorService>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            #endregion

            builder.Services.AddMvc();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopEva.API - v1"));
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.MapControllers();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();



            app.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //                .ConfigureWebHostDefaults(webBuilder =>
        //                {
        //                    webBuilder.UseStartup<Startup>();
        //                });
        //}
        
    }
}
