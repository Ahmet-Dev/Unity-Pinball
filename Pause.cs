using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    private Manage manage;
	public int Num;
	public GameObject Menu;
	public GameObject Tolid;
	public GameObject Mymenu;
	// Use this for initialization
	void Start () {
        manage = GameObject.Find("Manage").GetComponent<Manage>();
		if (Num == 1) {
			Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
        if (manage.End == false) { 

		if (Num == 0) {
			if (Tolid == null) {
				Tolid = Instantiate (Menu, new Vector3 (0, 0, -2), Quaternion.identity)as GameObject;
			}
		}
		if (Num == 1) {
			
			Time.timeScale = 1;
			//Application.LoadLevel (Application.loadedLevelName);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		}
		if (Num == 2) {

			Time.timeScale = 1;
                manage.Loadmymenu();
                manage.Startgame = false;
			
                SceneManager.LoadScene("Loading", LoadSceneMode.Single);


            }
		if (Num == 3) {

			Time.timeScale = 1;
			Destroy (Mymenu);

		}
        }
    }
}
