using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBaseEntity", menuName = "Scriptable Objects/DataBaseEntity")]
public class DataBaseEntity : SerializedScriptableObject
{

    private BaseEntityData lastItem;
    [FoldoutGroup("References")]
    [PreviewField(150)]
    public GameObject entityPrefab;

    [FoldoutGroup("Loot Database")]
    public Dictionary<Rarity, List<BaseEntityData>> dataBaseEntitys = new();

    public BaseEntityData GetRandomEntity(Rarity rarity)
    {
        if (dataBaseEntitys.TryGetValue(rarity, out List<BaseEntityData> entities))
        {
            if (entities.Count == 0)
            {
                return null;
            }

            BaseEntityData randomItem;

            do
            {
                randomItem = entities[Random.Range(0, entities.Count)];
            }
            while (entities.Count > 1 && randomItem == lastItem);

            lastItem = randomItem;

            return randomItem;
        }

        Debug.LogError("No existen items para esta rareza");
        return null;
    }

    public GameObject InstantiateEntity(Rarity rarity, Vector3 position)
    {
        GameObject obj = Instantiate(entityPrefab);

        BaseEntityData randomEntity = GetRandomEntity(rarity);

        obj.transform.position = position;

        return obj;
    }
}