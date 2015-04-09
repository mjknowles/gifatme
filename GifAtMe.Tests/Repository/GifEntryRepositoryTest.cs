using GifAtMe.Domain.Entities.GifEntry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Data.Entity;
using GifAtMe.Common.UnitOfWork;
using GifAtMe.Repository;
using GifAtMe.Repository.Repositories;
using System;

namespace GifAtMe.Tests.Repository
{
    [TestClass]
    public class GifEntryRepositoryTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IDbContextFactory> _mockDbContextFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockDbContextFactory = new Mock<IDbContextFactory>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockUnitOfWork.VerifyAll();
            _mockDbContextFactory.VerifyAll();
        }

        [TestMethod]
        public void GenericRepo_FindByUserNameKeywordAndIndex_ObjectExistsInRepo()
        {

            // Setup
            var data = new List<GifEntry> 
            { 
                new GifEntry { Id = 1, Keyword = "Test1", UserName = "TestUser" }, 
                new GifEntry { Id = 2, Keyword = "Test2", UserName = "TestUser" }, 
                new GifEntry { Id = 3, Keyword = "Test3", UserName = "TestUser" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<GifEntry>>();
            mockSet.As<IQueryable<GifEntry>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<GifEntry>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<GifEntry>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<GifEntry>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(m => m.AsNoTracking()).Returns(mockSet.Object);
            //mockSet.As<IQueryable<GifEntry>>().Setup(m => m.AsNoTracking().Returns<int>((x) => data.ElementAtOrDefault(x));
            //mockSet.As<IQueryable<GifEntry>>().Setup(m => m.AsNoTracking()).Returns(mockSet.Object);

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<GifEntry>()).Returns(mockSet.Object);

            _mockDbContextFactory.Setup(x => x.Create()).Returns(mockContext.Object);

            var expectedModel = new GifEntry { Id = 1, Keyword = "Test1", UserName = "TestUser" };
            var sut = new GifEntryRepository(_mockUnitOfWork.Object, _mockDbContextFactory.Object);

            //Act
            var actualModel = sut.GetGifEntryForUserNameAndKeywordAndAlternateIndex("TestUser", "Test1", 0);

            //Assert
            Assert.AreEqual(expectedModel.Id, actualModel.Id);
        }
    }
}