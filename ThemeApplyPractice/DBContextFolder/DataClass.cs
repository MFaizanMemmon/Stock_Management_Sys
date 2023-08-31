using NLog.LayoutRenderers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.DBContextFolder
{
    public class DataClass
    {
        private readonly myDbContext db;
        public IList<Product> products;
        public IList<Purchase> purchases;
        public IList<Issuance> issuances;
        public DataClass(myDbContext db)
        {
            this.db = db;
        }
        public IList<Product> getProduct(string date)
        {
            if (date == null)
            {
                products = db.products.ToList();
            }
            products = db.products.Where(x => x.Status == date).ToList();
            return products;
        }
        public IList<Purchase> GetPurchase(string date)
        {
            if (date == null)
            {
                purchases = db.purchases.ToList();
            }
            purchases = db.purchases.Where(x => x.Vendor == date).ToList();
            return purchases;
        }
        public IList<Issuance> getIssuanceDate(string date)
        {
            if (date == null)
            {
                issuances = db.issuances.ToList();
            }
            issuances = db.issuances.Where(x => x.Employee == date).ToList();
            return issuances;
        }

    }
}
