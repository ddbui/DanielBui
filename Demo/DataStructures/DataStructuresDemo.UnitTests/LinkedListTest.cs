using DataStructuresDemo.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresDemo.UnitTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void AddOneNodeToList()
        {
            var list = new LinkedList();

            string data = "one";
            Node node = new Node(data);
            list.Add(node);

            Assert.AreEqual(data, list.Head.Data.ToString(), "Failed");
        }

        [TestMethod]
        public void AddManyNodesToList()
        {
            var list = new LinkedList();

            list.Add(new Node("one"));
            list.Add(new Node("two"));
            list.Add(new Node("three"));
            list.Add(new Node("four"));

            Assert.AreEqual("four", list.Head.Data.ToString(), "Failed");

            list.Head = list.Head.Next;
            Assert.AreEqual("three", list.Head.Data.ToString(), "Failed");

            list.Head = list.Head.Next;
            Assert.AreEqual("two", list.Head.Data.ToString(), "Failed");

            list.Head = list.Head.Next;
            Assert.AreEqual("one", list.Head.Data.ToString(), "Failed");
        }
    }
}
