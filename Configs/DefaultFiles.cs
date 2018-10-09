using Microsoft.AspNetCore.Builder;

namespace AppApi.Configs
{
    public static class DefaultFiles
    {
        public static void DefaultFilesConfigure(IApplicationBuilder app){
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("/Frontend/index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
        }
    }
}