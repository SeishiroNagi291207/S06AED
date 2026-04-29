using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private EntityStats stats;

    public EntityStats Stats => stats;
    
    public float Speed => stats.Speed;
    public int ID => stats.Id;
    public string Name => stats.name;
}
