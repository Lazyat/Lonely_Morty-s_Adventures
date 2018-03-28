using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

	/*Doit marcher d'abord*/ 	public bool asseoirG					=false;
								public bool dabberG						=false; 
								public bool danserG						=false;
								public bool RamasserLancerGAttrapeD		=false;
								public bool RamasserLanceGTombeD		=false; 
								public bool RamasserLancerGRenvoyerD	=false;
								
	
	/*Doit marcher d'abord*/ 	public bool asseoirD					=false;
								public bool dabberD						=false; 
								public bool danserD						=false;
								public bool RamasserLancerDAttrapeG		=false;
								public bool RamasserLanceDTombeG		=false; 
								public bool RamasserLancerDRenvoyerG	=false;
	public bool play, alreadyLaunched = false;
	public bool activable = false;

	public GameObject fix, marche, leve, dab, assis, ramasse, danse, tombe, lance, attrape;
	private GameObject current_mortyG, current_mortyD, portal;
	private GameObject selected_mortyG, selected_mortyD;

	void ResetBoolean(string side){
		if(side == "GD"){
			asseoirG 					= RamasserLancerGAttrapeD 	= RamasserLanceGTombeD = 
			RamasserLancerGRenvoyerD 	= dabberG 					= danserG = 
			asseoirD 					= RamasserLancerDAttrapeG 	= RamasserLanceDTombeG = 
			RamasserLancerDRenvoyerG 	= dabberD 					= danserD 
			= false;

		}else if(side == "G"){
			asseoirG 					= RamasserLancerGAttrapeD 	= RamasserLanceGTombeD = 
			RamasserLancerGRenvoyerD 	= RamasserLancerDAttrapeG 	= RamasserLanceDTombeG = 
			RamasserLancerDRenvoyerG 	= dabberG 					= danserG 
			= false;

		}else if(side == "D"){
			asseoirD 					= RamasserLancerDAttrapeG 	= RamasserLanceDTombeG = 
			RamasserLancerDRenvoyerG 	= RamasserLancerGAttrapeD 	= RamasserLanceGTombeD = 
			RamasserLancerGRenvoyerD 	= dabberD 					= danserD 
			= false;
		}
	}

	public void FunctionasseoirG(){
		ResetBoolean("G");
		asseoirG = true;
	}

	public void FunctionasseoirD(){
		ResetBoolean("D");
		asseoirD = true;
	}

	public void FunctiondabberG(){
		ResetBoolean("G");
		dabberG = true;
	}

	public void FunctiondabberD(){
		ResetBoolean("D");
		dabberD = true;
	}

	public void FunctiondanserG(){
		ResetBoolean("G");
		danserG = true;
	}

	public void FunctiondanserD(){
		ResetBoolean("D");
		danserD = true;
	}

	public void FunctionRamasserLancerGAttrapeD(){
		ResetBoolean("GD");
		RamasserLancerGAttrapeD = true;
	}

	public void FunctionRamasserLancerDAttrapeG(){
		ResetBoolean("GD");
		RamasserLancerDAttrapeG = true;
	}

	public void FunctionRamasserLanceGTombeD(){
		ResetBoolean("GD");
		RamasserLanceGTombeD = true;
	}

	public void FunctionRamasserLanceDTombeG(){
		ResetBoolean("GD");
		RamasserLanceDTombeG = true;
	}

	public void FunctionRamasserLancerGRenvoyerD(){
		ResetBoolean("GD");
		RamasserLancerGRenvoyerD = true;
	}

	public void FunctionRamasserLancerDRenvoyerG(){
		ResetBoolean("GD");
		RamasserLancerDRenvoyerG = true;
	}

	public void FunctionPlay(){
		play = !play;
	}

	private void VerifierBool(){
		if(((danserG || dabberG || asseoirG) && (danserD || dabberD || asseoirD)) || (RamasserLancerDRenvoyerG || RamasserLancerGRenvoyerD || RamasserLanceDTombeG || RamasserLanceGTombeD || RamasserLancerDAttrapeG || RamasserLancerGAttrapeD)){
			activable = true;
		}else{
			activable = false;
		}
	}

	void SetTheMortys(){
		if(dabberG || danserG || asseoirG){
			if(dabberG){			selected_mortyG = dab;
			}else if(asseoirG){		selected_mortyG = assis;
			}else{					selected_mortyG = danse;
			}
		}
		if(dabberD || danserD || asseoirD){
			if(dabberD){			selected_mortyD = dab;
			}else if(asseoirD){		selected_mortyD = assis;
			}else{					selected_mortyD = danse;
			}
		}
		if(RamasserLancerDRenvoyerG || RamasserLancerGRenvoyerD || RamasserLanceDTombeG || RamasserLanceGTombeD || RamasserLancerDAttrapeG || RamasserLancerGAttrapeD){
			if(RamasserLancerDRenvoyerG){ 			selected_mortyD = ramasse; selected_mortyG = attrape;
			}else if(RamasserLancerGRenvoyerD){		selected_mortyD = attrape; selected_mortyG = ramasse;
			}else if(RamasserLanceDTombeG){
			}else if(RamasserLanceGTombeD){
			}else if(RamasserLancerDAttrapeG){
			}else if(RamasserLancerGAttrapeD){
			}
		}
	}

	void MakeAnim(){
		if(current_mortyG!=null && current_mortyD!=null){
			Destroy(current_mortyG);
			Destroy(current_mortyD);
		}
		SetTheMortys();
	}

	void InitAnim(){
		GameObject portalG = Instantiate(portal);
		GameObject portalD = Instantiate(portal);

		current_mortyG = Instantiate(fix);
		current_mortyD = Instantiate(fix);

		Destroy(portalG, 1);
		Destroy(portalD, 1);
	}

	// Use this for initialization
	void Start () {
		InitAnim();
	}
	
	// Update is called once per frame
	void Update () {
		VerifierBool();
		if (play && !alreadyLaunched && activable){
			alreadyLaunched = true;
			MakeAnim();
		}
	}
}


