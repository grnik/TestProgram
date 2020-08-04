using NUnit.Framework;
using DataLayer;
using System;

namespace NUnitTestDataLayer
{
    public class VisitTypeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Order(0)]
        [TestCase("Test1")]
        [TestCase("1")]
        [TestCase("Very long name")]
        public void GetById(string name)
        {
            VisitType visitType = new VisitType();
            visitType.Name = name;
            visitType.Add();

            Assert.That(visitType.Id, Is.Not.EqualTo(Guid.Empty));

            VisitType readVisitType = VisitType.GetById(visitType.Id);
            Compare(visitType, readVisitType);

            visitType.Delete();
        }

        [Order(1)]
        [TestCase("Test1")]
        [TestCase("1")]
        [TestCase("Very long name")]
        public void Create(string name)
        {
            int count = VisitType.GetAll().Count;

            VisitType visitType = new VisitType();
            visitType.Name = name;
            visitType.Add();

            Assert.That(visitType.Id, Is.Not.EqualTo(Guid.Empty));

            VisitType readVisitType = VisitType.GetById(visitType.Id);
            Compare(visitType, readVisitType);

            int count2 = VisitType.GetAll().Count;
            Assert.That(count, Is.EqualTo(count2 - 1));

            visitType.Delete();
        }

        [Test]
        public void GetAll()
        {
            int count = VisitType.GetAll().Count;

            VisitType[] creatingItem = new VisitType[5];
            int iCreate = 5;
            for (int i = 0; i < iCreate; i++)
            {
                creatingItem[i] = new VisitType();
                creatingItem[i].Name = i.ToString();
                creatingItem[i].Add();
            }

            var allItem = VisitType.GetAll();
            int count2 = allItem.Count;
            Assert.That(count, Is.EqualTo(count2 - iCreate));

            foreach (VisitType visitType in creatingItem)
            {
                var find = allItem.Find(v => v.Id == visitType.Id);
                Compare(visitType, find);
                find.Delete();
            }

            allItem = VisitType.GetAll();
            count2 = allItem.Count;
            Assert.That(count, Is.EqualTo(count2));

            foreach (VisitType visitType in creatingItem)
            {
                var find = allItem.Contains(visitType);
                Assert.IsFalse(find);
            }
        }

        private void Compare(VisitType visitType1, VisitType visitType2)
        {
            Assert.That(visitType1.Id, Is.EqualTo(visitType2.Id));
            Assert.That(visitType1.Name, Is.EqualTo(visitType2.Name));
        }
    }
}