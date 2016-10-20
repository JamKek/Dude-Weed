using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inv : MonoBehaviour {

	public static float MONEY;
	public static int[] SEEDS	=	{0,0,0,0};
	public static int[] NUGS	=	{0,0,0,0};
	public static bool[]SPECIAL	=	{ false,	false,	false,	false,	false, false}; //TODO 
	//===========================|     2/5        t      3/5      t      4/5      5/5

	public UnityEngine.UI.Text MoneyDisplay;
	public RectTransform invSeeds;
	public RectTransform invNugs;
	Text[] invSeedsButtons;
	Text[] invNugsButtons;
	public Button invOpenButton;
	public static bool isOpened;
	public RectTransform invPanel;
	Vector2 primaryPos = 	new Vector2(0,740);
	Vector2 secondaryPos =	new Vector2(0,0);

	public RectTransform InvUpdatePanel;
	public Image	UpdateNugImage;
	public Text		UpdateNugText;
	public Image	UpdateSeedImage;
	public Text		UpdateSeedText;
	public Text		UpdateMoneyText;

	public static int cSeedID;
	public static int cSeedA;
	public static int cNugA;
	public static int cMonA;
	public static bool cIsMoney;
	public static bool isUpdate;
	public static byte Alpha;
	public Color32 White0 = new Color32(255,255,255,0);
	public Color32 Black0 = new Color32(0,0,0,0);
	public Color32 White100 = new Color32(255,255,255,255);
	public Color32 Black100 = new Color32(0,0,0,255);

	void Start(){
		cSeedID = 0;
		cSeedA = 0;
		cNugA = 0;
		Alpha = 0;
		invPanel.anchoredPosition = primaryPos;
		isOpened = false;
		invSeedsButtons	=	invSeeds.GetComponentsInChildren<Text>();
		invNugsButtons	= 	invNugs.GetComponentsInChildren<Text> ();

		UpdateNugImage.color = White0;
		UpdateSeedImage.color = White0;
		UpdateNugText.color = Black0;
		UpdateSeedText.color = Black0;
		InvUpdatePanel.gameObject.SetActive (false);
		InvUpdatePanel.GetComponent<Image> ().color = White0;
		UpdateNugImage.gameObject.SetActive (false);
		UpdateSeedImage.gameObject.SetActive (false);
		UpdateNugText.gameObject.SetActive (false);
		UpdateSeedText.gameObject.SetActive (false);
		UpdateMoneyText.gameObject.SetActive (false);
	}

	void Update(){
		for (int s = 0;s < invSeedsButtons.Length;s++)
		{
			invSeedsButtons[s].text = SEEDS[s].ToString();
		}
		for (int n = 0;n < invNugsButtons.Length;n++)
		{
			invNugsButtons[n].text = NUGS[n].ToString();
		}
		MoneyDisplay.text = Inv.MONEY.ToString("C");

		if (isUpdate) {
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

		if(InvUpdatePanel.gameObject.activeInHierarchy){
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

	} //==========================endof Update

	public static void DisplayUpdate(bool isMoney,int smAmount,int nugAm,int sID){
		if (isMoney) { cMonA = smAmount; }
		else { cSeedA = smAmount; }
		cIsMoney = isMoney;
		cNugA = nugAm;
		cSeedID = sID;
		isUpdate = true;
	}

	public void InvOpen(){
		if (isOpened) {
			invPanel.anchoredPosition = primaryPos;
			isOpened = false;
		} else {
			invPanel.anchoredPosition = secondaryPos;
			isOpened = true;
		}
	}

}