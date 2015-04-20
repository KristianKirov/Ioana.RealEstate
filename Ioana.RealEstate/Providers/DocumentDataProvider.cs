using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Data.Model;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace Ioana.RealEstate.Providers
{
    public class DocumentDataProvider
    {
        private readonly IFileStorage fileStorage;

        public DocumentDataProvider(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public async Task Save(IEnumerable<InsertDocumentModel> documents)
        {
            List<Document> insertedDocuments = new List<Document>();
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                foreach (InsertDocumentModel document in documents)
                {
                    document.Url = await this.fileStorage.Store(document.FileStream, document.Url);

                    Document documentToInsert = new Document()
                    {
                        Url = document.Url,
                        ContentType = document.ContentType,
                    };
                    insertedDocuments.Add(documentToInsert);

                    dbContext.Documents.Add(documentToInsert);
                }

                await dbContext.SaveChangesAsync();
            }

            int i = 0;
            foreach (InsertDocumentModel document in documents)
            {
                document.Id = insertedDocuments[i].Id;

                ++i;
            }
        }

        public async Task<DocumentModel> GetDefaultImage(int offerId)
        {
            DocumentModel defaultImageModel = null;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                Document defaultImage = await dbContext.Documents.Where(d => d.EstateOffers.Any(o => o.Id == offerId)).OrderBy(d => d.Id).FirstOrDefaultAsync();
                if (defaultImage != null)
                {
                    defaultImageModel = new DocumentModel()
                    {
                        Id = defaultImage.Id,
                        ContentType = defaultImage.ContentType,
                        Url = defaultImage.Url
                    };
                }
            }

            return defaultImageModel;
        }
    }
}