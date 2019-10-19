﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EntityFramework
{
    class DbInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            IEnumerable<Region> regions = new List<Region>
            {
                new Region
                {
                    Id = 1,
                    Name = "Харьковская область"
                },
                new Region
                {
                    Id = 2,
                    Name = "Киевская область"
                },
                new Region
                {
                    Id = 3,
                    Name = "Полтавская область"
                },
                new Region
                {
                    Id = 4,
                    Name = "Донецкая область"
                },
                new Region
                {
                    Id = 5,
                    Name = "Луганская область"
                },
                new Region
                {
                    Id = 6,
                    Name = "Запорожская область"
                },
                new Region
                {
                    Id = 7,
                    Name = "Херсонская область"
                },
                new Region
                {
                    Id = 8,
                    Name = "Николаевская область"
                },
                new Region
                {
                    Id = 9,
                    Name = "Одесская область"
                },
                new Region
                {
                    Id = 10,
                    Name = "Кировоградская область"
                },
                new Region
                {
                    Id = 11,
                    Name = "Сумская область"
                },
                new Region
                {
                    Id = 12,
                    Name = "Черниговская область"
                },
                new Region
                {
                    Id = 13,
                    Name = "Черкасская область"
                },
                new Region
                {
                    Id = 14,
                    Name = "Винницкая область"
                },
                new Region
                {
                    Id = 15,
                    Name = "Житомирская область"
                },
                new Region
                {
                    Id = 16,
                    Name = "Хмельницкая область"
                },
                new Region
                {
                    Id = 17,
                    Name = "Тернопольская область"
                },
                new Region
                {
                    Id = 18,
                    Name = "Ровенская область"
                },
                new Region
                {
                    Id = 19,
                    Name = "Волынская область"
                },
                new Region
                {
                    Id = 20,
                    Name = "Черновицкая область"
                },
                new Region
                {
                    Id = 21,
                    Name = "Ивано-Франковская область"
                },
                new Region
                {
                    Id = 22,
                    Name = "Львовская область"
                },
                new Region
                {
                    Id = 23,
                    Name = "Закарпатская область"
                },
                new Region
                {
                    Id = 24,
                    Name = "Днепропетровская область"
                }
            };
            context.Regions.AddRange(regions.OrderBy(region => region.Name));
            context.SaveChanges();
            IEnumerable<City> cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    RegionId = 1,
                    Name = "Харьков"
                },
                new City
                {
                    Id = 2,
                    RegionId = 2,
                    Name = "Киев"
                },
                new City
                {
                    Id = 3,
                    RegionId = 3,
                    Name = "Полтава"
                },
                new City
                {
                    Id = 4,
                    RegionId = 4,
                    Name = "Донецьк"
                },
                new City
                {
                    Id = 5,
                    RegionId = 5,
                    Name = "Луганськ"
                },
                new City
                {
                    Id = 6,
                    RegionId = 6,
                    Name = "Запорожье"
                },
                new City
                {
                    Id = 7,
                    RegionId = 7,
                    Name = "Херсон"
                },
                new City
                {
                    Id = 8,
                    RegionId = 8,
                    Name = "Николаев"
                },
                new City
                {
                    Id = 9,
                    RegionId = 9,
                    Name = "Одесса"
                },
                new City
                {
                    Id = 10,
                    RegionId = 10,
                    Name = "Кировоград"
                },
                new City
                {
                    Id = 11,
                    RegionId = 11,
                    Name = "Суммы"
                },
                new City
                {
                    Id = 12,
                    RegionId = 12,
                    Name = "Чернигов"
                },
                new City
                {
                    Id = 13,
                    RegionId = 13,
                    Name = "Черкасы"
                },
                new City
                {
                    Id = 14,
                    RegionId = 14,
                    Name = "Винница"
                },
                new City
                {
                    Id = 15,
                    RegionId = 15,
                    Name = "Житомир"
                },
                new City
                {
                    Id = 16,
                    RegionId = 16,
                    Name = "Хмельницкий"
                },
                new City
                {
                    Id = 17,
                    RegionId = 17,
                    Name = "Тернополь"
                },
                new City
                {
                    Id = 18,
                    RegionId = 18,
                    Name = "Ровно"
                },
                new City
                {
                    Id = 19,
                    RegionId = 19,
                    Name = "Луцк"
                },
                new City
                {
                    Id = 20,
                    RegionId = 20,
                    Name = "Черновцы"
                },
                new City
                {
                    Id = 21,
                    RegionId = 21,
                    Name = "Ивано-Франковск"
                },
                new City
                {
                    Id = 22,
                    RegionId = 22,
                    Name = "Львов"
                },
                new City
                {
                    Id = 23,
                    RegionId = 23,
                    Name = "Закарпатье"
                },
                new City
                {
                    Id = 24,
                    RegionId = 24,
                    Name = "Кривой Рог"
                },
                new City
                {
                    Id = 25,
                    RegionId = 24,
                    Name = "Каменское"
                },
                new City
                {
                    Id = 26,
                    RegionId = 24,
                    Name = "Днепр"
                },
                new City
                {
                    Id = 27,
                    RegionId = 4,
                    Name = "Мариуполь"
                },
                new City
                {
                    Id = 28,
                    RegionId = 4,
                    Name = "Макеевка"
                },
                new City
                {
                    Id = 29,
                    RegionId = 4,
                    Name = "Горловка"
                },
                new City
                {
                    Id = 30,
                    RegionId = 3,
                    Name = "Кременчуг"
                },
                new City
                {
                    Id = 31,
                    RegionId = 2,
                    Name = "Белая Церковь"
                },
                new City
                {
                    Id = 32,
                    RegionId = 10,
                    Name = "Кропивницкий"
                }
            };
            context.Cities.AddRange(cities.OrderBy(city=>city.Name));

            IEnumerable<EducationalInstitution> educationalInstitutions = new List<EducationalInstitution>
            {
                new EducationalInstitution
                {
                    Name =
                        "Львівський фізико-математичний ліцей-інтернат при Львівському національному університеті імені Івана Франка",
                    CityId = 22
                },
                new EducationalInstitution
                {
                    Name =
                        "Ліцей \"Інтелект\"",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "Природничо-науковий ліцей №145 Печерського р-ну м. Києва",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "Технічний ліцей Національного технічного університету України \"Київський політехнічний інститут\" Солом’янського р-ну м.Києва",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "КЗ освіти \"Дніпровський ліцей інформаційних технологій при Дніпровському національному" +
                        " університеті імені Олеся Гончара\" Дніпровської міськради",
                    CityId = 26
                },
                new EducationalInstitution
                {
                    Name =
                        "Український фізико-математичний ліцей Київського національного університету імені Т.Шевченка",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "Український гуманітарний ліцей Київського національного університету імені Тараса Шевченка",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "Гімназія №178 Солом’янського р-ну м.Києва",
                    CityId = 2
                },
                new EducationalInstitution
                {
                    Name =
                        "КЗ \"Харківський фізико-математичний ліцей № 27 Харківської міськради Харківської обл.\"",
                    CityId = 1
                },
                new EducationalInstitution
                {
                    Name =
                        "Українська гімназія № 1 Івано-Франківської міськради Івано-Франківської обл.",
                    CityId = 21
                },
                new EducationalInstitution
                {
                    Name =
                        "Черкаський фізико-математичний ліцей (ФІМЛІ) Черкаської міськради Черкаської обл.",
                    CityId = 13
                },
                new EducationalInstitution
                {
                    Name =
                        "Львівська академічна гімназія при Національному університеті \"Львівська політехніка\"",
                    CityId = 22
                },
                new EducationalInstitution
                {
                    Name =
                        "Кіровоградський обласний НВК (гімназія-інтернат-школа мистецтв)",
                    CityId = 32
                },
                new EducationalInstitution
                {
                    Name =
                        "Волинський науковий ліцей-інтернат Волинської обласної ради",
                    CityId = 19
                }
            };
            context.EducationalInstitutions.AddRange(educationalInstitutions.OrderBy(obj => obj.CityId));
            context.SaveChanges();

            IEnumerable<SubjectEIE> subjectsEIE = new List<SubjectEIE>
            {
                new SubjectEIE
                {
                    Name = "Украинский язык и литература"
                },
                new SubjectEIE
                {
                    Name = "Математика "
                },
                new SubjectEIE
                {
                    Name = "История Украины"
                },
                new SubjectEIE
                {
                    Name = "Испанский язык"
                },
                new SubjectEIE
                {
                    Name = "Немецкий язык"
                },
                new SubjectEIE
                {
                    Name = "Французский язык"
                },
                new SubjectEIE
                {
                    Name = "Английский язык"
                },
                new SubjectEIE
                {
                    Name = "Физика"
                },
                new SubjectEIE
                {
                    Name = "Биология"
                },
                new SubjectEIE
                {
                    Name = "География"
                },
                new SubjectEIE
                {
                    Name = "Химия"
                }
            };
            context.SubjectEIEs.AddRange(subjectsEIE);

            IEnumerable<SubjectCertificate> subjectCertificates = new List<SubjectCertificate>
            {
                new SubjectCertificate
                {
                    Name = "Українська мова"
                },
                new SubjectCertificate
                {
                    Name = "Українська література"
                },
                new SubjectCertificate
                {
                    Name = "Іноземна мова"
                },
                new SubjectCertificate
                {
                    Name = "Світова література"
                },
                new SubjectCertificate
                {
                    Name = "Історія України"
                },
                new SubjectCertificate
                {
                    Name = "Всесвітня історія"
                },
                new SubjectCertificate
                {
                    Name = "Правознавство"
                },
                new SubjectCertificate
                {
                    Name = "Економіка"
                },
                new SubjectCertificate
                {
                    Name = "Людина і світ"
                },
                new SubjectCertificate
                {
                    Name = "Художня культура"
                },
                new SubjectCertificate
                {
                    Name = "Філософія"
                },
                new SubjectCertificate
                {
                    Name = "Математика"
                },
                new SubjectCertificate
                {
                    Name = "Алгебра і початки аналізу"
                },
                new SubjectCertificate
                {
                    Name = "Геометрія"
                },
                new SubjectCertificate
                {
                    Name = "Біологія"
                },
                new SubjectCertificate
                {
                    Name = "Астрономія"
                },
                new SubjectCertificate
                {
                    Name = "Географія"
                },
                new SubjectCertificate
                {
                    Name = "Фізика"
                },
                new SubjectCertificate
                {
                    Name = "Хімія"
                },
                new SubjectCertificate
                {
                    Name = "Психологія"
                },
                new SubjectCertificate
                {
                    Name = "Екологія"
                },
                new SubjectCertificate
                {
                    Name = "Технології"
                },
                new SubjectCertificate
                {
                    Name = "Інформатика"
                },
                new SubjectCertificate
                {
                    Name = "Фізична культура"
                },
                new SubjectCertificate
                {
                    Name = "Захист Вітчизни"
                }
            };
            context.SubjectCertificates.AddRange(subjectCertificates.OrderBy(sub => sub.Name));
            context.SaveChanges();
        }
    }
}