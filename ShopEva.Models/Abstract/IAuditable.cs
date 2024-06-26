﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        string? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string? ModifiedBy { get; set; }
        string? MetaKeyWord { get; set; }
        string? MetaDescription { get; set; }
        int Status { get; set; }
    }
}
