using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class td1 : MonoBehaviour
{
    Vector3 pos2, pos1, pos3, pos4;
    GameObject gold;
    float timer = 0f,w,y=0f;
    public GameObject prefab, prefab2, tdup;
    public Transform firePoint;
    float current_mp = 0f;
    public float max_mp, attack_speed;
    public Image bar_b, upgrade,yellow_box1, coin_png;
    public Text a;
    float timer3 = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
        pos1 = new Vector3(-218, 93, 0);
        pos2 = new Vector3(-177, 47, 0);
        pos3 = new Vector3(-173, -31, 0);
        pos4 = new Vector3(-221, -68, 0);
        pos_control_start();
        upgrade.enabled = false;
        w = attack_speed;
        gold = GameObject.FindGameObjectWithTag("MainCamera");
        yellow_box();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       // Debug.Log(gold.GetComponent<coin>().control_b1);
        if(gold.GetComponent<coin>().control_b1==true)
        {
           speedup();
            Debug.Log(gold.GetComponent<coin>().control_b1);
          //  gold.GetComponent<coin>().control_b1 = false;
        }

        bar_b.fillAmount = current_mp / max_mp;

        timer += Time.deltaTime;
        timer3 += Time.deltaTime;
        if (timer >= attack_speed)
        {

            Shoot();
            current_mp++;

            timer = 0f;

        }
        if (current_mp >= max_mp)
        {
            Shoot2();
            current_mp = 0;


        }
        if (gold.GetComponent<coin>().q >= 200f && y==1f)
        { upgrade.enabled = true; }
       
       else if (gold.GetComponent<coin>().q >= 500f && y == 2f)
        { upgrade.enabled = true; }
       
      else  if (gold.GetComponent<coin>().q >= 750f && y == 3f)
        { upgrade.enabled = true; }
      
      else  if (gold.GetComponent<coin>().q >= 1000f && y == 4f)
        { upgrade.enabled = true; }
       
      else  if (gold.GetComponent<coin>().q >= 10000f && y == 5f)
        { upgrade.enabled = true; }
        else { upgrade.enabled = false; }


        /*   if (this.transform.tag=="Player" && timer3>=2.6f)
           {

               Shoot2();
               timer3 = current_mp*0.8f+timer;

           }*/
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
    /*  void OnDestroy()
      {


              //Instantiate(tdup, this.transform.position, this.transform.rotation);


      }*/

    public void Destroy1()
    {
        if (gold.GetComponent<coin>().q >= 200)
        {  gold.GetComponent<coin>().lv2();
        Instantiate(tdup, this.transform.position, this.transform.rotation);
            y++;
            pos_control();
        Destroy(this.gameObject); }
        else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
        }


    }
    public void Destroy2()
    {
        if (gold.GetComponent<coin>().q >= 500)
        {
            gold.GetComponent<coin>().lv3();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            y++;
            pos_control();
            Destroy(this.gameObject);
        }
        else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
        }
    }
    public void Destroy3()
    {
        if (gold.GetComponent<coin>().q >= 750)
        {
            gold.GetComponent<coin>().lv4();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            y++;
            pos_control();
            Destroy(this.gameObject);
        }
       else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
        }
    }
    public void Destroy4()
    {
        if (gold.GetComponent<coin>().q >= 1000)
        {
            gold.GetComponent<coin>().lv5();
            Instantiate(tdup, this.transform.position, this.transform.rotation);
            y++;
            pos_control();
            Destroy(this.gameObject);
        }
        else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
        }
    }
    
    public void speedup()
    {if(w==attack_speed)
        { 
        attack_speed -= attack_speed * 0.35f;
      Invoke("speeddown", 5);
         }
    }
    public void speeddown()
    {

        attack_speed = w;
    }
  public  void  pos_control ()
    {if(transform.position==pos1)
        {
            PlayerPrefs.SetFloat("pos1", y);
        }
      else  if (transform.position == pos2)
        {
            PlayerPrefs.SetFloat("pos2", y);
        }
       else if (transform.position == pos3)
        {
            PlayerPrefs.SetFloat("pos3", y);
        }
       else if (transform.position == pos4)
        {
            PlayerPrefs.SetFloat("pos4", y);
        }

     
    }
    public void pos_control_start()
    {
        if (transform.position == pos1)
        {
           y= PlayerPrefs.GetFloat("pos1");
        }
        else if (transform.position == pos2)
        {
            y = PlayerPrefs.GetFloat("pos2");
        }
        else if (transform.position == pos3)
        {
            y = PlayerPrefs.GetFloat("pos3");
        }
        else if (transform.position == pos4)
        {
            y = PlayerPrefs.GetFloat("pos4");
        }


    }


}
