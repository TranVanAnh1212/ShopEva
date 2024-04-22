using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        Guid? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        Guid? ModifiedBy { get; set; }
        string? MetaKeyWord { get; set; }
        string? MetaDescription { get; set; }
        int Status { get; set; }
    }
}
