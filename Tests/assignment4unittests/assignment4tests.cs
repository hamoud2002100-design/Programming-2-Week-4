using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Assignment4;

namespace Assignment4.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private CultureInfo originalCulture;

        [SetUp]
        public void SetUp()
        {
            // Save the original culture and set the culture to invariant for consistent formatting
            originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void TearDown()
        {
            // Restore the original culture after each test
            CultureInfo.CurrentCulture = originalCulture;
        }

        [Test]
        public void ProductConstructor_ShouldInitializeProperties()
        {
            // Arrange
            string expectedName = "Notebook";
            double expectedPrice = 5.99;
            Category expectedCategory = Category.Stationary;

            // Act
            Product product = new Product(expectedName, expectedPrice, expectedCategory);

            // Assert
            Assert.That(product.Name, Is.EqualTo(expectedName));
            Assert.That(product.Price, Is.EqualTo(expectedPrice));
            Assert.That(product.Category, Is.EqualTo(expectedCategory));
        }

        [Test]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            string name = "Frying Pan";
            double price = 25.50;
            Category category = Category.Kitchenware;
            Product product = new Product(name, price, category);
            string expectedString = "Product: Frying Pan, Price: 25.50, Category: Kitchenware";

            // Act
            string result = product.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }
    }

    [TestFixture]
    public class ProgramTests
    {
        private CultureInfo originalCulture;

        [SetUp]
        public void SetUp()
        {
            // Save the original culture and set the culture to invariant for consistent formatting
            originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TearDown]
        public void TearDown()
        {
            // Restore the original culture after each test
            CultureInfo.CurrentCulture = originalCulture;
        }

        [Test]
        public void FilterByCategory_ShouldReturnCorrectProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Pen", 0.99, Category.Stationary),
                new Product("Pencil", 0.59, Category.Stationary),
                new Product("Coffee mug", 1.49, Category.Kitchenware)
            };
            var program = new Program();
            var expectedProducts = new List<Product>
            {
                new Product("Pen", 0.99, Category.Stationary),
                new Product("Pencil", 0.59, Category.Stationary)
            };

            // Act
            var result = program.FilterByCategory(products, Category.Stationary);

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedProducts.Count));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].Name, Is.EqualTo(expectedProducts[i].Name));
                Assert.That(result[i].Price, Is.EqualTo(expectedProducts[i].Price));
                Assert.That(result[i].Category, Is.EqualTo(expectedProducts[i].Category));
            }
        }

        [Test]
        public void PrintProducts_ShouldPrintAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Pen", 0.99, Category.Stationary),
                new Product("Pencil", 0.59, Category.Stationary),
                new Product("Coffee mug", 1.49, Category.Kitchenware)
            };
            var program = new Program();
            var expectedOutput = "1. Product: Pen, Price: 0.99, Category: Stationary\n" +
                                 "2. Product: Pencil, Price: 0.59, Category: Stationary\n" +
                                 "3. Product: Coffee mug, Price: 1.49, Category: Kitchenware\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.PrintProducts(products);

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }

        [Test]
        public void SortByPrice_ShouldSortProductsByPriceDescending()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("Pen", 0.99, Category.Stationary),
                new Product("Pencil", 0.59, Category.Stationary),
                new Product("Coffee mug", 1.49, Category.Kitchenware)
            };
            var program = new Program();
            var expectedProducts = new List<Product>
            {
                new Product("Coffee mug", 1.49, Category.Kitchenware),
                new Product("Pen", 0.99, Category.Stationary),
                new Product("Pencil", 0.59, Category.Stationary)
            };

            // Act
            program.SortByPrice(products);

            // Assert
            Assert.That(products.Count, Is.EqualTo(expectedProducts.Count));
            for (int i = 0; i < products.Count; i++)
            {
                Assert.That(products[i].Name, Is.EqualTo(expectedProducts[i].Name));
                Assert.That(products[i].Price, Is.EqualTo(expectedProducts[i].Price));
                Assert.That(products[i].Category, Is.EqualTo(expectedProducts[i].Category));
            }
        }
    }
}

