using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Againmenu : MonoBehaviour {
	public int Num;
	public GameObject Win;
	public GameObject Lose;
	private Manage Manage;
	// Use this for initialization
	void Start () {
		Manage = GameObject.Find ("Manage").GetComponent<Manage> ();
		if (Num == 0) {
			Manage.End = true;
			if (Manage.Score1>Manage.Score2) {
				Win.SetActive (true);
			}
			if (Manage.Score1<Manage.Score2) {
				Lose.SetActive (true);
			}

			//Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (Num == 0) {
		
			Manage.End = false;
			//Application.LoadLevel (Application.loadedLevelName);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
		if (Num == 1) {
		
			Manage.End = false;
            Time.timeScale = 1;
           Manage.Startgame = false;
            Manage.Loadmymenu();
            //Application.LoadLevel ("Loading");
            SceneManager.LoadScene("Loading");

		}
	}
}
