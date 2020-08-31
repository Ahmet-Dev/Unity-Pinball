using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
	public float Speedup;
	public float Speeddown;

	private Manage manage;


	public int Num;

	private Rigidbody2D rb2D;



	// Use this for initialization
	void Start () {
		manage = GameObject.Find ("Manage").GetComponent<Manage> ();


		rb2D = gameObject.GetComponent<Rigidbody2D> ();


	

	}
	

	void FixedUpdate ()
	{
		
		if (Num == 4) {
			if (manage.Move [3] == true) {
				
					rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,270, Speedup * Time.deltaTime));

			}
			if (manage.Move [3] == false) {
				
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));
			

			}

		}
		if (Num == 3) {
			if (manage.Move [2] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,270, Speedup * Time.deltaTime));
			}
			if (manage.Move [2] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}

		if (Num == 2) {
			if (manage.Move [1] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,90, Speedup * Time.deltaTime));
			}
			if (manage.Move [1] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}
		if (Num == 1) {
			if (manage.Move [0] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,90, Speedup * Time.deltaTime));
			}
			if (manage.Move [0] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}
		///----------------------COM--------------------------

		if (Num == 5) {
			if (manage.Move [4] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,90, Speedup * Time.deltaTime));
			}
			if (manage.Move [4] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}

		if (Num == 6) {
			if (manage.Move [5] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,90, Speedup * Time.deltaTime));
			}
			if (manage.Move [5] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}

		if (Num == 7) {
			if (manage.Move [6] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,270, Speedup * Time.deltaTime));
			}
			if (manage.Move [6] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}

		if (Num == 8) {
			if (manage.Move [7] == true) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,270, Speedup * Time.deltaTime));
			}
			if (manage.Move [7] == false) {
				rb2D.MoveRotation(Mathf.LerpAngle(rb2D.rotation,0, Speeddown * Time.deltaTime));

			}

		}
	}
}


