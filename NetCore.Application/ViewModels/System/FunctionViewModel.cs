using NetCore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }

       
        public string URL { set; get; }

     
        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public Status Status { set; get; }
        public int SorOrder { get; set; }
    }
}
