using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    GameObject gold;
    float fill;
    public Rigidbody2D rb;
    public float max_hp,speed;
    float current_hp;
    public Image bar_g, bar_y, bar_r;
    bool u;
    // Start is called before the first frame update
    void Start()
    {
        max_hp += max_hp*PlayerPrefs.GetFloat("level_stage")/10;
           gold = GameObject.FindGameObjectWithTag("MainCamera");
       // gold.GetComponent<coin>().coin_controll();
           current_hp = max_hp;
        bar_g.enabled = true;
        bar_y.enabled = false;
        bar_r.enabled = false;
       // rb.velocity = new Vector2(-15, 0f);
        move();

    }

    // Update is called once per frame
   void Update()
    {
        hp_control();
        if(current_hp<=0)
        {
         //   gold.GetComponent<coin>().coin_controll();
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {// Debug.Log(col.gameObject.GetComponent<sc>().damage);
        if (col.gameObject.tag == "my_ball" || col.gameObject.tag == "my_ball_52")
        {
           Destroy(col.gameObject);
            current_hp--;
            current_hp -= col.gameObject.GetComponent<sc>().damage;

            //  Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "my_ball_22" || col.gameObject.tag == "my_ball_521" || col.gameObject.tag == "my_ball_32") 
        {
            current_hp -= col.gameObject.GetComponent<sc>().damage;
            current_hp--;

           //  Destroy(this.gameObject);
        }
       
        if (col.gameObject.tag == "wind")
        {

            rb.velocity = new Vector2(60, 0f);
            u = true;
            Invoke("move", 0.5f);


            //  Destroy(this.gameObject);

        }
        if (col.gameObject.tag == "light" && u==false)
        {

            rb.velocity = new Vector2(0f, 0f);
            u = true;
            Invoke("move", 5f);


            //  Destroy(this.gameObject);

        }
        if (col.gameObject.tag == "slow3" && u == false)
        {
            move_slow();


            u = true;
            Invoke("move", 5f);


            //  Destroy(this.gameObject);

        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "my_ball_42")
        {
            
            current_hp -=0.05f;

            //  Destroy(this.gameObject);

        }
        if (col.gameObject.tag == "my_ball_422")
        {

            current_hp -= 0.2f;

            //  Destroy(this.gameObject);

        }

    }
    void hp_control()
    {

        fill = current_hp / max_hp;

        bar_g.fillAmount = fill;
        bar_y.fillAmount = fill;
        bar_r.fillAmount = fill;
        if (fill >= 0.7f)
        {
            bar_y.enabled = false;
            bar_r.enabled = false;
            bar_g.enabled = true;

        }
        if (fill <= 0.7f && fill >= 0.3f)
        {
            bar_y.enabled = true;
            bar_r.enabled = false;
            bar_g.enabled = false;

        }
        if (fill <= 0.3f)
        {
            bar_y.enabled = false;
            bar_r.enabled = true;
            bar_g.enabled = false;

        }
        bar_g.fillAmount = fill;
        bar_y.fillAmount = fill;
        bar_r.fillAmount = fill;
    }

    void OnDestroy()
    {
        gold.GetComponent<coin>().coin_controll();
    }
    void move()
    {

        rb.velocity = new Vector2(speed, 0f);
        u = false;
    }
    void move_slow ()
    {

        rb.velocity = new Vector2(speed/5, 0f);
        u = false;
    }


}
