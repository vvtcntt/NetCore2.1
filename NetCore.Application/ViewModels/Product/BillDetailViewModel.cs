﻿ using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.Product
{
    public class BillDetailViewModel
    {
        public int Id { set; get; }
        public int BillId { set; get; }

        public int ProductId { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public virtual BillViewModel Bill { set; get; }

        public virtual ProductViewModel Product { set; get; }

        public virtual ColorViewModel Color { set; get; }

        public virtual SizeViewModel Size { set; get; }
    }
}
