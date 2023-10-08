using ShopRu.EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Infrastructure
{
    public interface IBillService
    {
        Task<decimal> CalculateTotalAmount(Bill bill);
    }
}
