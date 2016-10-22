using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Weed : MonoBehaviour {

	//_____________________Variables
	public Image	toolbox;
	public Image	plant;
	public Image	pot;
	public Image	lamp;
	public Text		textTime;
	public Button	waterB;
	public RectTransform waterFillLevel;
	public float	timeLeft;
	public float	seedTime;
	public int		potID;
	public int		seedID;
	public int		lampID;
	public int		growthPerc;
	public int		growthStage;
	public bool[]	WaterS	= {false,false,false,false};
	public bool		isEmpty;
	public bool		isGrown;
	public bool		isUnlocked;
	public bool[]	isBuilt;
	//-----------------------------


	/* =============================================================================================
	================================================================================================
																			 00
																			0000
																		   000000
																00         000000          00
													  88		 0000      000000      00000
													  88		 000000    0000000   0000000
													  88		  000000   0000000 0000000
	8b      db      d8  ,adPPYba,  ,adPPYba,  ,adPPYb,88		   0000000 000000 0000000
	`8b    d88b    d8' a8P_____88 a8P_____88 a8"    `Y88			000000 00000 000000
	 `8b  d8'`8b  d8'  8PP""""""" 8PP""""""" 8b       88	 0000     000000 000 0000  000000000
	  `8bd8'  `8bd8'   "8b,   ,aa "8b,   ,aa "8a,   ,d88	  000000000  0000 0 000 000000000
		YP      YP      `"Ybbd8"'  `"Ybbd8"'  `"8bbdP"Y8		 000000000  0 0 0 000000000
																	 0000000000000000
																		  000 0 0000
																		00000 0  00000
																	   00     0      00
	================================================================================================
	================================================================================================*/

	void Start(){
		timeLeft = 0f;
		seedTime = 0f;
		potID = 0;
		seedID = 0;
		lampID = 0;
		growthPerc = 0;
		isEmpty = true;
		isGrown = false;
		isUnlocked = false;
		isBuilt [0] = false;
		isBuilt [1] = false;
		isBuilt [2] = false;
		pot.gameObject.SetActive (false);
		lamp.gameObject.SetActive (false);
		toolbox.gameObject.SetActive (false);
		waterB.gameObject.SetActive (false);
		RedrawSprite ();
	}


	void Update(){
		
		CheckBuilt ();

		//_________________________Check growth
		if (!isEmpty && !isGrown) {
			if (timeLeft - Time.deltaTime < 1) {
				isGrown = true;
				waterB.gameObject.SetActive (false);
				RedrawSprite ();
			} else {
				timeLeft -= Time.deltaTime;
				growthPerc = 100 - Mathf.RoundToInt(timeLeft / seedTime * 100);
				RedrawSprite();
			}
			CheckWater();
		}
		//-------------------------------------
	}
		
	/// Checks how built is it,
	/// activates pot and lamp accordingly
	public void CheckBuilt(){
		if (isBuilt[0]) {
			pot.gameObject.SetActive (true);
			lamp.gameObject.SetActive (true);
		}
		else if (!isBuilt[0] && pot.gameObject.activeInHierarchy && lamp.gameObject.activeInHierarchy) {
			isBuilt[0] = true;
			toolbox.gameObject.SetActive (false);
			RedrawSprite ();
			textTime.text = "Ready to grow!";
			if (Vars.isFirst) { FirstTimeDialogs.stage++; }
		}
		else if (!isBuilt[0]) {
			toolbox.gameObject.SetActive (true);
			if (pot.gameObject.activeInHierarchy) {
				toolbox.rectTransform.anchoredPosition = new Vector2 (20, 240);
				textTime.text = "You still need a lamp";
			} else {
				toolbox.rectTransform.anchoredPosition = new Vector2 (0, 45);
				textTime.text = "You need a pot and a lamp";
			}
			if (lamp.gameObject.activeInHierarchy){
				textTime.text = "You still need a pot";
			}
		}
	}

	//_________________WATERING FUNCTIONS
	void CheckWater(){
		//_________________For WaterLeft Display
		int WaterLevel = 0;
		//-----------------
		//
		//________________C_H_E_C_K___S_T_A_G_E___A_N_D___S_E_T___T_R_U_E________________________
		if		(growthStage == 0 && WaterS [0] == false) { waterB.gameObject.SetActive (true); } 
		else if	(growthStage == 1 && WaterS [1] == false) { waterB.gameObject.SetActive (true); }
		else if	(growthStage == 2 && WaterS [2] == false) { waterB.gameObject.SetActive (true); }
		else if	(growthStage == 3 && WaterS [3] == false) { waterB.gameObject.SetActive (true); }
		else { waterB.gameObject.SetActive (false); }
		//-------------------------------------------
		//
		//________D_I_S_P_L_A_Y___W_A_T_E_R___L_E_F_T______________
		for(int i = 0;i<WaterS.Length;i++){ if(WaterS[i]){WaterLevel++;} }
		waterFillLevel.offsetMax = Vars.WATERLEVELS[WaterLevel];
		//-------------------------------------------------------
	}
	public void Water(){
		WaterS[growthStage] = true; //WaterBottleClicked
	}
	//------------------------------------

	/// Plants the click.
	/// Checks if grown, and gives items if true;
	public void PlantClick(){
		if (isGrown) {
			//_________________Water multiplier
			float watMult = 0f;
			foreach(bool b in WaterS){ if(b == true){ watMult += 0.33f;} }
			//------------------------------------------------------------
			//
			//__________________________E_Q_U_I_P_M_E_N_T________M_U_L_T_I_P_L_I_E_R____________
			float eqMulti	= (Vars.POTMULTIS [potID] + Vars.LAMPMULTIS [lampID] + watMult) / 3;
			//----------------------------------------------------------------------------------
			//
			//_______________________S_E_E_D___A_N_D___N_U_G____C_H_A_N_C_E_S______________________
			float rndSeed	= Random.Range (Vars.SEEDMINMAX[seedID,0], Vars.SEEDMINMAX[seedID,1] );
			float rndNug	= Random.Range (Vars.NUGMINMAX [seedID,0], Vars.NUGMINMAX [seedID,1]);
			//-------------------------------------------------------------------------------------
			//
			//_____________G_E_N_E_R_A_T_E___A_M_O_U_N_T_S_________
			int SeedAmount	= Mathf.RoundToInt(rndSeed * eqMulti);
			int NugAmount	= Mathf.RoundToInt(rndNug  * eqMulti);
			//----------------------------------------------------
			//
			Inv.DisplayUpdate (false, SeedAmount, NugAmount, seedID);
			Inv.NUGS[seedID]	+= NugAmount;
			Inv.SEEDS[seedID]	+= SeedAmount;
			isGrown = false;
			isEmpty = true;
			for (int i = 0; i < 4; i++) { WaterS [i] = false; }
			RedrawSprite ();
		}
	}
		
	/// Updates weed component images.
	/// Pot,Plant,Text.
	public void RedrawSprite(){
		if (!isUnlocked) { gameObject.SetActive(false); }
		else {
			//______________________This weed is unlocked, display it
			gameObject.SetActive (true);
			//---------------------------
			//
			//__________________________________________________________________________Draw pot and lamp if they're unlocked
			if (isBuilt [1]) {
				pot.gameObject.SetActive(true);
				pot.GetComponent<Image>().sprite = Vars.POTSPRITES [potID];
			} else { pot.gameObject.SetActive (false); }
			//
			if (isBuilt [2]) {
				lamp.gameObject.SetActive(true);
				lamp.GetComponent<Image>().sprite = Vars.LAMPSPRITES [lampID];
			} else { lamp.gameObject.SetActive(true); }
			//----------------------------------------------------------------------------------------------
			//
			//____________Draw pot and plant
			if (isEmpty) {
				//_______________________________No seed,draw pot, set interactability
				plant.gameObject.SetActive (false);
				pot.GetComponent<Button> ().interactable = isBuilt[0] ? true : false;
				textTime.text = "Choose your seed!";
				textTime.color = Color.white;
				//----------------------------------
			} else {
				//______________________________not empty, means that seed is there, display its progress
				pot.GetComponent<Button>().interactable = false;
				plant.gameObject.SetActive(true);
				if (isGrown) 									{plant.GetComponent<Image>().sprite = Vars.PLANTSPRITES[seedID,4];	growthStage = 4;}
				else if	(growthPerc < 25)						{plant.GetComponent<Image>().sprite = Vars.PLANTSPRITES[seedID,0];	growthStage = 0;}
				else if	(growthPerc >= 25 && growthPerc < 50)	{plant.GetComponent<Image>().sprite = Vars.PLANTSPRITES[seedID,1];	growthStage = 1;}
				else if	(growthPerc >= 50 && growthPerc < 75)	{plant.GetComponent<Image>().sprite = Vars.PLANTSPRITES[seedID,2];	growthStage = 2;}
				else if	(growthPerc >= 75 && growthPerc < 100)	{plant.GetComponent<Image>().sprite = Vars.PLANTSPRITES[seedID,3];	growthStage = 3;}
				//-----------------------------------------------------------------------------------------------------------------------------------	
				//
				//____________TEXT DISPLAY, if grown show done, if not, show time
				if (isGrown) {
					textTime.text = "Done!";
					textTime.color = Color.green;
				} else {
					if (timeLeft / 3600 > 1) {
						textTime.text = Mathf.FloorToInt(timeLeft/3600) + "h " + Mathf.FloorToInt( (timeLeft%3600)/60 ) + "min"; //Hours:Minutes:Seconds
				} else if (timeLeft / 60 > 1){
					textTime.text = Mathf.FloorToInt(timeLeft/60) + " min " + Mathf.FloorToInt(timeLeft%60) + " sec";	//Minutes:Seconds
				} else {
					textTime.text = Mathf.FloorToInt(timeLeft) + " sec"; //Seconds
					}
				}
				//-------------------
			}
			//-----------------------------------------------------------------
		}
	}
}