//Tests dont work due to incorrect .NET version from the project skeleton.. I think.
//Test comment for push

using NUnit.Framework;
using Assignment3;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private SLL list;

        [SetUp]
        public void Setup()
        {
            // This method runs before each test
            list = new SLL();
        }

        [Test]
        public void LinkedList_IsEmpty_ShouldReturnTrue()
        {
            // Assert
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void LinkedList_PrependItem_ShouldAddToBeginning()
        {
            // Arrange
            var user = new User(1, "John Doe", "john@example.com", "password123");

            // Act
            list.AddFirst(user);

            // Assert
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void LinkedList_AppendItem_ShouldAddToEnd()
        {
            // Arrange
            var user = new User(1, "John Doe", "john@example.com", "password123");

            // Act
            list.AddLast(user);

            // Assert
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void LinkedList_InsertAtIndex_ShouldAddAtCorrectPosition()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");
            var user3 = new User(3, "Sam Smith", "sam@example.com", "password789");

            list.AddLast(user1);
            list.AddLast(user3);

            // Act
            list.Add(user2, 1);

            // Assert
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void LinkedList_ReplaceItem_ShouldUpdateValueAtIndex()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");

            list.AddLast(user1);

            // Act
            list.Replace(user2, 0);

            // Assert
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void LinkedList_DeleteFromBeginning_ShouldRemoveFirstItem()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");

            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            list.RemoveFirst();

            // Assert
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void LinkedList_DeleteFromEnd_ShouldRemoveLastItem()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");

            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            list.RemoveLast();

            // Assert
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void LinkedList_DeleteFromMiddle_ShouldRemoveItemAtIndex()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");
            var user3 = new User(3, "Sam Smith", "sam@example.com", "password789");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            // Act
            list.Remove(1);

            // Assert
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void LinkedList_FindAndRetrieve_ShouldReturnCorrectItem()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");

            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            var index = list.IndexOf(user2);
            var retrievedUser = list.GetValue(index);

            // Assert
            Assert.AreEqual(1, index);
            Assert.AreEqual(user2, retrievedUser);
        }

        [Test]
        public void LinkedList_Reverse_ShouldReverseTheList()
        {
            // Arrange
            var user1 = new User(1, "John Doe", "john@example.com", "password123");
            var user2 = new User(2, "Jane Doe", "jane@example.com", "password456");
            var user3 = new User(3, "Sam Smith", "sam@example.com", "password789");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            // Act
            list.Reverse();

            // Assert
            Assert.AreEqual(user3, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user1, list.GetValue(2));
        }
    }
}