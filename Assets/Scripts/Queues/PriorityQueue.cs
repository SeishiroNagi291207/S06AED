using System;

public class PriorityQueue<T>
{
    private QueueNode<T> head;
    private int count;
    private Func<T, T, bool> priority;

    public PriorityQueue(Func<T, T, bool> priority)
    {
        this.priority = priority;
    }

    public void SetPriority(Func<T, T, bool> newPriority)
    {
        priority = newPriority;
    }

    public void Enqueue(T value)
    {
        QueueNode<T> newNode = new(value);
        count++;

        // Lista vacía
        if (head == null)
        {
            head = newNode;
            return;
        }

        // Si tiene mayor prioridad que el primero
        if (priority(value, head.Value))
        {
            newNode.SetNext(head);
            head = newNode;
            return;
        }

        // Buscar posición correcta
        QueueNode<T> current = head;

        while (current.Next != null && !priority(value, current.Next.Value))
        {
            current = current.Next;
        }

        newNode.SetNext(current.Next);
        current.SetNext(newNode);
    }

    public T Dequeue()
    {
        if (head == null)
            throw new Exception("Queue vacía");

        T value = head.Value;
        head = head.Next;
        count--;
        return value;
    }

    public T Peek()
    {
        if (head == null)
            throw new Exception("Queue vacía");

        return head.Value;
    }

    public void Clear()
    {
        head = null;
        count = 0;
    }

    public int Count => count;

    public QueueNode<T> Head => head; // útil para UI
}