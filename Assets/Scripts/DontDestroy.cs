using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] Slider LoadingSlider;
    bool LoadingBool;
    // Start is called before the first frame update
    void Start()
    {
        //Advertisements.Instance.Initialize();
        //Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);
        DontDestroyOnLoad(this);
        if (PlayerPrefs.GetString("RetryScene") !="Null")
        {
        SceneManager.LoadScene(PlayerPrefs.GetString("RetryScene"));
            PlayerPrefs.SetString("RetryScene", "Null");
        }
        else
        {
            //LoadScene();
            LoadingSlider.value = 0;
            LoadingBool = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadingBool)
        {
            if (LoadingSlider.value < LoadingSlider.maxValue)
                LoadingSlider.value += 1 * Time.deltaTime * 10;
            else
            {
                LoadingBool = false;
                LoadScene();
            }
        }
    }

    void LoadingBar()
    {

    }

    void LoadScene()
    {
        //int number = Random.Range(1,3);
        int number = 1; //?
        SceneManager.LoadScene(number);
    }

    void Loading()
    {

    }


}
