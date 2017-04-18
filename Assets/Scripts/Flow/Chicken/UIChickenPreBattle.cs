using UnityEngine;
using UnityEngine.UI;

public class UIChickenPreBattle : MonoBehaviour {
	public Text textPlayerChickenName,
				textPlayerChickenHP,
				textPlayerChickenPower,
				textPlayerChickenSkill;

	public Text textEnemyChickenName,
				textEnemyChickenHP,
				textEnemyChickenPower,
				textEnemyChickenSkill;

	public Text textMultiplier;

	public Image playerChickenImage,
				 enemyChickenImage;

	void OnEnable(){
		SetDetails ();
	}

	void SetDetails(){
		CharacterSO playerChicken = PlayerChickenDataController.Instance.PlayerChicken.charData;
		CharacterSO enemyChicken = PlayerChickenDataController.Instance.EnemyChicken.charData;

		string tempPlayerAttackData = string.Empty;
		string tempEnemyAttackData = string.Empty;
		int totalAttackData = playerChicken.charAttackData.Length;
		for (int i = 0; i < totalAttackData; i++) {
			string temp1 = playerChicken.charAttackData [i].attackName;
			string temp2 = enemyChicken.charAttackData [i].attackName;
			if (i != totalAttackData - 1) {
				temp1 += ", ";
				temp2 += ", ";
			}
			tempPlayerAttackData += temp1;
			tempEnemyAttackData += temp2;
		}

		textPlayerChickenName.text = playerChicken.charName;
		textPlayerChickenHP.text = "Health : "+ playerChicken.charHealth.ToString();
		textPlayerChickenPower.text = "Power : "+ playerChicken.charPower.ToString();
		textPlayerChickenSkill.text = "Skills : "+ tempPlayerAttackData;

		textEnemyChickenName.text = enemyChicken.charName;
		textEnemyChickenHP.text = "Health : "+ enemyChicken.charHealth.ToString();
		textEnemyChickenPower.text ="Power : "+ enemyChicken.charPower.ToString();
		textEnemyChickenSkill.text = "Skills : "+ tempEnemyAttackData;

		textMultiplier.text = PlayerChickenDataController.Instance.Multiplier.ToString ();

		playerChickenImage.sprite = PlayerChickenDataController.Instance.PlayerChickenSprite;
		enemyChickenImage.sprite = PlayerChickenDataController.Instance.EnemyChickenSprite;
	}

	void PlaySound(){
		if (AudioManager.Instance) {
			AudioManager.Instance.Stop ();
			AudioManager.Instance.PlaySFX (eSFX.PRE_BATTLE_VS);
		}
	}

	void GoToGameScene(){
		SceneChickenSelectionManager.Instance.FadeOut ();
	}
}
