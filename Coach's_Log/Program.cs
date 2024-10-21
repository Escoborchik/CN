namespace Coach_s_Log
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;           
            services.RegisterAppServices(builder.Configuration);            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseCookiePolicy(new CookiePolicyOptions
            //{
            //    MinimumSameSitePolicy = SameSiteMode.Strict,
            //    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
            //    Secure = CookieSecurePolicy.Always
            //});
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5000"));

            app.MapControllers();

            app.Run();
        }
    }
}
