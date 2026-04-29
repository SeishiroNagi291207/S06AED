using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    [SerializeField] private float speed;//->mayor velocidad
    [SerializeField] private float id;//->menor id
    [SerializeField] private string entityName;

    public float Speed => speed;
    public float Id => id;
    public string EntityName => entityName;
}