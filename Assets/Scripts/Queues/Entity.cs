using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private EntityStats stats;

    public EntityStats Stats => stats;

    public float Speed => stats.Speed;
    public int ID => stats.Id;
    public string EntityName => stats.EntityName;

    private void OnEnable()
    {
        GameManagerPerQueue.Register(this);
    }

    private void OnDisable()
    {
        GameManagerPerQueue.Unregister(this);
    }
}