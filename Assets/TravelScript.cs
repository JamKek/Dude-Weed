﻿using UnityEngine;
using System.Collections;

public class TravelScript : MonoBehaviour {

	public RectTransform VincLuk;
	public RectTransform FTDPanelBlocker;
	public RectTransform FTDPanelBlocker2;
	public RectTransform FTDPanel;
	public UnityEngine.UI.Text	FTDText;

	public RectTransform outsidePanel;
	public RectTransform cityPanel;
	public RectTransform garagePanel;
	public RectTransform nugShopPanel;
	public RectTransform seedShopPanel;
	public RectTransform storeShopPanel;
	public RectTransform SettingsPanel;
	public RectTransform invPanel;
	public RectTransform seedMenu;

	Vector2 panelON		=	new Vector2 (0, 0);
	Vector2 outOFF		=	new Vector2(0,738);
	Vector2 cityOFF		=	new Vector2(-1280,0);
	Vector2 garageOFF	=	new Vector2(1280,738);
	Vector2 nugshopOff	=	new	Vector2(-1280,738);
	Vector2	seedshopOFF	=	new	Vector2(2560,0);
	Vector2	storeshopOFF=	new	Vector2(1280,-738);

	public static int PLACE;
	public static bool isReload;

	void Start(){
		SettingsPanel.gameObject.SetActive (false);
		VincLuk.gameObject.SetActive (false);
	}

	void OnEnable(){
	}

	void Update(){
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			Debug.Log(FirstTimeDialogs.stage);
		}
		if (Input.GetKeyDown (KeyCode.Escape) && (FirstTimeDialogs.stage == 11 || FirstTimeDialogs.stage == 13) ){
			if (Inv.isOpened) {
				invPanel.anchoredPosition = new Vector2 (0, 740);
				Inv.isOpened = false;
			}
			else if (seedMenu.gameObject.activeInHierarchy && PLACE == 0) {
				seedMenu.gameObject.SetActive (false);
			}
			else if (SettingsPanel.gameObject.activeInHierarchy && PLACE == 0) {
				SettingsPanel.gameObject.SetActive (false);
			}
			else if (PLACE == 0){
				SettingsPanel.gameObject.SetActive (true);
			}
			else {
			ExitPlace ();
			}
		}


		if (isReload) {
			SwitchPlace ();
			isReload = false;
		}
	}

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
			Debug.Log ("fin");
		}
		VincLuk.gameObject.SetActive (false);
	}

	public void ExitPlace(){
		switch (PLACE) {
		case 0:	//HOME
			
			break;
		case 1:	//Outside
			GoHome ();
			break;

		case 2:	//City
			if (FirstTimeDialogs.stage != 11) {
				GoOutside ();
			}
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
		}
	}

	public void SwitchPlace(){
		switch (PLACE) {
		case 0:	//HOME
			GoHome();
			break;
		case 1:	//Outside
			GoOutside ();
			Debug.Log("YESESSSSSSSSSS");
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
		}
	}

	public void GoHome(){
			outsidePanel.anchoredPosition	= outOFF;
			cityPanel.anchoredPosition		= cityOFF;
			garagePanel.anchoredPosition	= garageOFF;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			nugShopPanel.anchoredPosition	= nugshopOff;
			PLACE =	0;
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
	}
	public void GoOutside(){
			outsidePanel.anchoredPosition	= panelON;
			cityPanel.anchoredPosition		= cityOFF;
			garagePanel.anchoredPosition	= garageOFF;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			nugShopPanel.anchoredPosition	= nugshopOff;
			PLACE = 1;
	}
	public void GoToCity(){
			cityPanel.anchoredPosition		= panelON;
			outsidePanel.anchoredPosition	= outOFF;
			garagePanel.anchoredPosition	= garageOFF;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			nugShopPanel.anchoredPosition	= nugshopOff;
			PLACE = 2;
	}
	public void GoToGarage(){
			garagePanel.anchoredPosition	= panelON;
			outsidePanel.anchoredPosition	= outOFF;
			cityPanel.anchoredPosition		= cityOFF;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			nugShopPanel.anchoredPosition	= nugshopOff;
			PLACE = 3;
	}
	public void GoToNugShop(){
			nugShopPanel.anchoredPosition	= panelON;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			garagePanel.anchoredPosition	= garageOFF;
			outsidePanel.anchoredPosition	= outOFF;
			cityPanel.anchoredPosition		= cityOFF;
			PLACE = 4;
	}
	public void GoToSeedShop(){
			seedShopPanel.anchoredPosition	= panelON;
			nugShopPanel.anchoredPosition	= nugshopOff;
			storeShopPanel.anchoredPosition	= storeshopOFF;
			garagePanel.anchoredPosition	= garageOFF;
			outsidePanel.anchoredPosition	= outOFF;
			cityPanel.anchoredPosition		= cityOFF;
			PLACE = 5;
	}
	public void GoToStoreShop(){
			storeShopPanel.anchoredPosition	= panelON;
			seedShopPanel.anchoredPosition	= seedshopOFF;
			nugShopPanel.anchoredPosition	= nugshopOff;
			garagePanel.anchoredPosition	= garageOFF;
			outsidePanel.anchoredPosition	= outOFF;
			cityPanel.anchoredPosition		= cityOFF;
			PLACE = 6;
	}
	//---------------------------- 0:Home 1:Outside 2:City 3:Garage 4:NugShop 5:SeedShop 6:StoreShop|||
}