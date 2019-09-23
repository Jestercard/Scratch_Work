using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Challenge_379
{
    class Tests
    {
        private readonly Mock _taxesMock;

        public static Tests()
        {
            var _sut = new Mock<Tests>();

            _sut.Setup(x => x._taxesMock).Returns(It.IsAny<_taxesMock.Object>());
        }

        [Fact]
        public async Task TaxOwed_MoreThanBracketOne()
        {
            // Arrange


            // Act


            // Assert


        }

    }
}
