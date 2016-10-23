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
	//______O_T_H_E_R___
	public RectTransform WheelHandle;
	public CircleCollider2D circleColl;
	//
	//
	//_V_A_R_I_A_B_L_E_S___
	public bool		isRotating;
	public bool		canRotate;
	private int		_seedID;
	public float	rewindSpeed;
	private Vector2 dir;
	private float angle;
	private float dist;
	private float check;
	private bool checkPoint;
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
		_seedID = 0;
		isRotating = false;
		canRotate = true;
		check = 360;
		rewindSpeed = 1f;
	}
	public void Update(){
		//________________Rotate if possible
		if (isRotating && canRotate) {
			
			if (Inv.SEEDS [_seedID] >= 1) {
				
				seedAmounts [_seedID].color = Color.white;
				dir =	(Input.mousePosition - Wheel.transform.position); //Vector of direction from center to mouse pos
				dist	=	Mathf.Sqrt (dir.x * dir.x + dir.y * dir.y); //Distance between mouse and the center

				if (dist < 350 && dist > 150) {
					
					angle =	Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
					angle =	(angle > 0) ? angle : angle + 360;

					if ((angle < check && check - angle < 90) || angle > 350) {
						Wheel.transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
						check = angle;
					}

				}

			} else { seedAmounts[_seedID].color = Color.red; }

		} else {seedAmounts[_seedID].color = Color.white;}
		//------------------------------------------
		//
		//________________CHECKPOINT
		if(angle > 160 && angle < 200){
			checkPoint = true;
		}
		//-------------------------
		//
		//____________________ProcessCompleted
		if(angle > 350 && checkPoint){
			checkPoint = false;
			Inv.SEEDS [_seedID]--;
			Inv.MISC [0]++;
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
			InputImage.sprite = Vars.SEEDSPRITES[_seedID];
		}
	}
	//--------------------------------
	//
	//________________________rewind
	IEnumerator RewindWheel(){
		canRotate = false;
		while (angle < 359) {
			if (angle == 0){ angle = 360; }
			if (angle - rewindSpeed <= 360) { angle += rewindSpeed; }
			else { angle = 360; }
			Wheel.transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
			yield return new WaitForFixedUpdate();
		}
		canRotate = true;
	}
	//-----------------------------
	//
	//____D_R_A_G___H_A_N_D_L_E_R___
	public void BeginDrag(){
		isRotating = canRotate ? true : false;
	}
	public void EndDrag(){
		isRotating = false;
	}
	//-------------------------------
}