using System.Collections.Generic;
using Autofac.Extras.Moq;
using BookExchange.API.Controllers;
using BookExchange.API.Data;
using Xunit;

namespace BookExchange.API.Tests
{
    public class testexamples
    {

        [Fact]
        public void AuthorTest()
        {
            UsersbooksController _testCtrl = new UsersbooksController(null);
            List<string> authorsExpected = new List<string> { "William Inge", "Christopher Eric Hitchens", "J.K. Rowling" };
            List<string> tittles = new List<string> { "Summer Brave", "Bóg nie jest wielki", "Harry Potter i Kamień Filozoficzny" };
            List<string> authorsActual = new List<string>();

            for (int i = 0; i < tittles.Count; i++)
            {
                authorsActual.Add(_testCtrl.GetAuthor(tittles[i]));
            }
            Assert.Equal(authorsExpected, authorsActual);
        }

        [Fact]
        public void ThumbnailTest()
        {
            UsersbooksController _testCtrl = new UsersbooksController(null);

            var actual = _testCtrl.GetThumbnail("Bóg nie jest wielki");
            var expected = "http://books.google.com/books/content?id=J9XVCQAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api";
            Assert.Equal(expected, actual);
        }

    }
}