﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GifAtMe.Tests.Repository
{
    [TestClass]
    public class GifEntryRepositoryTest
    {
        /*[TestMethod]
        public void TestRepoIsEmpty()
        {
            // Arrange
            GifEntryRepository repo = new GifEntryRepository(new TestEfUnitOfWork<GifEntry>());

            // Act
            List<GifEntry> entries = (List<GifEntry>)repo.GetAll();

            // Assert
            Assert.IsNotNull(entries);
            Assert.AreEqual(0, entries.Count);
        }

        [TestMethod]
        public void TestAddOneGifEntryWithoutCommit()
        {
            // Arrange
            TestEfUnitOfWork<GifEntry> uow = new TestEfUnitOfWork<GifEntry>();
            GifEntryRepository repo = new GifEntryRepository(uow);

            // Act
            repo.Insert(new GifEntry() { Id = 1 });

            // Assert
            Assert.AreEqual(1, uow.AddedEntities.Count);
        }

        [TestMethod]
        public void TestAddOneGifEntryWithCommit()
        {
            // Arrange
            TestEfUnitOfWork<GifEntry> uow = new TestEfUnitOfWork<GifEntry>();
            GifEntryRepository repo = new GifEntryRepository(uow);

            // Act
            repo.Insert(new GifEntry() { Id = 1 });
            uow.Commit();
            List<GifEntry> entries = (List<GifEntry>)repo.GetAll();

            // Assert
            Assert.AreEqual(0, uow.AddedEntities.Count);
        }*/
    }
}