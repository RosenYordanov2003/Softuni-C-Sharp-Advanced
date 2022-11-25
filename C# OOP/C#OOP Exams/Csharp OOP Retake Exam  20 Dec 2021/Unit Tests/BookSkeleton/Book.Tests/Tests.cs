namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Beliq Zub", "Jack London");
        }

        [Test]
        public void TesConstructor()
        {
            string expectedBookName = "Beliq Zub";
            string expectedAuthor = "Jack London";
            Assert.AreEqual(expectedBookName, book.BookName);
            Assert.AreEqual(expectedAuthor, book.Author);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_WithInvalid_BookName(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(bookName, "Vesko");
            });
        }
        [TestCase("Kniga za Junglata")]
        [TestCase("Pod igoto")]
        [TestCase("Mary Poppins")]
        public void Test_WithValid_BookName(string bookName)
        {
            book = new Book(bookName, "Author");
            Assert.AreEqual(bookName, book.BookName);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_WithInvalid_Author(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("Beliq Zub", author);
            });
        }
        [TestCase("Gosho")]
        [TestCase("Elin Pelin")]
        [TestCase("Lefterov")]
        [TestCase("Mitko")]
        [TestCase("Hristo Botev")]
        [TestCase("Ivan Vazov")]
        public void Test_WithValid_Author(string author)
        {
            book = new Book("Book", author);
            Assert.AreEqual(author, book.Author);
        }
        [Test]
        public void Test_AddFootnote_Method_ShouldWork()
        {
            book.AddFootnote(2, "Imalo edno vreme");
            int expectedCount = 1;
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void Test_AddFootnote_Method_Should_NotWork()
        {
            book.AddFootnote(2, "Imalo edno vreme");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(2, "Imalo edno vreme");
            });
        }

        [Test]
        public void Test_FindFootnote_Method_ShouldWork()
        {
            book.AddFootnote(2, "Imalo edno vreme");
            string expectedResult = string.Format($"Footnote #{2}: {"Imalo edno vreme"}");
            Assert.AreEqual(expectedResult, book.FindFootnote(2));
        }
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(0)]
        [TestCase(99)]
        public void Test_FindFootnote_Method_ShouldNotWork(int footNoteNumber)
        {
            book.AddFootnote(2, "Imalo edno vreme");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(footNoteNumber);
            });
        }

        [Test]
        public void Test_AlterFootnote_Method_ShouldNotWork()
        {
            book.AddFootnote(2, "Imalo edno vreme");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(100, "Hello world");
            });
        }
        [Test]
        public void Test_AlterFootnote_Method_ShouldWork()
        {
            book.AddFootnote(2, "Imalo edno vreme");
            book.AlterFootnote(2, "Hello world");
            string expectedResult = string.Format($"Footnote #{2}: {"Hello world"}");
            Assert.AreEqual(expectedResult, book.FindFootnote(2));
        }
    }
}