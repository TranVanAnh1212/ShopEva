﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public Guid ID { set; get; }
        public string Message { set; get; }
        public string StackTrace { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
