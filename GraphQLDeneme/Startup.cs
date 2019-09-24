using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLDeneme.Data;
using GraphQLDeneme.Data.Concrete;
using GraphQLDeneme.Models.GraphQLModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GraphQLDeneme.Models.GraphQLModels.AppMutation;

namespace GraphQLDeneme
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
            services.AddScoped<AppQuery>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<CategoryType>();
            services.AddTransient<ProductType>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddScoped<AppMutation>();
            services.AddScoped<AppSchema>();
            services.AddScoped<ProductInputType>();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new AppSchema(sp.GetRequiredService<IDependencyResolver>()));

            //services.AddGraphQL(o => { o.ExposeExceptions = false; })
            //    .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            
        }
    }
}
