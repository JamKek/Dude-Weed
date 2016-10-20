using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Weed : MonoBehaviour {

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
	public bool[]	WaterS =	{false,false,false,false};
	public bool		isEmpty;
	public bool		isGrown;
	public bool		isUnlocked;
	public bool[]	isBuilt;

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
		
		if (!isBuilt[0] && pot.gameObject.activeInHierarchy && lamp.gameObject.activeInHierarchy) {
			isBuilt[0] = true;
			if (Vars.isFirst) {
				FirstTimeDialogs.stage++;
			}
			toolbox.gameObject.SetActive (false);
			textTime.text = "Ready to grow!";
			RedrawSprite ();
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
		if (isBuilt[0]) {
			pot.gameObject.SetActive (true);
			lamp.gameObject.SetActive (true);
		}

		if (!isEmpty && !isGrown) {
			if (timeLeft - Time.deltaTime < 1) {
				isGrown = true;
				waterB.gameObject.SetActive (false);
				RedrawSprite ();
			} else {
				timeLeft -= Time.deltaTime;
				growthPerc = 100 - Mathf.RoundToInt(timeLeft / seedTime * 100);
				RedrawSprite();
				DisplayTime ();
			}
			CheckWater();
		}

	}

	//========================================WATER
	void CheckWater(){
		int WaterLevel = 0;

		if		(growthStage == 0 && WaterS [0] == false) { waterB.gameObject.SetActive (true); } 
		else if	(growthStage == 1 && WaterS [1] == false) { waterB.gameObject.SetActive (true); }
		else if	(growthStage == 2 && WaterS [2] == false) { waterB.gameObject.SetActive (true); }
		else if	(growthStage == 3 && WaterS [3] == false) { waterB.gameObject.SetActive (true); }
		else { waterB.gameObject.SetActive (false); }

		foreach(bool b in WaterS){ if(b == true){ WaterLevel++; } }

		switch (WaterLevel) {
		case 0: waterFillLevel.offsetMax = new Vector2(0, -27.5f);
				break;
		case 1: waterFillLevel.offsetMax = new Vector2(0, -69.5f);
				break;
		case 2: waterFillLevel.offsetMax = new Vector2(0, -99.3f);
				break;
		case 3: waterFillLevel.offsetMax = new Vector2(0, -129.3f);
				break;
		}

	}
	public void Water(){
		WaterS[growthStage] = true;
	}
	//========================================WATER


	void DisplayTime(){
		if (timeLeft / 3600 > 1) { //hours:minutes:seconds
			textTime.text = Mathf.FloorToInt(timeLeft/3600) + "h "
							+ Mathf.FloorToInt( (timeLeft%3600)/60 ) + "min";
		} else if (timeLeft / 60 > 1){ //minutes:seconds
			textTime.text = Mathf.FloorToInt(timeLeft/60) + " min "
							+ Mathf.FloorToInt(timeLeft%60) + " sec";
		} else { //seconds
			textTime.text = Mathf.FloorToInt(timeLeft) + " sec";
		}
	}


	//=============================================== ___ M U L T I
	public void PlantClick(){
		if (isGrown) {
			float watMult = 0f; //water multiplier
			foreach(bool b in WaterS){ if(b == true){ watMult += 0.33f;} }

			float eqMulti	= (Vars.POTMULTIS [potID] + Vars.LAMPMULTIS [lampID] + watMult) / 3;
			float rndSeed	= Random.Range (Vars.SEEDMINMAX[seedID,0], Vars.SEEDMINMAX[seedID,1] );
			float rndNug	= Random.Range (Vars.NUGMINMAX [seedID,0], Vars.NUGMINMAX [seedID,1]);

			int SeedAmount	= Mathf.RoundToInt(rndSeed * eqMulti);
			int NugAmount	= Mathf.RoundToInt(rndNug  * eqMulti);

			Inv.DisplayUpdate (false, SeedAmount, NugAmount, seedID);
			Inv.NUGS [seedID]	+= NugAmount;
			Inv.SEEDS [seedID]	+= SeedAmount;
			isGrown = false;
			isEmpty = true;
			for (int i = 0; i < 4; i++) { WaterS [i] = false; }
			RedrawSprite ();
			pot.GetComponent<Button> ().interactable = true;
			textTime.text = "Choose seed";
			textTime.color = Color.white;
		}
	}
		
	public void RedrawSprite(){
		
		if (!isUnlocked) { gameObject.SetActive (false); }
		else {
				gameObject.SetActive (true);

				switch (potID) {
					case 0:	pot.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Pots/pot_0");
						break;
					case 1:	pot.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Pots/pot_1");
						break;
					case 2:	pot.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Pots/pot_2");
						break;
					case 3:	pot.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Pots/pot_3");
						break;
					}

				switch (lampID) {
					case 0:	lamp.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Lamps/lamp_0");
						break;
					case 1:	lamp.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Lamps/lamp_1");
						break;
					}
	
				if (isEmpty) {
					plant.gameObject.SetActive (false);
					pot.GetComponent<Button> ().interactable = true;
				} else {	plant.gameObject.SetActive(true);
						switch(seedID){
						case 0:
							if (isGrown) 									{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_0_100");growthStage = 4;}
							else if	(growthPerc < 25)						{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_0_0");	growthStage = 0;}
							else if	(growthPerc >= 25 && growthPerc < 50)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_0_25");	growthStage = 1;}
							else if	(growthPerc >= 50 && growthPerc < 75)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_0_50");	growthStage = 2;}
							else if	(growthPerc >= 75 && growthPerc < 100)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_0_75");	growthStage = 3;}
							break;
						case 1:
							if (isGrown) 									{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_1_100");growthStage = 4;}
							else if	(growthPerc < 25)						{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_1_0");	growthStage = 0;}
							else if	(growthPerc >= 25 && growthPerc < 50)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_1_25");	growthStage = 1;}
							else if	(growthPerc >= 50 && growthPerc < 75)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_1_50");	growthStage = 2;}
							else if	(growthPerc >= 75 && growthPerc < 100)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_1_75");	growthStage = 3;}
							break;
						case 2:
							if (isGrown) 									{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_2_100");growthStage = 4;}
							else if	(growthPerc < 25)						{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_2_0");	growthStage = 0;}
							else if	(growthPerc >= 25 && growthPerc < 50)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_2_25");	growthStage = 1;}
							else if	(growthPerc >= 50 && growthPerc < 75)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_2_50");	growthStage = 2;}
							else if	(growthPerc >= 75 && growthPerc < 100)	{plant.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Plants/plant_2_75");	growthStage = 3;}
							break;
						}
						
						if (isGrown) {
						textTime.text = "Done!";
						textTime.color = Color.green;
						}
					}
				if (!isBuilt[0]) {
					pot.GetComponent<Button> ().interactable = false;
				}
		}
	}

}