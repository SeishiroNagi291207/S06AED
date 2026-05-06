using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerPerQueue : MonoBehaviour
{
    public static List<Entity> entities = new();

    private PriorityQueue<Entity> priorityQueue;
    public TMP_Text criterioText;

    public enum PriorityType
    {
        Speed,
        ID
    }

    public PriorityType currentPriority = PriorityType.Speed;

    [Header("UI")]
    public Transform turnListParent;
    public GameObject turnItemPrefab;

    void Start()
    {
        priorityQueue = new PriorityQueue<Entity>(CompareBySpeed);

        BuildQueue();
        UpdateUI();
    }

    // Registro automático
    public static void Register(Entity e)
    {
        if (!entities.Contains(e))
            entities.Add(e);
    }

    public static void Unregister(Entity e)
    {
        entities.Remove(e);
    }

    // Construir cola
    public void BuildQueue()
    {
        priorityQueue.Clear();

        foreach (var entity in entities)
        {
            priorityQueue.Enqueue(entity);
        }
    }

    // Prioridades
    bool CompareBySpeed(Entity a, Entity b)
    {
        return a.Speed > b.Speed;
    }

    bool CompareByID(Entity a, Entity b)
    {
        return a.ID < b.ID;
    }

    // Cambiar prioridad
    public void ChangePriority()
    {
        if (currentPriority == PriorityType.Speed)
        {
            currentPriority = PriorityType.ID;
            priorityQueue.SetPriority(CompareByID);
        }
        else
        {
            currentPriority = PriorityType.Speed;
            priorityQueue.SetPriority(CompareBySpeed);
        }

        BuildQueue();
        UpdateUI();
    }

    // Siguiente turno
    public void NextTurn()
    {
        if (priorityQueue.Count == 0)
            return;

        Entity current = priorityQueue.Dequeue();

        Debug.Log("Ataca: " + current.EntityName);

        UpdateUI();
    }

    // UI con prefab
    public void UpdateUI()
    {

        if (turnListParent == null || turnItemPrefab == null)
        {
            Debug.LogError("Falta asignar TurnList o TurnItemPrefab en el GameManager");
            return;
        }

        foreach (Transform child in turnListParent)
        {
            Destroy(child.gameObject);
        }

        QueueNode<Entity> current = priorityQueue.Head;
        int pos = 1;

        while (current != null)
        {
            GameObject item = Instantiate(turnItemPrefab, turnListParent);

            Transform posT = item.transform.Find("PositionText");
            Transform nameT = item.transform.Find("NameText");

            if (posT == null || nameT == null)
            {
                Debug.LogError("No encuentra PositionText o NameText en el prefab");
                return;
            }

            TMP_Text posText = posT.GetComponent<TMP_Text>();
            TMP_Text nameText = nameT.GetComponent<TMP_Text>();

            if (posText == null || nameText == null)
            {
                Debug.LogError("Falta componente Text en los hijos");
                return;
            }

            posText.text = pos.ToString();
            nameText.text = current.Value.EntityName;
            current = current.Next;
            pos++;
        }
        criterioText.text = "Criterio: " + currentPriority;
    }
}