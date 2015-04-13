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
                    Name = "�������"
                },
                new OfferType()
                {
                    Id = 2,
                    Name = "���� ��� ����"
                },
            };


            context.OfferTypes.AddOrUpdate(ot => ot.Id, offerTypesToSeed);
        }

        private void SeedCities(RealEstateDbContext context)
        {
            City varna = new City()
            {
                Id = 1,
                Name = "�����"
            };

            varna.Regions.Add(new CityRegion()
            {
                Name = "����������"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "��������� ���������"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "������"
            });

            varna.Regions.Add(new CityRegion()
            {
                Name = "���������"
            });

            City sofia = new City()
            {
                Id = 2,
                Name = "�����"
            };

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "������ ����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "��������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "���� �����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "���� �����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "������ ������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "����������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�����"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "����������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "��������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "���������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "�������"
            });

            sofia.Regions.Add(new CityRegion()
            {
                Name = "����������"
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
                    Name = "��������� A���������"
                },
                new EstateType()
                {
                    Id = 2,
                    Name = "�������� ����������"
                },
                new EstateType()
                {
                    Id = 3,
                    Name = "�������� ����������"
                },
                new EstateType()
                {
                    Id = 4,
                    Name = "����������� ����������"
                },
                new EstateType()
                {
                    Id = 5,
                    Name = "���������� ����������"
                },
                new EstateType()
                {
                    Id = 6,
                    Name = "���� �� ����"
                },
                new EstateType()
                {
                    Id = 7,
                    Name = "����"
                },
                new EstateType()
                {
                    Id = 8,
                    Name = "����"
                },
                new EstateType()
                {
                    Id = 9,
                    Name = "�������"
                },
                new EstateType()
                {
                    Id = 10,
                    Name = "���������"
                },
                new EstateType()
                {
                    Id = 11,
                    Name = "�����"
                },
                new EstateType()
                {
                    Id = 12,
                    Name = "�������"
                },
                new EstateType()
                {
                    Id = 13,
                    Name = "�����"
                },
                new EstateType()
                {
                    Id = 14,
                    Name = "������"
                },
                new EstateType()
                {
                    Id = 15,
                    Name = "������"
                },
                new EstateType()
                {
                    Id = 16,
                    Name = "�����"
                },
                new EstateType()
                {
                    Id = 17,
                    Name = "���"
                },
                new EstateType()
                {
                    Id = 18,
                    Name = "���������� �����"
                },
                new EstateType()
                {
                    Id = 19,
                    Name = "��� ������"
                },
                new EstateType()
                {
                    Id = 20,
                    Name = "���������� �������"
                },
                new EstateType()
                {
                    Id = 21,
                    Name = "�������������� �������"
                },
                new EstateType()
                {
                    Id = 22,
                    Name = "��������� ���������"
                },
                new EstateType()
                {
                    Id = 23,
                    Name = "�����������"
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
                    Name = "���������"
                },
                new FurnishingType()
                {
                    Id = 2,
                    Name = "�����������"
                },
                new FurnishingType()
                {
                    Id = 3,
                    Name = "�������������"
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
                    Name = "����"
                },
                new ConstructionStatus()
                {
                    Id = 2,
                    Name = "�����"
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
                    Name = "�����"
                },
                new ConstructionType()
                {
                    Id = 2,
                    Name = "�����"
                },
                new ConstructionType()
                {
                    Id = 3,
                    Name = "���"
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
                    Name = "��������"
                },
                new HeatingInstallation()
                {
                    Id = 2,
                    Name = "���"
                },
                new HeatingInstallation()
                {
                    Id = 3,
                    Name = "�������"
                },
                new HeatingInstallation()
                {
                    Id = 4,
                    Name = "���"
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
                    Name = "����������"
                },
                new JoineryType()
                {
                    Id = 3,
                    Name = "�������"
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
                    Name = "�������"
                },
                new FlooringType()
                {
                    Id = 2,
                    Name = "������"
                },
                new FlooringType()
                {
                    Id = 3,
                    Name = "�������"
                },
                new FlooringType()
                {
                    Id = 4,
                    Name = "�����������"
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
                    Name = "�������"
                },
                new OfferStatus()
                {
                    Id = 2,
                    Name = "�����������"
                },
                new OfferStatus()
                {
                    Id = 3,
                    Name = "���������"
                },
                new OfferStatus()
                {
                    Id = 4,
                    Name = "����"
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
                    Name = "�������"
                },
                new EstateCharacteristic()
                {
                    Id = 2,
                    Name = "������"
                },
                new EstateCharacteristic()
                {
                    Id = 3,
                    Name = "�������� ��������"
                },
                new EstateCharacteristic()
                {
                    Id = 4,
                    Name = "������"
                },
                new EstateCharacteristic()
                {
                    Id = 5,
                    Name = "���16"
                },
                new EstateCharacteristic()
                {
                    Id = 6,
                    Name = "���15"
                },
                new EstateCharacteristic()
                {
                    Id = 7,
                    Name = "���������"
                },
                new EstateCharacteristic()
                {
                    Id = 8,
                    Name = "��������������"
                },
                new EstateCharacteristic()
                {
                    Id = 9,
                    Name = "���"
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
                    Name = "����"
                },
                new Currency()
                {
                    Id = 2,
                    Name = "����"
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
