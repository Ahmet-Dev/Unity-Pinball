using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonsgame : MonoBehaviour {
	public GameObject[] Buttons;
    private AudioSource Soundbutton1;
    private AudioSource Soundbutton2;
    private Manage manage;
	public Sprite[] button1Sprites;

	private SpriteRenderer B1;
	private SpriteRenderer B2;
	private SpriteRenderer B3;
	private SpriteRenderer B4;


	private int b1FingerID = -1;
	private int b2FingerID = -1;
	private int b3FingerID = -1;
	private int b4FingerID = -1;
    private bool Onceplay;
	void Start() {
		manage = GameObject.Find ("Manage").GetComponent<Manage> ();
		B1 = Buttons [0].GetComponent<SpriteRenderer> ();
		B2 = Buttons [1].GetComponent<SpriteRenderer> ();
		B3 = Buttons [2].GetComponent<SpriteRenderer> ();
		B4 = Buttons [3].GetComponent<SpriteRenderer> ();
        Soundbutton1 = GameObject.Find("Button-Sound-1").GetComponent<AudioSource>();
        Soundbutton2 = GameObject.Find("Button-Sound-2").GetComponent<AudioSource>();


    }

	void Update () {
		if (manage.End == false) {
			if (Input.touchCount > 0) {
				foreach (Touch touch in Input.touches) {
					if (touch.phase == TouchPhase.Began) {
						Vector2 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
						RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);

						if (hit.collider != null) {
							Debug.Log (hit.collider.name + " : " + touch.fingerId);

							if (hit.collider.name.Equals ("Button1")) {
								b1FingerID = touch.fingerId;
								B1.sprite = button1Sprites [1];
                                if(manage.Sound==0&& Onceplay == false)
                                {
                                    Soundbutton2.Play();
                                }
								manage.Move [0] = true;
							}

							if (hit.collider.name.Equals ("Button2")) {
								b2FingerID = touch.fingerId;
								B2.sprite = button1Sprites [3];
                                if (manage.Sound == 0 && Onceplay == false)
                                {
                                    Soundbutton1.Play();
                                }
                                manage.Move [1] = true;
							}

							if (hit.collider.name.Equals ("Button3")) {
								b3FingerID = touch.fingerId;
								B3.sprite = button1Sprites [5];
                                if (manage.Sound == 0 && Onceplay == false)
                                {
                                    Soundbutton1.Play();
                                }
                                manage.Move [2] = true;
							}

							if (hit.collider.name.Equals ("Button4")) {
								b4FingerID = touch.fingerId;
								B4.sprite = button1Sprites [7];
                                if (manage.Sound == 0 && Onceplay == false)
                                {
                                    Soundbutton2.Play();
                                }
                                manage.Move [3] = true;
							}
						}
						//Debug.Log (touch.fingerId + " : " + hit.collider.name);
					}

					if (touch.phase == TouchPhase.Ended) {
						if (touch.fingerId == b1FingerID) {
							//B1.enabled = true;
							//B11.enabled = false;
							B1.sprite = button1Sprites [0];

							b1FingerID = -1;
                            Onceplay = false;
							manage.Move [0] = false;
						}

						if (touch.fingerId == b2FingerID) {
							B2.sprite = button1Sprites [2];
							//B2.enabled = true;
							//B22.enabled = false;

							b2FingerID = -1;
                            Onceplay = false;
                            manage.Move [1] = false;
						}

						if (touch.fingerId == b3FingerID) {
							B3.sprite = button1Sprites [4];
							//	B3.enabled = true;
							//B33.enabled = false;

							b3FingerID = -1;
                            Onceplay = false;
                            manage.Move [2] = false;
						}

						if (touch.fingerId == b4FingerID) {
							B4.sprite = button1Sprites [6];
							//B4.enabled = true;
							//B44.enabled = false;

							b4FingerID = -1;
                            Onceplay = false;
                            manage.Move [3] = false;
						}
					}
				}
			}


		}
	}
}
