using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour
{
    [SerializeField] Image PlayerHealthImage;
    [SerializeField] Image EnemyHealthImage;

    [SerializeField] List<Sprite> PlayersImages;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransform(int index)
    {
        //if ((float)GlobalValues.Level%4==0)
        //{
        //    Debug.Log("Bonusss");
        //    FindObjectOfType<Manager>().BonusRound();
        //    FindObjectOfType<CanvasManager>().SetEnemySprite();
        //}
        //else
        //{
            GlobalValues.isBonus = false;
            Instantiate(index);
            enemy.transform.parent = null;
            GameObject SpawnPoint = GameObject.Find("EnemySpawnPoint");
            enemy.transform.position = SpawnPoint.transform.position;
            enemy.transform.rotation = SpawnPoint.transform.rotation;
        //}

    }

    void Instantiate(int index)
    {
        if (PlayerPrefs.GetString("Retry")!="Null")
        {
            if (enemy != null)
                Destroy(enemy);
            enemy = Instantiate(Resources.Load("enemies/characters/" + PlayerPrefs.GetString("Retry")) as GameObject, transform, false);
            enemy.name = PlayerPrefs.GetString("Retry");
            enemy.GetComponent<Animator>().SetBool("WaitForSlap", true);
            FindObjectOfType<CanvasManager>().SetEnemySprite();
            PlayerPrefs.SetString("Retry","Null");
        }
        else
        {
            int number = GetUniqueNumber(index);

            EnemyHealthImage.sprite = PlayersImages[number];
            PlayerHealthImage.sprite = PlayersImages[index];

            Debug.Log("Enemy Number: " + number);
            // Debug.Log("enemies/characters/" + SceneManager.GetActiveScene().name.Substring(0, 3) + number);
            //string name = SceneManager.GetActiveScene().name.Substring(0, 3) + number;
            string name = "Enemy" + number;
            if (enemy != null)
                Destroy(enemy);
            enemy = Instantiate(Resources.Load("enemies/characters/" +name) as GameObject, transform, false);
            enemy.name = name;
            enemy.GetComponent<Animator>().SetBool("WaitForSlap", true);
            FindObjectOfType<CanvasManager>().SetEnemySprite();
        }
    }

    int GetUniqueNumber(int index)
    {
        int number = Random.Range(0, 4);

        if (number == index)
        {
            Debug.Log("Number matches index, rerolling...");
            return GetUniqueNumber(index); // Recursive call with return statement
        }
        else
        {
            Debug.Log("Unique number generated: " + number);
            return number;
        }
    }
}
