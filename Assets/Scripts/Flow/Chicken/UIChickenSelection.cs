using UnityEngine;
using UnityEngine.UI;

public class UIChickenSelection : MonoBehaviour {
	public Character[] chickens;
	public SupportSO suster; //biar ga error
	public Text[] textChickenPrices;
	public Text[] textChickenNames;
	public Sprite[] chickenSprites;

	void OnEnable(){
		InitChickenData ();
	}

	void InitChickenData(){
		for (int i = 0; i < chickens.Length; i++) {
			textChickenPrices [i].text = "$ "+chickens [i].charData.charPrice.ToString();
			textChickenNames [i].text = chickens [i].charData.charName;
		}
	}

	void GenerateEnemyChicken(int index){
		int rnd = 0;

		do {
			rnd = Random.Range (0, chickens.Length);
		}while(rnd == index);

		PlayerChickenDataController.Instance.EnemyChickenSprite = chickenSprites [rnd];
		PlayerChickenDataController.Instance.EnemyChicken = chickens [rnd];

		Support sus = new Support (suster);
		PlayerChickenDataController.Instance.SetSupport (sus);
	}

	public void ButtonChickenOnClick(int index){
		PlayerChickenDataController.Instance.PlayerChickenSprite = chickenSprites[index];
		PlayerChickenDataController.Instance.PlayerChicken = chickens[index];
		GenerateEnemyChicken (index);
	}
}