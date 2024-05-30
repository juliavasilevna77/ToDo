using ToDoListMVC.Data;
using ToDoListMVC.Models;

namespace ToDo.Repositories
{
    public class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await InitializeDatabase(context);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private async Task InitializeDatabase(AppDbContext context)
        {
            if (!context.Items.Any())
            {
                var items = new[]
                {
                    new Item
                    {
                        Title = "Buy groceries",
                        Description = "Purchase vegetables, fruits, and bread",
                        Deadline = new DateTime(2024, 5, 10),
                        Done = true
                    },
                    new Item
                    {
                        Title = "Read a book",
                        Description = "Finish reading 'Clean Code'",
                        Deadline = new DateTime(2024, 5, 11),
                        Done = true
                    },
                    new Item
                    {
                        Title = "Go for a run",
                        Description = "Run 5 kilometers in the park",
                        Deadline = new DateTime(2024, 5, 12),
                        Done = true
                    },
                    new Item
                    {
                        Title = "Complete IT assignment",
                        Description = "Finish the database project",
                        Deadline = new DateTime(2024, 5, 14),
                        Done = true
                    },
                    new Item
                    {
                        Title = "Learn English grammar",
                        Description = "Study and practice conditional sentences",
                        Deadline = new DateTime(2024, 5, 15),
                        Done = true
                    },

                    new Item
                    {
                        Title = "Prepare for exam",
                        Description = "Review notes and practice questions for IT exam",
                        Deadline = new DateTime(2024, 6, 10),
                        Done = false
                    },
                    new Item
                    {
                        Title = "Visit the dentist",
                        Description = "Routine dental check-up",
                        Deadline = new DateTime(2024, 6, 11),
                        Done = false
                    },
                    new Item
                    {
                        Title = "Plan weekend trip",
                        Description = "Organize itinerary for a weekend getaway",
                        Deadline = new DateTime(2024, 6, 12),
                        Done = false
                    },
                    new Item
                    {
                        Title = "Attend webinar",
                        Description = "Join online webinar on cybersecurity",
                        Deadline = new DateTime(2024, 6, 14),
                        Done = false
                    },
                    new Item
                    {
                        Title = "Practice coding",
                        Description = "Solve problems on LeetCode",
                        Deadline = new DateTime(2024, 6, 15),
                        Done = false
                    }
                };

                context.Items.AddRange(items);
                await context.SaveChangesAsync();
            }
        }
    }
}
