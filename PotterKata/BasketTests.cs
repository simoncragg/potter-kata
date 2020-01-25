using NUnit.Framework;

namespace PotterKata
{
    [TestFixture]
    public class BasketTests
    {
        private const decimal StdPrice = 8; 

        [Test]
        public void AddZeroBooks()
        {
            var basket = new Basket();
            Assert.AreEqual(0m, basket.Total);
        }

        [Test]
        public void AddOneBook()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            Assert.AreEqual(StdPrice, basket.Total);
        }

        [Test]
        public void Add2DifferentBooks()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            Assert.AreEqual(2 * StdPrice * (1 - 0.05m), basket.Total);
        }

        [Test]
        public void Add2DifferentBooksAndAnotherSameBook()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(1));

            Assert.AreEqual(2 * StdPrice * (1 - 0.05m) + 8m, basket.Total);
        }

        [Test]
        public void Add3DifferentBooks()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));

            const decimal expectedTotal = 3 * StdPrice * (1 - 0.10m);
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add3DifferentBooksAndAnotherSameBook()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(1));

            const decimal expectedTotal = 3 * StdPrice * (1 - 0.10m) + 8m;
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add4DifferentBooks()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(4));

            const decimal expectedTotal = 4 * StdPrice * (1 - 0.20m);
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add4DifferentBooksAndAnotherSameBook()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(4));
            basket.Add(new Book(1));

            const decimal expectedTotal = 4 * StdPrice * (1 - 0.20m) + 8m;
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add5DifferentBooks()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(4));
            basket.Add(new Book(5));

            const decimal expectedTotal = 5 * StdPrice * (1 - 0.25m);
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add5DifferentBooksAndAnotherSameBook()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(4));
            basket.Add(new Book(5));
            basket.Add(new Book(1));

            const decimal expectedTotal = 5 * StdPrice * (1 - 0.25m) + 8m;
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void Add2DifferentBooksTwice()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(1));
            basket.Add(new Book(2));

            const decimal expectedTotal = 2 * StdPrice * (1 - 0.05m) * 2;
            Assert.AreEqual(expectedTotal, basket.Total);
        }

        [Test]
        public void ComplexTest1()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(3));
            basket.Add(new Book(4));
            basket.Add(new Book(5));

            const decimal bucket1Total = 4 * StdPrice * (1 - 0.20m);
            const decimal bucket2Total = 4 * StdPrice * (1 - 0.20m);
            const decimal expectedTotal = bucket1Total + bucket2Total;

            Assert.AreEqual(expectedTotal, basket.Total);
            Assert.AreEqual(2, basket.Bundles.Count);
        }

        [Test]
        public void ComplexTest2()
        {
            var basket = new Basket();
            basket.Add(new Book(1));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(2));
            basket.Add(new Book(3));
            basket.Add(new Book(3));
            basket.Add(new Book(1));

            const decimal bucket1Total = 3 * 8m * (1 - 0.10m);
            const decimal bucket2Total = 3 * 8m * (1 - 0.10m);
            const decimal bucket3Total = 8m;
            const decimal expectedTotal = bucket1Total + bucket2Total + bucket3Total;
            
            Assert.AreEqual(expectedTotal, basket.Total);
            Assert.AreEqual(3, basket.Bundles.Count);
        }
    }
}
