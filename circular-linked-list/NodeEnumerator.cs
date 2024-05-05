using System.Collections;

public class NodeEnumerator<T> : IEnumerator<T>
{
    private Node<T> _head;
    private Node<T> _current;

    public NodeEnumerator(Node<T>? head, Node<T>? tail)
    {
        _head = head;
    }

    public T Current
    {
        get
        {
            return _current.Data;
        }
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public bool MoveNext()
    {
        if (_head == null)
        {
            return false;
        }

        if (_current == null)
        {
            _current = _head;
            return true;
        }
        else
        {
            _current = _current.Next;
            return true;
        }
    }

    public void Reset()
    {
        _current = _head;
    }

    public void Dispose()
    {
    }
}
