using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels
{
    public class ProductProductCategoryViewModel
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }

    }
}
