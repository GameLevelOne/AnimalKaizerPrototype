using UnityEngine;
using UnityEngine.UI;

public class UIChickenPreBattle : MonoBehaviour {
	public Text textPlayerChickenHP,
				textPlayerChickenPower,
				textPlayerChickenSPMove;

	public Text textEnemyChickenHP,
				textEnemyChickenPower,
				textEnemyChickenSPMove;

	public Text textMultiplier;

	public Image playerChickenImage,
				  enemyChickenImage;

	void OnEnable(){
		SetDetails ();
	}

	void SetDetails(){
		textPlayerChickenHP.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charHealth.ToString();
		textPlayerChickenPower.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charPower.ToString();
//		textPlayerChickenSPMove.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charSPMove;

		textEnemyChickenHP.text = PlayerChickenDataController.Instance.EnemyChicken.charData.charHealth.ToString();
		textEnemyChickenPower.text = PlayerChickenDataController.Instance.EnemyChicken.charData.charPower.ToString();
//		textEnemyChickenSPMove.text = PlayerChickenDataController.Instance.EnemyChicken.charData.charSPMove;

		textMultiplier.text = PlayerChickenDataController.Instance.Multiplier.ToString ("##.00");

		playerChickenImage.sprite = PlayerChickenDataController.Instance.PlayerChickenSprite;
		enemyChickenImage.sprite = PlayerChickenDataController.Instance.EnemyChickenSprite;
	}
}
