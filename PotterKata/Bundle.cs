using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Bundle
    {
        private const decimal StandardBookPrice = 8m;

        public List<Book> Books = new List<Book>();

        public decimal Total
        {
            get
            {
                var total = 0m;
                var numDistinctBooks = Books.Select(b => b.Id).Distinct().Count();
                var discount = GetDiscount(numDistinctBooks);
                total += StandardBookPrice * numDistinctBooks * (1 - discount);
                total += (Books.Count - numDistinctBooks) * StandardBookPrice;
                return total;
            }
        }

        public void Add(Book book)
        {
            Books.Add(book);
        }

        public void Remove(Book book)
        {
            Books.Remove(book);
        }

        public decimal GetDiscount(int numDistinctBooks)
        {
            switch (numDistinctBooks)
            {
                case 2: return 0.05m;
                case 3: return 0.10m;
                case 4: return 0.20m;
                case 5: return 0.25m;
                default: return 0m;
            }
        }
    }
}