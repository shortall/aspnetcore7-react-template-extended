namespace TemplateApp.Data.EF.Context
{
    public class DbInitialiser
    {
        private readonly DashboardDBContext _context;

        public DbInitialiser(DashboardDBContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}