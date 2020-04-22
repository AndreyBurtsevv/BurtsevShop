using Lesson19_1.DataModels;
using Lesson19_1.Models.Basket;
using Lesson19_1.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Helpers
{
    public static class BrandHelpers
    {
        public static BrandResponse BrandDataToBrandResponse(BrandData from) 
        {
            var to = new BrandResponse { Name = from.Name };
            return to;
        }

        public static IList<BrandResponse> BrandDataListToBrandResponseList(IList<BrandData> from)
        {
            return from.Select(b=> BrandDataToBrandResponse(b)).ToList();
        }

        //public static IList<OrderData> BasketResponseToOrderDataList(IList<BasketResponse> from)
        //{
             
        //    return from.Select(b => BrandDataToBrandResponse(b)).ToList();
        //}
    }
}
