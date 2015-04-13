using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models.Editors
{
    public class FilesPickerModel
    {
        public string Accept { get; set; }

        public bool PreviewImages { get; set; }

        public string SelectLabel { get; set; }

        public DocumentModel[] ExistingImages { get; set; }

        public HttpPostedFileBase[] Files { get; set; }

        public HttpPostedFileBase[] GetApplicableFiles()
        {
            if (this.Files == null)
            {
                return new HttpPostedFileBase[0];
            }

            if (string.IsNullOrEmpty(this.Accept))
            {
                return this.Files.Where(f => !(f == null)).ToArray();
            }

            string[] acceptFilters = this.Accept.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            return this.Files.Where(f => this.IsFileApplicable(f, acceptFilters)).ToArray();
        }

        private bool IsFileApplicable(HttpPostedFileBase f, string[] acceptFilters)
        {
            if (f == null || string.IsNullOrEmpty(f.ContentType))
            {
                return false;
            }

            foreach (string acceptFilter in acceptFilters)
            {
                if (acceptFilter[0] == '.')
                {
                    if (!string.IsNullOrEmpty(f.FileName))
                    {
                        string fileExtension = Path.GetExtension(f.FileName);
                        if (acceptFilter.Equals(fileExtension, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
                else if (acceptFilter.EndsWith("/*"))
                {
                    string contentTypeGroup = acceptFilter.Substring(0, acceptFilter.Length - 1);
                    if (contentTypeGroup.Length == 6 && f.ContentType.StartsWith(contentTypeGroup, StringComparison.InvariantCultureIgnoreCase)) // audio/ | video/ | image/
                    {
                        return true;
                    }
                }
                else if (acceptFilter.Equals(f.ContentType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}