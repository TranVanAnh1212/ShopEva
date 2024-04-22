
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string? MetaKeyWord { get; set; }
        [MaxLength(256)]
        public string? MetaDescription { get; set; }
        public int Status { get; set; }
    }
}
