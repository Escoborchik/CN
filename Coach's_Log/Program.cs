using MangaMania.Services;
using Microsoft.Extensions.FileProviders;

namespace Coach_s_Log
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;           
            services.RegisterAppServices(builder.Configuration);

            builder.Services.AddTransient<IFileService, FileService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5173"));
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, FileService.ROOT_FOLDER_NAME)),
                RequestPath = "/assets"
            });

            app.MapControllers();

            app.Run();
        }
    }
}
