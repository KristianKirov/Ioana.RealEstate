using Ioana.RealEstate.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Data.Model;
using Ioana.RealEstate.DataManipulation;

namespace Ioana.RealEstate.Providers
{
    public class ClientDataProvider
    {
        public async Task<string[]> GetClientPhones(int clientId)
        {
            string[] clientPhones;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                clientPhones = await dbContext.ClientPhones.Where(p => p.ClientId == clientId).Select(p => p.Phone).ToArrayAsync();
            }

            return clientPhones;
        }

        public async Task<int?> GetClientIdFromPhone(string phone)
        {
            int? clientId = null;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                clientId = await dbContext.ClientPhones.Where(cp => cp.Phone == phone).Select(cp => (int?)cp.ClientId).FirstOrDefaultAsync();
            }

            return clientId;
        }

        public async Task<ClientModel> GetClientFromPhone(string phone)
        {
            ClientModel client = null;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                Client clientData = await dbContext.Clients.Include(c => c.Phones).Where(c => c.Phones.Any(p => p.Phone == phone)).FirstOrDefaultAsync();
                if (clientData != null)
                {
                    client = new ClientModel()
                    {
                        Id = clientData.Id,
                        Names = clientData.Names,
                        Email = clientData.Email,
                        Phones = clientData.Phones.Select(p => p.Phone).ToArray()
                    };
                }
            }

            return client;
        }

        public async Task InsertOfferingClient(ClientModel clientData)
        {
            PhoneNormalizer normalizer = new PhoneNormalizer();

            Client client = new Client()
            {
                Email = clientData.Email,
                Names = clientData.Names,
                DateCreated = DateTime.UtcNow,
                IsOffering = true
            };

            client.Phones = new List<ClientPhone>();
            foreach (string phone in clientData.Phones)
            {
                if (string.IsNullOrEmpty(phone))
                {
                    continue;
                }

                client.Phones.Add(new ClientPhone()
                {
                    Phone = normalizer.Normalize(phone)
                });
            }

            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                dbContext.Clients.Add(client);

                await dbContext.SaveChangesAsync();
            }

            clientData.Id = client.Id;
        }

        public async Task UpdateOfferingClient(ClientModel clientData)
        {
            PhoneNormalizer normalizer = new PhoneNormalizer();
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                Client client = await dbContext.Clients.Include(c => c.Phones).FirstAsync(c => c.Id == clientData.Id);
                if (!client.Email.Equals(clientData.Email, StringComparison.InvariantCultureIgnoreCase))
                {
                    client.Email = clientData.Email;
                }

                if (!client.Names.Equals(clientData.Names, StringComparison.InvariantCultureIgnoreCase))
                {
                    client.Names = clientData.Names;
                }

                if (!client.IsOffering)
                {
                    client.IsOffering = true;
                }

                foreach (string phone in clientData.Phones)
                {
                    if (string.IsNullOrEmpty(phone))
                    {
                        continue;
                    }

                    string normalizedPhone = normalizer.Normalize(phone);
                    if (!client.Phones.Any(p => p.Phone.Equals(normalizedPhone, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        client.Phones.Add(new ClientPhone()
                        {
                            Phone = normalizedPhone
                        });
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}