using UnityEngine;

public class Node<T>
{
    public T value;
    public Node<T> next;

    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
}
public class Queue<T>
{
    private Node<T> front;
    private Node<T> back;
    public Queue()
    {
        front = null;
        back = null;
    }
    public void Enqueue(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (back == null)
        {
            front = newNode;
            back = newNode;
        }
        else
        {
            back.next = newNode;
            back = newNode;
        }
    }
    public T Dequeue()
    {
        if (front == null)
        {
            throw new System.Exception("어머...큐가 비어버렸네??");
        }
        T value = front.value;
        front = front.next;
        if (front == null)
        {
            back = null;
        }
        return value;
    }
    public int Count()
    {
        int count = 0;
        Node<T> current = front;
        while (current != null)
        {
            count++;
            current = current.next;
        }
        return count;
    }
}
