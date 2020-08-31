using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour {
	public GameObject OneTwoThree;
	public GameObject Tolid;
	private Manage Manage;
	public int Rand;
    public GameObject Lights;
	// Use this for initialization
	void Start () {
		
		Manage = GameObject.Find ("Manage").GetComponent<Manage> ();
        Manage.InsBall1 = false;
        Manage.InsBall2 = false;
        Manage.Startgame = false;
        StartCoroutine (Des ());
        Manage.Lights = Lights;
        Manage.Stopmusic();
		Manage.Score1 = 0;
		Manage.Score2 = 0;
		Manage.End = false;
		Tolid =Instantiate (OneTwoThree, new Vector3 (0, 0, -2), Quaternion.identity)as GameObject;
		if (Manage.Sound == 0) {
			GetComponent<AudioSource> ().Play ();
		}
	}
	
	
	void Update () {
		
	}
	IEnumerator Des(){
		yield return new WaitForSeconds (3.1f);
		
		Rand = Random.Range (0, 2);
		if (Rand == 0) {
			Manage.InsBall1 = true;
            Manage.InsBall2 = false;
        }
		if (Rand == 1) {
			Manage.InsBall2 = true;
            Manage.InsBall1 = false;
        }
        Manage.Startgame = true;
        Destroy (Tolid);
		
	}
}
