/*
 * Student Names: Motsamai Teboho
 * Student Number: 2016206381
 * */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace libQueues
{
    public class DynamicQueue<T> where T : Ticket
    {
        [Serializable]
        private class Node
        {
            public int priority { get; private set; }
            public T element { get; private set; }
            public Node Next { get; set; } //Recursive definition
                                           //Constructor
            public Node(T element, int priority)
            {
                this.priority = priority;
                this.element = element;
                Next = null;
            }
        } //embedded class Node

        private Node head, tail;
        private string Category;
        private int maxTicketNumber;
        public int Count { get; private set; } //Count

        public DynamicQueue(string Category)
        {
            this.Category = Category;
            maxTicketNumber = 0;
            this.head = null;
            this.tail = null;
            this.Count = 0;
        } //Constructor
        public T this[int i]
        {
            get
            {
                Node current = head;
                for (int index = 0; index < i; index++)
                    current = current.Next;
                return current.element;
            }
        }
        public int MaxTicketNumber
        {
            get
            {
                return this.maxTicketNumber;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.element;
                current = current.Next;
            }

        }
        public void Enqueue(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            if (this.head == null) //Empty queue - this is the first element to be added
                this.head = newNode;
            else
            {
                //Step through existing nodes and find position of new node.
                
                Node prev = null, current = head;
                while (current != null && current.priority <= newNode.priority)
                {
                    prev = current;
                    //update  MaxTicketNumber
                    if (current.element.TicketNumber > maxTicketNumber)
                        maxTicketNumber = current.element.TicketNumber;
                    current = current.Next;
                }
                //Insert new node between prev and current
                if (prev != null)
                    prev.Next = newNode;
                else //New node goes to the front
                    head = newNode;
                newNode.Next = current;
            } //else
            Count++;
           
        } //Enqueue

        public void Save()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = Path.Combine(path, Category + "Queue.bin");

            FileStream fs = new FileStream(fileName, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, head);
            fs.Close();
        }
        public void Read()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = Path.Combine(path, Category + "Queue.bin");

            FileStream fs = new FileStream(fileName, FileMode.Open);
            IFormatter formatter = new BinaryFormatter();
            if (fs.Length > 0)
            {
                head = (Node)formatter.Deserialize(fs);
                Node current = head;
                Count = 0;
                while (current != null)
                {
                    if (current.element.TicketNumber > maxTicketNumber)
                        maxTicketNumber = current.element.TicketNumber;
                    Count++;
                    current = current.Next;
                }
            }
            fs.Close();
        }
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        } //Clear

        public T Dequeue()
        {
            if (head != null)
            {
                T item = head.element;
                head = head.Next;
                Count--;
                return item;
            }
            return default(T);
        } //Dequeue
        public T Peek()
        {
            if (head != null)
                return head.element;
            else
                return default(T);
        } //Peek

        public bool Contains(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return true;
                else
                    current = current.Next;
            }
            return false;
        } //Contains
        public int Position(T item)
        {
            Node current = head;
            int i = 0;
            while (current != null)
            {
                if (object.Equals(current.element, item))
                    return i;
                else
                {
                    current = current.Next;
                    i++;
                }
            }
            return -1;

        } //Position

    } //class DynamicQueue

}
