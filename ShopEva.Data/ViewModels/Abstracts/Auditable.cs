using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels.Abstracts
{
    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        [NotMapped()]
        public string? Creator { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [NotMapped()]
        public string? Modifior { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string? MetaKeyWord { get; set; }
        public string? MetaDescription { get; set; }
        public int Status { get; set; }
    }
}
