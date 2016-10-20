using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {
	
	public Weed WEED0;
	public Weed WEED1;
	public Weed WEED2;
	public Weed WEED3;
	public Weed WEED4;

	//============================SEED_SHOP
	public Button	BuySeed0;
	public Text 	BuySeed0Name;
	public Text 	BuySeed0Time;
	public Text 	BuySeed0Worth;
	public Text 	BuySeed0Price;
	public Button	BuySeed1;
	public Text 	BuySeed1Name;
	public Text 	BuySeed1Time;
	public Text 	BuySeed1Worth;
	public Text 	BuySeed1Price;
	public Button	BuySeed2;
	public Text 	BuySeed2Name;
	public Text 	BuySeed2Time;
	public Text 	BuySeed2Worth;
	public Text 	BuySeed2Price;
	//=============================SEED_SHOP

	//===============================NUG_SHOP
	public Text		NugMultiText;
	public Button	SellNug0;
	public Text 	SellNug0Name;
	public Text 	SellNug0Price;
	public Button	SellNug1;
	public Text 	SellNug1Name;
	public Text 	SellNug1Price;
	public Button	SellNug2;
	public Text 	SellNug2Name;
	public Text 	SellNug2Price;
	//===============================NUG_SHOP

	//===============================STORE_SHOP
	public RectTransform ChooseWeed;
	public Text	ChooseWeedText;

	public Button	Lamp0;
	public Text		Lamp0Name;
	public Text		Lamp0Quality;
	public Text		Lamp0Price;
	public Button	Lamp1;
	public Text		Lamp1Name;
	public Text		Lamp1Quality;
	public Text		Lamp1Price;

	public Button	Pot0;
	public Text		Pot0Name;
	public Text		Pot0Quality;
	public Text		Pot0Price;
	public Button	Pot1;
	public Text		Pot1Name;
	public Text		Pot1Quality;
	public Text		Pot1Price;
	public Button	Pot2;
	public Text		Pot2Name;
	public Text		Pot2Quality;
	public Text		Pot2Price;
	public Button	Pot3;
	public Text		Pot3Name;
	public Text		Pot3Quality;
	public Text		Pot3Price;

	public Button	UpWeed0;
	public Image	UpWeed0Lamp;
	public Image	UpWeed0Plant; 
	public Image	UpWeed0Pot;

	public Button	UpWeed1;
	public Image	UpWeed1Lamp;
	public Image	UpWeed1Plant; 
	public Image	UpWeed1Pot;

	public Button	UpWeed2;
	public Image	UpWeed2Lamp;
	public Image	UpWeed2Plant; 
	public Image	UpWeed2Pot;

	public Button	UpWeed3;
	public Image	UpWeed3Lamp;
	public Image	UpWeed3Plant; 
	public Image	UpWeed3Pot;

	public Button	UpWeed4;
	public Image	UpWeed4Lamp;
	public Image	UpWeed4Plant; 
	public Image	UpWeed4Pot;

	public Button	SpecialButton;
	public Text		SpecialName; 
	public Image	SpecialImage;
	public Text		SpecialDescription;
	public Text		SpecialPrice;

	public Button	Tool0;
	public Button	Tool1;
	//==============================STORE_SHOP

	//==========================SeedMenu
	public ScrollRect SeedMenu;
	public RectTransform SeedMenuPanel;
	public Text SeedMenuText;
	Text[] SeedMenuAmounts;
	//=========================SeedMenu

	int plantID;
	int lampID;
	int potID;
	int partID;
	int nugMulti;
	int	specPrice;

	void Start () {
		BuySeed0Name.text	= Vars.SEEDNAMES [0] + " seed";
		BuySeed0Price.text	= Vars.SEEDPRICES[0] + "$";					//===TODO
		BuySeed0Time.text	= "Grow Time: " + Vars.SEEDTIMES [0] + "s";
		BuySeed0Worth.text	= "Nug worth: " + Vars.NUGPRICES [0] + "$";
		BuySeed1Name.text	= Vars.SEEDNAMES [1] + " seed";
		BuySeed1Price.text	= Vars.SEEDPRICES[1] + "$";
		BuySeed1Time.text	= "Grow Time: " + Vars.SEEDTIMES [1] + "s";
		BuySeed1Worth.text	= "Nug worth: " + Vars.NUGPRICES [1] + "$";
		BuySeed2Name.text	= Vars.SEEDNAMES [2] + " seed";
		BuySeed2Price.text	= Vars.SEEDPRICES[2] + "$";
		BuySeed2Time.text	= "Grow Time: " + Vars.SEEDTIMES [2] + "s";
		BuySeed2Worth.text	= "Nug worth: " + Vars.NUGPRICES [2] + "$";

		nugMulti = 1;
		NugMultiText.text = "1x";
		SellNug0Name.text	= Vars.SEEDNAMES [0] + " nug";
		SellNug0Price.text	= "Sell price: " + Vars.NUGPRICES [0] + "$";
		SellNug1Name.text	= Vars.SEEDNAMES [1] + " nug";
		SellNug1Price.text	= "Sell price: " + Vars.NUGPRICES [1] + "$";
		SellNug2Name.text	= Vars.SEEDNAMES [2] + " nug";
		SellNug2Price.text	= "Sell price: " + Vars.NUGPRICES [2] + "$";

		Lamp0Name.text		= Vars.LAMPNAMES [0];
		Lamp0Quality.text	= "Quality rating: " + Vars.LAMPMULTIS [0] + "x";
		Lamp0Price.text		= Vars.LAMPPRICES [0] + "$";
		Lamp1Name.text		= Vars.LAMPNAMES [1];
		Lamp1Quality.text	= "Quality rating: " + Vars.LAMPMULTIS [1] + "x";
		Lamp1Price.text		= Vars.LAMPPRICES [1] + "$";

		Pot0Name.text		= Vars.POTNAMES [0];
		Pot0Quality.text	= "Quality rating: " + Vars.POTMULTIS [0] + "x";
		Pot0Price.text		= Vars.POTPRICES [0] + "$";
		Pot1Name.text		= Vars.POTNAMES [1];
		Pot1Quality.text	= "Quality rating: " + Vars.POTMULTIS [1] + "x";
		Pot1Price.text		= Vars.POTPRICES [1] + "$";
		Pot2Name.text		= Vars.POTNAMES [2];
		Pot2Quality.text	= "Quality rating: " + Vars.POTMULTIS [2] + "x";
		Pot2Price.text		= Vars.POTPRICES [2] + "$";
		Pot3Name.text		= Vars.POTNAMES [3];
		Pot3Quality.text	= "Quality rating: " + Vars.POTMULTIS [3] + "x";
		Pot3Price.text		= Vars.POTPRICES [3] + "$";
		Tool0.gameObject.SetActive (false);
		Tool1.gameObject.SetActive (false);

		plantID = 0;
		lampID = 0;
		potID = 0;
		partID = 0;
		specPrice = 0;
		ChooseWeedText.text = "Choose the plant you want to upgrade";
		ChooseWeed.gameObject.SetActive (false);
		SeedMenu.gameObject.SetActive (false);
		SeedMenuAmounts = SeedMenuPanel.GetComponentsInChildren<Text>();
	}

	void Update () {
		//===========================Update numbers, buying availability
		if(TravelScript.PLACE == 0){
			for (int s = 0;s < SeedMenuAmounts.Length;s++)
			{
				SeedMenuAmounts[s].text = Inv.SEEDS[s].ToString();
			}
		}
		else if(TravelScript.PLACE == 3){
			if (Inv.SPECIAL [1] == true) {
				Tool0.gameObject.SetActive (true);
			} else { Tool0.gameObject.SetActive (false); }

			if (Inv.SPECIAL [3] == true) {
				Tool1.gameObject.SetActive (true);
			} else { Tool1.gameObject.SetActive (false); }
		}
		else if(TravelScript.PLACE == 4){
			if (Inv.NUGS[0] >= nugMulti) {
				SellNug0Price.color = Color.black;
			} else { SellNug0Price.color = Color.red; }
			if (Inv.NUGS[1] >= nugMulti) {
				SellNug1Price.color = Color.black;
			} else { SellNug1Price.color = Color.red; }
			if (Inv.NUGS[2] >= nugMulti) {
				SellNug2Price.color = Color.black;
			} else { SellNug2Price.color = Color.red; }
		}
		else if (TravelScript.PLACE == 5) {
			if (Inv.MONEY >= Vars.SEEDPRICES[0]) {
				BuySeed0Price.color = Color.black;
			} else { BuySeed0Price.color = Color.red; }
			if (Inv.MONEY >= Vars.SEEDPRICES[1]) {
				BuySeed1Price.color = Color.black;
			} else { BuySeed1Price.color = Color.red; }
			if (Inv.MONEY >= Vars.SEEDPRICES[2]) {
				BuySeed2Price.color = Color.black;
			} else { BuySeed2Price.color = Color.red; }
		}
		else if (TravelScript.PLACE == 6) {
			if (WEED0.gameObject.activeInHierarchy) {
				UpWeed0.gameObject.SetActive (true);
				if (WEED0.lamp.gameObject.activeInHierarchy) { UpWeed0Lamp.gameObject.SetActive (true); UpWeed0Lamp.sprite = WEED0.lamp.sprite; }
														else { UpWeed0Lamp.gameObject.SetActive(false); }
				if (WEED0.pot.gameObject.activeInHierarchy) { UpWeed0Pot.gameObject.SetActive (true); UpWeed0Pot.sprite = WEED0.pot.sprite; }
														else { UpWeed0Pot.gameObject.SetActive(false); }
				if (WEED0.isBuilt[0]) { UpWeed0Plant.gameObject.SetActive (true); UpWeed0Plant.sprite = WEED0.plant.sprite; }
														else { UpWeed0Plant.gameObject.SetActive (false); }
			} else { UpWeed0.gameObject.SetActive (false); }
			if (WEED1.gameObject.activeInHierarchy) {
				UpWeed1.gameObject.SetActive (true);
				if (WEED1.lamp.gameObject.activeInHierarchy) { UpWeed1Lamp.gameObject.SetActive (true); UpWeed1Lamp.sprite = WEED1.lamp.sprite; }
														else { UpWeed1Lamp.gameObject.SetActive(false); }
				if (WEED1.pot.gameObject.activeInHierarchy) { UpWeed1Pot.gameObject.SetActive (true); UpWeed1Pot.sprite = WEED1.pot.sprite; }
														else { UpWeed1Pot.gameObject.SetActive(false); }
				if (WEED1.isBuilt[0]) { UpWeed1Plant.gameObject.SetActive (true); UpWeed1Plant.sprite = WEED1.plant.sprite; }
														else { UpWeed1Plant.gameObject.SetActive (false); }
			} else { UpWeed1.gameObject.SetActive (false); }
			if (WEED2.gameObject.activeInHierarchy) {
				UpWeed2.gameObject.SetActive (true);
				if (WEED2.lamp.gameObject.activeInHierarchy) { UpWeed2Lamp.gameObject.SetActive (true); UpWeed2Lamp.sprite = WEED2.lamp.sprite; }
														else { UpWeed2Lamp.gameObject.SetActive(false); }
				if (WEED2.pot.gameObject.activeInHierarchy) { UpWeed2Pot.gameObject.SetActive (true); UpWeed2Pot.sprite = WEED2.pot.sprite; }
														else { UpWeed2Pot.gameObject.SetActive(false); }
				if (WEED2.isBuilt[0]) { UpWeed2Plant.gameObject.SetActive (true); UpWeed2Plant.sprite = WEED2.plant.sprite; }
														else { UpWeed2Plant.gameObject.SetActive (false); }
			} else { UpWeed2.gameObject.SetActive (false); }
			if (WEED3.gameObject.activeInHierarchy) {
				UpWeed3.gameObject.SetActive (true);
				if (WEED3.lamp.gameObject.activeInHierarchy) { UpWeed3Lamp.gameObject.SetActive (true); UpWeed3Lamp.sprite = WEED3.lamp.sprite; }
														else { UpWeed3Lamp.gameObject.SetActive(false); }
				if (WEED3.pot.gameObject.activeInHierarchy) { UpWeed3Pot.gameObject.SetActive (true); UpWeed3Pot.sprite = WEED3.pot.sprite; }
														else { UpWeed3Pot.gameObject.SetActive(false); }
				if (WEED3.isBuilt[0]) { UpWeed3Plant.gameObject.SetActive (true); UpWeed3Plant.sprite = WEED3.plant.sprite; }
														else { UpWeed3Plant.gameObject.SetActive (false); }
			} else { UpWeed3.gameObject.SetActive (false); }
			if (WEED4.gameObject.activeInHierarchy) {
				UpWeed4.gameObject.SetActive (true);
				if (WEED4.lamp.gameObject.activeInHierarchy) { UpWeed4Lamp.gameObject.SetActive (true); UpWeed4Lamp.sprite = WEED4.lamp.sprite; }
														else { UpWeed4Lamp.gameObject.SetActive(false); }
				if (WEED4.pot.gameObject.activeInHierarchy) { UpWeed4Pot.gameObject.SetActive (true); UpWeed4Pot.sprite = WEED4.pot.sprite; }
														else { UpWeed4Pot.gameObject.SetActive(false); }
				if (WEED4.isBuilt[0]) { UpWeed4Plant.gameObject.SetActive (true); UpWeed4Plant.sprite = WEED4.plant.sprite; }
														else { UpWeed4Plant.gameObject.SetActive (false); }
			} else { UpWeed4.gameObject.SetActive (false); }

			if (Inv.MONEY >= Vars.LAMPPRICES [0]) {
				Lamp0Price.color = Color.white;
			} else {Lamp0Price.color = Color.red;}
			if (Inv.MONEY >= Vars.LAMPPRICES [1]) {
				Lamp1Price.color = Color.white;
			} else {Lamp1Price.color = Color.red;}
			if (Inv.MONEY >= Vars.POTPRICES [0]) {
				Pot0Price.color = Color.white;
			} else {Pot0Price.color = Color.red;}
			if (Inv.MONEY >= Vars.POTPRICES [1]) {
				Pot1Price.color = Color.white;
			} else {Pot1Price.color = Color.red;}
			if (Inv.MONEY >= Vars.POTPRICES [2]) {
				Pot2Price.color = Color.white;
			} else {Pot2Price.color = Color.red;}
			if (Inv.MONEY >= Vars.POTPRICES [3]) {
				Pot3Price.color = Color.white;
			} else {Pot3Price.color = Color.red;}

			if (Inv.SPECIAL [0] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Pots/pot_3");
				SpecialName.text = Vars.SPECIALNAMES [0];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [0];
				SpecialPrice.text = Vars.SPECIALPRICES [0] + "$";
				specPrice = Vars.SPECIALPRICES [0];
			} else if (Inv.SPECIAL [1] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Tools/tool_0");
				SpecialName.text = Vars.SPECIALNAMES [1];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [1];
				SpecialPrice.text = Vars.SPECIALPRICES [1] + "$";
				specPrice = Vars.SPECIALPRICES [1];
			} else if (Inv.SPECIAL [2] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Pots/pot_3");
				SpecialName.text = Vars.SPECIALNAMES [2];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [2];
				SpecialPrice.text = Vars.SPECIALPRICES [2] + "$";
				specPrice = Vars.SPECIALPRICES [2];
			} else if (Inv.SPECIAL [3] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Tools/tool_1");
				SpecialName.text = Vars.SPECIALNAMES [3];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [3];
				SpecialPrice.text = Vars.SPECIALPRICES [3] + "$";
				specPrice = Vars.SPECIALPRICES [3];
			} else if (Inv.SPECIAL [4] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Pots/pot_3");
				SpecialName.text = Vars.SPECIALNAMES [4];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [4];
				SpecialPrice.text = Vars.SPECIALPRICES [4] + "$";
				specPrice = Vars.SPECIALPRICES [4];
			} else if (Inv.SPECIAL [5] != true) {
				SpecialImage.sprite = Resources.Load<Sprite> ("Images/Pots/pot_3");
				SpecialName.text = Vars.SPECIALNAMES [5];
				SpecialDescription.text = Vars.SPECIALDESCRIPTIONS [5];
				SpecialPrice.text = Vars.SPECIALPRICES [5] + "$";
				specPrice = Vars.SPECIALPRICES [5];
			} else {
				SpecialName.text = "Well Done!";
				SpecialImage.sprite = Resources.Load<Sprite>("Images/Misc/waterbottle");
				SpecialDescription.text = "You've bought all the upgrades! Feel like accomplished something?";
				SpecialPrice.text = "420$";
			}
			if(Inv.MONEY >= specPrice){
				SpecialPrice.color = Color.white;
			} else { SpecialPrice.color = Color.red; }
		}


	}
	//=================endof UPDATE


	//============================================================SEEDMENU
	public void SeedChoose(int ID){ //id is the pot id
		switch(ID){
		case 0:
			if (WEED0.isEmpty) {
				SeedMenu.gameObject.SetActive (true);
				plantID = ID;
			} else {Debug.Log("WARNING: SeedChoose" + ID);}
			break;

		case 1:
			if (WEED1.isEmpty) {
				SeedMenu.gameObject.SetActive (true);
				plantID = ID;
			} else {Debug.Log("WARNING: SeedChoose" + ID);}
			break;

		case 2:
			if (WEED2.isEmpty) {
				SeedMenu.gameObject.SetActive (true);
				plantID = ID;
			} else {Debug.Log("WARNING: SeedChoose" + ID);}
			break;

		case 3:
			if (WEED3.isEmpty) {
				SeedMenu.gameObject.SetActive (true);
				plantID = ID;
			} else {Debug.Log("WARNING: SeedChoose" + ID);}
			break;

		case 4:
			if (WEED4.isEmpty) {
				SeedMenu.gameObject.SetActive (true);
				plantID = ID;
			} else {Debug.Log("WARNING: SeedChoose" + ID);}
			break;
		}
	}
	public void SeedChosen(int ID){ //id is the seed id
		switch (plantID) {
		case 0:
			if (Inv.SEEDS[ID] > 0) {
				Inv.SEEDS[ID]--;
				WEED0.seedID = ID;
				WEED0.isEmpty = false;
				WEED0.seedTime = Vars.SEEDTIMES [ID];
				WEED0.timeLeft = WEED0.seedTime;
				WEED0.RedrawSprite ();
				WEED0.pot.GetComponent<Button> ().interactable = false;
				SeedMenuText.color = Color.white;
				SeedMenuText.text = "Choose your seed!";
				SeedMenu.gameObject.SetActive (false);
			} else {
				SeedMenuText.color = Color.red;
				SeedMenuText.text = "No seeds :(";
			}
			break;
		case 1:
			if (Inv.SEEDS[ID] > 0) {
				Inv.SEEDS[ID]--;
				WEED1.seedID = ID;
				WEED1.isEmpty = false;
				WEED1.seedTime = Vars.SEEDTIMES [ID];
				WEED1.timeLeft = WEED1.seedTime;
				WEED1.RedrawSprite ();
				WEED1.pot.GetComponent<Button> ().interactable = false;
				SeedMenuText.color = Color.white;
				SeedMenuText.text = "Choose your seed!";
				SeedMenu.gameObject.SetActive (false);
			} else {
				SeedMenuText.color = Color.red;
				SeedMenuText.text = "No seeds :(";
			}
			break;
		case 2:
			if (Inv.SEEDS[ID] > 0) {
				Inv.SEEDS[ID]--;
				WEED2.seedID = ID;
				WEED2.isEmpty = false;
				WEED2.seedTime = Vars.SEEDTIMES [ID];
				WEED2.timeLeft = WEED2.seedTime;
				WEED2.RedrawSprite ();
				WEED2.pot.GetComponent<Button> ().interactable = false;
				SeedMenuText.color = Color.white;
				SeedMenuText.text = "Choose your seed!";
				SeedMenu.gameObject.SetActive (false);
			} else {
				SeedMenuText.color = Color.red;
				SeedMenuText.text = "No seeds :(";
			}
			break;
		case 3:
			if (Inv.SEEDS[ID] > 0) {
				Inv.SEEDS[ID]--;
				WEED3.seedID = ID;
				WEED3.isEmpty = false;
				WEED3.seedTime = Vars.SEEDTIMES [ID];
				WEED3.timeLeft = WEED3.seedTime;
				WEED3.RedrawSprite ();
				WEED3.pot.GetComponent<Button> ().interactable = false;
				SeedMenuText.color = Color.white;
				SeedMenuText.text = "Choose your seed!";
				SeedMenu.gameObject.SetActive (false);
			} else {
				SeedMenuText.color = Color.red;
				SeedMenuText.text = "No seeds :(";
			}
			break;
		case 4:
			if (Inv.SEEDS[ID] > 0) {
				Inv.SEEDS[ID]--;
				WEED4.seedID = ID;
				WEED4.isEmpty = false;
				WEED4.seedTime = Vars.SEEDTIMES [ID];
				WEED4.timeLeft = WEED4.seedTime;
				WEED4.RedrawSprite ();
				WEED4.pot.GetComponent<Button> ().interactable = false;
				SeedMenuText.color = Color.white;
				SeedMenuText.text = "Choose your seed!";
				SeedMenu.gameObject.SetActive (false);
			} else {
				SeedMenuText.color = Color.red;
				SeedMenuText.text = "No seeds :(";
			}
			break;
		}
	}
	public void SeedMenuClose(){
		SeedMenu.gameObject.SetActive(false);
	}
	//==============================================SEEDMENU


	//===============================================STORE_SHOP
	public void BuyLamp(int ID){
		if(Inv.MONEY - Vars.LAMPPRICES[ID] >= 0){
		lampID = ID;
		partID = 1;
		ChooseWeed.gameObject.SetActive (true);
		}
	}
	public void BuyPot(int ID){
		if(Inv.MONEY - Vars.POTPRICES[ID] >= 0){
			potID = ID;
			partID = 0;
			ChooseWeed.gameObject.SetActive (true);
		}
	}
	public void BuyUpgrade(int ID){ //parts:  0=pot 1=lamp
		switch (ID) { //id is the selected plant
		case 0:
			if ( (partID == 0 && WEED0.potID < potID) || (partID==0 && !WEED0.isBuilt[0]) ) {
				if (Vars.isFirst) { FirstTimeDialogs.stage++; }
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEED0.potID = potID;
				WEED0.pot.gameObject.SetActive (true);
				WEED0.RedrawSprite ();
				CloseUpgrade ();
			}
			else if ( (partID == 1 && WEED0.lampID < lampID) || (partID == 1 && !WEED0.isBuilt[0]) ) {
				if (Vars.isFirst) { FirstTimeDialogs.stage++; }
				Inv.MONEY -= Vars.LAMPPRICES [lampID];
				WEED0.lampID = lampID;
				WEED0.lamp.gameObject.SetActive (true);
				WEED0.RedrawSprite ();
				CloseUpgrade ();
			}
			else {
				ChooseWeedText.text = "Current or better upgrade is already installed on this plant";
			}
			break;

		case 1:
			if ( (partID == 0 && WEED1.potID < potID) || (partID==0 && !WEED1.isBuilt[0]) ) {
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEED1.potID = potID;
				WEED1.pot.gameObject.SetActive (true);
				WEED1.RedrawSprite ();
				CloseUpgrade ();
			}
			else if ( (partID == 1 && WEED1.lampID < lampID) || (partID==1 && !WEED1.isBuilt[0]) ) {
				Inv.MONEY -= Vars.LAMPPRICES [lampID];
				WEED1.lampID = lampID;
				WEED1.lamp.gameObject.SetActive (true);
				WEED1.RedrawSprite ();
				CloseUpgrade ();
			}
			else {
				ChooseWeedText.text = "Current or better upgrade is already installed on this plant";
			}
			break;

		case 2:
			if ( (partID == 0 && WEED2.potID < potID) || (partID==0 && !WEED2.isBuilt[0]) ) {
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEED2.potID = potID;
				WEED2.pot.gameObject.SetActive (true);
				WEED2.RedrawSprite ();
				CloseUpgrade ();
			}
			else if ( (partID == 1 && WEED2.lampID < lampID) || (partID==1 && !WEED2.isBuilt[0]) ) {
				Inv.MONEY -= Vars.LAMPPRICES [lampID];
				WEED2.lampID = lampID;
				WEED2.lamp.gameObject.SetActive (true);
				WEED2.RedrawSprite ();
				CloseUpgrade ();
			}
			else {
				ChooseWeedText.text = "Current or better upgrade is already installed on this plant";
			}
			break;

		case 3:
			if ( (partID == 0 && WEED3.potID < potID) || (partID==0 && !WEED3.isBuilt[0]) ) {
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEED3.potID = potID;
				WEED3.pot.gameObject.SetActive (true);
				WEED3.RedrawSprite ();
				CloseUpgrade ();
			}
			else if ( (partID == 1 && WEED3.lampID < lampID) || (partID==1 && !WEED3.isBuilt[0]) ) {
				Inv.MONEY -= Vars.LAMPPRICES [lampID];
				WEED3.lampID = lampID;
				WEED3.lamp.gameObject.SetActive (true);
				WEED3.RedrawSprite ();
				CloseUpgrade ();
			}
			else {
				ChooseWeedText.text = "Current or better upgrade is already installed on this plant";
			}
			break;

		case 4:
			if ( (partID == 0 && WEED4.potID < potID) || (partID==0 && !WEED4.isBuilt[0]) ) {
				Inv.MONEY -= Vars.POTPRICES[potID];
				WEED4.potID = potID;
				WEED4.pot.gameObject.SetActive (true);
				WEED4.RedrawSprite ();
				CloseUpgrade ();
			}
			else if ( (partID == 1 && WEED4.lampID < lampID) || (partID==4 && !WEED4.isBuilt[0]) ) {
				Inv.MONEY -= Vars.LAMPPRICES [lampID];
				WEED4.lampID = lampID;
				WEED4.lamp.gameObject.SetActive (true);
				WEED4.RedrawSprite ();
				CloseUpgrade ();
			}
			else {
				ChooseWeedText.text = "Current or better upgrade is already installed on this plant";
			}
			break;
		}
	}
	public void CloseUpgrade(){
		ChooseWeedText.text = "Choose the plant you want to upgrade";
		ChooseWeed.gameObject.SetActive (false);
	}
	//=============================================STORE_SHOP

	//=========================================SEED NUG SHOP
	public void BuySeed(int ID){
		if (Inv.MONEY - Vars.SEEDPRICES [ID] >= 0) {
			Inv.MONEY = Inv.MONEY - Vars.SEEDPRICES [ID];
			Inv.SEEDS [ID]++;
		}
	}
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
	//=========================================SEED NUG SHOP

	//SPECIAL BUY
	public void SpecialButtonClick(){
		if			(Inv.SPECIAL [0] != true && Inv.MONEY >= Vars.SPECIALPRICES [0] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [0];
			Inv.SPECIAL [0] = true;

			WEED1.gameObject.SetActive (true);
			WEED1.isEmpty = true;
			WEED1.isGrown = false;
			WEED1.isUnlocked = true;
			WEED1.RedrawSprite ();
		}
		else if		(Inv.SPECIAL [1] != true && Inv.MONEY >= Vars.SPECIALPRICES [1] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [1];
			Inv.SPECIAL [1] = true;

			Tool0.gameObject.SetActive (true);
		}
		else if		(Inv.SPECIAL [2] != true && Inv.MONEY >= Vars.SPECIALPRICES [2] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [2];
			Inv.SPECIAL [2] = true;

			WEED2.gameObject.SetActive(true);
			WEED2.isEmpty = true;
			WEED2.isGrown = false;
			WEED2.isUnlocked = true;
			WEED2.RedrawSprite ();
		}
		else if		(Inv.SPECIAL [3] != true && Inv.MONEY >= Vars.SPECIALPRICES [3] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [3];
			Inv.SPECIAL [3] = true;

			Tool1.gameObject.SetActive (true);
		}
		else if		(Inv.SPECIAL [4] != true && Inv.MONEY >= Vars.SPECIALPRICES [4] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [4];
			Inv.SPECIAL [4] = true;

			WEED3.gameObject.SetActive(true);
			WEED3.isEmpty = true;
			WEED3.isGrown = false;
			WEED3.isUnlocked = true;
			WEED3.RedrawSprite ();
		}
		else if		(Inv.SPECIAL [5] != true && Inv.MONEY >= Vars.SPECIALPRICES [5] ) {
			Inv.MONEY -= Vars.SPECIALPRICES [5];
			Inv.SPECIAL [5] = true;

			WEED4.gameObject.SetActive(true);
			WEED4.isEmpty = true;
			WEED4.isGrown = false;
			WEED4.isUnlocked = true;
			WEED4.RedrawSprite ();

			//Final upgrade
			SpecialName.text = "Well Done!";
			SpecialImage.sprite = Resources.Load<Sprite>("Images/Misc/waterbottle");
			SpecialDescription.text = "You've bought all the upgrades! Feeling like you accomplished something?";
			SpecialPrice.text = "420$";
		}
	}
	//SPECIAL BUY
}
