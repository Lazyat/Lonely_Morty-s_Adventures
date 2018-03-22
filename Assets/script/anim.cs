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

	// Use this for initialization
	void Start () {
		portalVG = new Vector3(2.5f, 2f, 5f);
		portalVD = new Vector3(-2.5f, 2f, 5f);
		mortyVG = new Vector3(2.5f, 0.1f, 4.3f);
		mortyVD = new Vector3(-2.5f, 0.1f, 4.3f);
		base0 = new Quaternion();

		MakeAnim(mortyTombe, mortyDab);
	}

	void MakeAnim (GameObject morty1, GameObject morty2){
		portalG = Instantiate(portal, portalVG, base0);
		portalD = Instantiate(portal, portalVD, base0);

		mortyG = Instantiate(morty1, mortyVG, base0);
		mortyD = Instantiate(morty2, mortyVD, base0);

		Destroy(portalG, 1);
		Destroy(portalD, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
