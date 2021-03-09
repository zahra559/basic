﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basic_project.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string mimeType { get; set; }
        public string Description { get; set; }
        public string UploadedBy { get; set; }
        public double size { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string FilePath { get; set; }
    }
}
