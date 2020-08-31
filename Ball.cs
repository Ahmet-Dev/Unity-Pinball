using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float Y;
	public bool Stay;
	public GameObject Goalpart;
	public float Sp;
	private Manage manage;
	private AudioSource Sound1;
	private AudioSource Sound2;
	private AudioSource Sound3;
	private AudioSource Sound4;
	private AudioSource Sound5;
	private AudioSource Sound6;
	private AudioSource Sound7;
	public int Handsound;
	public GameObject[] Audiogameobjects;
	private Rigidbody2D rb2D;

	public float Speed;
	public GameObject P;
	private bool shouldForceToBall;
	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		Sound1  = GameObject.Find("Sound1").GetComponent<AudioSource> ();
        Sound2  = GameObject.Find("Sound2").GetComponent<AudioSource> ();
		Sound3  = GameObject.Find("Sound3").GetComponent<AudioSource> ();
		Sound4  = GameObject.Find("Sound4").GetComponent<AudioSource> ();
		Sound5  = GameObject.Find("Sound5").GetComponent<AudioSource> ();
		Sound6  = GameObject.Find("Sound6").GetComponent<AudioSource> ();
		Sound7  = GameObject.Find("Sound7").GetComponent<AudioSource> ();
		//InvokeRepeating ("Smoke",0.1f, 0.1f);
	
		manage = GameObject.Find ("Manage").GetComponent<Manage> ();



		if (manage.Sound == 0) {
			Sound5 .Play ();
		}
			
	}
	

	void FixedUpdate () {
		if (Stay == true) {
			transform.position = new Vector3 (transform.position.x, Y, transform.position.z);
            rb2D.drag = 10;

        }
		//transform.position += new Vector3 (0.3f * Time.deltaTime, 0, 0);
		if (rb2D.velocity.magnitude <= 0) {
			if (!shouldForceToBall) {
				StartCoroutine (ForceToBall ());
			}
		}
		if (transform.position.y <= -5.65f) {
			if (manage.Goal1 == false && manage.Goal2 == false) {
				manage.Score2 += 1;
				Sound7 .Play ();
				Instantiate (Goalpart, new Vector3 (0, 0 , -4f), Quaternion.identity);
				StartCoroutine (PART ());
				StartCoroutine (Des ());
				manage.Lights.SetActive (true);
				manage.Goal2 = true;
			}
		}

		if (transform.position.y >= 5.65f) {
			if (manage.Goal1 == false && manage.Goal2 == false) {
				Sound7 .Play ();
				Instantiate (Goalpart, new Vector3 (0, 0 , -4f), Quaternion.identity);
				StartCoroutine (PART ());
				manage.Score1 += 1;
				StartCoroutine (Des ());
				manage.Lights.SetActive (true);
				manage.Goal1 = true;
			}
		}



	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "Star1"||coll.gameObject.name == "Star2") {
			Sound6 .Play ();

		}
		if (coll.gameObject.name == "White-meddle-backgrand") {
			Sound1 .Play ();

	}
		if (coll.gameObject.tag == "Hand") {
			if (manage.Sound == 0) {
				Handsound = Random.Range (0, 3);
				if (Handsound == 0) {
					Sound4.Play ();
				
				}
				if (Handsound == 1) {
					Sound2.Play ();

				}
				if (Handsound == 2) {
					Sound3.Play ();

				}

			}
		}


		}



	private IEnumerator ForceToBall() {
		Debug.Log(rb2D.velocity);

		rb2D.AddForce (transform.right * 5000f);

		shouldForceToBall = true;

		yield return new WaitForSeconds (0.5f);

		shouldForceToBall = false;
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Out") {
			if (transform.position.x > 0) {
				transform.position = new Vector3 (transform.position.x-0.5f, transform.position.y, transform.position.z);
			}
			if (transform.position.x < 0) {
				transform.position = new Vector3 (transform.position.x+0.5f, transform.position.y, transform.position.z);
			}

		}
		if (coll.gameObject.tag == "Finish") {
			Y = transform.position.y;
			Stay = true;
		}
	}


	IEnumerator Des(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
	IEnumerator PART(){
		yield return new WaitForSeconds (0.1f);
		ParticleSystem ps = GameObject.Find ("GOAL").GetComponent<ParticleSystem>();
		var em = ps.emission;
		em.enabled = true;
	}
}

