using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {
	public float C;
	public float moveX;
	public float moveY;
	public float Scales;

	public int randomrorate;
	// Use this for initialization
	void Start () {
		randomrorate = Random.Range (0, 2);
		if (randomrorate == 0) {
		}
		moveX = Random.Range (-1.2f,1.2f);
		moveY = Random.Range (-1.2f, 1.2f);
	}

	// Update is called once per frame
	void Update () {
		if (randomrorate == 0) {
			transform.eulerAngles += new Vector3 (0, 0, 150 * Time.deltaTime);
		}
		if (randomrorate == 1) {
			transform.eulerAngles -= new Vector3 (0, 0, 150 * Time.deltaTime);
		}
		Scales += 0.5f * Time.deltaTime;
		C -= 0.5f * Time.deltaTime;

		Color color = GetComponent<SpriteRenderer>().material.color;
		color.a = 1f+C;
		color.r = 1;
		color.g = 1;
		color.b = 1;
		GetComponent<SpriteRenderer>().material.SetColor("_Color", color);


		transform.position += new Vector3 (moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
		transform.localScale -= new Vector3 (Scales*Time.deltaTime, Scales*Time.deltaTime, 1);
		if (Scales >= 1) {
			Destroy (gameObject);
		}
	}
}
