using Microsoft.EntityFrameworkCore;


namespace Discount.Grpc.Data;

public static class Extensions
{
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        // DbContext use AddScoped so we create a scope to dispose after using it
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

        dbContext.Database.MigrateAsync();

        return app;
    }
}
