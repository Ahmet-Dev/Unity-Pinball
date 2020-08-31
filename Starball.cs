using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starball : MonoBehaviour {
	public int Num;
	public GameObject Tolid;
	public GameObject Ball;
	public GameObject[] Stars;
	public GameObject Sprite1;
	public GameObject Sprite2;
	public GameObject[] pos;
	public bool Change;
	public float Timer;
	private Manage Manage;
	private Rigidbody2D rb2D;
	public int Once;
	// Use this for initialization
	void Start () {
		Manage = GameObject.Find ("Manage").GetComponent<Manage>();
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		Change = false;
	}
	
	// Update is called once per frame
	void Update () {
		//rb2D.MoveRotation(rb2D.rotation + 500f * Time.fixedDeltaTime);
	

		if (Manage.Startgame == true) {
			if (Manage.InsBall1 == true&&Num==1) {
				transform.position=Vector3.Lerp (transform.position, pos[1].transform.position, Time.deltaTime *1.2f);
				Once += 1;
				if (Once == 1) {
					StartCoroutine (insball ());


				}
			}
			if (Manage.InsBall2 == true&&Num==2) {
				transform.position=Vector3.Lerp (transform.position, pos[1].transform.position, Time.deltaTime *1.2f);
				Once += 1;
				if (Once == 1) {
					StartCoroutine (insball ());


				}
			}
			if (Manage.InsBall1 == false&&Manage.InsBall2 == false) {
				transform.position=Vector3.Lerp (transform.position, pos[0].transform.position, Time.deltaTime *1.2f);
			}

		}
		if (Change == true) {
			Sprite1.SetActive ( false);
			Sprite2.SetActive ( true);
			Timer += 1 * Time.deltaTime;
			if (Timer >= 1.5f) {
				Change = false;
			}
		}
		if (Change == false) {
			Sprite1.SetActive (true);
			Sprite2.SetActive (false);
		}

		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ball") {

				Timer = 0;
			Change = true;
			Instantiate (Stars[0], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (Stars[1], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (Stars[2], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (Stars[3], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (Stars[4], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			//coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.right *500);

			// Add Force Oposite of Ball
			Vector3 force = transform.position - coll.transform.position;

			force.Normalize();
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce(-force * 45000);
		}
	}

	IEnumerator insball(){
		yield return new WaitForSeconds (1.5f);
		if (Num == 1) {
			Tolid = Instantiate (Ball, new Vector3 (pos [0].transform.position.x + 0.3f, pos [0].transform.position.y , transform.position.z), Quaternion.identity)as GameObject;
			Tolid.transform.GetComponent<Rigidbody2D> ().velocity = new Vector3 (Random.Range(3f,1f),3);
		}
		if (Num == 2) {
			Tolid = Instantiate (Ball, new Vector3 (pos [0].transform.position.x - 0.3f, pos [0].transform.position.y , transform.position.z), Quaternion.identity)as GameObject;
			Tolid.transform.GetComponent<Rigidbody2D> ().velocity = new Vector3 (Random.Range(-3f,-1f),-3);
		}


		Once = 0;
		Manage.InsBall1 = false;
		Manage.InsBall2 = false;

	}
}
