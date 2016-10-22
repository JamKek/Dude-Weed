using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inv : MonoBehaviour {

	//_______________________INVENTORY ITEM ARRAYS
	public static float MONEY;
	public static int[] SEEDS	=	{0,0,0,0};
	public static int[] NUGS	=	{0,0,0,0};
	//
	/// 0:Bad paper,
	public static int[] MISC	=	{0};
	//
	/// 0:Weed1, 1:Tool0, 2:Weed2 3:Tool1 4:Weed3 5:Weed4
	public static bool[]SPECIAL	=	{ false,	false,	false,	false,	false, false};
	//--------------------------------------------------------------------------------
	//
	//____________________________INVENTORY DISPLAYS
	public	Text	MoneyDisplay;
	public	Image[]	invSeedsImages;
	public	Text[]	invSeedsTexts;
	public	Image[]	invNugsImages;
	public	Text[]	invNugsTexts;
	public	Image[]	invMiscImages;
	public	Text[]	invMiscTexts;
	//----------------------------
	//
	//___________________________INV UI
	public	RectTransform InvUpdatePanel;
	public	Image		UpdateNugImage;
	public	Text		UpdateNugText;
	public	Image		UpdateSeedImage;
	public	Text		UpdateSeedText;
	public	Text		UpdateMoneyText;
	//-----------------------------------
	//
	//__________________________VARIABLES
	public static bool isUpdate;//---------------
	public static bool cIsMoney;//	all of these
	public static int cSeedID;//	are for
	public static int cSeedA;//	the update panel
	public static int cNugA;//	amounts n stuff
	public static int cMonA;//----------------
	public static byte Alpha;
	public Color32 White0 = new Color32(255,255,255,0);
	public Color32 Black0 = new Color32(0,0,0,0);
	public Color32 White100 = new Color32(255,255,255,255);
	public Color32 Black100 = new Color32(0,0,0,255);
	//----------------------------------------------------

	/*	=================================
	 	 _____ ____  _____ ____   ____  
		|_   _|_   \|_   _|_  _| |_  _| 
		  | |   |   \ | |   \ \   / /   
		  | |   | |\ \| |    \ \ / /    
		 _| |_ _| |_\   |_    \ ' /     
		|_____|_____|\____|    \_/      
	==================================== */
	void Start(){
		cSeedID = 0;
		cSeedA = 0;
		cNugA = 0;
		Alpha = 0;

		UpdateNugImage.color = White0;
		UpdateSeedImage.color = White0;
		UpdateNugText.color = Black0;
		UpdateSeedText.color = Black0;
		InvUpdatePanel.gameObject.SetActive (false);
		InvUpdatePanel.GetComponent<Image>().color = White0;
		UpdateNugImage.gameObject.SetActive (false);
		UpdateSeedImage.gameObject.SetActive (false);
		UpdateNugText.gameObject.SetActive (false);
		UpdateSeedText.gameObject.SetActive (false);
		UpdateMoneyText.gameObject.SetActive (false);
	}

	void Update(){
		//________________________________________Update sprites and amounts in inv
		MoneyDisplay.text = Inv.MONEY.ToString("C");
		for (int i = 0; i < Vars.SEEDNAMES.Length; i++) {	//Should I set sprites on start?
			invSeedsImages[i].sprite=	Vars.SEEDSPRITES [i];
			invSeedsTexts[i].text	=	SEEDS[i].ToString();
			invNugsImages[i].sprite	=	Vars.NUGSPRITES [i];
			invNugsTexts[i].text	=	NUGS[i].ToString();
		}
		//
		for (int i = 0;i < invMiscImages.Length;i++){
			switch (i) {
			case 0:
				invMiscImages [i].sprite = Resources.Load<Sprite> ("Images/Misc/seedPacket");
				break;
			}
		}
		for (int i = 0; i < invMiscTexts.Length; i++) {
			invMiscTexts[i].text = MISC[i].ToString();
		}
		//-----------------------------------------------
		//
		//__________________________FADE THE UPDATE PANEL
		if (isUpdate) { SetFade(); }
		if (InvUpdatePanel.gameObject.activeInHierarchy){
			if (Alpha > 0) {
				Alpha--;
				Color32 WhiteAlpha = new Color32 (255, 255, 255, Alpha);
				Color32 BlackAlpha = new Color32 (0, 0, 0, Alpha);
				if(cIsMoney){
					UpdateMoneyText.color = BlackAlpha;
				} else {
					UpdateNugImage.color = WhiteAlpha;
					UpdateSeedImage.color = WhiteAlpha;
					UpdateNugText.color = BlackAlpha;
					UpdateSeedText.color = BlackAlpha;
				}
				InvUpdatePanel.GetComponent<Image> ().color = WhiteAlpha;
			} else {
				UpdateNugImage.gameObject.SetActive (false);
				UpdateSeedImage.gameObject.SetActive (false);
				UpdateNugText.gameObject.SetActive (false);
				UpdateSeedText.gameObject.SetActive (false);
				UpdateMoneyText.gameObject.SetActive (false);
				InvUpdatePanel.gameObject.SetActive (false);
				}
		}
		//--------------------------------------------------
	}

	public static void DisplayUpdate(bool isMoney,int smAmount,int nugAm,int sID){
		if (isMoney) { cMonA = smAmount; }
		else { cSeedA = smAmount; }
		cIsMoney = isMoney;
		cNugA = nugAm;
		cSeedID = sID;
		isUpdate = true;
	}
	public void SetFade(){
		if (cIsMoney) {
			UpdateMoneyText.text = cMonA + "$";
			UpdateMoneyText.color = Black100;
			UpdateMoneyText.gameObject.SetActive (true);
			UpdateNugImage.gameObject.SetActive (false);
			UpdateSeedImage.gameObject.SetActive (false);
			UpdateNugText.gameObject.SetActive (false);
			UpdateSeedText.gameObject.SetActive (false);
		} else {
			UpdateNugImage.sprite = Resources.Load<Sprite> ("Images/Nugs/nug_" + cSeedID);
			UpdateSeedImage.sprite = Resources.Load<Sprite> ("Images/Seeds/seed_" + cSeedID);
			UpdateNugText.text = "+" + cNugA;
			UpdateSeedText.text = "+" + cSeedA;
			UpdateNugImage.color = White100;
			UpdateSeedImage.color = White100;
			UpdateNugText.color = Black100;
			UpdateSeedText.color = Black100;
			UpdateNugImage.gameObject.SetActive (true);
			UpdateSeedImage.gameObject.SetActive (true);
			UpdateNugText.gameObject.SetActive (true);
			UpdateSeedText.gameObject.SetActive (true);
			UpdateMoneyText.gameObject.SetActive (false);
		}
		Alpha = 255;
		InvUpdatePanel.gameObject.SetActive (true);
		InvUpdatePanel.GetComponent<Image>().color = White100;
		isUpdate = false;
	}
}