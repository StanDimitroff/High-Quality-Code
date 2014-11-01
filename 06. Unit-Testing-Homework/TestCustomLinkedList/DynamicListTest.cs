namespace TestCustomLinkedList
{
    using System;
    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        public void GettingListCountShouldReturnCorrectValue()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');

            Assert.AreEqual(1, dynamicList.Count, "Getter doesn't return correct list count.");
        }

        [TestMethod]
        public void AddingItemShouldIncrementListCountByOne()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');

            Assert.AreEqual(2, dynamicList.Count, "Add method doesn't increment list count by one.");
        }

        [TestMethod]
        public void AddingItemShouldReturnCorrectAddedItem()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            var added = dynamicList[0];

            Assert.AreEqual('a', added, "Add method doesn't add the correct item.");
        }

        [TestMethod]
        public void RemovingValidItemShouldDecrementListCountByOne()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Remove('a');

            Assert.AreEqual(
                0,
                dynamicList.Count,
                "Remove method doesn't decrement list count by one.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingInvalidItemShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Remove('b');
        }

        [TestMethod]
        public void RemovingItemAtValidPositionShouldDecrementListCountByOne()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.RemoveAt(0);

            Assert.AreEqual(0, dynamicList.Count, "RemoveAt method doesn't decrement list count.");
        }

        [TestMethod]
        public void RemovingItemAtValidPositionShouldReturnCorrectRemovedItem()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            var removed = dynamicList[0];
            dynamicList.RemoveAt(0);

            Assert.IsTrue(removed == 'a', "RemoveAt method doesn't remove the correct item.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingItemAtNegativePositionShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void RemovingItemAtInvalidPositionShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.RemoveAt(1);
        }

        [TestMethod]
        public void GettingItemByValidIndexShouldReturnCorrectItem()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');

            Assert.IsTrue(
                dynamicList[0] == 'a',
                "Getting item by index method doesn't return the correct item.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GettingItemByNegativeIndexShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            var position = dynamicList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GettingItemByInvalidIndexShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            var position = dynamicList[3];
        }

        [TestMethod]
        public void SettingItemByValidIndexShouldReturnCorrectItem()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            dynamicList[2] = 'd';

            Assert.IsTrue(
                dynamicList[2] == 'd',
                "Setting item by index method doesn't return correct item.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingItemByNegativeIndexShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            dynamicList[-1] = 'd';
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingItemByInvalidIndexShouldThrowException()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            dynamicList[3] = 'd';
        }

        [TestMethod]
        public void CkeckingIndexOfValidItemShouldReturnCorrectIndex()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            int index = dynamicList.IndexOf('b');

            Assert.AreEqual(1, index, "IndexOf method doesn't return correct index.");
        }

        [TestMethod]
        public void CkeckingIndexOfInvalidItemShouldReturnMinusOne()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            int index = dynamicList.IndexOf('z');

            Assert.AreEqual(-1, index, "IndexOf method doesn't -1.");
        }

        [TestMethod]
        public void CheckingIfExcistingItemContainsShouldReturnTrue()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            bool isContains = dynamicList.Contains('a');

            Assert.AreEqual(true, isContains, "Contains method doesn't return true.");
        }

        [TestMethod]
        public void CheckingIfNonExcistingItemContainsShouldReturnFalse()
        {
            var dynamicList = new DynamicList<char>();
            dynamicList.Add('a');
            dynamicList.Add('b');
            dynamicList.Add('c');

            bool isContains = dynamicList.Contains('z');

            Assert.AreEqual(false, isContains, "Contains method doesn't return false.");
        }
    }
}