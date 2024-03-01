using System.Collections;

public class MyCircularLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    public int Count { get; private set; }
    public bool IsEmpty
    {
        get
        {
            return Count == 0;
        }
    }

    public MyCircularLinkedList()
    {
        _head = _tail = null;
        Count = 0;
    }
    public MyCircularLinkedList(T head)
    {
        var node = new Node<T>(head);
        _head = node;
        _tail = node;
        node.Next = _head;

        Count = 1;
    }
    public MyCircularLinkedList(T[] items)
    {
        foreach ( var item in items )
        {
            Add( item );
        }
        Count = items.Length;
    }
    
    public void Add(T data)
    {
        var node = new Node<T>(data);
        if (Count == 0)
        {
            _head = node;
            _tail = node;
            node.Next = node;
        }
        else
        {
            node.Next = _head!;
            _tail!.Next = node;
            _tail = node;
        }
        Count++;
    }
    
    public bool Remove(T data)
    {
        Node<T>? current = _head;
        Node<T>? previous = null;

        if (IsEmpty)
        {
            return false;
        }

        do
        {
            if (current!.Data!.Equals(data))
            {
                // Только один узел
                if (Count == 1)
                {
                    _head = _tail = null;
                }
                // Искомый узел - первый
                else if (current == _head)
                {
                    _tail!.Next = current.Next;
                    _head = current.Next!;
                }
                // Искомый узел - последний
                else if (current == _tail)
                {
                    _tail = previous!;
                    previous!.Next = _head;
                }
                // Искомый узел - в середине
                else
                {
                    previous!.Next = current.Next;
                }
                Count--;

                return true;
            }

            previous = current;
            current = current.Next!;
        }
        while (current != _head);

        return false;
    }
    
    public void Clear()
    {
        _head = _tail = null;
        Count = 0;
    }
    
    public bool Contains(T data)
    {
        Node<T>? current = _head;

        if (IsEmpty)
        {
            return false;
        }

        do
        {
            if (current!.Next!.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next!;
        }
        while (current != _head);
        
        return false;
    }
    
    public Node<T> Find(T data)
    {
        Node<T>? current = _head;

        if (IsEmpty)
        {
            return null;
        }

        do
        {
            if (current!.Next!.Data!.Equals(data))
            {
                return current;
            }
            current = current.Next!;
        }
        while (current != _head);

        return null;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new NodeEnumerator<T>(_head, _tail);
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}