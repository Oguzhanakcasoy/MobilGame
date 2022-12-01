using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spwn : MonoBehaviour
{
    GameObject b2,gold;
    
    public GameObject button6, button, button2, button3, button4, button5,prefab2, prefab1, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9, prefab10, prefab11, prefab12;
    float timer2 = 0.0f, level_stage=1f,enemy_count=0f;
    // Start is called before the first frame update
    void Start()
    {level_stage = PlayerPrefs.GetFloat("level_stage");
        b2 = GameObject.FindWithTag("next_stage");
        b2.SetActive(false);
        level_stage_up();
        Debug.Log(level_stage);
        gold = GameObject.FindGameObjectWithTag("MainCamera");


    }

     void Update()
      {
        if (enemy_count >= level_stage * 5)
        {

            CancelInvoke("Spawn2");
         //   b2 = GameObject.FindWithTag("next_stage");
            
            level_stage++;
            PlayerPrefs.SetFloat("level_stage",level_stage);
            b2.SetActive(true);
            Invoke("level_stage_up", 9);

        }
          }
    



    void Spawn2()
    {

        float x2 = Random.Range(321, 380);
        float y2 = Random.Range(-85, 100);
        float z2 = Random.Range(1, 13);
        Vector3 position2 = new Vector3(x2, y2, 0);
        enemy_count++;
        switch (z2)
        {
            case 1:
               
                Instantiate(prefab2, position2, Quaternion.identity);
                break;
            case 2:
                Instantiate(prefab1, position2, Quaternion.identity);
                break;
            case 3:
                Instantiate(prefab3, position2, Quaternion.identity);
                break;
            case 4:
                Instantiate(prefab4, position2, Quaternion.identity);
                break;
            case 5:
                Instantiate(prefab5, position2, Quaternion.identity);
                break;
            case 6:
                Instantiate(prefab6, position2, Quaternion.identity);
                break;
            case 7:
                Instantiate(prefab7, position2, Quaternion.identity);
                break;
            case 8:
                Instantiate(prefab8, position2, Quaternion.identity);
                break;
            case 9:
                Instantiate(prefab9, position2, Quaternion.identity);
                break;
            case 10:
                Instantiate(prefab10, position2, Quaternion.identity);
                break;
            case 11:
                Instantiate(prefab11, position2, Quaternion.identity);
                break;
            case 12:
                Instantiate(prefab12, position2, Quaternion.identity);
                break;
            
            
         
    }


    }
 public void level_stage_up()
    {
        CancelInvoke("level_stage_up");
        InvokeRepeating("Spawn2", 1, 0.3f);
        b2.SetActive(false);
        enemy_count = 0f;
      //  gold.GetComponent<coin>().skill_control();
        skill_control();

    }
    public void skill_control()
    {
        button.SetActive(true);
        if (1 == PlayerPrefs.GetFloat("b2_de"))
        {
            //  b2 = GameObject.FindWithTag("b2");
            //  b2.SetActive(false);
            button2.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b3_de"))
        {
            // b2 = GameObject.FindWithTag("b3");
            // b2.SetActive(false);
            button3.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b4_de"))
        {
            // b2 = GameObject.FindWithTag("b4");
            //  b2.SetActive(false);
            button4.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b5_de"))
        {
            //  b2 = GameObject.FindWithTag("b5");
            //  b2.SetActive(false);
            button5.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b6_de"))
        {
            //  b2 = GameObject.FindWithTag("b6");
            // b2.SetActive(false);
            button6.SetActive(true);

        }
        Debug.Log("qqqq");
    }
  

}
