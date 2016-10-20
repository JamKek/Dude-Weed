using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstTimeDialogs : MonoBehaviour {

	public RectTransform FTDPanelBlocker;
	public RectTransform FTDPanelBlocker2;
	public RectTransform FTDPanel;
	public Text	FTDText;


	public static int stage;

	void Start(){
		stage = 0;
	}

	void OnEnable(){
		Dialog ();
	}

	public void BonusClix(){
		if(Vars.isFirst){
			Dialog ();
		}
		Debug.Log ("Bonus clicked");
		Debug.Log(stage);
	}

	public void BonusClicked(){
		if(Vars.isFirst){
		stage++;
		Dialog ();
		}
		Debug.Log ("Bonus clicked");
		Debug.Log(stage);
	}

	public void OnClicc(){
		stage++;
		Dialog ();
	}

	public void RectOffset(RectTransform rT,float left,float top,float right,float bottom){
		rT.offsetMin = new Vector2 (left,bottom);
		rT.offsetMax = new Vector2 (-right,-top);
	}

	public void	Dialog(){
		Debug.Log ("stage: " + stage);

		switch (stage) {
		case 0:
			FTDText.text = "Welcome to Dude WEED LMAOOOOO \n (tap me)";
			FTDPanel.anchoredPosition = new Vector2 (0, 0);

			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 1:
			FTDText.text = "This is a game about growing weed!";
			FTDPanel.anchoredPosition = new Vector2 (0, 0);

			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 2:
			FTDText.text = "But you have no weed nor you can grow any right now!";
			FTDPanel.anchoredPosition = new Vector2(0,0);

			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 3:
			FTDText.text = "What a shame. Let's fix this!";
			FTDPanel.anchoredPosition = new Vector2(0,0);

			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 4:
			FTDText.text = "You have a nice place to grow, but you lack a pot and a lamp";
			FTDPanel.anchoredPosition = new Vector2 (345, 0);

			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 5:
			FTDText.text = "Let's go outside and buy them!";
			FTDPanel.anchoredPosition3D = new Vector2 (182, -232);
			FTDPanel.GetComponent<Button> ().interactable = false;

			RectOffset (FTDPanelBlocker,0,0,0,60);
			RectOffset (FTDPanelBlocker2,0,0,178,0);
			break;
		case 6:
			FTDText.text = "This is your house! Now go to the city...";
			FTDPanel.anchoredPosition = new Vector2 (182, -232);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 150, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 260);
			break;
		case 7:
			FTDText.text = "Welcome to the city! We need a pot and a lamp, so go to the upgrade shop!";
			FTDPanel.anchoredPosition3D = new Vector2 (256, -128);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 1040, 0);
			RectOffset (FTDPanelBlocker2, 540, 0, 0, 0);
			break;
		case 8:
			FTDText.text = "Tap on the lamp or pot you can buy right now, and select the plant you have unlocked";
			FTDPanel.anchoredPosition3D = new Vector2 (-380, -240);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 1280, 0);
			RectOffset (FTDPanelBlocker2, 1280, 0, 0, 0);
			break;
		case 9:
			FTDText.text = "One more left...";
			FTDPanel.anchoredPosition3D = new Vector2 (-380, -240);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 1280, 0);
			RectOffset (FTDPanelBlocker2, 1280, 0, 0, 0);
			break;
		case 10:
			FTDText.text = "Good job! Now click the back button to go back to the city and head to the seed shop...";
			FTDPanel.anchoredPosition3D = new Vector2 (0, 0);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 200, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 200, 0, 0, 0);
			break;
		case 11:
			FTDText.text = "We need a seed to get some weed!";
			FTDPanel.anchoredPosition3D = new Vector2 (-380, -240);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 1280, 0);
			RectOffset (FTDPanelBlocker2, 1280, 0, 0, 0);
			break;
		case 12:
			FTDText.text = "We need a seed to get some weed!";
			FTDPanel.anchoredPosition3D = new Vector2 (-380, -240);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 1280, 0);
			RectOffset (FTDPanelBlocker2, 1280, 0, 0, 0);
			break;
		case 13:
			FTDText.text = "All ready! Go back home now... \n (by tapping back button)";
			FTDPanel.anchoredPosition3D = new Vector2 (-380, -240);
			FTDPanel.GetComponent<Button> ().interactable = false;
			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 14:
			//in travelscript;
			break;
		case 15:
			FTDText.text = "You're off to grow the dankest buds ever!\n" +
			"Remember to water your plants by clicking the water bottle! Good luck!";
			FTDPanel.anchoredPosition3D = new Vector2 (0, 0);
			FTDPanel.GetComponent<Button> ().interactable = true;
			RectOffset (FTDPanelBlocker, 0, 0, 0, 0);
			RectOffset (FTDPanelBlocker2, 0, 0, 0, 0);
			break;
		case 16:
			FTDPanel.gameObject.SetActive (false);
			FTDPanelBlocker.gameObject.SetActive (false);
			FTDPanelBlocker2.gameObject.SetActive (false);
			Vars.isFirst = false;
			break;
		}
	}
}
