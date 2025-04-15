using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class SLL : ILinkedListADT
    {
        private Node head;
        private Node tail;
        private int count;

        public SLL()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return count == 0; //If the count matches 0, therefore the list is empty.
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value); //Create a new node with the value passed in
            if (IsEmpty()) //If the list is empty
            {
                head = newNode; //Set the head to the new node
                tail = newNode; //Set the tail to the new node
            }
            else
            {
                tail.Next = newNode; //Set the next of the tail to the new node
                tail = newNode; //Set the tail to the new node
            }
            count++; //Increment the count
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value); //Create a new node with the value passed in
            if (IsEmpty()) //If the list is empty
            {
                head = newNode; //Set the head to the new node
                tail = newNode; //Set the tail to the new node
            }
            else
            {
                newNode.Next = head; //Set the next of the new node to the head
                head = newNode; //Set the head to the new node
            }
            count++; //Increment the count
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count) //If the index is out of bounds
                throw new IndexOutOfRangeException("Index out of bounds");
            if (index == 0) //If the index is 0
            {
                AddFirst(value); //Add to the front
            }
            else if (index == count) //If the index is equal to the count
            {
                AddLast(value); //Add to the end
            }
            else
            {
                Node newNode = new Node(value); //Create a new node with the value passed in
                Node current = head; //Set current to the head
                for (int i = 0; i < index - 1; i++) //Loop through the list until we reach the index - 1
                {
                    current = current.Next; //Set current to the next node
                }
                newNode.Next = current.Next; //Set the next of the new node to the next of current
                current.Next = newNode; //Set the next of current to the new node
                count++; //Increment the count
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count) //If the index is out of bounds
                throw new IndexOutOfRangeException("Index out of bounds");
            Node current = head; //Set current to the head
            for (int i = 0; i < index; i++) //Loop through the list until we reach the index
            {
                current = current.Next; //Set current to the next node
            }
            current.Data = value; //Set the value of current to the value passed in
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException("The list is empty.");

            head = head.Next;
            if (head == null)
                tail = null;

            count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
                throw new InvalidOperationException("The list is empty.");

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            count--;
        }

        public void Remove(int index) // Remove at index method
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            if (current.Next == null)
                tail = current;

            count--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1; //If the index of the value is not -1, then it exists in the list
        }

        public void Reverse()
        {
            // If the list is empty or has only one element, no need to reverse
            if (head == null || head.Next == null)
                return;

            Node prev = null; // This will eventually become the new tail
            Node current = head; // Start with the head of the list
            Node next = null; // This will temporarily store the next node
            tail = head; // The current head will become the new tail

            while (current != null)
            {
                next = current.Next; // Store the next node
                current.Next = prev; // Reverse the current node's pointer
                prev = current; // Move prev to the current node
                current = next; // Move to the next node in the original list
            }

            head = prev; // The last processed node becomes the new head
        }

    }
}