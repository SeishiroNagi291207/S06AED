using UnityEngine;
using TMPro;

public class UIInventory : MonoBehaviour
{
    public InvetoryData data;

    public TMP_Text hpText;
    public TMP_Text strText;
    public TMP_Text lifeText;

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (data == null) return;

        hpText.text = "HP: " + data.hp;
        strText.text = "STR: " + data.str;
        lifeText.text = "LIFE: " + data.life;
    }

    public void AddHP()
    {
        data.hp += 10;
        UpdateUI();
    }

    public void AddSTR()
    {
        data.str += 5;
        UpdateUI();
    }

    public void AddLife()
    {
        data.life += 1;
        UpdateUI();
    }
}