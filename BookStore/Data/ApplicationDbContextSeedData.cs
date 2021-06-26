namespace BookStore.Data
{
    internal static class ApplicationDbContextSeedData
    {
        internal static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}