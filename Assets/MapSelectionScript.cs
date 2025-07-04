using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSelectionScript : MonoBehaviour
{
    [SerializeField] GameObject[] Maps;
    // Start is called before the first frame update
    void Start()
    {
        //Maps = GameObject.FindGameObjectsWithTag("Map");
        //Maps = Maps.OrderBy((x) => x.name).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaps()
    {
        UiManager.Instance.ShowHideMapSelectionScreen(true);
        Maps = Manager.Instance.Maps;
    }

    public void MapButton(int value)
    {
        for (int i = 0; i < Maps.Length; i++)
        {
            Maps[i].SetActive(false);
        }
        Maps[value].SetActive(true);
        UiManager.Instance.ShowHideMapSelectionScreen(false);
    }

    public void BackButton()
    {
        UiManager.Instance.ShowHideWeaponSelectionScreen(true);
        UiManager.Instance.ShowHideMapSelectionScreen(false);
    }

    
}
