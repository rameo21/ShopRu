using ShopRu.EntityLayer.Entity;
using ShopRu.EntityLayer.Enums;
using ShopRu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.BusinessLayer
{
    public class BillService : IBillService
    {
        public async Task<decimal> CalculateTotalAmount(Bill bill)
        {
            decimal totalAmount = bill.Products.Where(w => !w.IsGrocery).Sum(s => s.Price);
            decimal totalAmountGroceries = bill.Products.Where(w => w.IsGrocery).Sum(s => s.Price);

            // Apply discounts
            if (bill.User.UserType == EntityLayer.Enums.UserType.Employee)
            {
                totalAmount -= (totalAmount * 0.30m); // 30% discount for employees
            }
            else if (bill.User.UserType == EntityLayer.Enums.UserType.Affiliate)
            {
                totalAmount -= (totalAmount * 0.10m); // 10% discount for affiliates
            }
            else if (bill.User.UserType == EntityLayer.Enums.UserType.Customer && IsCustomerEligibleForDiscount(bill.User))
            {
                totalAmount -= (totalAmount * 0.05m); // 5% discount for loyal customers
            }
            totalAmount += totalAmountGroceries;
            // Apply $5 discount for every $100 on the bill
            int discountAmount = (int)(totalAmount / 100) * 5;
            totalAmount -= discountAmount;

            return Math.Max(totalAmount, 0); // Ensure the final amount is non-negative
        }
        private bool IsCustomerEligibleForDiscount(User user)
        {
            // Check if the user has been a customer for over 2 years
            return (DateTime.Now - user.InsertDate).TotalDays >= 730; // Assuming 2 years is 730 days
        }

    }
}
