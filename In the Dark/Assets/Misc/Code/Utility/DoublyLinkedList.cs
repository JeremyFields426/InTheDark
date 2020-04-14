public class DoublyLinkedList<T>
{
    private DLLNode<T> head = null;
    private DLLNode<T> tail = null;
    

    public int Count { get; private set; }


    public DoublyLinkedList()
    {

    }

    public DoublyLinkedList(T data)
    {
        AddFirst(data);
    }

    private void AddFirst(T data)
    {
        DLLNode<T> n = new DLLNode<T>(data);

        head = n;
        tail = n;
        Count = 1;
    }

    public void Push(T data)
    {
        if (Count == 0)
        {
            AddFirst(data);
        }
        else
        {
            DLLNode<T> n = new DLLNode<T>(data);

            tail.next = n;
            n.prev = tail;
            tail = n;
            Count++;
        }
    }

    public T Pop()
    {
        T data = default;

        if (Count == 1)
        {
            data = head.Data;

            head = null;
            tail = null;
            Count--;

            return data;
        }
        else if (Count > 1)
        {
            data = tail.Data;

            tail.prev.next = null;
            tail = tail.prev;
            Count--;

            return data;
        }

        return data;
    }

    public bool Remove(T data)
    {
        DLLNode<T> step = head;

        int index = 0;
        while (step != null && !step.Data.Equals(data))
        {
            step = step.next;
            index++;
        }

        if (step == null) { return false; }
        
        if (index == 0)
        {
            step.next.prev = null;
            head = step.next;
        }
        else if (index == Count - 1)
        {
            step.prev.next = null;
            tail = step.prev;
        }
        else
        {
            step.prev.next = step.next;
            step.next.prev = step.prev;
        }

        Count--;
        return true;
    }

    public T Peek()
    {
        return tail.Data;
    }
}
