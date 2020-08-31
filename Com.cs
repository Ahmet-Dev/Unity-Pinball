using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com : MonoBehaviour {
	public int Num;
	public float Levels;
	private Manage manage;
	public bool Col;
	public bool Shoot;
	public float FalseTime;
	public float Truetime;
	// Use this for initialization
	void Start () {
		
		manage = GameObject.Find ("Manage").GetComponent<Manage> ();
		InvokeRepeating ("Shooting",Levels, Levels);
		InvokeRepeating ("Trueshoot",Truetime,Truetime);
	}
	
	// Update is called once per frame
	void Update () {
		if (Shoot == false) {
			if (Num == 5) {
				manage.Move [4] = false;
			}
			if (Num == 6) {
				manage.Move [5] = false;
			}
			if (Num == 7) {
				manage.Move [6] = false;
			}
			if (Num == 8) {
				manage.Move [7] = false;
			}
		}
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Ball") {
			Col = true;
		}
	}
	void OnTriggerExit2D (Collider2D coll)
	{
		Col = false;
		StartCoroutine (EX ());

	}
	void Trueshoot (){
		Shoot = true;
	}
	void Shooting (){
		if (Col == true) {

			if (Shoot) {
				if (Num == 5) {
					manage.Move [4] = true;
				}
				if (Num == 6) {
					manage.Move [5] = true;
				}
				if (Num == 7) {
					manage.Move [6] = true;
				}
				if (Num == 8) {
					manage.Move [7] = true;
				}
			}
			StartCoroutine (SH ());



		}
	}
	IEnumerator SH(){
		yield return new WaitForSeconds (FalseTime);
		Shoot = false;
	}
	IEnumerator EX(){
		yield return new WaitForSeconds (FalseTime);
		if (Col == false) {
			if (Num == 5) {
				manage.Move [4] = false;
			}
			if (Num == 6) {
				manage.Move [5] = false;
			}
			if (Num == 7) {
				manage.Move [6] = false;
			}
			if (Num == 8) {
				manage.Move [7] = false;
			}
		}
	}
}
