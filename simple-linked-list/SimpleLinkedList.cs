using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    T value = default(T);
    SimpleLinkedList<T> next = null;

    public SimpleLinkedList(T value)
    {
        this.value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        var curr = this;

        if (values != null)
        {
            values.ToList().ForEach(x =>
            {
                if (this.value.Equals(default(T)))
                {
                    this.value = x;
                }
                else
                {
                    curr.next = new SimpleLinkedList<T>(x);
                    curr = curr.Next;
                }
            });
        }
    }

    public T Value
    {
        get
        {
            return this.value;
        }
    }

    public SimpleLinkedList<T> Next
    {
        get
        {
            return this.next;
        }
    }

    public SimpleLinkedList<T> Add(T value)
    {
        this.next = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SimpleLinkedList<T> head = this;
        while (head != null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        SimpleLinkedList<T> head = this;
        while (head != null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }
}