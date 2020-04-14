public class DLLNode<T>
{
    public T Data = default;

    public DLLNode<T> prev = null;

    public DLLNode<T> next = null;


    public DLLNode(T data)
    {
        Data = data;
    }
}
