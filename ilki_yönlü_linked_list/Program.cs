using System;
using System.Collections.Generic;
public class DoublyNode
{
    public int Data;
    public DoublyNode Previous;
    public DoublyNode Next;

    public DoublyNode(int data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}
public class DoublyLinkedList
{
    private DoublyNode head;
    private DoublyNode tail;
    private int count;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public int Count => count;
    public bool IsEmpty => count == 0;

    // 1. Add to Head
    public void AddToHead(int data)
    {
        DoublyNode newNode = new DoublyNode(data);

        if (IsEmpty)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        count++;
        Console.WriteLine($"Added {data} to head.");
    }

    // 2. Add to Tail
    public void AddToTail(int data)
    {
        DoublyNode newNode = new DoublyNode(data);

        if (IsEmpty)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        count++;
        Console.WriteLine($"Added {data} to tail.");
    }

    // 3. Insert After a Specific Value
    public void InsertAfter(int existingData, int newData)
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty. Cannot insert after.");
            return;
        }

        DoublyNode current = head;
        while (current != null && current.Data != existingData)
        {
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine($"Value {existingData} not found in the list.");
            return;
        }

        DoublyNode newNode = new DoublyNode(newData);

        newNode.Next = current.Next;
        newNode.Previous = current;

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        else
        {
            tail = newNode; // If inserting after tail
        }

        current.Next = newNode;
        count++;
        Console.WriteLine($"Inserted {newData} after {existingData}.");
    }

    // 4. Insert Before a Specific Value
    public void InsertBefore(int existingData, int newData)
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty. Cannot insert before.");
            return;
        }

        DoublyNode current = head;
        while (current != null && current.Data != existingData)
        {
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine($"Value {existingData} not found in the list.");
            return;
        }

        DoublyNode newNode = new DoublyNode(newData);

        newNode.Previous = current.Previous;
        newNode.Next = current;

        if (current.Previous != null)
        {
            current.Previous.Next = newNode;
        }
        else
        {
            head = newNode; // If inserting before head
        }

        current.Previous = newNode;
        count++;
        Console.WriteLine($"Inserted {newData} before {existingData}.");
    }

    // 5. Delete from Head
    public void DeleteFromHead()
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty. Cannot delete from head.");
            return;
        }

        int deletedData = head.Data;

        if (head == tail) // Only one element
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Previous = null;
        }

        count--;
        Console.WriteLine($"Deleted {deletedData} from head.");
    }

    // 6. Delete from Tail
    public void DeleteFromTail()
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty. Cannot delete from tail.");
            return;
        }

        int deletedData = tail.Data;

        if (head == tail) // Only one element
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Previous;
            tail.Next = null;
        }

        count--;
        Console.WriteLine($"Deleted {deletedData} from tail.");
    }

    // 7. Delete by Value (Search and Delete)
    public void DeleteByValue(int data)
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty. Cannot delete.");
            return;
        }

        DoublyNode current = head;
        while (current != null && current.Data != data)
        {
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine($"Value {data} not found in the list.");
            return;
        }

        if (current == head)
        {
            DeleteFromHead();
        }
        else if (current == tail)
        {
            DeleteFromTail();
        }
        else
        {
            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            count--;
            Console.WriteLine($"Deleted {data} from the list.");
        }
    }

    // 8. Search
    public bool Search(int data)
    {
        DoublyNode current = head;
        int position = 0;

        while (current != null)
        {
            if (current.Data == data)
            {
                Console.WriteLine($"Value {data} found at position {position}.");
                return true;
            }
            current = current.Next;
            position++;
        }

        Console.WriteLine($"Value {data} not found in the list.");
        return false;
    }

    // 9. Display List
    public void Display()
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Console.Write("List (Forward): ");
        DoublyNode current = head;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null) Console.Write(" <-> ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // 10. Display List in Reverse
    public void DisplayReverse()
    {
        if (IsEmpty)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Console.Write("List (Reverse): ");
        DoublyNode current = tail;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Previous != null) Console.Write(" <-> ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    // 11. Clear All
    public void ClearAll()
    {
        head = null;
        tail = null;
        count = 0;
        Console.WriteLine("All elements have been cleared from the list.");
    }

    // 12. Convert Linked List to Array
    public int[] ToArray()
    {
        int[] array = new int[count];
        DoublyNode current = head;
        int index = 0;

        while (current != null)
        {
            array[index++] = current.Data;
            current = current.Next;
        }

        Console.WriteLine($"Linked list converted to array with {count} elements.");
        return array;
    }

    // Additional utility method to display array
    public void DisplayArray(int[] array)
    {
        Console.Write("Array: [");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i < array.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}


class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        bool exit = false;

        Console.WriteLine("=== DOUBLY LINKED LIST OPERATIONS ===");

        while (!exit)
        {
            DisplayMenu();
            Console.Write("Enter your choice (1-12): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter data to add to head: ");
                    if (int.TryParse(Console.ReadLine(), out int headData))
                        list.AddToHead(headData);
                    break;

                case "2":
                    Console.Write("Enter data to add to tail: ");
                    if (int.TryParse(Console.ReadLine(), out int tailData))
                        list.AddToTail(tailData);
                    break;

                case "3":
                    Console.Write("Enter existing data: ");
                    if (int.TryParse(Console.ReadLine(), out int existingAfter))
                    {
                        Console.Write("Enter new data to insert after: ");
                        if (int.TryParse(Console.ReadLine(), out int newAfter))
                            list.InsertAfter(existingAfter, newAfter);
                    }
                    break;

                case "4":
                    Console.Write("Enter existing data: ");
                    if (int.TryParse(Console.ReadLine(), out int existingBefore))
                    {
                        Console.Write("Enter new data to insert before: ");
                        if (int.TryParse(Console.ReadLine(), out int newBefore))
                            list.InsertBefore(existingBefore, newBefore);
                    }
                    break;

                case "5":
                    list.DeleteFromHead();
                    break;

                case "6":
                    list.DeleteFromTail();
                    break;

                case "7":
                    Console.Write("Enter data to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteData))
                        list.DeleteByValue(deleteData);
                    break;

                case "8":
                    Console.Write("Enter data to search: ");
                    if (int.TryParse(Console.ReadLine(), out int searchData))
                        list.Search(searchData);
                    break;

                case "9":
                    list.Display();
                    list.DisplayReverse();
                    break;

                case "10":
                    list.ClearAll();
                    break;

                case "11":
                    int[] array = list.ToArray();
                    list.DisplayArray(array);
                    break;

                case "12":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("1. Add to Head");
        Console.WriteLine("2. Add to Tail");
        Console.WriteLine("3. Insert After");
        Console.WriteLine("4. Insert Before");
        Console.WriteLine("5. Delete from Head");
        Console.WriteLine("6. Delete from Tail");
        Console.WriteLine("7. Delete by Value");
        Console.WriteLine("8. Search");
        Console.WriteLine("9. Display List");
        Console.WriteLine("10. Clear All");
        Console.WriteLine("11. Convert to Array");
        Console.WriteLine("12. Exit");
    }
}