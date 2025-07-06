using UnityEngine;
using UnityEngine.UI;

public class WeaponButtonSetup : MonoBehaviour
{
    public int weaponIndex;
    public GameObject lockIcon;
    public Text priceText;

    void Start()
    {
        if (weaponIndex == 0)
        {
            lockIcon.SetActive(false);
            priceText.gameObject.SetActive(false);
            return;
        }

        string id = $"weapon_{weaponIndex}";
        bool unlocked = PlayerPrefs.GetInt($"{id}_unlocked", 0) == 1;

        if (unlocked)
        {
            lockIcon.SetActive(false);
            priceText.gameObject.SetActive(false);
        }
    }
}
