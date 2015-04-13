namespace Ioana.RealEstate.Data.Migrations
{
    using Ioana.RealEstate.Data.EntityFramework;
    using Ioana.RealEstate.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RealEstateDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ioana.RealEstate.Data.EntityFramework.RealEstateDbContext";
        }

        protected override void Seed(RealEstateDbContext context)
        {
            this.SeedOfferTypes(context);
            this.SeedCities(context);
            this.SeedEstateTypes(context);
            this.SeedFurnishingTypes(context);
            this.SeedConstructionStatuses(context);
            this.SeedConstructionTypes(context);
            this.SeedHeatingInstallations(context);
            this.SeedJoineryTypes(context);
            this.SeedFlooringTypes(context);
            this.SeedOfferStatuses(context);
            this.SeedEstateCharacteristics(context);
            this.SeedCurrencies(context);
            this.SeedRoles(context);

            context.SaveChanges();
        }

        private void SeedOfferTypes(RealEstateDbContext context)
        {
            OfferType[] offerTypesToSeed = new OfferType[]
            {
                new OfferType()
                {
                    Id = 1,
                    Name = "Продава"
                },
                new OfferType()
                {
                    Id = 2,
                    Name = "Дава под наем"
                },
            };


            context.OfferTypes.AddOrUpdate(ot => ot.Id, offerTypesToSeed);
        }

        private void SeedCities(RealEstateDbContext context)
        {
            City varna = new City()
            {
                Id = 1,
                Name = "Варна"
            };

            varna.Regions.Add(new CityRegion()
            {
                Name = "Аспарухово"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "Владислав Варненчик"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "Младост"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "Одесос"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "Приморски"
            });

            City sofia = new City()
            {
                Id = 2,
                Name = "София"
            };

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Люлин"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Сердика"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Красно Село"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Триадица"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Младост"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Нови Искър"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Оборище"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Овча Купел"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Илинден"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Искър"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Красна Поляна"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Лозенец"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Надежда"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Средец"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Подуяне"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Студентски"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Банкя"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Изгрев"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Кремиковци"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Връбница"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Витоша"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Панчарево"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Слатина"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "Възраждане"
            });

            City[] citiesToSeed = new City[] { varna, sofia };

            context.Cities.AddOrUpdate(c => c.Id, citiesToSeed);
        }

        private void SeedEstateTypes(RealEstateDbContext context)
        {
            EstateType[] estateTypesToSeed = new EstateType[]
            {
                new EstateType()
                {
                    Id = 1,
                    Name = "Едностаен Aпартамент"
                },
                new EstateType()
                {
                    Id = 2,
                    Name = "Двустаен апартамент"
                },
                new EstateType()
                {
                    Id = 3,
                    Name = "Тристаен апартамент"
                },
                new EstateType()
                {
                    Id = 4,
                    Name = "Четиристаен апартамент"
                },
                new EstateType()
                {
                    Id = 5,
                    Name = "Многостаен апартамент"
                },
                new EstateType()
                {
                    Id = 6,
                    Name = "Етаж от Къща"
                },
                new EstateType()
                {
                    Id = 7,
                    Name = "Къща"
                },
                new EstateType()
                {
                    Id = 8,
                    Name = "Офис"
                },
                new EstateType()
                {
                    Id = 9,
                    Name = "Магазин"
                },
                new EstateType()
                {
                    Id = 10,
                    Name = "Заведение"
                },
                new EstateType()
                {
                    Id = 11,
                    Name = "Гараж"
                },
                new EstateType()
                {
                    Id = 12,
                    Name = "Паркинг"
                },
                new EstateType()
                {
                    Id = 13,
                    Name = "Хотел"
                },
                new EstateType()
                {
                    Id = 14,
                    Name = "Сграда"
                },
                new EstateType()
                {
                    Id = 15,
                    Name = "Парцел"
                },
                new EstateType()
                {
                    Id = 16,
                    Name = "Склад"
                },
                new EstateType()
                {
                    Id = 17,
                    Name = "Цех"
                },
                new EstateType()
                {
                    Id = 18,
                    Name = "Фризьорски Салон"
                },
                new EstateType()
                {
                    Id = 19,
                    Name = "Спа Център"
                },
                new EstateType()
                {
                    Id = 20,
                    Name = "Медицински Кабинет"
                },
                new EstateType()
                {
                    Id = 21,
                    Name = "Стоматологичен Кабинет"
                },
                new EstateType()
                {
                    Id = 22,
                    Name = "Търговско Помещение"
                },
                new EstateType()
                {
                    Id = 23,
                    Name = "Лаборатория"
                }
            };

            context.EstateTypes.AddOrUpdate(ot => ot.Id, estateTypesToSeed);
        }

        private void SeedFurnishingTypes(RealEstateDbContext context)
        {
            FurnishingType[] furnishingTypesToSeed = new FurnishingType[]
            {
                new FurnishingType()
                {
                    Id = 1,
                    Name = "Обзаведен"
                },
                new FurnishingType()
                {
                    Id = 2,
                    Name = "Необзаведен"
                },
                new FurnishingType()
                {
                    Id = 3,
                    Name = "Полуобзаведен"
                }
            };

            context.FurnishingTypes.AddOrUpdate(ft => ft.Id, furnishingTypesToSeed);
        }

        private void SeedConstructionStatuses(RealEstateDbContext context)
        {
            ConstructionStatus[] constructionStatusesToSeed = new ConstructionStatus[]
            {
                new ConstructionStatus()
                {
                    Id = 1,
                    Name = "Ново"
                },
                new ConstructionStatus()
                {
                    Id = 2,
                    Name = "Старо"
                }
            };

            context.ConstructionStatuses.AddOrUpdate(cs => cs.Id, constructionStatusesToSeed);
        }

        private void SeedConstructionTypes(RealEstateDbContext context)
        {
            ConstructionType[] constructionTypesToSeed = new ConstructionType[]
            {
                new ConstructionType()
                {
                    Id = 1,
                    Name = "Тухла"
                },
                new ConstructionType()
                {
                    Id = 2,
                    Name = "Панел"
                },
                new ConstructionType()
                {
                    Id = 3,
                    Name = "ЕПК"
                }
            };

            context.ConstructionTypes.AddOrUpdate(ct => ct.Id, constructionTypesToSeed);
        }

        private void SeedHeatingInstallations(RealEstateDbContext context)
        {
            HeatingInstallation[] heatingInstallationsToSeed = new HeatingInstallation[]
            {
                new HeatingInstallation()
                {
                    Id = 1,
                    Name = "Климатик"
                },
                new HeatingInstallation()
                {
                    Id = 2,
                    Name = "Ток"
                },
                new HeatingInstallation()
                {
                    Id = 3,
                    Name = "Локално"
                },
                new HeatingInstallation()
                {
                    Id = 4,
                    Name = "Тец"
                }
            };

            context.HeatingInstallations.AddOrUpdate(hi => hi.Id, heatingInstallationsToSeed);
        }

        private void SeedJoineryTypes(RealEstateDbContext context)
        {
            JoineryType[] joineryTypesToSeed = new JoineryType[]
            {
                new JoineryType()
                {
                    Id = 1,
                    Name = "PVC"
                },
                new JoineryType()
                {
                    Id = 2,
                    Name = "Алуминиева"
                },
                new JoineryType()
                {
                    Id = 3,
                    Name = "Дървена"
                }
            };

            context.JoineryTypes.AddOrUpdate(jt => jt.Id, joineryTypesToSeed);
        }

        private void SeedFlooringTypes(RealEstateDbContext context)
        {
            FlooringType[] flooringTypesToSeed = new FlooringType[]
            {
                new FlooringType()
                {
                    Id = 1,
                    Name = "Ламинат"
                },
                new FlooringType()
                {
                    Id = 2,
                    Name = "Паркет"
                },
                new FlooringType()
                {
                    Id = 3,
                    Name = "Теракот"
                },
                new FlooringType()
                {
                    Id = 4,
                    Name = "Гранитогрес"
                }
            };

            context.FlooringTypes.AddOrUpdate(ft => ft.Id, flooringTypesToSeed);
        }

        private void SeedOfferStatuses(RealEstateDbContext context)
        {
            OfferStatus[] offerStatusesToSeed = new OfferStatus[]
            {
                new OfferStatus()
                {
                    Id = 1,
                    Name = "Активна"
                },
                new OfferStatus()
                {
                    Id = 2,
                    Name = "Полуактивна"
                },
                new OfferStatus()
                {
                    Id = 3,
                    Name = "Неактивна"
                },
                new OfferStatus()
                {
                    Id = 4,
                    Name = "Нова"
                }
            };

            context.OfferStatuses.AddOrUpdate(os => os.Id, offerStatusesToSeed);
        }

        private void SeedEstateCharacteristics(RealEstateDbContext context)
        {
            EstateCharacteristic[] estateCharacteristicsToSeed = new EstateCharacteristic[]
            {
                new EstateCharacteristic()
                {
                    Id = 1,
                    Name = "Портиер"
                },
                new EstateCharacteristic()
                {
                    Id = 2,
                    Name = "Охрана"
                },
                new EstateCharacteristic()
                {
                    Id = 3,
                    Name = "Затворен комплекс"
                },
                new EstateCharacteristic()
                {
                    Id = 4,
                    Name = "Басейн"
                },
                new EstateCharacteristic()
                {
                    Id = 5,
                    Name = "АКТ16"
                },
                new EstateCharacteristic()
                {
                    Id = 6,
                    Name = "АКТ15"
                },
                new EstateCharacteristic()
                {
                    Id = 7,
                    Name = "Регулация"
                },
                new EstateCharacteristic()
                {
                    Id = 8,
                    Name = "Електрификация"
                },
                new EstateCharacteristic()
                {
                    Id = 9,
                    Name = "ПУП"
                }
            };

            context.EstateCharacteristics.AddOrUpdate(ec => ec.Id, estateCharacteristicsToSeed);
        }

        private void SeedCurrencies(RealEstateDbContext context)
        {
            Currency[] currenciesToSeed = new Currency[]
            {
                new Currency()
                {
                    Id = 1,
                    Name = "Лева"
                },
                new Currency()
                {
                    Id = 2,
                    Name = "Евро"
                }
            };

            context.Currencies.AddOrUpdate(c => c.Id, currenciesToSeed);
        }

        private void SeedRoles(RealEstateDbContext context)
        {
            RealEstateRole[] rolesToSeed = new RealEstateRole[]
            {
                new RealEstateRole()
                {
                    Id = 1,
                    Name = "Superadmin"
                },
                new RealEstateRole()
                {
                    Id = 2,
                    Name = "Admin"
                },
                new RealEstateRole()
                {
                    Id = 3,
                    Name = "Broker"
                }
            };

            context.Roles.AddOrUpdate(rolesToSeed);
        }
    }
}
