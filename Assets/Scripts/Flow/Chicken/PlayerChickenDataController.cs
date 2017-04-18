using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChickenDataController : MonoBehaviour {

	//singleton
	static PlayerChickenDataController instance = null;
	public static PlayerChickenDataController Instance{
		get{ return instance; }
	}

	static Sprite playerChickenSprite;
	static Sprite enemyChickenSprite;
	static Character playerChicken;
	static Character enemyChicken;
	static float multiplier;

	public Sprite PlayerChickenSprite{
		get{ return playerChickenSprite; }
		set{ playerChickenSprite = value; }
	}

	public Sprite EnemyChickenSprite{
		get{ return enemyChickenSprite; }
		set{ enemyChickenSprite = value; }
	}

	public Character PlayerChicken{
		get{ return playerChicken; }
		set{ playerChicken = value; }
	}

	public Character EnemyChicken{
		get{ return enemyChicken; }
		set{ enemyChicken = value; }
	}

	public float Multiplier{
		get{ return multiplier; }
		set{ multiplier = value; }
	}

	void Awake(){
		if (instance != null && instance != this) {
			// destroy any other singleton object of this class
			Destroy(this.gameObject);  
			return;
		} else instance = this;

		// make it indestructible
		DontDestroyOnLoad(this.gameObject); 
	}
}
