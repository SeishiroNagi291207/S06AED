using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManagerPerQueue : MonoBehaviour
{
    public MyQueue<string> BankQueue = new();

    public float speed = 0;
    public float MaxSpeed = 100;


    public PriorityQueue<EntityStats> priorityQueue =
        new((a, b) => a.Speed > b.Speed);

    public List<Entity> entitys = new ();
    void Start()
    {

    }
    [Button]
    public void Enqueue(EntityStats Entity)
    {
        priorityQueue.Enqueue(Entity);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido : " + priorityQueue.Dequeue());
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera ... " + priorityQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        priorityQueue.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log(priorityQueue.Count);
    }



}