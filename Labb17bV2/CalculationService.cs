using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb17bV2.Services
{
    class CalculationService
    {

        internal static CustomerType getCustomerType(decimal ordervalue)
        {
            if (ordervalue < 1000)
            {
                return CustomerType.Regular;
            }
            else if (ordervalue < 5000)
            {
                return CustomerType.Good;
            }
            else
            {
                return CustomerType.Excellent;
            }
        }

        internal static decimal getDiscount(CustomerType customerType, decimal ordersum)
        {
            switch (customerType)
            {
                case CustomerType.Regular:
                    return getRegularDiscount(ordersum);
                case CustomerType.Good:
                    return getGoodDiscount(ordersum);
                case CustomerType.Excellent:
                    return getExcellentDiscount(ordersum);
                default:
                    return 0;
            }
        }

        private static decimal getExcellentDiscount(decimal ordersum)
        {
            if (ordersum > 500)
            {
                return 0.08m * ordersum;
            }
            else
            {
                return 0.05m * ordersum;
            }
        }

        private static decimal getGoodDiscount(decimal ordersum)
        {
            if (ordersum > 500)
            {
                return 0.05m * ordersum;
            }
            else
            {
                return 0.02m * ordersum;
            }
        }

        private static decimal getRegularDiscount(decimal ordersum)
        {
            if (ordersum <= 100)
            {
                return 0;
            }
            else
            {
                return 0.02m * ordersum;
            }
        }
    }
}
