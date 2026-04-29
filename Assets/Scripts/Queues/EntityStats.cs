using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    [SerializeField] private float speed;//->mayor velocidad
    [SerializeField] private int id;//->menor id
    [SerializeField] private string entityName;//nombre

    public float Speed => speed;
    public int Id => id;
    public string EntityName => entityName;
}