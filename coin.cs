using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coin : MonoBehaviour
{
    
    public float p = 1,b2_de,b3_de,b4_de,b5_de,b6_de;
    public Text coin_text,nnn2, nnn3, nnn4, nnn5, nnn6;
   public  bool control_b1;
    public GameObject prefab, prefab2, prefab3, prefab_slow1,prefab_fireball,button6, button, button2, button3, button4, button5,b2;
    public float k = 0f,t=0f,y=0,q=0f,b=0f;
    public Image n2, n3, n4, n5, n6, nn2, nn3, nn4, nn5, nn6;

    public static float coin_sayac;


    // Start is called before the first frame update
    void Start()
    {p = PlayerPrefs.GetFloat("main_lv");
        n2_de();
        n3_de();
        n4_de();
        n5_de();
        n6_de();


        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        if(1 == PlayerPrefs.GetFloat("b2_de"))
        {
            b2 = GameObject.FindWithTag("b2");
            b2.SetActive(false);
            button2.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b3_de"))
        {
            b2 = GameObject.FindWithTag("b3");
            b2.SetActive(false);
            button3.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b4_de"))
        {
            b2 = GameObject.FindWithTag("b4");
            b2.SetActive(false);
            button4.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b5_de"))
        {
            b2 = GameObject.FindWithTag("b5");
            b2.SetActive(false);
            button5.SetActive(true);

        }
        if (1 == PlayerPrefs.GetFloat("b6_de"))
        {
            b2 = GameObject.FindWithTag("b6");
            b2.SetActive(false);
            button6.SetActive(true);

        }
        coin_sayac = PlayerPrefs.GetFloat("total_coin");
        coin_text.text = coin_sayac.ToString();
        // button.SetActive(false);
       

        //  coin_controll();
    }

    // Update is called once per frame
    void Update()
    {
        q = coin_sayac;
    }
    public void coin_controll()
    {
        coin_sayac++;
        PlayerPrefs.SetFloat("total_coin", coin_sayac);
        coin_text.text = coin_sayac.ToString();

    }
    public void lv1()
    {
        coin_sayac -= 75f;
        coin_text.text = coin_sayac.ToString();

    }
    public void lv2()
    {
        coin_sayac -= 200f;
        coin_text.text = coin_sayac.ToString();

    }
    public void lv3()
    {
        coin_sayac -= 500f;
        coin_text.text = coin_sayac.ToString();

    }
    public void lv4()
    {
        coin_sayac -= 750f;
        coin_text.text = coin_sayac.ToString();

    }
    public void lv5()
    {
        coin_sayac -= 50f;
        coin_text.text = coin_sayac.ToString();

    }
    public void coin_test()
    {
        coin_sayac += 500;
    }
    public void lvMain()
    {switch (p)
            {
            case 0:
                coin_sayac -= 1000;
                coin_text.text = coin_sayac.ToString();
                p++;
                break;
            case 1:
                coin_sayac -= 3500;
                coin_text.text = coin_sayac.ToString();
                p++;
                break;
            case 2:
                coin_sayac -= 7500;
                coin_text.text = coin_sayac.ToString();
                p++;
                break;
            case 3:
                coin_sayac -= 20000;
                coin_text.text = coin_sayac.ToString();
                p++;
                break;
        }
        
      /*  coin_sayac -= p*15f;
        coin_text.text = coin_sayac.ToString();
        p++;*/

    }
    public void add_gold()
    {
        coin_sayac += 250;
    }
    public  void attackbutton ()
        {
        control_b1 = true;
        Debug.Log("ok");
        Invoke("attackbuttondown", 3);
       // button = GameObject.Find("button1");
        button.SetActive(false);

    }
    public void attackbuttondown()
    {
        control_b1 = false;
        Debug.Log("ok");

    }
    public void holebutton()
    {
        float x = Random.Range(-90, 226);
        float  y = Random.Range(-90, 111);
        Vector3 position = new Vector3(x, y, 0);
        Instantiate(prefab, position, Quaternion.identity);
        Debug.Log("ok");
        k++;
        
        if(k >= 25f)
        {
         CancelInvoke("holebutton");
            k = 0f;
            
        }
        
        //**  -90 110**x225 -90

    }
    public void holebutton_active ()
    {
        InvokeRepeating("holebutton", 1, 0.7f);
       button2.SetActive(false);

    }
    //-86 133
    public void wind()
    {
        float x2 = Random.Range(-380, -321);
        float y2 = Random.Range(-85, 130);
        Vector3 position2 = new Vector3(x2, y2, 0);
        Instantiate(prefab2, position2, Quaternion.identity);
        t++;
        if (t >= 35f)
        {
            CancelInvoke("wind");
            t = 0f;
        }

    }
    public void wind_active()
    {
        InvokeRepeating("wind", 1, 0.3f);
        button3.SetActive(false);

    }
    public void light_active()
    {
        InvokeRepeating("light", 1, 0.3f);
        button4.SetActive(false);

    }
    public void fireball_active()
    {
        InvokeRepeating("fireball", 1, 0.3f);
        button6.SetActive(false);

    }
    public void light()
    {
        float x3 = Random.Range(-380, -321);
        float y3 = Random.Range(-85, 130);
        Vector3 position3 = new Vector3(x3, y3, 0);
        Instantiate(prefab3, position3, Quaternion.identity);
        y++;
        if (y >= 35f)
        {
            CancelInvoke("light");
            y = 0f;
        }

    }
   public void slow11_spawn()
    {
        button5.SetActive(false);
        Vector3 position = new Vector3(-200, 200, 0);

        Instantiate(prefab_slow1, position, Quaternion.identity);
    }
    public void fireball()
    {
        float x4 = Random.Range(-120, 250);
        
        Vector3 position2 = new Vector3(x4, 200f, 0);
        Instantiate(prefab_fireball, position2, Quaternion.identity);
        b++;
        if (b >= 35f)
        {
            CancelInvoke("fireball");
            b = 0f;
        }

    }
    public void n2_de()
    {

        n2.enabled = false;
        nn2.enabled = false;
        nnn2.enabled = false;
    }
    public void n2_act()
    {

        n2.enabled = true;
        nn2.enabled = true;
        nnn2.enabled = true;
    }
    public void n3_de()
    {

        n3.enabled = false;
        nn3.enabled = false;
        nnn3.enabled = false;
    }
    public void n3_act()
    {

        n3.enabled = true;
        nn3.enabled = true;
        nnn3.enabled = true;
    }
    public void n4_de()
    {

        n4.enabled = false;
        nn4.enabled = false;
        nnn4.enabled = false;
    }
    public void n4_act()
    {

        n4.enabled = true;
        nn4.enabled = true;
        nnn4.enabled = true;
    }
    public void n5_de()
    {

        n5.enabled = false;
        nn5.enabled = false;
        nnn5.enabled = false;
    }
    public void n5_act()
    {

        n5.enabled = true;
        nn5.enabled = true;
        nnn5.enabled = true;
    }
    public void n6_de()
    {

        n6.enabled = false;
        nn6.enabled = false;
        nnn6.enabled = false;
    }
    public void n6_act()
    {

        n6.enabled = true;
        nn6.enabled = true;
        nnn6.enabled = true;
    }
    public void b2_active()
    {if (coin_sayac >= 15000)
        {
            b2_de = 1f;
            PlayerPrefs.SetFloat("b2_de", b2_de);
            coin_sayac -= 5f;
            coin_text.text = coin_sayac.ToString();
            b2 = GameObject.FindWithTag("b2");
            b2.SetActive(false);
            button2.SetActive(true);
        }
    else
        {
            n2_act();
            Invoke("n2_de", 2);
        }

        
    }
    public void b3_active()
    {
        if (coin_sayac >= 1000)
        {
            b3_de = 1f;
            PlayerPrefs.SetFloat("b3_de", b3_de);
            coin_sayac -= 5f;
            coin_text.text = coin_sayac.ToString();
            b2 = GameObject.FindWithTag("b3");
            b2.SetActive(false);
            button3.SetActive(true);

        }
        else
        {
            n3_act();
            Invoke("n3_de", 2);
        }

    }
    public void b4_active()
    {
        if (coin_sayac >= 4000)
        {
            b4_de = 1f;
            PlayerPrefs.SetFloat("b4_de", b4_de);
            coin_sayac -= 5f;
            coin_text.text = coin_sayac.ToString();
            b2 = GameObject.FindWithTag("b4");
            b2.SetActive(false);
            button4.SetActive(true);
        }
        else
        {
            n4_act();
            Invoke("n4_de", 2);
        }

    }
    public void b5_active()
    {
        if (coin_sayac >= 8000)
        {
            b5_de = 1f;
            PlayerPrefs.SetFloat("b5_de", b5_de);
            coin_sayac -= 5f;
            coin_text.text = coin_sayac.ToString();
            b2 = GameObject.FindWithTag("b5");
            b2.SetActive(false);
            button5.SetActive(true);
        }
        else
        {
            n5_act();
            Invoke("n5_de", 2);
        }

    }
    public void b6_active()
    {
        if (coin_sayac >= 25000)
        {
            b6_de = 1f;
            PlayerPrefs.SetFloat("b6_de", b6_de);
            coin_sayac -= 5f;
            coin_text.text = coin_sayac.ToString();
            b2 = GameObject.FindWithTag("b6");
            b2.SetActive(false);
            button6.SetActive(true);
        }
        else
        {
            n6_act();
            Invoke("n6_de", 2);
        }

    }
    public void reset()
    {
        PlayerPrefs.SetFloat("pos1",0f);
        PlayerPrefs.SetFloat("pos2",0f);
        PlayerPrefs.SetFloat("pos3",0f);
        PlayerPrefs.SetFloat("pos4",0f);
        PlayerPrefs.SetFloat("main_lv", 0f);
        PlayerPrefs.SetFloat("level_stage", 1f);
        PlayerPrefs.SetFloat("b3_de",0f);
        PlayerPrefs.SetFloat("b2_de", 0f);
        PlayerPrefs.SetFloat("b4_de", 0f);
        PlayerPrefs.SetFloat("b5_de", 0f);
        PlayerPrefs.SetFloat("b6_de", 0f);
        PlayerPrefs.SetFloat("total_coin", 0f);
        coin_sayac = 0f;
       // coin_controll();
    }
  /*  public void skill_control()
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
    }*/
   

}
