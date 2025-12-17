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
                            DayOfWeek = DaysOfWeek.pazartesi,
                            Hour = "9.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.pazartesi,
                            Hour = "10.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.pazartesi,
                            Hour = "11.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.pazartesi,
                            Hour = "12.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.sali,
                            Hour = "13.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "14.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "15.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "16.00",
                        },
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "17.00",
                        },
                        
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.persembe,
                            Hour = "9.00",
                        },
                        
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "10.00",
                        },
                        
                        new Availability
                        {
                            TrainerId = ahmet.Id,
                            DayOfWeek = DaysOfWeek.carsamba,
                            Hour = "11.00",
                        }
                        
                    );
                    context.SaveChanges();
                }

                Specialization pilates = null;
                Specialization bodybuilding = null;
                Specialization cardio = null;
                Specialization yoga = null;
                Specialization personalTraining = null;
                Service sPilates = null;
                Service sBodybuilding = null;
                Service sCardio = null;
                Service sYoga= null;
                Service sPersonalTraining = null;

                if (!context.Specializations.Any())
                {
                    pilates = new Specialization { Name = "Pilates" };
                    bodybuilding = new Specialization { Name = "Bodybuilding" };
                    cardio = new Specialization { Name = "Cardio" };
                    yoga = new Specialization { Name = "Yoga" };
                    personalTraining = new Specialization { Name = "Personal Training" };


                    context.Specializations.AddRange(pilates, bodybuilding, cardio, personalTraining, yoga);
                    context.SaveChanges();
                }
                else
                {
                    pilates = context.Specializations.FirstOrDefault(s => s.Name == "Pilates");
                    bodybuilding = context.Specializations.FirstOrDefault(s => s.Name == "Bodybuilding");
                    cardio = context.Specializations.FirstOrDefault(s => s.Name == "Cardio");
                    yoga = context.Specializations.FirstOrDefault(s => s.Name == "Yoga");
                    personalTraining = context.Specializations.FirstOrDefault(s => s.Name == "Personal Training");

                }

                if (!context.TrainerSpecializations.Any())
                {
                    context.TrainerSpecializations.AddRange(
                        new TrainerSpecialization { TrainerId = ahmet.Id, SpecializationId = pilates.Id },
                        new TrainerSpecialization { TrainerId = ahmet.Id, SpecializationId = bodybuilding.Id },
                        new TrainerSpecialization { TrainerId = ahmet.Id, SpecializationId = cardio.Id }
                    );
                    context.SaveChanges();
                }

                if (!context.Services.Any())
                {
                    sPilates = new Service { Name = "Pilates" , trainingFee =900};
                    sBodybuilding = new Service { Name = "Bodybuilding", trainingFee = 1000 };
                    sCardio = new Service { Name = "Cardio",  trainingFee = 850 };
                    sYoga = new Service { Name = "Yoga" , trainingFee = 750 };
                    sPersonalTraining = new Service { Name = "Personal Training" ,trainingFee = 800 };


                    context.Services.AddRange(sPilates, sBodybuilding, sCardio, sYoga,sPersonalTraining);
                    context.SaveChanges();
                }
                else
                {
                    sPilates = context.Services.FirstOrDefault(s => s.Name == "Pilates");
                    sBodybuilding = context.Services.FirstOrDefault(s => s.Name == "Bodybuilding");
                    sCardio = context.Services.FirstOrDefault(s => s.Name == "Cardio");
                    sYoga = context.Services.FirstOrDefault(s => s.Name == "Yoga");
                    sPersonalTraining = context.Services.FirstOrDefault(s => s.Name == "Personal Training");
                }
                if (!context.TrainerServices.Any())
                {
                    context.TrainerServices.AddRange(
                        new TrainerService { TrainerId = ahmet.Id, ServiceId = sPilates.Id },
                        new TrainerService { TrainerId = ahmet.Id, ServiceId = sBodybuilding.Id },
                        new TrainerService { TrainerId = ahmet.Id, ServiceId = sCardio.Id }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
