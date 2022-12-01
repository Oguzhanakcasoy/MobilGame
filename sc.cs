using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 move;
    float timer = 0;
    public float damage=0f,p=85f;
    public static float  c = 0f;
    public string tag;
    float a = 0f;
    float b = 0f,r=0f,q=0;
    bool t = true;
    float timer3 = 0;
    public Transform n;
    public GameObject prefab521,prefab_slow;


   GameObject kk;
    // Start is called before the first frame update
    void Start()
    {
        tag = transform.tag;
        kk = FindClosestEnemy();
        // kk = GameObject.FindWithTag("e1"); -120,250  y200
     
       
        if (tag == "wind" )
        {
            wind_move();

        }
         else if(tag == "fireball")
        {
            fireball_move();

        }
        else if (tag == "light")
        {
           light_move();

        }else if (tag == "slow3" )
        {

            kk = GameObject.FindGameObjectWithTag("slow1");
            move = -(kk.transform.position - transform.position).normalized * p;
            rb.velocity = new Vector2(move.x, move.y);

        }
        else if(tag == "slow2")
        {
            InvokeRepeating("slow2_spawn", 5.5f, 0.7f);
        }
        else if (tag == "slow1")
        {
            // slow1_move();
           
            InvokeRepeating("slow1_move", 1, 0.1f);
        }
        else {    move = (kk.transform.position - transform.position).normalized * p;
        rb.velocity = new Vector2(move.x, move.y);}
        if (tag == "my_ball_521")
        {
            switch ( sc.c)
            {
                case 0f:
                    rb.velocity = new Vector2(50f, 0f);
                   sc.c++;
                    break;

                case 1f:
                    rb.velocity = new Vector2(50f, 50f);
                   sc.c++;
                    break;
                case 2f:
                    rb.velocity = new Vector2(50f, -50f);
                   sc.c++;
                    break;
                case 3f:
                    rb.velocity = new Vector2(50f, 25f);
                    sc.c++;
                    break;
                case 4f:
                    rb.velocity = new Vector2(50f, -25f);
                     sc.c=0f;
                    break;
          }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (tag == "hole")
        {
               rb.velocity = new Vector2(0f, 0f);
            timer3 += Time.deltaTime;
            if (timer3 <= 4f)
            {

                transform.localScale += new Vector3(0.03f, 0.03f, 0);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (tag == "my_ball_32" && a>=1)
        { 
        kk = FindClosestEnemy();
        move = (kk.transform.position - transform.position).normalized * p;
        rb.velocity = new Vector2(move.x, move.y);
            a--;
    }
        timer +=Time.deltaTime;//oto death
        if(timer>15)
        {
            Destroy(this.gameObject);

        }


        if ((tag == "my_ball_42" || tag == "my_ball_422") && t==false)
        {
            timer3 += Time.deltaTime;
            if(timer3<=4f)
            {

                transform.localScale += new Vector3(0.03f, 0.03f, 0);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
      

    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("e1");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
   
        public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "e1" && tag == "my_ball_32")

        {
            
             if (b <= 7)
            {
                a++;
                
            }
            b++; 
              
        }
        if (col.gameObject.tag == "e1" && (tag == "my_ball_42"|| tag == "my_ball_422"))
        {
            rb.velocity = new Vector2(0f, 0f);
            t = false;
           

        }
        if (col.gameObject.tag == "e1" && tag == "light")
        {

            r++;
            if(r>=3)
            {
                Destroy(this.gameObject);

            }


        }
        if (col.gameObject.tag == "e1" && tag == "fireball")
        {

            
                Destroy(col.gameObject);

            


        }
        if (col.gameObject.tag == "e1" && tag == "my_ball_52")
        {
            rb.velocity = new Vector2(0f, 0f);
            t = false;


        }

        if (col.gameObject.tag == "e1" && tag == "hole")
        {
            if (a< 3f)
            {
             Destroy(col.gameObject);
            a++;
            }
            else
                { Destroy(this.gameObject); }
            


        }
    }

         void OnDestroy()
         {
           if (tag == "my_ball_52")
            {for(int i=0;i<=4;i++)
            { 
              Instantiate(prefab521, n.position, n.rotation);
            }
           }
         }
    void wind_move()
    {

        float x = Random.Range(75, 116);
        rb.velocity = new Vector2(x, 0f);
    }
    void light_move()
    {

        float x = Random.Range(105, 136);
        rb.velocity = new Vector2(x, 0f);
    }
    void slow2_spawn()
    {

        Instantiate(prefab_slow, transform.position, transform.rotation);
    }
   void slow1_move()
    {
        q += 5f;
        // transform.Rotate(0, 0, q);
        Vector3 position1 = new Vector3(0f, 0f, 0);
        transform.eulerAngles = Vector3.forward * q;
        transform.position = Vector3.Lerp(transform.position, position1 , q*0.0008f);
    }
    void fireball_move()
    {

        float y = Random.Range(-116, -75);
        rb.velocity = new Vector2(0f, y);
    }

}
