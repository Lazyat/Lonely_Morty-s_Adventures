using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class anim : MonoBehaviour {

	public GameObject mortyClean, mortyDab, mortyDance, mortyMarche, mortyTombe, mortyAssoir, mortyRecevoir, mortyLance, mortyRamasse;
	public GameObject portal;


	private GameObject portalG, portalD, mortyD, mortyG;
	private Vector3 portalVG, portalVD, mortyVG, mortyVD;
	private Quaternion base0;

	private bool launched = false;

	// Use this for initialization
	void Start () {
		portalVG = new Vector3(2.5f, 2f, 5f);
		portalVD = new Vector3(-2.5f, 2f, 5f);
		mortyVG = new Vector3(2.5f, 0.1f, 4f);
		mortyVD = new Vector3(-2.5f, 0.1f, 4f);
		base0 = new Quaternion();

		MakeAnim(mortyDab, mortyDab);
	}

	void MakeAnim (GameObject morty1, GameObject morty2){
		portalG = Instantiate(portal, portalVG, base0);
		portalD = Instantiate(portal, portalVD, base0);

		mortyG = Instantiate(morty1, mortyVG, base0);
		mortyD = Instantiate(morty2, mortyVD, base0);

		Destroy(portalG, 1);
		Destroy(portalD, 1);
	}
	
	void move (GameObject morty1, int dg){
		if(dg == 1){
			morty1.GetComponent<Transform>().Translate(0,0,Time.deltaTime);
		}else{
			morty1.GetComponent<Transform>().Translate(0,0,Time.deltaTime);
		}

	}

	// Update is called once per frame
	void Update () {

		if (!launched){
			move(mortyG, 1);
		}
	}
}
