using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Utilities.Dtos
{
   public class PagedResult<T>: PageResultBase where T:class
    {

        public PagedResult()
        {
            Results = new List<T>();
        }
        public IList<T> Results { get; set; }

    }
}
