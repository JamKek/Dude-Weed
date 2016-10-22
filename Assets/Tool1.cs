using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tool1 : MonoBehaviour {

	//____I_T_E_M_S___D_I_S_P_L_A_Y__
	public	Text[] seedAmounts;
	public	Image[] seedImages;
	public	Text   paperAmount;
	//---------------------------
	//
	//_____I_M_A_G_E_S_______	
	public	Image	InputImage;
	public	Image	OutputImage;
	public	Image	Wheel;
	//-------------------------
	//
	//_V_A_R_I_A_B_L_E_S___
	public float	rotAngle;
	public bool		isRotating;
	public bool		canRotate;
	private int		_seedID;
	//---------------------

	/* =============================================================================
		TTTTTTTTTTTTTTTTTTTTTTT                               lllllll   1111111   
		T:::::::::::::::::::::T                               l:::::l  1::::::1   
		T:::::::::::::::::::::T                               l:::::l 1:::::::1   
		T:::::TT:::::::TT:::::T                               l:::::l 111:::::1   
		TTTTTT  T:::::T  TTTTTTooooooooooo      ooooooooooo    l::::l    1::::1   
				T:::::T      oo:::::::::::oo  oo:::::::::::oo  l::::l    1::::1   
				T:::::T     o:::::::::::::::oo:::::::::::::::o l::::l    1::::1   
				T:::::T     o:::::ooooo:::::oo:::::ooooo:::::o l::::l    1::::l   
				T:::::T     o::::o     o::::oo::::o     o::::o l::::l    1::::l   
				T:::::T     o::::o     o::::oo::::o     o::::o l::::l    1::::l   
				T:::::T     o::::o     o::::oo::::o     o::::o l::::l    1::::l   
				T:::::T     o::::o     o::::oo::::o     o::::o l::::l    1::::l   
			  TT:::::::TT   o:::::ooooo:::::oo:::::ooooo:::::ol::::::l111::::::111
			  T:::::::::T   o:::::::::::::::oo:::::::::::::::ol::::::l1::::::::::1
			  T:::::::::T    oo:::::::::::oo  oo:::::::::::oo l::::::l1::::::::::1
			  TTTTTTTTTTT      ooooooooooo      ooooooooooo   llllllll111111111111
	================================================================================ */
	public void Start(){
		rotAngle = 0f;
		_seedID = 0;
		isRotating = false;
		canRotate = true;
	}
	public void Update(){
		//________________Rotate if possible
		if (isRotating) {
			if (Inv.SEEDS[_seedID] >= 1) {
				Wheel.transform.rotation = Quaternion.AngleAxis (rotAngle, Vector3.forward); //TODO
				rotAngle += 9f;
				Vibration.Vibrate(10);
			} else {
				seedAmounts[_seedID].color = Color.red; //Not enough seeds
			}
		} else {
			seedAmounts[_seedID].color = Color.white;
		}
		//------------------------------------------
		//
		//____________________ProcessCompleted
		if (rotAngle > 360f) {
			rotAngle = 0;
			Inv.SEEDS[_seedID]--;
			Inv.MISC[0]++;
			Vibration.Vibrate(30);
		}
		//-----------------------
		//
		//_______________U_P_D_A_T_E___T_E_X_T_S___________
		for (int i = 0; i < seedAmounts.Length; i++) {
			seedAmounts[i].text	 = Inv.SEEDS[i].ToString ();
			seedImages[i].sprite = Vars.SEEDSPRITES[i];
		}
		paperAmount.text = Inv.MISC [0].ToString();
		//------------------------------------------
	}


	//________CHOOSE__SEED_________
	public void SeedChoose(int ID){
		if (ID != _seedID) {
			_seedID = ID;
			StartCoroutine (RewindWheel ());
		}
		InputImage.sprite = Vars.SEEDSPRITES[_seedID];
	}
	//--------------------------------
	//
	//________________________rewind
	IEnumerator RewindWheel(){
		canRotate = false;
		while (rotAngle > 0) {
			if (rotAngle == 360){ rotAngle = 0; }
			if (rotAngle - 9f >= 0) { rotAngle -= 9f; }
			else { rotAngle = 0; }
			Wheel.transform.rotation = Quaternion.AngleAxis (rotAngle, Vector3.forward);
			Debug.Log (rotAngle);
			yield return new WaitForFixedUpdate();
		}
		canRotate = true;
	}
	//-----------------------------
	//
	//____D_R_A_G___H_A_N_D_L_E_R___
	public void WheelButtonDown(){
		isRotating = canRotate ? true : false;
	}
	public void WheelButtonUp(){
		isRotating = false;
	}
	//-------------------------------
}