using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionScript : MonoBehaviour
{
    public Player player;
    //public UnityEditor.Animations.AnimatorController[] animList;
    public RuntimeAnimatorController[] animList;
    GameObject PowerBar;
    //public AnimatorController animList2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectWeapon(int index)
    {
        UiManager.Instance.ShowHideWeaponSelectionScreen(false);
        UiManager.Instance.ShowHideMapSelectionScreen(true);

        if (index == 0)
        {
            player.anim.runtimeAnimatorController = animList[0];
            for (int i = 0; i < player.CurrentCharacter.WeaponList2.Count; i++)
            {
                player.CurrentCharacter.WeaponList2[i].gameObject.SetActive(false);
            }
        }
        else
        {
            player.anim.runtimeAnimatorController = animList[1];
            for (int i = 0; i < player.CurrentCharacter.WeaponList2.Count; i++)
            {
                player.CurrentCharacter.WeaponList2[i].transform.gameObject.SetActive(false);
            }
            player.CurrentCharacter.WeaponList2[index].gameObject.SetActive(true);

        }

        GlobalValues.WeaponPower = player.CurrentCharacter.WeaponList2[index].WeaponPower;
        if (!PowerBar)
        {
            PowerBar = FindObjectOfType<PowerBar>().gameObject;
        }
        int value = GlobalValues.MaxPower + GlobalValues.WeaponPower;
        PowerBar.GetComponentInChildren<Text>().text = "" + value;

    }

    public void BackButton()
    {
        UiManager.Instance.ShowHideCharacterSelectionScreen(true);
        UiManager.Instance.ShowHideWeaponSelectionScreen(false);
    }
}
