using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class GameManagerPerQueue : MonoBehaviour
{
    public MyQueue<string> BankQueue = new();

    public float speed = 0;
    public float MaxSpeed = 100;


    public PriorityQueue<EntityStats> priorityQueue =
        new((a, b) => a.Speed < b.Speed);
    void Start()
    {

    }
    [Button]
    public void Enqueue(string name)
    {
        BankQueue.Enqueue(name);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido : " + BankQueue.Dequeue());
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera ... " + BankQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        BankQueue.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log(BankQueue.Count);
    }



}