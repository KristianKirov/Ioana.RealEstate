using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public string ContentType { get; set; }

        public string Url { get; set; }
    }

    public class InsertDocumentModel : DocumentModel
    {
        public Stream FileStream { get; set; }
    }
}