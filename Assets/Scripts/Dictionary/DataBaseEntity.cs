using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "DataBaseEntity", menuName = "Scriptable Objects/DataBaseEntity")]
public class DataBaseEntity : SerializedScriptableObject
{
    [FoldoutGroup("References"), PreviewField(150)]
    public GameObject entityPrefab;

    public Dictionary <Rarity, List<BaseEntityData>> dataBaseEntitys = new();

    public BaseEntityData GetRandomEntity (Rarity rarity)
    {
        if(dataBaseEntitys.TryGetValue(rarity, out List<BaseEntityData> entities))
        {
            return entities[ Random.Range(0, entities.Count)];
        }
        else 
        {
            throw new System.Exception("La rareza definida no existe!!!");
        }
    }

    public GameObject InstantiateEntity(Rarity rarity, Vector3 position)
    {
        GameObject obj = Instantiate(entityPrefab);
      //obj.GetComponent<BaseEntity>().Set(GetRandomEntity(rarity));
        obj.transform.position = position;
        return obj;
    }
}
