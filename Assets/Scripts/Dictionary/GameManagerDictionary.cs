using UnityEngine;
using UnityEngine.InputSystem;

public class GameManagerDictionary : MonoBehaviour
{
    public InputSystem_Actions inputs;

    public DataBaseEntity dataBase;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Update()
    {
        if (inputs.Player.Loot1.triggered)
        {
            GetRandomItem(Rarity.Common);
        }

        if (inputs.Player.Loot2.triggered)
        {
            GetRandomItem(Rarity.Rare);
        }

        if (inputs.Player.Loot3.triggered)
        {
            GetRandomItem(Rarity.Epic);
        }

        if (inputs.Player.Loot4.triggered)
        {
            GetRandomItem(Rarity.Legendary);
        }
    }

    public void GetRandomItem(Rarity quality)
    {
        BaseEntityData item = dataBase.GetRandomEntity(quality);

        if (item != null)
        {
            Debug.Log("Item obtenido: " + item.EntityName);
        }
    }
}