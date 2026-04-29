public class MyStack<T>
{
    #region Privates
    private StackNode<T> top;
    private int count;
    #endregion

    #region Public Methods

    public virtual void Push(T value)
    {
        StackNode<T> newNode = new StackNode<T>(value);

        if (top == null)
        {
            top = newNode;
        }
        else
        {
            newNode.SetNext(top);
            top = newNode;
        }

        count++;
    }

    public virtual T Pop()
    {
        if (top == null)
            return default;

        T tempValue = top.Value;

        top = top.Next;
        count--;

        return tempValue;
    }

    public virtual T Peek()
    {
        if (top == null)
            return default;

        return top.Value;
    }

    public virtual void Clear()
    {
        top = null;
        count = 0;
    }

    #endregion

    #region Getters
    public StackNode<T> Top => top;
    public int Count => count;
    #endregion
}