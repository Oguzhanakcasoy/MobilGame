using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == true)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void gamePaused_active()
    {

        gamePaused = true;

    }
    public void gameResume_active()
    {

        gamePaused = false;

    }
     public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="e1")
        {

         restart.SetActive(true);
            gamePaused = true;
        }

    }
    public void load_scene()
    {
        PlayerPrefs.SetFloat("level_stage", (PlayerPrefs.GetFloat("level_stage")-1));

        Application.LoadLevel(Application.loadedLevel);
        restart.SetActive(false);

    }
}

