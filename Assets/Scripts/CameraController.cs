using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    // Start is called before the first frame update
    GameObject PowerBar;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPowerPower()
    {
        if (!PowerBar)
        {
            PowerBar = FindObjectOfType<PowerBar>().gameObject;
        }
        //GlobalValues.MaxPower += GlobalValues.WeaponPower;
        int value = GlobalValues.MaxPower + GlobalValues.WeaponPower;

        PowerBar.GetComponentInChildren<Text>().text = ""+value;
        PowerBar.SetActive(!PowerBar.activeSelf);
    }
}
