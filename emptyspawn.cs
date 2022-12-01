using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emptyspawn : MonoBehaviour
{
    float y = 0f;
    Vector3 pos2,pos1,pos3,pos4;
    public GameObject k,tdmain1,tdmain2,tdmain3,tdmain4,tdmain5,td1,td2,td3,td4,td5;
    GameObject gold;
   public Text a;
    public Image upgrade,yellow_box1,coin_png;
    // Start is called before the first frame update
    void Start()
    
    { gold = GameObject.FindGameObjectWithTag("MainCamera");
        pos1 = new Vector3(-218, 93, 0);
        pos2 = new Vector3(-177, 47, 0);
        pos3 = new Vector3(-173, -31, 0);
        pos4 = new Vector3(-221, -68, 0);
        pos_control_start();
        td();
        yellow_box();
     

        /*  switch(transform.position)
          {
              case pos1 :
                  break;
              case pos2 :
                  break;
              case pos3 :
                  break;
              case pos4 :
                  break;

          }*/
        if (transform.tag == "empty_main")
        {
            maintd();
           /* switch (PlayerPrefs.GetFloat("main_lv"))
            {
                case 0:
                    Instantiate(tdmain1, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    break;

                case 1:
                    Instantiate(tdmain2, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    break;
                case 2:
                    Instantiate(tdmain3, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    break;
                case 3:
                    Instantiate(tdmain4, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    break;
                case 4:
                    Instantiate(tdmain5, this.transform.position, this.transform.rotation);
                    Destroy(this.gameObject);
                    break;
            }*/
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gold.GetComponent<coin>().q >= 75)
        { upgrade.enabled = true; }
        else { upgrade.enabled = false; }
    }
    public void spawnemp()
    {
        if (gold.GetComponent<coin>().q >= 75)
        {
            gold.GetComponent<coin>().lv1();
            y++;
            pos_control();
        Instantiate(k, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            yellow_box_act();

            Invoke("yellow_box", 2);
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
    public void pos_control()
    {
        if (transform.position == pos1)
        {
            PlayerPrefs.SetFloat("pos1", y);
        }
        else if (transform.position == pos2)
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
            y = PlayerPrefs.GetFloat("pos1");
        }
        else if (transform.position == pos2)
        {
            y = PlayerPrefs.GetFloat("pos2");
            Debug.Log("eherherhedrhed");
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
    public void td()
    {
        switch (y)
        {
            case 5:
                Instantiate(td5, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;

            case 1:
                Instantiate(td1, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 2:
                Instantiate(td2, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 3:
                Instantiate(td3, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 4:
                Instantiate(td4, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
    public void maintd()
    {
        switch (PlayerPrefs.GetFloat("main_lv"))
        {
            case 0:
                Instantiate(tdmain1, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;

            case 1:
                Instantiate(tdmain2, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 2:
                Instantiate(tdmain3, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 3:
                Instantiate(tdmain4, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
            case 4:
                Instantiate(tdmain5, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
                break;
        }
    }

}
