using BlazorKonva;
using BlazorKonvaTest.Components;
using Microsoft.AspNetCore.ResponseCompression;

namespace BlazorKonvaTest
{
    public class Program
    {

        public static void DetectCorrectCurrentDirectory()
        {
            try
            {

                //Block needed to enable correct finding of log folder to store dll logs
                //dll logs are stored locally in the component as, set_log_path of dll doesnt work
                string cur_dir = System.IO.Directory.GetCurrentDirectory() + "\\";
                //log.Debug("Current dir: " + cur_dir);
                string app_dir = AppDomain.CurrentDomain.BaseDirectory;
                //log.Debug("App dir: " + app_dir);
                if (cur_dir.Equals(app_dir))
                {
                    //log.Debug("Current directory = App directory. OK");
                }
                else
                {
                    System.IO.Directory.SetCurrentDirectory(app_dir);
                    //log.Debug("Altered Current Dir: " + System.IO.Directory.GetCurrentDirectory());
                }
            }
            catch (Exception ex)
            {
                //log.Warn(ex, "DetectCorrectCurrentDirectory");
            }
        }


        public static void Main(string[] args)
        {

            DetectCorrectCurrentDirectory();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<BlazorKonvaWrapper>();

            #region AspNetCore_Specials

            builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));

            //Response time optimization
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions()
            {
                ServeUnknownFileTypes = true
            });
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
