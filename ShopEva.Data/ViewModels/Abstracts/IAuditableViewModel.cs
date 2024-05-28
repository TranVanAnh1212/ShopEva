using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels.Abstracts
{
    public interface IAuditableViewModel
    {
        DateTime? CreatedDate { get; set; }
        Guid? CreatedBy { get; set; }
        [NotMapped()]
        string? Creator { get; set; }
        DateTime? ModifiedDate { get; set; }
        [NotMapped()]
        string? Modifior { get; set; }
        Guid? ModifiedBy { get; set; }
        string? MetaKeyWord { get; set; }
        string? MetaDescription { get; set; }
        int Status { get; set; }
    }
}
