﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Contracts;
using DatingApp.API.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using DatingApp.API.Helpers;
using DatingApp.API.Data;
using AutoMapper;

namespace DatingApp.API
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
            services.AddDbContext<DatingContext>(options => {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);                    
            services.AddCors();
            services.AddAutoMapper(typeof(DatingRepository).Assembly);
            services.AddControllers().AddNewtonsoftJson( options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddTransient<seed>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IBlogsRepository, BlogsRepository>();
            services.AddScoped<IBlogCommentsRepository, BlogCommentsRepository>();
            services.AddScoped<IDatingRepository, DatingRepository>();       
            services.AddScoped<LogUserActivity>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
              app.UseExceptionHandler(builder => {
                  builder.Run(async context => {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                      var error = context.Features.Get<IExceptionHandlerFeature>();
                      if(error != null)
                      {
                          context.Response.AddApplicationError(error.Error.Message);
                          await context.Response.WriteAsync(error.Error.Message);
                      }
                  });
              });  
            }
            app.UseHsts();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseHttpsRedirection();           
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endPoints => {
                endPoints.MapControllers();
                endPoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
