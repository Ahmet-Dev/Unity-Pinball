using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    public GameObject Levels;
	public Sprite[] Soundsprite;
    public int Buttonnumber;
    private Manage Manage;
    public GameObject Mymenu;
    private Image Soundimage;
    private GameObject Output;
   
    private AudioSource Audio;
	// Use this for initialization
	void Start () {
        Audio = GameObject.Find("Buttonaudio").GetComponent<AudioSource>();
               Manage = GameObject.Find ("Manage").GetComponent<Manage> ();
        if (Buttonnumber == 1)
        {
          
            if (Manage.Sound == 0)
            {
                Manage.Playmusic();
            }
            Manage.Menu = Mymenu;
        }
            if (Buttonnumber == 2)
        {
            Soundimage = GetComponent<Image>();
            if (Manage.Sound == 0)
            {
                Manage.Playmusic();
            }

            if (Manage.Sound == 0)
            {
              
                Soundimage.sprite = Soundsprite[0];
            }
            if (Manage.Sound == 1)
            {
                Soundimage.sprite = Soundsprite[1];
               
            }

          
        
        }
  
    }


    void Update()
    {


    }
    public void OnClick()
    {
        if (Manage.Sound == 0)
        {
            Audio.Play();
        }
        //--play button
        if (Buttonnumber == 1 )
        {
            Output=Instantiate(Levels, new Vector3(0,0, 0), Quaternion.identity)as GameObject;
            Output.transform.SetParent(GameObject.Find("Canvas").transform);
            Output.transform.localScale = Vector3.one;
            Manage.Menu.SetActive(false);
        }
        //--sound button
        if (Buttonnumber == 2)
        {
            Manage.Sound += 1;
            if (Manage.Sound >= 2) { Manage.Sound = 0; }
            if (Manage.Sound == 0)
            {
                Soundimage.sprite = Soundsprite[0];
                Manage.Playmusic();
            }
            if (Manage.Sound == 1)
            {
                Soundimage.sprite = Soundsprite[1];
                Manage.Stopmusic();
            }

        }
        //--exit button
        if (Buttonnumber == 3)
        {
            Application.Quit();
        }
        //--Levels button
        if (Buttonnumber == 4)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
       
        }
        //--Levels button
        if (Buttonnumber == 5)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
          
        }
        //--Levels button
        if (Buttonnumber == 6)
        {
           
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        //--Levels button
        if (Buttonnumber == 7)
        {
            Manage.Menu.SetActive(true);
            Destroy(Mymenu);
        }
    }
}