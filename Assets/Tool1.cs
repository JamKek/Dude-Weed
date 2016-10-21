using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tool1 : MonoBehaviour {

	public	Text[] seedAmounts;
	public	Text   paperAmount;
		
	public	Image	InputImage;
	public	Image	OutputImage;
	public	Image	Wheel;
	public	Image	WheelButton;
	public Camera cam;

	int SeedID;
	public float rotAngle;
	public bool isRotating;

	public void Start(){
		rotAngle = 0f;
		SeedID = 0;
		isRotating = false;
	}



	public void Update(){
		if (isRotating) {
			if (Inv.SEEDS [SeedID] >= 1) {
				Wheel.transform.rotation = Quaternion.AngleAxis (rotAngle, Vector3.forward);
				rotAngle += 9f;
			} else {
				seedAmounts [SeedID].color = Color.red;
			}

		} else {
			seedAmounts [SeedID].color = Color.white;
		}

		if (rotAngle > 360f) {
			rotAngle = 0;
			MakePaper ();
		}

		for (int i = 0; i < seedAmounts.Length; i++) {
			seedAmounts [i].text = Inv.SEEDS [i].ToString ();
		}
		paperAmount.text = Inv.MISC [0].ToString();
	}

	public void MakePaper(){
		Inv.SEEDS	[SeedID]--;
		Inv.MISC	[0]++;
	}

	public void WheelButtonDown(){
		isRotating = true;
	}
	public void WheelButtonUp(){
		isRotating = false;
	}

	public void SeedChoose(int ID){
		SeedID = ID;
		switch (ID) {
		case 0:
			InputImage.sprite = Resources.Load<Sprite> ("Images/Seeds/seed_0");
			break;
		case 1:
			InputImage.sprite = Resources.Load<Sprite>("Images/Seeds/seed_1");
			break;
		case 2:
			InputImage.sprite = Resources.Load<Sprite>("Images/Seeds/seed_2");
			break;
		}
		Debug.Log (InputImage.sprite);
	}
}
