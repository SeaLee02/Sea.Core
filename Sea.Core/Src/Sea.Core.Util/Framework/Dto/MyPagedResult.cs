using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Framework.Dto
{
    public class MyPagedResult<TData> where TData : class
    {
        public List<TData> DataList
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageCount => (int)Math.Ceiling(RowCount * 1.0 / PageSize);

        public int PageSize
        {
            get;
            set;
        }

        public int RowCount
        {
            get;
            set;
        }
    }
}
