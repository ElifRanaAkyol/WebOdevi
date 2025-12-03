using WebOdevi.Data.Enums;
using WebOdevi.Models;

namespace WebOdevi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // 1️⃣ FitnessCenter ekle
                FitnessCenter sakaryaGym = null;
                FitnessCenter cityFitness = null;

                if (!context.FitnessCenters.Any())
                {
                    sakaryaGym = new FitnessCenter
                    {
                        Name = "Sakarya Gym",
                        Address = "Sakarya Üniversitesi Kampüsü",
                    };

                    cityFitness = new FitnessCenter
                    {
                        Name = "City Fitness",
                        Address = "Adapazarı Merkezi",
                    };

                    context.FitnessCenters.AddRange(sakaryaGym, cityFitness);
                    context.SaveChanges(); // Id’ler burada atanır
                }
                else
                {
                    sakaryaGym = context.FitnessCenters.FirstOrDefault(fc => fc.Name == "Sakarya Gym");
                    cityFitness = context.FitnessCenters.FirstOrDefault(fc => fc.Name == "City Fitness");
                }

                // 2️⃣ Trainer ekle
                Trainer ahmet = null;
                Trainer ayse = null;

                if (!context.Trainers.Any())
                {
                    ahmet = new Trainer
                    {
                        ProfileImageUrl = "/images/Trainers/trainer1.png",
                        FullName = "Ahmet Yılmaz",
                        FitnessCenterId = sakaryaGym.Id
                    };

                    ayse = new Trainer
                    {
                        ProfileImageUrl = "/images/Trainers/trainer1.png",

                        FullName = "Ayşe Demir",
                        FitnessCenterId = cityFitness.Id
                    };

                    context.Trainers.AddRange(ahmet, ayse);
                    context.SaveChanges();
                }
                else
                {
                    ahmet = context.Trainers.FirstOrDefault(t => t.FullName == "Ahmet Yılmaz");
                    ayse = context.Trainers.FirstOrDefault(t => t.FullName == "Ayşe Demir");
                }

                // 3️⃣ Availability ekle
                if (!context.Availabilities.Any())
                {
                    context.Availabilities.AddRange(
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = "Pazartesi",
                            StartTime = 5,
                            EndTime = 6
                        },
                        new Availability
                        {
                            TrainerId = ayse.Id,
                            DayOfWeek = "Salı",
                            StartTime = 5,
                            EndTime = 6
                        }
                    );
                    context.SaveChanges();
                }

                // 4️⃣ Specializations ekle
                Specialization pilates = null;
                Specialization bodybuilding = null;
                Specialization cardio = null;

                if (!context.Specializations.Any())
                {
                    pilates = new Specialization { Name = "Pilates" };
                    bodybuilding = new Specialization { Name = "Bodybuilding" };
                    cardio = new Specialization { Name = "Cardio" };

                    context.Specializations.AddRange(pilates, bodybuilding, cardio);
                    context.SaveChanges();
                }
                else
                {
                    pilates = context.Specializations.FirstOrDefault(s => s.Name == "Pilates");
                    bodybuilding = context.Specializations.FirstOrDefault(s => s.Name == "Bodybuilding");
                    cardio = context.Specializations.FirstOrDefault(s => s.Name == "Cardio");
                }

                // 5️⃣ TrainerSpecializations ekle
                if (!context.TrainerSpecializations.Any())
                {
                    context.TrainerSpecializations.AddRange(
                        new TrainerSpecialization { TrainerId = ahmet.Id, SpecializationId = pilates.Id },
                        new TrainerSpecialization { TrainerId = ahmet.Id, SpecializationId = bodybuilding.Id },
                        new TrainerSpecialization { TrainerId = ayse.Id, SpecializationId = cardio.Id }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
