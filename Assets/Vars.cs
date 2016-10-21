using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Vars : MonoBehaviour {

	public Weed WEED0;
	public Weed WEED1;
	public Weed WEED2;
	public Weed WEED3;
	public Weed WEED4;

	public RectTransform FTDPanel;
	public RectTransform FTDPanelBlocker;
	public RectTransform FTDPanelBlocker2;
	string SavePath;

	public Text DebugText;
	public static bool isReady = false;
	public static bool isFirst;

	// Define New Plants Here ==============|	Seed0	Seed1	Seed2
	public static string[]	SEEDNAMES	=	{	"Shit",	"Meh",	"Better"};	//Name of the seed
	public static int[]		SEEDPRICES	=	{	12,		40,		250		};	//Price of the seed
	public static float[]	SEEDTIMES	=	{	120f,	720f,	1800f	};	//How long it grows
	public static int[]		NUGPRICES	=	{	6,		12,		20		};	//Price of nug
	public static int[,]	NUGMINMAX	=	{ 	{0, 4},	{2,10},	{2,12}	};	//MinMax nug amnt on harvest
	public static int[,]	SEEDMINMAX	=	{ 	{1,10},	{0, 4},	{0, 2}	};	//MinMax seed amnt on harvest


	//===========================================================	UPGRADES

	//--------------------Lamps
	public static string[]	LAMPNAMES	=	{	"Shit",	"Cheap"	};	//Name of the lamp
	public static int[] 	LAMPPRICES	=	{	30,		90		};	//Price of the lamp
	public static float[]	LAMPMULTIS	=	{	0.5f,	1f		};	//Lamp multiplier

	//--------------------Pots
	public static string[]	POTNAMES	=	{	"Broken",	"Cheap",	"Plastic",	"Nice"};	//Name of the pot
	public static int[] 	POTPRICES	=	{	5,			60,			200,		500};		//Price of the pot
	public static float[]	POTMULTIS	=	{	0.5f,		1f,			1.5f,		2f };		//Pot multiplier

	//--------------------Specials
	public static string[] 	SPECIALNAMES = {"Second pot!","Rolling machine!","Third pot!","Grinder!","Fifth pot?!","The final pot"};
	public static string[]	SPECIALDESCRIPTIONS = {	"Buy a second pot! \n Why not?! \n Don't stop!",
													"Rolling machine for all your rolling needs!",
													"Third pot for your third eye!",
													"Finally a grinder to grind up all those useless seeds!",
													"A fourth pot?  Why do you need so many?",
													"THIS IS IT'S FINAL FORM"};
	public static int[]		SPECIALPRICES = {10000,	30000, 40000, 80000, 90000, 1000000 };

	//=========================================================== UPGRADES


	//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=FUNCTIONS
	void Start () {
		SavePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saveTokes.dank";
		DebugText.text += " Start ";
		DebugText.text += " SP: " + SavePath + "\n";

		FTDPanel.gameObject.SetActive (false);
		Load();
		isReady = true;
	}

	void OnApplicationFocus(bool hasFocus){
		if (hasFocus && isReady) {
			DebugText.text += " Focus! ";

			Load ();
		}
		if (!hasFocus && isReady) {
			DebugText.text += " FocusLost ";

			Save ();
		}
	}

	public void QuitGame(){
		Save ();
		Application.Quit ();
	}

	//===================SAVE/LOAD FUNCTIONS
	public void Save(){
		DebugText.text += " |Save| \n";
		Debug.Log ("Save() at " + Time.time);

		BinaryFormatter binFor = new BinaryFormatter ();

		if (File.Exists(SavePath) ) {
			File.Delete (SavePath);
		}
			
		FileStream file = File.Create(SavePath);
		PlayerData data = new PlayerData();

		data.sIsFirst	=	isFirst;
		data.sStage =	FirstTimeDialogs.stage;
		data.sPlace	= 	TravelScript.PLACE;
		//-------------------------------------OFFLINE PROGRESS
		data.sDateTime = DateTime.Now;
		//-------------------------------------INV
		data.sMoney	=	Inv.MONEY;
		data.sSeeds	=	Inv.SEEDS;
		data.sNugs	=	Inv.NUGS;
		data.sSpecial=	Inv.SPECIAL;

		//-------------------------------------WEEDS
		data.timeLeft[0]	=	WEED0.timeLeft;
		data.seedTime[0]	=	WEED0.seedTime;
		data.potID[0]		=	WEED0.potID;
		data.seedID[0]		=	WEED0.seedID;
		data.lampID[0]		=	WEED0.lampID;
		data.growthPerc[0]	=	WEED0.growthPerc;
		data.growthStage[0]	=	WEED0.growthStage;
		data.WaterS[0]		=	WEED0.WaterS;
		data.isEmpty[0]		=	WEED0.isEmpty;
		data.isGrown[0]		=	WEED0.isGrown;
		data.isUnlocked[0]	=	WEED0.isUnlocked;
		data.isBuilt[0] 	=	WEED0.isBuilt;

		data.timeLeft[1]	=	WEED1.timeLeft;
		data.seedTime[1]	=	WEED1.seedTime;
		data.potID[1]		=	WEED1.potID;
		data.seedID[1]		=	WEED1.seedID;
		data.lampID[1]		=	WEED1.lampID;
		data.growthPerc[1]	=	WEED1.growthPerc;
		data.growthStage[1]	=	WEED1.growthStage;
		data.WaterS[1]		=	WEED1.WaterS;
		data.isEmpty[1]		=	WEED1.isEmpty;
		data.isGrown[1]		=	WEED1.isGrown;
		data.isUnlocked[1]	=	WEED1.isUnlocked;
		data.isBuilt[1] 	=	WEED1.isBuilt;

		data.timeLeft[2]	=	WEED2.timeLeft;
		data.seedTime[2]	=	WEED2.seedTime;
		data.potID[2]		=	WEED2.potID;
		data.seedID[2]		=	WEED2.seedID;
		data.lampID[2]		=	WEED2.lampID;
		data.growthPerc[2]	=	WEED2.growthPerc;
		data.growthStage[2]	=	WEED2.growthStage;
		data.WaterS[2]		=	WEED2.WaterS;
		data.isEmpty[2]		=	WEED2.isEmpty;
		data.isGrown[2]		=	WEED2.isGrown;
		data.isUnlocked[2]	=	WEED2.isUnlocked;
		data.isBuilt[2] 	=	WEED2.isBuilt;

		data.timeLeft[3]	=	WEED3.timeLeft;
		data.seedTime[3]	=	WEED3.seedTime;
		data.potID[3]		=	WEED3.potID;
		data.seedID[3]		=	WEED3.seedID;
		data.lampID[3]		=	WEED3.lampID;
		data.growthPerc[3]	=	WEED3.growthPerc;
		data.growthStage[3]	=	WEED3.growthStage;
		data.WaterS[3]		=	WEED3.WaterS;
		data.isEmpty[3]		=	WEED3.isEmpty;
		data.isGrown[3]		=	WEED3.isGrown;
		data.isUnlocked[3]	=	WEED3.isUnlocked;
		data.isBuilt[3] 	=	WEED3.isBuilt;

		data.timeLeft[4]	=	WEED4.timeLeft;
		data.seedTime[4]	=	WEED4.seedTime;
		data.potID[4]		=	WEED4.potID;
		data.seedID[4]		=	WEED4.seedID;
		data.lampID[4]		=	WEED4.lampID;
		data.growthPerc[4]	=	WEED4.growthPerc;
		data.growthStage[4]	=	WEED4.growthStage;
		data.WaterS[4]		=	WEED4.WaterS;
		data.isEmpty[4]		=	WEED4.isEmpty;
		data.isGrown[4]		=	WEED4.isGrown;
		data.isUnlocked[4]	=	WEED4.isUnlocked;
		data.isBuilt[4] 	=	WEED4.isBuilt;

		if(WEED0.pot.gameObject.activeInHierarchy)	{WEED0.isBuilt[1] = true;}
		if(WEED0.lamp.gameObject.activeInHierarchy)	{WEED0.isBuilt[2] = true;}
		if(WEED1.pot.gameObject.activeInHierarchy)	{WEED1.isBuilt[1] = true;}
		if(WEED1.lamp.gameObject.activeInHierarchy)	{WEED1.isBuilt[2] = true;}
		if(WEED2.pot.gameObject.activeInHierarchy)	{WEED2.isBuilt[1] = true;}
		if(WEED2.lamp.gameObject.activeInHierarchy)	{WEED2.isBuilt[2] = true;}
		if(WEED3.pot.gameObject.activeInHierarchy)	{WEED3.isBuilt[1] = true;}
		if(WEED3.lamp.gameObject.activeInHierarchy)	{WEED3.isBuilt[2] = true;}
		if(WEED4.pot.gameObject.activeInHierarchy)	{WEED4.isBuilt[1] = true;}
		if(WEED4.lamp.gameObject.activeInHierarchy)	{WEED4.isBuilt[2] = true;}

		binFor.Serialize (file, data);
		file.Close ();
	}
	public void Load(){
		DebugText.text += " |LOAD|";
		Debug.Log ("Load() at " + Time.time);

			if (File.Exists(SavePath )) {
			BinaryFormatter binFor = new BinaryFormatter ();
			FileStream file = File.Open (SavePath, FileMode.Open);
			PlayerData data = (PlayerData)binFor.Deserialize (file);
			file.Close ();

			isFirst = data.sIsFirst;
			FirstTimeDialogs.stage	=	data.sStage;
			TravelScript.PLACE = data.sPlace;

			Debug.Log ("LOADED :" + TravelScript.PLACE);
			Debug.Log ("LOADED STAGEEE: " + FirstTimeDialogs.stage);
			Debug.Log (data.sStage);
			//-------------------------------------INV
			Inv.MONEY	=	data.sMoney;
			Inv.SEEDS	=	data.sSeeds;
			Inv.NUGS	=	data.sNugs;
			Inv.SPECIAL	=	data.sSpecial;
			//-------------------------------------WEED 0 LOAD
			WEED0.timeLeft		=	data.timeLeft[0];
			WEED0.seedTime		=	data.seedTime [0];
			WEED0.potID			=	data.potID [0];
			WEED0.seedID		=	data.seedID [0];
			WEED0.lampID		=	data.lampID [0];
			WEED0.growthPerc	=	data.growthPerc [0];
			WEED0.growthStage	=	data.growthStage [0];
			WEED0.WaterS		=	data.WaterS [0];
			WEED0.isEmpty		=	data.isEmpty [0];
			WEED0.isGrown		=	data.isGrown [0];
			WEED0.isUnlocked	=	data.isUnlocked [0];
			WEED0.isBuilt		=	data.isBuilt[0];

			WEED1.timeLeft		=	data.timeLeft[1];
			WEED1.seedTime		=	data.seedTime [1];
			WEED1.potID			=	data.potID [1];
			WEED1.seedID		=	data.seedID [1];
			WEED1.lampID		=	data.lampID [1];
			WEED1.growthPerc	=	data.growthPerc [1];
			WEED1.growthStage	=	data.growthStage [1];
			WEED1.WaterS		=	data.WaterS [1];
			WEED1.isEmpty		=	data.isEmpty [1];
			WEED1.isGrown		=	data.isGrown [1];
			WEED1.isUnlocked	=	data.isUnlocked [1];
			WEED1.isBuilt		=	data.isBuilt[1];

			WEED2.timeLeft		=	data.timeLeft[2];
			WEED2.seedTime		=	data.seedTime [2];
			WEED2.potID			=	data.potID [2];
			WEED2.seedID		=	data.seedID [2];
			WEED2.lampID		=	data.lampID [2];
			WEED2.growthPerc	=	data.growthPerc [2];
			WEED2.growthStage	=	data.growthStage [2];
			WEED2.WaterS		=	data.WaterS [2];
			WEED2.isEmpty		=	data.isEmpty [2];
			WEED2.isGrown		=	data.isGrown [2];
			WEED2.isUnlocked	=	data.isUnlocked [2];
			WEED2.isBuilt		=	data.isBuilt[2];

			WEED3.timeLeft		=	data.timeLeft[3];
			WEED3.seedTime		=	data.seedTime [3];
			WEED3.potID			=	data.potID [3];
			WEED3.seedID		=	data.seedID [3];
			WEED3.lampID		=	data.lampID [3];
			WEED3.growthPerc	=	data.growthPerc [3];
			WEED3.growthStage	=	data.growthStage [3];
			WEED3.WaterS		=	data.WaterS [3];
			WEED3.isEmpty		=	data.isEmpty [3];
			WEED3.isGrown		=	data.isGrown [3];
			WEED3.isUnlocked	=	data.isUnlocked [3];
			WEED3.isBuilt		=	data.isBuilt[3];

			WEED4.timeLeft		=	data.timeLeft[4];
			WEED4.seedTime		=	data.seedTime [4];
			WEED4.potID			=	data.potID [4];
			WEED4.seedID		=	data.seedID [4];
			WEED4.lampID		=	data.lampID [4];
			WEED4.growthPerc	=	data.growthPerc [4];
			WEED4.growthStage	=	data.growthStage [4];
			WEED4.WaterS		=	data.WaterS [4];
			WEED4.isEmpty		=	data.isEmpty [4];
			WEED4.isGrown		=	data.isGrown [4];
			WEED4.isUnlocked	=	data.isUnlocked [4];
			WEED4.isBuilt		=	data.isBuilt[4];

			if (WEED0.isBuilt [1]) {WEED0.pot.gameObject.SetActive (true);}
			if (WEED0.isBuilt [2]) {WEED0.lamp.gameObject.SetActive (true);}
			if (WEED1.isBuilt [1]) {WEED1.pot.gameObject.SetActive (true);}
			if (WEED1.isBuilt [2]) {WEED1.lamp.gameObject.SetActive (true);}
			if (WEED2.isBuilt [1]) {WEED2.pot.gameObject.SetActive (true);}
			if (WEED2.isBuilt [2]) {WEED2.lamp.gameObject.SetActive (true);}
			if (WEED3.isBuilt [1]) {WEED3.pot.gameObject.SetActive (true);}
			if (WEED3.isBuilt [2]) {WEED3.lamp.gameObject.SetActive (true);}
			if (WEED4.isBuilt [1]) {WEED4.pot.gameObject.SetActive (true);}
			if (WEED4.isBuilt [2]) {WEED4.lamp.gameObject.SetActive (true);}

			//---------------------------------OFFLINE PROGRESS
			TimeSpan timePassed = DateTime.Now.Subtract(data.sDateTime);
			float Seconds = (float)timePassed.TotalSeconds;
			WEED0.timeLeft -= Seconds;
			WEED1.timeLeft -= Seconds;
			WEED2.timeLeft -= Seconds;
			WEED3.timeLeft -= Seconds;
			WEED4.timeLeft -= Seconds;
		} else
		{
			Debug.Log ("WHALCEUMCE");
			DebugText.text += "\n _FIRST_ ";
			isFirst = true;
			TravelScript.PLACE = 0;
			FirstTimeDialogs.stage = 0;
			Inv.MONEY = LAMPPRICES [0] + POTPRICES [0] + SEEDPRICES [0] * 2;
			WEED0.isUnlocked = true;
			WEED0.RedrawSprite ();
		}

		if (WEED0.isEmpty) { WEED0.pot.GetComponent<Button> ().interactable = true; } else { WEED0.pot.GetComponent<Button> ().interactable = false; }
		if (WEED1.isEmpty) { WEED1.pot.GetComponent<Button> ().interactable = true; } else { WEED1.pot.GetComponent<Button> ().interactable = false; }
		if (WEED2.isEmpty) { WEED2.pot.GetComponent<Button> ().interactable = true; } else { WEED2.pot.GetComponent<Button> ().interactable = false; }
		if (WEED3.isEmpty) { WEED3.pot.GetComponent<Button> ().interactable = true; } else { WEED3.pot.GetComponent<Button> ().interactable = false; }
		if (WEED4.isEmpty) { WEED4.pot.GetComponent<Button> ().interactable = true; } else { WEED4.pot.GetComponent<Button> ().interactable = false; }

		if (Inv.SPECIAL [0]) { WEED1.isUnlocked = true;} else { WEED1.isUnlocked = false;}	//invspecial 1, 3 are tools
		if (Inv.SPECIAL [2]) { WEED2.isUnlocked = true;} else { WEED2.isUnlocked = false;}
		if (Inv.SPECIAL [4]) { WEED3.isUnlocked = true;} else { WEED3.isUnlocked = false;}
		if (Inv.SPECIAL [5]) { WEED4.isUnlocked = true;} else { WEED4.isUnlocked = false;}
		WEED0.RedrawSprite ();
		WEED1.RedrawSprite (); 
		WEED2.RedrawSprite ();
		WEED3.RedrawSprite ();
		WEED4.RedrawSprite ();
		if (isFirst) {
			FTDPanel.gameObject.SetActive (true);
			FTDPanelBlocker.gameObject.SetActive (true);
			FTDPanelBlocker2.gameObject.SetActive (true);
		} else {
			FTDPanel.gameObject.SetActive (false);
			FTDPanelBlocker.gameObject.SetActive (false);
			FTDPanelBlocker2.gameObject.SetActive (false);
		}
		TravelScript.isReload = true;
		DebugText.text += "\n isFirst:" + isFirst + " Unlocked:" + WEED0.isUnlocked + " Active:" + WEED0.gameObject.activeInHierarchy + "\n";
	}
	//===================SAVE/LOAD FUNCTIONS

}//endofclass

[Serializable]
class PlayerData {
	public DateTime	sDateTime;

	//FirstTimeDialog&Place
	public bool		sIsFirst;
	public int		sStage;
	public int		sPlace;
	//INV
	public float	sMoney;
	public int[]	sSeeds;
	public int[]	sNugs;
	public bool[]	sSpecial;

	//----------------------WEEDS
	public float[]	timeLeft	= new float[5];
	public float[]	seedTime	= new float[5];
	public int[]	potID		= new int[5];
	public int[]	seedID		= new int[5];
	public int[]	lampID		= new int[5];
	public int[]	growthPerc	= new int[5];
	public int[]	growthStage	= new int[5];
	public bool[][]	WaterS		= new bool[5][];
	public bool[]	isEmpty		= new bool[5];
	public bool[]	isGrown		= new bool[5];
	public bool[]	isUnlocked	= new bool[5];
	public bool[][]	isBuilt		= new bool[5][];
}