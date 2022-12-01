using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_turrett : MonoBehaviour
{
    GameObject gold;
    public GameObject prefab,prefab2,prefab3, tdup;
    public Transform firePoint;
    float timer = 0f,o=0f,w;
    public float attack_speed,max_mp;
    public Image bar_b,upgrade, yellow_box1, coin_png;
    float current_mp=0f;
    public Text a;

    // Start is called before the first frame update
    void Start()
    { w = attack_speed;
        o = PlayerPrefs.GetFloat("main_lv");
        
        upgrade.enabled = false;
        gold = GameObject.FindGameObjectWithTag("MainCamera");
        yellow_box();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gold.GetComponent<coin>().control_b1 == true)
        {
            speedup();
            Debug.Log(gold.GetComponent<coin>().control_b1);
            //  gold.GetComponent<coin>().control_b1 = false;
        }
        bar_b.fillAmount = current_mp/max_mp;
        timer += Time.deltaTime;
        if (timer>=attack_speed)
        { 

        Shoot();
           current_mp+=1f;
           timer = 0f;

        }
        if (current_mp >= max_mp)
        {
            control();
          
        }
        if (gold.GetComponent<coin>().q >= 1000f && o == 0f)
        { upgrade.enabled = true; }

        else if (gold.GetComponent<coin>().q >= 3500f && o == 1f)
        { upgrade.enabled = true; }

        else if (gold.GetComponent<coin>().q >= 7500f && o == 2f)
        { upgrade.enabled = true; }

        else if (gold.GetComponent<coin>().q >= 20000f && o == 3f)
        { upgrade.enabled = true; }

        else if (gold.GetComponent<coin>().q >= 100000f && o == 4f)
        { upgrade.enabled = true; }
        else { upgrade.enabled = false;
            }
    }
    public void yellow_box()
    {

        yellow_box1.enabled = false;
        a.enabled = false;
        coin_png.enabled = false;
    }
    public void yellow_box_act()
    {

        yellow_box1.enabled = true;
        a.enabled = true;
        coin_png.enabled = true;
    }

    void Shoot()
    {//Vector3 position7 = new Vector3(-50f, 5f, 0);
       // Instantiate(prefab, position7, Quaternion.identity);
        Instantiate(prefab, firePoint.position, firePoint.rotation);
    }

    void Shoot2()
    {//Vector3 position7 = new Vector3(-50f, 5f, 0);
     // Instantiate(prefab, position7, Quaternion.identity);
        Instantiate(prefab2, firePoint.position, firePoint.rotation);
    }
   /* void Shoot3()
    {

        Vector3 position1 = new Vector3(-155f, 25f, 0);
        Vector3 position2 = new Vector3(-155f, 15f, 0);
        Vector3 position3 = new Vector3(-155f, 5f, 0);
        Vector3 position4 = new Vector3(-155f, -5f, 0);
        Vector3 position5 = new Vector3(-155f, -15f, 0);
        Vector3 position6 = new Vector3(-155f, 35f, 0);

       
        Instantiate(prefab3, position2, Quaternion.identity);
        Instantiate(prefab3, position3, Quaternion.identity);
        Instantiate(prefab3, position4, Quaternion.identity);
        Instantiate(prefab3, position5, Quaternion.identity);
        Instantiate(prefab3, position6, Quaternion.identity);
        Instantiate(prefab3, position1, Quaternion.identity);
    }*/
    void control()
    {
        Shoot2();
        current_mp = 0f;
        /*  float a = Random.Range(1, 3);
          switch (a)
          {
              case 1:
                  Shoot2();
                  current_mp = 0f;
                  break;
              case 2:
                  Shoot3();
                  current_mp = 0f;
                  break;

          }*/

    }
    public void DestroyMain()
    {
        if (gold.GetComponent<coin>().q >= 1000f && o == 0f)
        {
            gold.GetComponent<coin>().lvMain();
                   Instantiate(tdup, this.transform.position, this.transform.rotation);
            o++;
            PlayerPrefs.SetFloat("main_lv", o);
            Destroy(this.gameObject);
        }
        else if (gold.GetComponent<coin>().q >= 3500f && o == 1f)
        {
            gold.GetComponent<coin>().lvMain();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            o++;
            PlayerPrefs.SetFloat("main_lv", o);
            Destroy(this.gameObject);
        }
        else if (gold.GetComponent<coin>().q >= 7500f && o == 2f)
        {
            gold.GetComponent<coin>().lvMain();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            o++;
            PlayerPrefs.SetFloat("main_lv", o);
            Destroy(this.gameObject);
        }
        else if (gold.GetComponent<coin>().q >= 20000f && o == 3f)
        {
            gold.GetComponent<coin>().lvMain();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            o++;
            PlayerPrefs.SetFloat("main_lv", o);
            Destroy(this.gameObject);
        }
        else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
        }



    }
    public void speedup()
    {
        if (w == attack_speed)
        {
            attack_speed -= attack_speed * 0.35f;
            Invoke("speeddown", 5);
        }
    }
    public void speeddown()
    {

        attack_speed = w;
    }

}
