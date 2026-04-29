using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    #region Class06
    /*public MyStack<string> nameStack = new();

     void Start()
    {
        
    }

    [Button]
    public void PushToStack(string value)
    {
        nameStack.Push(value);
    }
    [Button]
    public void PopFromStack()
    {
       Debug.Log(nameStack.Pop());
    }
    [Button]
    public void PeekFromStack()
    {
        Debug.Log(nameStack.Peek());
    }
    [Button]
    public void ClearStack()
    {
       nameStack.Clear();   
    }
    [Button]
    public void Count() => Debug.Log(nameStack.Count);
    */
    #endregion
    public MyQueue<string> BankQueue = new();

    public float speed = 0;

    public float Maxspeed = 100;

    private void Start()
    {
    }
    private void Update()
    {
        //speed = Mathf.Lerp (speed, Maxspeed, Time.deltaTime);
        speed = Mathf.PingPong(Time.time * 1.5f, 5);

        transform.position = new Vector3(speed, 0, 0);


    }
    [Button]
    public void TestMathf()
    {
        Debug.Log(Mathf.Clamp(1000, 0, 1));
        Debug.Log(Mathf.Abs(-20));
        Debug.Log(Mathf.Max(20, 20));
        Debug.Log(Mathf.Round(5.5f));
        Debug.Log(Mathf.Floor(5.9999f)); //-> 5
        Debug.Log(Mathf.Ceil(5.0001f));  //-> 6
        Debug.Log(Mathf.Sqrt(25)); //->
        Debug.Log(Mathf.Pow(2, 3)); //->2*2*2=8


    }

    [Button]
    public void Enqueue(string name)
    {
        BankQueue.Enqueue(name);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido: " + BankQueue.Dequeue());
    }

    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido será: " + BankQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        BankQueue.Clear();
    }
}