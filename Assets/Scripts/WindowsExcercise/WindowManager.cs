using System;
using UnityEngine;

public class WindowManager : MyStack<Window>
{
    public Action<Window> OnElementAdded;
    public Action<Window> OnElementRemoved;

    public override void Push(Window value)
    {
        base.Push(value);
        OnElementAdded?.Invoke(Peek());
    }

    public override Window Pop()
    {
        if (Count == 0) return null;

        Window topWindow = Peek();

        if (topWindow != null && topWindow.window.activeSelf)
        {
            OnElementRemoved?.Invoke(topWindow);
            return base.Pop();
        }
        else
        {
            base.Pop();
            return Pop();
        }
    }

    public bool Contains(GameObject panel)
    {
        StackNode<Window> current = Top;

        while (current != null)
        {
            if (current.Value.window == panel)
                return true;

            current = current.Next;
        }

        return false;
    }
}
