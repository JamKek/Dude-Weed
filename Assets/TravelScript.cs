using UnityEngine;
using System.Collections;

public class TravelScript : MonoBehaviour {

	public RectTransform VincLuk;

	//____F_I_R_S_T___T_I_M_E__D_I_A_L_O_G_
	public RectTransform FTDPanelBlocker;
	public RectTransform FTDPanelBlocker2;
	public RectTransform FTDPanel;
	public UnityEngine.UI.Text	FTDText;
	//-----------------------------------
	//
	//_______P_L_A_C_E_S_____________
	public RectTransform invPanel;
	public RectTransform outsidePanel;
	public RectTransform cityPanel;
	public RectTransform garagePanel;
	public RectTransform nugShopPanel;
	public RectTransform seedShopPanel;
	public RectTransform storeShopPanel;
	public RectTransform SettingsPanel;
	public RectTransform seedMenu;
	public RectTransform tool1Panel;
	//--------------------------------
	//
	//____P_L_A_C_E_S___P_O_S_I_T_I_O_N_S_______
	Vector2 panelON		=	new Vector2 (0, 0);
	Vector2	invOff		=	new	Vector2(0,740);
	Vector2 outOFF		=	new Vector2(0,738);
	Vector2 cityOFF		=	new Vector2(-1280,0);
	Vector2 garageOFF	=	new Vector2(1280,738);
	Vector2 nugshopOff	=	new	Vector2(-1280,738);
	Vector2	seedshopOFF	=	new	Vector2(2560,0);
	Vector2	storeshopOFF=	new	Vector2(1280,-738);
	Vector2 tool1OFF	=	new Vector2(2560,-720);
	//---------------------------------------------
	//
	//___V_A_R_I_A_B_L_E_S______
	public static int PLACE;
	public static bool isReload;
	public static bool invOpened;
	//--------------------------

	/* ======================================================
	  ,d                                                 88
	  88                                                 88
	MM88MMM 8b,dPPYba, ,adPPYYba, 8b       d8  ,adPPYba, 88
	  88    88P'   "Y8 ""     `Y8 `8b     d8' a8P_____88 88
	  88    88         ,adPPPPP88  `8b   d8'  8PP""""""" 88
	  88,   88         88,    ,88   `8b,d8'   "8b,   ,aa 88
	  "Y888 88         `"8bbdP"Y8     "8"      `"Ybbd8"' 88
	======================================================== */
	void Start(){
		SettingsPanel.gameObject.SetActive (false);
		VincLuk.gameObject.SetActive (false);
	}
	void Update(){
		//______________________E_S_C_A_P_E_/_B_A_C_K___B_U_T_T_O_N___H_A_N_D_L_E_R___
		if (Input.GetKeyDown (KeyCode.Escape)
			&& (!Vars.isFirst || FirstTimeDialogs.stage == 11 || FirstTimeDialogs.stage == 13) )
			{
				if (invOpened) { InvClose (); }
				else if (seedMenu.gameObject.activeInHierarchy && PLACE == 0) {
					seedMenu.gameObject.SetActive (false);
				}
				else if (SettingsPanel.gameObject.activeInHierarchy && PLACE == 0) {
					SettingsPanel.gameObject.SetActive (false);
				}
				else if (PLACE == 0){
					SettingsPanel.gameObject.SetActive (true);
				}
				else { ExitPlace (); }
			}
		//---------------------------------------------------
		//
		//_____________Reload "Function"
		if (isReload) {
			SwitchPlace ();
			isReload = false;
		}
		//-------------------
	}
		

	//_______________________VINCLUK EASTER EGGOOO
	public void VincasLukas(){
		if (VincLuk.gameObject.activeInHierarchy) {
			VincLuk.gameObject.SetActive (false);
			VincLuk.localScale = new Vector2 (0.001f, 0.001f);
		} else {
			VincLuk.gameObject.SetActive (true);
			StartCoroutine (VincLukScale ());
		}
	}
	IEnumerator VincLukScale(){
		AudioSource fanfarai = VincLuk.GetComponent<AudioSource> ();
		fanfarai.Play ();
		float x = 0.0f;
		float y = 0.0f;
		while (fanfarai.isPlaying) {
			VincLuk.localScale = new Vector2(x,x);
			VincLuk.anchoredPosition = new Vector2 (0, y);
			x += 0.005f;
			if (x < 0.1f) {
				y -= 0.05f;
			} else if (x > 0.9f)
			{
				y -= 0.8f;
			} else { y -= 0.5f; }
			yield return new WaitForFixedUpdate ();
		}
		VincLuk.gameObject.SetActive (false);
	}
	//-----------------------------------------

	//___C_H_A_N_G_E___P_L_A_C_E_S______
	public void ExitPlace(){	//CALLED ON ESCAPE
		switch (PLACE) {
		case 0:	//HOME
			break;
		case 1:	//Outside
			GoHome ();
			break;
		case 2:	//City
			if (FirstTimeDialogs.stage != 11) { GoOutside (); }
			break;
		case 3:	//Garage
			GoOutside ();
			break;
		case 4:	//NugShop
			GoToCity ();
			break;
		case 5:	//SeedShop
			GoToCity ();
			break;
		case 6:	//StoreShop
			GoToCity ();
			break;
		case 8: //Tool1
			GoToGarage ();
			break;
		}
	}
	public void SwitchPlace(){
		switch (PLACE) {
		case 0:	//HOME
			GoHome();
			break;
		case 1:	//Outside
			GoOutside ();
			break;
		case 2:	//City
			GoToCity();
			break;
		case 3:	//Garage
			GoToGarage();
			break;
		case 4:	//NugShop
			GoToNugShop();
			break;
		case 5:	//SeedShop
			GoToSeedShop();
			break;
		case 6:	//StoreShop
			GoToStoreShop();
			break;
		case 8: //Tool1
			GoToTool1Panel();
			break;
		}
	}
	//-------------------------------------------
	//
	//____________________Panel_Opening_Functions
	public void GoHome(){
			TurnAllOff ();
			PLACE =	0;
			//_____F_I_R_S_T_____T_I_M_E___D_I_A_L_O_G________
			if (Vars.isFirst && FirstTimeDialogs.stage >= 12) {
			//case 14
			FirstTimeDialogs.stage++;
			FTDText.text = "Great, now click on the pot and select which seed you want to put in it...";
			FTDPanel.anchoredPosition3D = new Vector2 (-360, -230);
			FTDPanel.GetComponent<UnityEngine.UI.Button> ().interactable = false;
			FTDPanelBlocker.offsetMin = new Vector2 (0,0); // left bottom
			FTDPanelBlocker.offsetMax = new Vector2 (-900,0); //-right -top
			FTDPanelBlocker2.offsetMin = new Vector2 (750, 0);
			FTDPanelBlocker2.offsetMax = new Vector2 (0, 0);
			}
			//------------------------------------------------
	}
	public void GoOutside(){
			TurnAllOff ();
			outsidePanel.anchoredPosition	= panelON;
			PLACE = 1;
	}
	public void GoToCity(){
			TurnAllOff ();
			cityPanel.anchoredPosition		= panelON;
			PLACE = 2;
	}
	public void GoToGarage(){
			TurnAllOff ();
			garagePanel.anchoredPosition	= panelON;
			PLACE = 3;
	}
	public void GoToNugShop(){
			TurnAllOff ();
			nugShopPanel.anchoredPosition	= panelON;
			PLACE = 4;
	}
	public void GoToSeedShop(){
			TurnAllOff ();
			seedShopPanel.anchoredPosition	= panelON;
			PLACE = 5;
	}
	public void GoToStoreShop(){
			TurnAllOff ();
			storeShopPanel.anchoredPosition	= panelON;
			PLACE = 6;
	}

	public void GoToTool1Panel(){
			TurnAllOff ();
			tool1Panel.anchoredPosition = panelON;
			PLACE = 8;
	}
	//---------------------------- 0:Home 1:Outside 2:City 3:Garage 4:NugShop 5:SeedShop 6:StoreShop 8:Tool1 9:TODO|||
	//
	//_____________________INV
	public void InvOpen(){
		invPanel.anchoredPosition = panelON;
		invOpened = true;
	}
	public void InvClose(){
		invPanel.anchoredPosition = invOff;
		invOpened = false;
	}
	//--------------------
	//
	//________________HIDE ALL PANELS (except inside)
	void TurnAllOff(){
		outsidePanel.anchoredPosition	= outOFF;
		cityPanel.anchoredPosition		= cityOFF;
		garagePanel.anchoredPosition	= garageOFF;
		storeShopPanel.anchoredPosition	= storeshopOFF;
		seedShopPanel.anchoredPosition	= seedshopOFF;
		nugShopPanel.anchoredPosition	= nugshopOff;
		tool1Panel.anchoredPosition		= tool1OFF;
		invPanel.anchoredPosition		= invOff;
	}
	//---------------------------------------------
}
