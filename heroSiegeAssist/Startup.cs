using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace heroSiegeAssist;

public class Startup
{
  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {
    ConfigureCors(services);
    ConfigureAuth(services);
    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "heroSiegeAssist", Version = "v1" });
    });
    services.AddSingleton<Auth0Provider>();
    services.AddScoped<IDbConnection>(x => CreateDbConnection());

    services.AddScoped<AccountsRepository>();
    services.AddScoped<AccountService>();

    services.AddTransient<RunesRepository>();
    services.AddTransient<RunesService>();

    services.AddTransient<RunewordsRepository>();
    services.AddTransient<RunewordsService>();

    services.AddTransient<RuneRunewordsRepository>();
    services.AddTransient<RuneRunewordsService>();

    services.AddTransient<EffectsRepository>();
    services.AddTransient<EffectsService>();

    services.AddTransient<AbilitiesRepository>();
    services.AddTransient<AbilitiesService>();

    services.AddTransient<ItemsRepository>();
    services.AddTransient<ItemsService>();
  }

  private void ConfigureCors(IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy("CorsDevPolicy", builder =>
            {
              builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                // .AllowCredentials()
                .AllowAnyOrigin();
            });

      options.AddPolicy("CorsProdPolicy", builder =>
            {
              builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                // .AllowCredentials()
                .AllowAnyOrigin();
            });
    });
  }

  private void ConfigureAuth(IServiceCollection services)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.Authority = $"https://{Configuration["AUTH0_DOMAIN"]}/";
      options.Audience = Configuration["AUTH0_AUDIENCE"];
    });

  }

  private IDbConnection CreateDbConnection()
  {
    string connectionString = Configuration["CONNECTION_STRING"];
    return new MySqlConnection(connectionString);
  }


  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jot v1"));
      // app.UseCors("CorsDevPolicy");
    }

    app.UseCors("CorsDevPolicy");
    app.UseHttpsRedirection();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });
  }
}

