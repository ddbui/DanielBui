using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDemo.DataStructures
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public void Add(Node node)
        {
            node.Next = Head;
            Head = node;
        }
    }

    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node(object data)
        {
            Data = data;
        }
    }
}
