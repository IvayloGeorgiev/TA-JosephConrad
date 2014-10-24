namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileUploadData
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string FileType { get; set; }

        public DateTime? UploadDate { get; set; }
    }
}
