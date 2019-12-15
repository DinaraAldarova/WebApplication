using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TestWebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<MagicBall>();
            //services.AddTransient<Coin>();
            //services.AddTransient<Dice>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app/*,*/ /*IHostingEnvironment env*/ /*MagicBall magicBall*/)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Run(async (context) =>
            {
                if(context.Request.Query.ContainsKey("magicball"))
                {
                    MagicBall magicBall = JsonConvert.DeserializeObject<MagicBall>(context.Request.Query["magicball"]);
                    await context.Response.WriteAsync(magicBall.GetAnswerQuestion());
                }
                else if (context.Request.Query.ContainsKey("coin"))
                {
                    Coin coin = JsonConvert.DeserializeObject<Coin>(context.Request.Query["coin"]);
                    await context.Response.WriteAsync(coin.GetAnswerQuestion());
                }
                else if (context.Request.Query.ContainsKey("dice"))
                {
                    Dice dice = JsonConvert.DeserializeObject<Dice>(context.Request.Query["dice"]);
                    await context.Response.WriteAsync(dice.GetAnswerQuestion());
                }
            });
        }
    }
}
