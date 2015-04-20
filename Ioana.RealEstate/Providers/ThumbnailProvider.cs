using ImageResizer;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace Ioana.RealEstate.Providers
{
    public class ThumbnailProvider
    {
        private readonly IFileStorage thumbnailStorage;
        private readonly IFileStorage imagesStorage;
        private readonly DocumentDataProvider documentDataProvider;

        public ThumbnailProvider()
        {
            this.imagesStorage = new FileSystemStorage(HostingEnvironment.MapPath("\\docs"));
            this.thumbnailStorage = new FileSystemStorage(HostingEnvironment.MapPath("\\tmbs"));
            this.documentDataProvider = new DocumentDataProvider(this.thumbnailStorage);
        }

        public async Task GenerateDefaultThumbnail(int offerId)
        {
            DocumentModel defaultImage = await this.documentDataProvider.GetDefaultImage(offerId);
            if (defaultImage == null)
            {
                using (Stream defaultThumbnailStream = this.thumbnailStorage.GetReadStream("no-image.png"))
                {
                    using (Stream thumbnailStream = this.thumbnailStorage.CreateWriteStream(string.Concat(offerId, ".png")))
                    {
                        await defaultThumbnailStream.CopyToAsync(thumbnailStream);
                    }
                }
            }
            else
            {
                using (Stream imageStream = this.imagesStorage.GetReadStream(defaultImage.Url))
                {
                    using (Stream thumbnailStream = this.thumbnailStorage.CreateWriteStream(string.Concat(offerId, ".png")))
                    {
                        ResizeSettings resizeSettings = new ResizeSettings();
                        resizeSettings.Format = "png";
                        resizeSettings.Width = 150;
                        resizeSettings.Height = 100;
                        resizeSettings.Scale = ScaleMode.Both;
                        resizeSettings.Mode = FitMode.Crop;
                        resizeSettings.Quality = 50;
                        resizeSettings.Anchor = System.Drawing.ContentAlignment.MiddleCenter;

                        ImageBuilder.Current.Build(imageStream, thumbnailStream, resizeSettings);
                    }
                }
            }
        }
    }
}