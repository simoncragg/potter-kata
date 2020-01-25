using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        public List<Bundle> Bundles = new List<Bundle>();

        public decimal Total => Bundles.Sum(bucket => bucket.Total);

        public void Add(Book book)
        {
            var bundle = ResolveBestBundleForBook(book);

            if (bundle != null)
            {
                bundle.Add(book);
            }
            else
            {
                bundle = new Bundle { Books = new List<Book> { book } };
                Bundles.Add(bundle);
            }
        }

        private Bundle ResolveBestBundleForBook(Book book)
        {
            var candidates = Bundles
                .Where(bb => bb.Books.All(b => b.Id != book.Id))
                .ToList();

            if (candidates.Any() == false) return null;

            var cheapestTotal = decimal.MaxValue;
            Bundle bestBundle = null;

            foreach (var bundle in candidates)
            {
                bundle.Add(book);
                if (Total < cheapestTotal)
                {
                    cheapestTotal = Total;
                    bestBundle = bundle;
                }
                bundle.Remove(book);
            }

            return bestBundle;
        }
    }
}