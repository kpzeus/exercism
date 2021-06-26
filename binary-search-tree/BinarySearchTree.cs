using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    int value;
    BinarySearchTree left;
    BinarySearchTree right;

    public BinarySearchTree(int value)
    {
        this.value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        if (values != null)
        {
            values.ToList().ForEach(x =>
            {
                if (this.value == 0)
                    this.value = x;
                else
                    this.Add(x);
            });
        }
    }

    public int Value
    {
        get
        {
            return this.value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return left;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return right;
        }
    }

    public BinarySearchTree Add(int value)
    {
        if (this.value >= value)
        {
            if (this.left != null)
            {
                return this.left.Add(value);
            }
            else
            {
                this.left = new BinarySearchTree(value);
                return left;
            }
        }
        else
        {
            if (this.right != null)
            {
                return this.right.Add(value);
            }
            else
            {
                this.right = new BinarySearchTree(value);
                return right;
            }
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return this.Enumerator().Cast<int>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Enumerator().GetEnumerator();
    }

    private IEnumerable Enumerator()
    {
        var stack = new Stack<BinarySearchTree>();
        var current = this;
        while (stack.Count > 0 || current != null)
        {
            if (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }
            else
            {
                current = stack.Pop();
                yield return current.Value;
                current = current.Right;
            }
        }
    }
}