using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stack_react_business.Domains;
using stack_react_business.Domains.Interfaces;
using stack_react_data;
using stack_react_data.Repostiories;
using stack_react_data.Repostiories.Interfaces;

namespace stack_react_api
{
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
      services.AddControllers();
      services.AddDbContext<IStackDbContext, StackDbContext>(builder =>
        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(builder =>
        {
          builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000");
        });
      });

      services.AddTransient<IQuestionRepository, QuestionRepository>();
      services.AddTransient<IQuestionDomain, QuestionDomain>();

      services.AddTransient<IAnswerRepository, AnswerRepository>();
      services.AddTransient<IAnswerDomain, AnswerDomain>();

      var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new stack_react_business.MapProfile()));
      services.AddSingleton(mapConfig.CreateMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
