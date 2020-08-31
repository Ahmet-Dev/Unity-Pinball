using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage : MonoBehaviour {
    public GameObject Menu;
	public bool End;
	public bool[] Move;
	public bool Goal1;
	public bool Goal2;
	public int Score1;
	public int Score2;
	public bool InsBall1;
	public bool InsBall2;
	public bool Startgame;
	public int Sound;
	public GameObject Lights;

	private AudioSource Soundmenu;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Soundmenu = GetComponent<AudioSource> ();
        StartCoroutine(loadmenu());

     
        }
	
	
	void Update () {
	
		if (Sound >= 2) {
			Sound = 0;
		}
		if (Score1 >= 5) {
			Score1 = 5;
		}
		if (Score2 >= 5) {
			Score2 = 5;
		}

	}
    public void Playmusic()
    {
        Soundmenu.Play();
    }
    public void Stopmusic()
    {
        Soundmenu.Stop();
    }
    IEnumerator loadmenu()
    {
        yield return new WaitForSeconds(3f);
       
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Loadmymenu()
    {
        StartCoroutine(loadmenu());
    }
}
