using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Context;
using Data.Initializer;
using Data.Models;
using Repositories;
using Services;
using UI;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var connectionString = "Server=LAPTOP-1J9VUMO8; Database=DbEcoStation; Integrated Security=True; Encrypt=False;";

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                using (var dbContext = new AppDbContext(optionsBuilder.Options))
                {
                    dbContext.Database.EnsureCreated();

                    DbInitializer.SeedData(dbContext);

                    var employeeRepository = new Repository<Employees>(dbContext);
                    var expeditionRepository = new Repository<ExpeditionTeams>(dbContext);
                    var equipRepo = new Repository<Equipment>(dbContext);
                    var expRepo = new Repository<Expeditions>(dbContext);
                    var locRepo = new Repository<Locations>(dbContext);
                    var measRepo = new Repository<Measurements>(dbContext);
                    var reportRepo = new Repository<ExpeditionReports>(dbContext);

                    var employeeService = new EmployeeService(employeeRepository, expeditionRepository);
                    var equipService = new EquipmentService(equipRepo, employeeRepository);
                    var expService = new ExpeditionService(expRepo, expeditionRepository, reportRepo);
                    var locService = new LocationService(locRepo);
                    var measService = new MeasurementService(measRepo);

                    Application.Run(new MainForm(
                        employeeService,
                        equipService,
                        expService,
                        locService,
                        measService));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}\n{ex.InnerException?.Message}");
            }
        }
    }
}
