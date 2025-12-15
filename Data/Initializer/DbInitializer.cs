using System;
using System.Linq;
using Data.Context;
using Data;        
using Data.Models; 
namespace Data.Initializer
{
    public static class DbInitializer
    {
        public static void SeedData(AppDbContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            Console.WriteLine("Початок заповнення тестовими даними...");

            var emp1 = new Employees
            {
                FullName = "Дослідниця Ольга Коваль",
                Role = "Керівник станції",
                ContactInfo = "olga.k@eco.ua",
                Status = "Активний"
            };
            var emp2 = new Employees
            {
                FullName = "Студент Тарас Петренко",
                Role = "Волонтер",
                ContactInfo = "taras.p@gmail.com",
                Status = "Активний"
            };
            var emp3 = new Employees
            {
                FullName = "Андрій Мельник",
                Role = "Водій",
                ContactInfo = "+380670000001",
                Status = "Активний"
            };
            var emp4 = new Employees
            {
                FullName = "Марія Савчук",
                Role = "Аналітик даних",
                ContactInfo = "m.savchuk@eco.ua",
                Status = "У відпустці"
            };
            var emp5 = new Employees
            {
                FullName = "Петро Бойко",
                Role = "Технік обладнання",
                ContactInfo = "p.boyko@eco.ua",
                Status = "Активний"
            };

            context.Employees.AddRange(emp1, emp2, emp3, emp4, emp5);

            var loc1 = new Locations
            {
                Name = "Заплава біля річки (Точка R1)",
                EcosystemType = "Річка",
                GpsLatitude = 49.8397,
                GpsLongitude = 24.0297,
                Description = "Верхня ділянка до впадіння струмка"
            };
            var loc2 = new Locations
            {
                Name = "Сосняк на пагорбі (Точка F1)",
                EcosystemType = "Ліс",
                GpsLatitude = 49.8410,
                GpsLongitude = 24.0310,
                Description = "Контроль на пагорбі, сухий пісок"
            };
            var loc3 = new Locations
            {
                Name = "Гірське озеро (Точка L1)",
                EcosystemType = "Озеро",
                GpsLatitude = 48.6000,
                GpsLongitude = 23.7000,
                Description = "Високогірне озеро, чиста вода"
            };
            var loc4 = new Locations
            {
                Name = "Степова ділянка (Точка S1)",
                EcosystemType = "Степ",
                GpsLatitude = 46.5000,
                GpsLongitude = 32.5000,
                Description = "Відкрита місцевість, сильний вітер"
            };

            context.Locations.AddRange(loc1, loc2, loc3, loc4);

            var eq1 = new Equipment
            {
                Name = "Мультипараметр Hach HQ40d",
                SerialNumber = "SN-H-1001-A",
                EquipmentType = "Сенсор",
                Status = "Робочий",
                LastCalibrationDate = DateTime.Now.AddDays(-7),
                Employee = emp1 
            };
            var eq2 = new Equipment
            {
                Name = "Фотопастка Bushnell",
                SerialNumber = "SN-B-2002-C",
                EquipmentType = "Пастка",
                Status = "Робочий",
                LastCalibrationDate = DateTime.Now.AddDays(-30),
                Employee = emp2 
            };
            var eq3 = new Equipment
            {
                Name = "Дрон DJI Mavic 3",
                SerialNumber = "DJI-M3-999",
                EquipmentType = "Дрон",
                Status = "Потребує ремонту", 
                LastCalibrationDate = DateTime.Now.AddMonths(-2),
                Employee = null 
            };
            var eq4 = new Equipment
            {
                Name = "Toyota Hilux",
                SerialNumber = "AA0001AA",
                EquipmentType = "Транспорт",
                Status = "Робочий",
                LastCalibrationDate = DateTime.Now.AddDays(-5),
                Employee = emp3 
            };
            var eq5 = new Equipment
            {
                Name = "GPS Трекер Garmin",
                SerialNumber = "GM-555",
                EquipmentType = "Навігація",
                Status = "Робочий",
                LastCalibrationDate = DateTime.Now.AddDays(-10),
                Employee = null 
            };

            context.Equipment.AddRange(eq1, eq2, eq3, eq4, eq5);

            context.SaveChanges();

            var exp1 = new Expeditions
            {
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(-2).AddHours(8),
                WeatherConditions = "Сонячно, +22C",
                Status = "Завершено",
                Notes = "Успішний збір проб води.",
                Location = loc1 
            };

            var exp2 = new Expeditions
            {
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddDays(7),
                WeatherConditions = "Прогноз: Дощ",
                Status = "Заплановано",
                Notes = "Поїздка в гори для перевірки дрона.",
                Location = loc3 
            };

            context.Expeditions.AddRange(exp1, exp2);
            context.SaveChanges();

            context.ExpeditionTeams.AddRange(
                new ExpeditionTeams { ExpeditionId = exp1.ExpeditionId, EmployeeId = emp1.EmployeeId, RoleInExpedition = "Керівник" },
                new ExpeditionTeams { ExpeditionId = exp1.ExpeditionId, EmployeeId = emp2.EmployeeId, RoleInExpedition = "Асистент" }
            );

            context.ExpeditionTeams.AddRange(
                new ExpeditionTeams { ExpeditionId = exp2.ExpeditionId, EmployeeId = emp1.EmployeeId, RoleInExpedition = "Керівник" },
                new ExpeditionTeams { ExpeditionId = exp2.ExpeditionId, EmployeeId = emp3.EmployeeId, RoleInExpedition = "Водій" },
                new ExpeditionTeams { ExpeditionId = exp2.ExpeditionId, EmployeeId = emp5.EmployeeId, RoleInExpedition = "Оператор БПЛА" }
            );


            var report1 = new ExpeditionReports
            {
                ExpeditionId = exp1.ExpeditionId,
                Summary = "Вода чиста, рівень pH в нормі.",
                Issues = "Батарея сенсора розряджається швидко.",
                ReportDate = new DateTime(2025, 11, 15, 18, 0, 0) 
            };
            context.ExpeditionReports.Add(report1);

            context.Measurements.AddRange(
                new Measurements
                {
                    Timestamp = exp1.StartDate.AddHours(1),
                    ParameterType = "pH",
                    Value = 7.4,
                    Unit = "pH",
                    Depth = 0.5,
                    LocationId = loc1.LocationId,
                    ExpeditionId = exp1.ExpeditionId,
                    EquipmentId = eq1.EquipmentId,
                    EmployeeId = emp1.EmployeeId
                },
                new Measurements
                {
                    Timestamp = exp1.StartDate.AddHours(2),
                    ParameterType = "Температура",
                    Value = 18.5,
                    Unit = "C",
                    Depth = 0.5,
                    LocationId = loc1.LocationId,
                    ExpeditionId = exp1.ExpeditionId,
                    EquipmentId = eq1.EquipmentId,
                    EmployeeId = emp1.EmployeeId
                },
                new Measurements
                {
                    Timestamp = exp1.StartDate.AddHours(3),
                    ParameterType = "Спостереження",
                    Value = 1,
                    Unit = "шт",
                    Notes = "Бачили видру.",
                    LocationId = loc1.LocationId,
                    ExpeditionId = exp1.ExpeditionId,
                    EquipmentId = eq2.EquipmentId,
                    EmployeeId = emp2.EmployeeId
                }
            );

            context.SaveChanges();
            Console.WriteLine("Дані успішно завантажено!");
        }
    }
}