using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonslocation : MonoBehaviour {
	// Use this for initialization
	public float Locationx;
	public float Locationy;

	void Start()
	{

		Vector3 CamPosx = Camera.main.ViewportToWorldPoint(new Vector3( 0f , 0f , 0));
		Vector3 CamPosy = Camera.main.ViewportToWorldPoint(new Vector3( 0f , 0f , 0));

		Locationx = CamPosx.x;
		Locationy = CamPosy.y;

		Vector3 pos = transform.position;

		pos.x = Locationx-Locationx;
		pos.y = Locationy;
		//transform.position = new Vector3 (pos.x + 1, transform.position.y , 0);
		transform.position = pos;
	}
}

