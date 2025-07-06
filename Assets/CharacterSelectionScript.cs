using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter(int index)
    {
      
        UiManager.Instance.ShowHideCharacterSelectionScreen(false);
        UiManager.Instance.ShowHideWeaponSelectionScreen(true);
        player.HairsParent = player.HairsParentList[index];
        player.FaceParent = player.FaceParentList[index];

        for (int i = 0; i < player.CharactersList.Count; i++)
        {
            player.CharactersList[i].gameObject.SetActive(false);
        }
        player.CharactersList[index].gameObject.SetActive(true);
        player.CurrentCharacter = player.CharactersList[index].GetComponent<WeaponListScript>();

        player.anim.avatar = player.CharactersAvatarList[index]; //Changing Animator Avatar
        Manager.Instance.enemy.GetComponent<AIController>().SetTransform(index); //Temp Off //?

    }
}
