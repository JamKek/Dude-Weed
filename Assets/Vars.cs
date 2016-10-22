using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Vars : MonoBehaviour {
	
	//_______W_E_E_D_S______
	public Weed[] WEEDS;
	//----------------
	//
	//________________________________________________S_E_E_D_S___________
	public static string[]	SEEDNAMES	=	{	"Shit",	"Meh",	"Better"};	/// Array of seed prices
	public static int[]		SEEDPRICES	=	{	12,		40,		250		};	/// Array of seed times
	public static float[]	SEEDTIMES	=	{	120f,	720f,	1800f	};	/// Array of nug prices
	public static int[]		NUGPRICES	=	{	6,		12,		30		};	/// Array of min/max values for nugs in rng
	public static int[,]	NUGMINMAX	=	{ 	{0, 4},	{2,10},	{4,16}	};	/// Array of min/max values for seeds in rng
	public static int[,]	SEEDMINMAX	=	{ 	{1,10},	{0, 4},	{0, 2}	};	/// Array of seed sprites, to declare size
	public static Sprite[]	SEEDSPRITES =	{	null,	null,	null	};	//==========================================DEFINE NEW PLANTS HERE_|
	public static Sprite[]	NUGSPRITES	=	{	null,	null,	null	};
	public static Sprite[,]	PLANTSPRITES=	{	{null,null,null,null,null}	,	//okay
												{null,null,null,null,null}	,	// [i][k]
												{null,null,null,null,null}	};	// i= plantID, k, growth id,01235=0,25,50,75,100...
	//-----------------------------------------------------------------------
	//
	//___________________________________________L_A_M_P_S_______
	public static string[]	LAMPNAMES	=	{	"Shit",	"Cheap"	};
	public static int[]		LAMPPRICES	=	{	30,		90		};
	public static float[]	LAMPMULTIS	=	{	0.5f,	1f		};
	public static Sprite[]	LAMPSPRITES	=	{	null,	null	};
	//------------------------------------------------------------
	//
	//________________________________________________________P_O_T_S________________________
	public static string[]	POTNAMES	=	{	"Broken",	"Cheap",	"Plastic",	"Nice"	};	//Name of the pot
	public static int[]		POTPRICES	=	{	5,			60,			200,		500		};		//Price of the pot
	public static float[]	POTMULTIS	=	{	0.5f,		1f,			1.5f,		2f		};		//Pot multiplier
	public static Sprite[]	POTSPRITES	=	{	null,		null,		null,		null	};
	//-----------------------------------------------------------------------------------
	//
	//_____________________TOOLS
	public static Sprite[] TOOLSPRITES	=	{	null,	null};
	//---------------------------
	//______________________________________________S_P_E_C_I_A_L_S_______________________________
	public static string[]	SPECIALNAMES	=	{	"Second pot!","Rolling machine!","Third pot!",
													"Grinder!","Fifth pot?!","The final pot"};
	public static int[]		SPECIALPRICES	=	{	10000,	30000,	40000,	80000,	90000,	1000000};
	public static string[]	SPECIALDESCRIPTIONS	= {
		"Buy a second pot! \n Why not?! \n Don't stop!",
		"Rolling machine for all your rolling needs!",
		"Third pot for your third eye!",
		"Finally a grinder to grind up all those useless seeds!",
		"A fourth pot?  Why do you need so many?",
		"THIS IS IT'S FINAL FORM"	};
	//--------------------------------
	//
	//____________________________First_time_launch_dialogs
	public RectTransform FTDPanel;
	public RectTransform FTDPanelBlocker;
	public RectTransform FTDPanelBlocker2;
	//------------------------------------
	//
	//_____O_T_H_E_R___
	public static Vector2[]	WATERLEVELS;
	//-----------------
	//
	//______________VARIABLES
	string SavePath;
	public static bool isFirst;
	public static bool isReady = false;
	//----------------------------------

	/* ===================================================================================================================FUNCTIONS!
				  JJJJJJJJJJJ                                          KKKKKKKKK    KKKKKKK                    kkkkkkkk           
				  J:::::::::J                                          K:::::::K    K:::::K                    k::::::k           
				  J:::::::::J                                          K:::::::K    K:::::K                    k::::::k           
				  JJ:::::::JJ                                          K:::::::K   K::::::K                    k::::::k           
					J:::::J    aaaaaaaaaaaaa      mmmmmmm    mmmmmmm   KK::::::K  K:::::KKK    eeeeeeeeeeee     k:::::k    kkkkkkk
					J:::::J    a::::::::::::a   mm:::::::m  m:::::::mm   K:::::K K:::::K     ee::::::::::::ee   k:::::k   k:::::k 
					J:::::J    aaaaaaaaa:::::a m::::::::::mm::::::::::m  K::::::K:::::K     e::::::eeeee:::::ee k:::::k  k:::::k  
					J:::::j             a::::a m::::::::::::::::::::::m  K:::::::::::K     e::::::e     e:::::e k:::::k k:::::k   
					J:::::J      aaaaaaa:::::a m:::::mmm::::::mmm:::::m  K:::::::::::K     e:::::::eeeee::::::e k::::::k:::::k    
		JJJJJJJ		J:::::J    aa::::::::::::a m::::m   m::::m   m::::m  K::::::K:::::K    e:::::::::::::::::e  k:::::::::::k     
		J:::::J		J:::::J   a::::aaaa::::::a m::::m   m::::m   m::::m  K:::::K K:::::K   e::::::eeeeeeeeeee   k:::::::::::k     
		J::::::J   J::::::J  a::::a    a:::::a m::::m   m::::m   m::::mKK::::::K  K:::::KKKe:::::::e            k::::::k:::::k    
		J:::::::JJJ:::::::J  a::::a    a:::::a m::::m   m::::m   m::::mK:::::::K   K::::::Ke::::::::e          k::::::k k:::::k   
		 JJ:::::::::::::JJ   a:::::aaaa::::::a m::::m   m::::m   m::::mK:::::::K    K:::::K e::::::::eeeeeeee  k::::::k  k:::::k  
		   JJ:::::::::JJ      a::::::::::aa:::am::::m   m::::m   m::::mK:::::::K    K:::::K  ee:::::::::::::e  k::::::k   k:::::k 
			 JJJJJJJJJ         aaaaaaaaaa  aaaammmmmm   mmmmmm   mmmmmmKKKKKKKKK    KKKKKKK    eeeeeeeeeeeeee  kkkkkkkk    kkkkkkk
	======================================================================================================================FUNCTIONS!*/

	void Start () {
		//__________________________________________Load Resources
		for (int i = 0; i < SEEDNAMES.Length; i++) {
			SEEDSPRITES[i]	= Resources.Load<Sprite>("Images/Seeds/seed_" + i);
			NUGSPRITES [i]	= Resources.Load<Sprite>("Images/Nugs/nug_" + i);

			for (int j = 0; j < 5; j++){ PLANTSPRITES[i,j] = Resources.Load<Sprite>("Images/Plants/plant_"+ i +"_"+ j); }
		}
		for (int i = 0; i < POTSPRITES.Length; i++)	{ POTSPRITES[i]	= Resources.Load<Sprite>("Images/Pots/pot_"	+ i); }
		for (int i = 0; i < LAMPSPRITES.Length; i++){ LAMPSPRITES[i]= Resources.Load<Sprite>("Images/Lamps/lamp_" + i); }
		for (int i = 0; i < TOOLSPRITES.Length; i++){ TOOLSPRITES[i]= Resources.Load<Sprite>("Images/Tools/tool_" + i); }

		WATERLEVELS		= new Vector2[5];
		WATERLEVELS[0]	= new Vector2(0, -27.5f);
		WATERLEVELS[1]	= new Vector2(0, -69.5f);
		WATERLEVELS[2]	= new Vector2(0, -99.3f);
		WATERLEVELS[3]	= new Vector2(0, -129.3f);
		WATERLEVELS[4]	= new Vector2 (0, 0);
		//---------------------------------------------------------------------------------------

		SavePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saveTokes.dank";
		Load();
		isReady = true;
	}

	void OnApplicationFocus(bool hasFocus){
		if (hasFocus && isReady) { Load (); }
		if (!hasFocus && isReady) { Save (); }
	}
	public void QuitGame(){
		Save ();
		Application.Quit ();
	}

	///	Saves the variables to a save file.
	public void Save(){
		BinaryFormatter binFor = new BinaryFormatter ();
		if( File.Exists(SavePath)){ File.Delete(SavePath);}
		FileStream file = File.Create(SavePath);
		PlayerData data = new PlayerData();
		
		//___________________________First Time variables
		data.sIsFirst	=	isFirst;
		data.sStage		=	FirstTimeDialogs.stage;
		//-----------------------------------------
		//
		//_____________________________________Current place
		data.sPlace		=	TravelScript.PLACE;
		//--------------------------------------
		//
		//____________________________OFFLINE PROGRESS
		data.sDateTime	=	DateTime.Now;
		//----------------------------
		//
		//________________________INV
		data.sMoney	=	Inv.MONEY;
		data.sSeeds	=	Inv.SEEDS;
		data.sNugs	=	Inv.NUGS;
		data.sMisc	=	Inv.MISC;
		data.sSpecial=	Inv.SPECIAL;
		//--------------------------
		//
		//_____________________________________WEEDS
		for (int i = 0; i < WEEDS.Length; i++) {
			data.timeLeft[i]	=	WEEDS[i].timeLeft;
			data.seedTime[i]	=	WEEDS[i].seedTime;
			data.potID[i]		=	WEEDS[i].potID;
			data.seedID[i]		=	WEEDS[i].seedID;
			data.lampID[i]		=	WEEDS[i].lampID;
			data.growthPerc[i]	=	WEEDS[i].growthPerc;
			data.growthStage[i]	=	WEEDS[i].growthStage;
			data.WaterS[i]		=	WEEDS[i].WaterS;
			data.isEmpty[i]		=	WEEDS[i].isEmpty;
			data.isGrown[i]		=	WEEDS[i].isGrown;
			data.isUnlocked[i]	=	WEEDS[i].isUnlocked;
			data.isBuilt[i]		=	WEEDS[i].isBuilt;
			if(WEEDS[i].pot.gameObject.activeInHierarchy)	{WEEDS[i].isBuilt[1] = true;}
			if(WEEDS[i].lamp.gameObject.activeInHierarchy)	{WEEDS[i].isBuilt[2] = true;}
		}
		//-------------------------------------------------------------------------------
		binFor.Serialize (file, data);
		file.Close ();
	}
	/// Sets variables from a save file.
	/// If save file does not exist,
	/// it initiates First Time dialog
	public void Load(){
		if ( !File.Exists(SavePath)) {
			isFirst = true;
			TravelScript.PLACE = 0;
			FirstTimeDialogs.stage = 0;
			WEEDS[0].isUnlocked = true;
			WEEDS[0].RedrawSprite ();
			Inv.MONEY = LAMPPRICES [0] + POTPRICES [0] + SEEDPRICES [0] * 2;
		}
		else {
			BinaryFormatter binFor = new BinaryFormatter ();
			FileStream file = File.Open (SavePath, FileMode.Open);
			PlayerData data = (PlayerData)binFor.Deserialize (file);
			file.Close ();

			//______________________First Time variables
			isFirst	= data.sIsFirst;
			FirstTimeDialogs.stage	= data.sStage;
			//-------------------------------------
			//
			//________________________________Current place
			TravelScript.PLACE	= data.sPlace;
			TravelScript.isReload = true;
			//----------------------------------
			//
			//_____________________OFFLINE PROGRESS
			TimeSpan	timePassed		= DateTime.Now.Subtract(data.sDateTime);
			float		secondsPassed	= (float)timePassed.TotalSeconds;
			//-------------------------------------
			//
			//________________________INV
			Inv.MONEY	=	data.sMoney;
			Inv.SEEDS	=	data.sSeeds;
			Inv.NUGS	=	data.sNugs;
			Inv.MISC	=	data.sMisc;
			Inv.SPECIAL	=	data.sSpecial;
			//--------------------------
			//
			//________________________________________WEEDS
			for (int i = 0; i < WEEDS.Length; i++) {
				WEEDS[i].timeLeft		=	data.timeLeft[i];
				WEEDS[i].seedTime		=	data.seedTime [i];
				WEEDS[i].potID			=	data.potID [i];
				WEEDS[i].seedID			=	data.seedID[i];
				WEEDS[i].lampID			=	data.lampID[i];
				WEEDS[i].growthPerc		=	data.growthPerc[i];
				WEEDS[i].growthStage	=	data.growthStage[i];
				WEEDS[i].WaterS			=	data.WaterS[i];
				WEEDS[i].isEmpty		=	data.isEmpty[i];
				WEEDS[i].isGrown		=	data.isGrown[i];
				WEEDS[i].isUnlocked		=	data.isUnlocked[i];
				WEEDS[i].isBuilt		=	data.isBuilt[i];
				WEEDS[i].timeLeft		-=	secondsPassed;
				WEEDS[i].RedrawSprite();
			}
			//---------------------------------------------------------------
		}
		//
		if (isFirst) {
			FTDPanel.gameObject.SetActive (true);
			FTDPanelBlocker.gameObject.SetActive (true);
			FTDPanelBlocker2.gameObject.SetActive (true);
		} else {
			FTDPanel.gameObject.SetActive (false);
			FTDPanelBlocker.gameObject.SetActive (false);
			FTDPanelBlocker2.gameObject.SetActive (false);
		}
	}
}


//============PLAYER SAVE DATA
[Serializable]
class PlayerData {
	
	public DateTime	sDateTime;

	//______________________First Time Dialog
	public bool		sIsFirst;
	public int		sStage;
	//---------------------
	//
	//_____________________Place
	public int		sPlace;
	//---------------------
	//
	//____________________INV
	public float	sMoney;
	public int[]	sSeeds;
	public int[]	sNugs;
	public bool[]	sSpecial;
	public int[]	sMisc;
	//--------------------
	//
	//________________________________________WEEDS
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
	//------------------------------------------
}