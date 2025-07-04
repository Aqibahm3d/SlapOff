using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public MapSelectionScript MapSelectionScreen;
    public CharacterSelectionScript CharacterSelectionScreen;
    public WeaponSelectionScript WeaponSelectionScreen;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ShowHideMapSelectionScreen(false);
        ShowHideCharacterSelectionScreen(true);
        ShowHideWeaponSelectionScreen(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideMapSelectionScreen(bool toggle)
    {
        MapSelectionScreen.gameObject.SetActive(toggle);
    }

    public void ShowHideCharacterSelectionScreen(bool toggle)
    {
        CharacterSelectionScreen.gameObject.SetActive(toggle);
    }

    public void ShowHideWeaponSelectionScreen(bool toggle)
    {
        WeaponSelectionScreen.gameObject.SetActive(toggle);
    }
}
