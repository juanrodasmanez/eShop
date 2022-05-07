using Microsoft.AspNetCore.Builder;
using System;

namespace eShop.Api
{
    public static class SwaggerConfiguration
    {
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            if(app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eShop.Api v1"));
            
            return app;
        }

        
    }
}
