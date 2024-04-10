using Moq;
using Microsoft.EntityFrameworkCore;
using UniversalColorTranslator.API.Interface;
using UniversalColorTranslator.API.Model;
using UniversalColorTranslator.API.Repository;

namespace UniversalColorTranslator.Tests
{
    public class UniversalColorTranslatorRepositoryTest
    {
        
        public Mock<IUniversalColorTranslatorDbContext> MockDb = new Mock<IUniversalColorTranslatorDbContext>() { CallBase = true };

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        [Fact]
        public void TestGetColors()
        {
            //Arrange
            DbSet<Colors> mockColors = GetQueryableMockDbSet(TestData.GetColors());
            MockDb.Setup(c => c.Colors).Returns(mockColors);
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository(MockDb.Object);
            
            //Act
            var result = repo.GetColors();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestGetColor()
        {
            //Arrange
            DbSet<Colors> mockColors = GetQueryableMockDbSet(TestData.GetColors());
            MockDb.Setup(c => c.Colors).Returns(mockColors);
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository(MockDb.Object);

            //Act
            var result = repo.GetColor("red");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestGetColorHex()
        {
            //Arrange
            DbSet<Colors> mockColors = GetQueryableMockDbSet(TestData.GetColors());
            MockDb.Setup(c => c.Colors).Returns(mockColors);
            UniversalColorTranslatorRepository repo = new UniversalColorTranslatorRepository(MockDb.Object);

            //Act
            var result = repo.GetColorHex("red");

            //Assert
            Assert.NotNull(result);
        }
    }
}