using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{

    //base class olduğundan abstract yaptık.
    public abstract class RequestParameters
    {
        //50 üzerinde okumayı yasaklıyoruz
        const int maxPageSize = 50;

        public int PageNumber { get; set; }


        //full-prop tanım
        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }

    }
}
