using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	public GameObject Againmenu;
	public float C;
	public float Startmove;
	public float Endmove;
	public GameObject Mypose;
	public bool A;
	public bool B;
	public int Num;
	public GameObject Cam;
	private Manage Manage;
	public int Once;
	public int Once2;
	// Use this for initialization
	void Start () {

		Manage = GameObject.Find ("Manage").GetComponent<Manage> ();
		Cam = GameObject.Find ("Main Camera");
		StartCoroutine (Move1 ());
		StartCoroutine (Move2 ());
		if (Manage.Sound == 0) {
			GameObject.Find ("Sound8").GetComponent<AudioSource> ().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (transform.position.x <= Cam.transform.position.x - 15f) {
//			Destroy (gameObject);
//		}
		if (A == true) {


			if (Num == 1) {
				Once += 1;
				if (Once == 1) {
					StartCoroutine (PART ());
				}
				transform.position=Vector3.Lerp (transform.position, transform.position=new Vector3(0,0,-1), Time.deltaTime *6f);
				transform.localScale += new Vector3 (0, C * Time.deltaTime, 0);
				if (transform.localScale.y >= 1) {
					transform.localScale = new Vector3 (1, 1, 1);
				}
			}
			if (Num != 1) {
				
				transform.position=Vector3.Lerp (transform.position, transform.position=new Vector3(Mypose.transform.position.x,Mypose.transform.position.y,-2), Time.deltaTime *6f);
			}

		}
		if (B == true) {
			if (Num == 1) {

				transform.localScale -= new Vector3 (0,C*3* Time.deltaTime, 0);
				if (transform.localScale.y <= 0) {
					transform.localScale = new Vector3 (0, 0, 0);
					Once2 += 1;
					if (Once2 == 1) {
						StartCoroutine (INS ());
					}
				}

			}
			if (Num== 0) {
				
				transform.position = Vector3.Lerp (transform.position, transform.position = new Vector3 (-10f, Mypose.transform.position.y, -2), Time.deltaTime * 3f);
			}
			if (Num == 2) {
				transform.position = Vector3.Lerp (transform.position, transform.position = new Vector3 (10f, Mypose.transform.position.y, -2), Time.deltaTime * 3f);
			}


		}
	}
	IEnumerator Move1(){
		yield return new WaitForSeconds (Startmove);
		A = true;
	}
	IEnumerator Move2(){
		yield return new WaitForSeconds (Endmove);

		A = false;
		B = true;
	}
	IEnumerator PART(){
		yield return new WaitForSeconds (1f);
		ParticleSystem ps = GameObject.Find ("GOAL").GetComponent<ParticleSystem>();
		var em = ps.emission;
		em.enabled = false;
	}
	IEnumerator INS(){
		yield return new WaitForSeconds (0.5f);
		if (Manage.Score1 < 5 && Manage.Score2 < 5) {
			if (Manage.Goal1 == true) {
				Manage.InsBall1 = true;
			}
			if (Manage.Goal2 == true) {
				Manage.InsBall2 = true;
			}
		}
		if (Manage.Score1 >= 5 || Manage.Score2 >= 5) {
			Instantiate (Againmenu, new Vector3 (0, 0 , -4f), Quaternion.identity);
		}




		Manage.Goal1 = false;
		Manage.Goal2 = false;
		Manage.Lights.SetActive (false);
		Destroy (gameObject);
	}

}


