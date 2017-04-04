using System.Collections;
using UnityEngine;

public enum eBGM{
	MENU = 0,
	GAME
}

public enum eSFX{
	BUTTON_PRESS = 0,
	COIN,
	PREBATTLE_VS,
	ROUND,
	ONE,
	TWO,
	THREE,
	COUNTDOWN,
	FIGHT,
	ROULETTE_SPIN,
	ROULETTE_PRESS,
	POWER_COMPARISON,
	MOVE_NAME,
	ATTACK_SWISH,
	ATTACK_HIT,
	STRUGGLE_START,
	YOU_WIN,
	YOU_LOSE,
	GAME_OVER
}

public class AudioManager : MonoBehaviour{
	static AudioManager instance = null;

	public static AudioManager Instance {
		get { return instance; }
	}

	public AudioClip[] Clip_BGM ;
	public AudioClip[] Clip_SFX ;

	static AudioSource source;

	void Awake(){
		if (instance != null && instance != this) {
			Destroy(this.gameObject);  // destroy any other singleton object of this class
			return;
		} else instance = this;
		
		DontDestroyOnLoad(this.gameObject); // make it indestructible

		source = GetComponent<AudioSource>();
	}


	public void PlaySFX(eSFX sfx){
		source.PlayOneShot(Clip_SFX[(int)sfx]);
	}

	public void PlayBGM(eBGM bgm){
		source.clip = Clip_BGM[(int)bgm];
		source.Play();
	}

	public void Stop(){
		source.Stop();
	}
}