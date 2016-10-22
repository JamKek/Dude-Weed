using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

	//______W_E_E_D_S__
	public Weed[] WEEDS;
	//-----------------
	//
	//_______S_E_E_D____M_E_N_U_
	public ScrollRect SeedMenu;
	public Text		SeedMenuTitle;
	public Image[]	SeedMenuImages;
	public Text[]	SeedMenuTexts;
	//----------------------------
	//
	//______S_E_E_D___S_H_O_P___
	public Image[]	SeedImages;
	public Text[]	SeedNames;
	public Text[]	SeedTimes;
	public Text[]	SeedWorth;
	public Text[]	SeedPrices;
	//-------------------------
	//
	//______N_U_G____S_H_O_P_____
	public Text		NugMultiText;
	public Image[]	NugImages;
	public Text[]	NugNames;
	public Text[]	NugPrices;
	//-------------------------

	//===============================STORE_SHOP
	public Text	ChooseWeedText;

	public Image[]	LampImages;
	public Text[]	LampNames;
	public Text[]	LampQuality;
	public Text[]	LampPrices;

	public Image[]	PotImages;
	public Text[]	PotNames;
	public Text[]	PotQuality;
	public Text[]	PotPrices;

	public RectTransform StoreWeedMenu;
	public Button[]	MenuWeed;
	public Image[]	MenuWeedLamp;
	public Image[]	MenuWeedPlant;
	public Image[]	MenuWeedPot;

	public Button	SpecialButton;
	public Text		SpecialName; 
	public Image	SpecialImage;
	public Text		SpecialDescription;
	public Text		SpecialPrice;

	public Button	Tool0;
	public Button	Tool1;
	//==============================STORE_SHOP

	//__________Variables
	int plantID;
	int lampID;
	int potID;
	int partID;
	int nugMulti;
	int	specPrice;
	//-------------

	/* ===============================\_
	|				_____				\_
	|				|_ _|				  \
	|		   n	(O O)	 n			  |
	|		   H   _|\_/|_   H	G O O D	  |
	|		  nHnn/ \___/ \nnHn	 L U C K |
	|		 <V VV /	 \ VV V>		|
	|		  \__\/|	 |\/__/		   /
	================================ */

	void Start () {
		for (int i = 0; i < Vars.SEEDNAMES.Length; i++) {
			SeedImages[i].sprite = Vars.SEEDSPRITES [i];
			SeedNames [i].text	= Vars.SEEDNAMES [i] + " seed";
			SeedPrices[i].text	= Vars.SEEDPRICES[i] + "$";
			SeedTimes [i].text	= "Grow time: " + Vars.SEEDTIMES [i] + " seconds";
			SeedWorth [i].text	= "Nug worth: " + Vars.NUGPRICES [i] + "$";

			NugImages[i].sprite	= Vars.NUGSPRITES[i];
			NugNames [i].text	= Vars.SEEDNAMES[i] + " nug";
			NugPrices[i].text	= "Sell price: " + Vars.NUGPRICES[i] + "$";
		}
		for (int i = 0; i < Vars.LAMPNAMES.Length; i++) {
			LampImages[i].sprite = Vars.LAMPSPRITES [i];
			LampNames[i].text	= Vars.LAMPNAMES [i];
			LampPrices[i].text	= Vars.LAMPPRICES [i] + "$";
			LampQuality[i].text	= "Quality rating: " + Vars.LAMPMULTIS[i];
		}
		for (int i = 0; i < Vars.POTNAMES.Length; i++) {
			PotImages[i].sprite	= Vars.POTSPRITES [i];
			PotNames[i].text	= Vars.POTNAMES [i];
			PotQuality[i].text	= "Quality rating: " + Vars.POTMULTIS [i];
			PotPrices[i].text	= Vars.POTPRICES[i] + "$";
		}
		plantID = 0;
		lampID = 0;
		potID = 0;
		partID = 0;
		specPrice = 0;
		nugMulti = 1;
		NugMultiText.text = "1x";
		ChooseWeedText.text = "Choose the plant you want to upgrade";
		StoreWeedMenu.gameObject.SetActive(false);
		SeedMenu.gameObject.SetActive(false);
		Tool0.gameObject.SetActive(false);
		Tool1.gameObject.SetActive(false);
	}
	void Update () {
		switch (TravelScript.PLACE) {
		case 0:	if(SeedMenu.gameObject.activeInHierarchy){ CheckSeedMenu(); }
			break;
		case 3:	CheckTools();
			break;
		case 4:	CheckNugs();
			break;
		case 5:	CheckSeeds();
			break;
		case 6:	CheckLamps();
				CheckPots ();
				CheckSpecial();
				if(StoreWeedMenu.gameObject.activeInHierarchy){ CheckWeedMenu(); }
			break;
		}
	}


	//____________________S_E_E_D__M_E_N_U__C_H_E_C_K______
	void CheckSeedMenu(){
		for (int i = 0; i < Vars.SEEDNAMES.Length; i++) {
			SeedMenuTexts[i].text = Inv.SEEDS[i].ToString ();
			SeedMenuImages [i].sprite = Vars.SEEDSPRITES [i];
		}
	}
	//-----------------------------------------------------
	//
	//_________________G_A_R_A_G_E___C_H_E_C_K____________________________
	void CheckTools(){
		if (Inv.SPECIAL[1] == true) { Tool0.gameObject.SetActive(true); }
		else { Tool0.gameObject.SetActive(false); }

		if (Inv.SPECIAL[3] == true) { Tool1.gameObject.SetActive(true); }
		else { Tool1.gameObject.SetActive(false); }
	}
	//-----------------------------------------------
	//
	//__________________N_U_G__S_H_O_P__C_H_E_C_K_____
	void CheckNugs(){
		for (int i = 0; i < NugPrices.Length; i++){
			NugPrices[i].color = (Inv.NUGS[i] >= nugMulti) ? Color.black : Color.red;
		}
	}
	//------------------------------------------------------------------
	//
	//_________________S_E_E_D__S_H_O_P__C_H_E_C_K____
	void CheckSeeds(){
		for (int i = 0; i < SeedPrices.Length; i++) {
			SeedPrices[i].color = (Inv.MONEY >= Vars.SEEDPRICES[i]) ? Color.black : Color.red;
		}
	}
	//-------------------------------------------------------------------
	//
	//_____________________S_T_O_R_E___S_H_O_P___C_H_E_C_K_S___________________________________
	void CheckLamps(){
		for (int i = 0; i < Vars.LAMPNAMES.Length; i++) {
			LampPrices[i].color = (Inv.MONEY >= Vars.LAMPPRICES[i]) ? Color.white : Color.red;
		}
	}
	void CheckPots(){
		for (int i = 0; i < Vars.POTNAMES.Length; i++) {
			PotPrices[i].color = (Inv.MONEY >= Vars.POTPRICES[i]) ? Color.white : Color.red;
		}
	}
	void CheckSpecial(){
		int cSpec = 0;
		for(int i = 0;i < Inv.SPECIAL.Length;i++) {
			if(!Inv.SPECIAL[i]){ break; }
			else{ cSpec++; }
		}
		if (cSpec < Inv.SPECIAL.Length) {
			if		(cSpec == 1) { SpecialImage.sprite = Vars.TOOLSPRITES[0]; }
			else if (cSpec == 3) { SpecialImage.sprite = Vars.TOOLSPRITES[1]; }
			else				 { SpecialImage.sprite = Vars.POTSPRITES [3]; }
			SpecialName.text = Vars.SPECIALNAMES [cSpec];
			SpecialDescription.text	= Vars.SPECIALDESCRIPTIONS [cSpec];
			SpecialPrice.text = Vars.SPECIALPRICES [cSpec] + "$";
			specPrice = Vars.SPECIALPRICES [cSpec];
		}
		else {
			SpecialName.text = "Well Done!";
			SpecialImage.sprite = Resources.Load<Sprite>("Images/Misc/waterbottle");
			SpecialDescription.text = "You've bought all the upgrades! Feel like accomplished something?";
			SpecialPrice.text = "SIX GAZILLION$";
		}
		SpecialPrice.color = (Inv.MONEY >= specPrice) ? Color.white : Color.red;
	}
	void CheckWeedMenu(){
		for (int i = 0; i < WEEDS.Length; i++) {
			if (!WEEDS[i].gameObject.activeInHierarchy){MenuWeed[i].gameObject.SetActive(false); }
			else {
				MenuWeed[i].gameObject.SetActive (true);
				if (!WEEDS[i].lamp.gameObject.activeInHierarchy) { MenuWeedLamp[i].gameObject.SetActive(false); }
				else {
					MenuWeedLamp[i].gameObject.SetActive (true);
					MenuWeedLamp[i].sprite = WEEDS[i].lamp.sprite;
				}
				if (!WEEDS[i].pot.gameObject.activeInHierarchy) { MenuWeedPot[i].gameObject.SetActive(false); }
				else {
					MenuWeedPot[i].gameObject.SetActive(true);
					MenuWeedPot[i].sprite = WEEDS[i].pot.sprite;
				}
				if (WEEDS[i].isEmpty) { MenuWeedPlant[i].gameObject.SetActive(false); }
				else {
					MenuWeedPlant[i].gameObject.SetActive(true);
					MenuWeedPlant[i].sprite = WEEDS[i].plant.sprite;
				}

			}
		}
	}
	//----------------------------------------------------------------
	//
	//________________________________S_E_E_D___M_E_N_U________________
	public void SeedChoose(int ID){
		if(WEEDS[ID].isEmpty){
			plantID = ID;
			SeedMenu.gameObject.SetActive(true);
		}
	}
	public void SeedChosen(int ID){
		if (Inv.SEEDS [ID] > 0) {
			Inv.SEEDS[ID]--;

			WEEDS[plantID].seedID = ID;
			WEEDS[plantID].isEmpty = false;
			WEEDS[plantID].seedTime = Vars.SEEDTIMES[ID];
			WEEDS[plantID].timeLeft = Vars.SEEDTIMES[ID];
			WEEDS[plantID].RedrawSprite ();

			SeedMenuTitle.color = Color.white;
			SeedMenuTitle.text = "Choose your seed!";
			SeedMenu.gameObject.SetActive (false);
		} else {
			SeedMenuTitle.color = Color.red;
			SeedMenuTitle.text = "No seeds :(";
		}
	}
	public void SeedMenuClose(){ SeedMenu.gameObject.SetActive(false); }
	//------------------------------------------------------------------
	//
	//____________________________S_E_E_D__S_H_O_P___
	public void BuySeed(int ID){
		if (Inv.MONEY - Vars.SEEDPRICES [ID] >= 0) {
			Inv.MONEY = Inv.MONEY - Vars.SEEDPRICES [ID];
			Inv.SEEDS [ID]++;
		}
	}
	//------------------------
	//
	//______________________________________N_U_G___S_H_O_P___________
	public void SellNug(int ID){
		if (Inv.NUGS[ID] - nugMulti >= 0) {
			Inv.NUGS [ID] -= nugMulti;
			Inv.MONEY = Inv.MONEY + Vars.NUGPRICES[ID] * nugMulti;
			Inv.DisplayUpdate (true, Vars.NUGPRICES [ID] * nugMulti, 0, ID);
		}
	}
	public void NugMultiplier(){
		switch (nugMulti) {
		case 1:
			nugMulti = 10;
			NugMultiText.text = "10x";
			break;
		case 10:
			nugMulti = 50;
			NugMultiText.text = "50x";
			break;
		case 50:
			nugMulti = 1;
			NugMultiText.text = "1x";
			break;
		}
	}
	//-------------------------------------------------------------------------
	//
	//___________________________S_T_O_R_E__S_H_O_P_________
	public void BuyLamp(int ID){
		if(Inv.MONEY - Vars.LAMPPRICES[ID] >= 0){
		lampID = ID;
		partID = 1;
		StoreWeedMenu.gameObject.SetActive (true);
		}
	}
	public void BuyPot(int ID){
		if(Inv.MONEY - Vars.POTPRICES[ID] >= 0){
			potID = ID;
			partID = 0;
			StoreWeedMenu.gameObject.SetActive (true);
		}
	}
	public void BuyUpgrade(int ID){
		switch (partID) {
		case 0: //POT
			if(potID > WEEDS[ID].potID || !WEEDS[ID].isBuilt[1]){ //if pot to buy is not the same, or if there is no pot
				if(Vars.isFirst){ FirstTimeDialogs.stage++;} //ftd
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEEDS[ID].potID = potID;
				WEEDS[ID].pot.gameObject.SetActive(true);
				WEEDS[ID].isBuilt [1] = true;
				WEEDS[ID].RedrawSprite ();
				CloseUpgrade ();
			}
			else { ChooseWeedText.text = "Current or better upgrade is already installed on this plant"; }
			break;
		case 1: //LAMP
			if(lampID > WEEDS[ID].lampID || !WEEDS[ID].isBuilt[2]) {	//if lamp to buy is not the same, or if there is no lamp
				if(Vars.isFirst){ FirstTimeDialogs.stage++;}
				Inv.MONEY -= Vars.LAMPPRICES [lampID];

				WEEDS[ID].lampID = lampID;
				WEEDS[ID].lamp.gameObject.SetActive (true);
				WEEDS[ID].isBuilt[2] = true;
				WEEDS[ID].RedrawSprite ();
				CloseUpgrade ();
			}
			else { ChooseWeedText.text = "Current or better upgrade is already installed on this plant"; }
			break;
		}
	}
	public void CloseUpgrade(){
		ChooseWeedText.text = "Choose the plant you want to upgrade";
		StoreWeedMenu.gameObject.SetActive (false);
	}
	//--------------------------------------------------------
	//
	//__________________________________SPECIAL_BUY__
	public void SpecialButtonClick(){
		int currentSpecial = 0;
		for(int i = 0;i < Inv.SPECIAL.Length;i++) {
			if(!Inv.SPECIAL[i]){ break; }
			else{ currentSpecial++; }
		}
		switch (currentSpecial) {
		case 0:	//Second Pot
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [currentSpecial];
				Inv.SPECIAL [0] = true;
				WEEDS [1].isUnlocked = true;
				WEEDS [1].RedrawSprite ();
			}
			break;
		case 1:	//First Tool
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [1];
				Inv.SPECIAL [1] = true;
			}
			break;
		case 2:	//Third Pot
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [currentSpecial];
				Inv.SPECIAL [2] = true;
				WEEDS [2].isUnlocked = true;
				WEEDS [2].RedrawSprite ();
			}
			break;
		case 3:	//Second Tool
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [1];
				Inv.SPECIAL [3] = true;
			}
			break;
		case 4:	//Fourth Pot
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [currentSpecial];
				Inv.SPECIAL [4] = true;
				WEEDS[3].isUnlocked = true;
				WEEDS[3].RedrawSprite ();
			}
			break;
		case 5:	//Fifth Pot
			if (Inv.MONEY >= Vars.SPECIALPRICES [currentSpecial]) {
				Inv.MONEY -= Vars.SPECIALPRICES [currentSpecial];
				Inv.SPECIAL [5] = true;
				WEEDS [4].isUnlocked = true;
				WEEDS [4].RedrawSprite ();
			}
			break;
		case 6:
			Debug.Log ("IT'S THE LAST UPGRADE");
			break;
		}
	}
	//------------------------------------------------------
}