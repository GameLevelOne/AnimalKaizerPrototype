using System.Collections;
using UnityEngine;

public enum eBGM{
	MENU = 0,
	GAME
}

public enum eSFX{
	BUTTON_START = 0,
	LETS_FIGHT,
	THREE,
	TWO,
	ONE,
	FIGHT,
	ROUND_ONE,
	ROUND_TWO,
	FINAL_ROUND,
	YOU_WIN,
	YOU_LOSE,
	GAME_OVER,
	BUTTON_PRESS,
	PRE_BATTLE_VS,
    POWER_COMPARISON,
    COIN,
    ROULETTE_SPIN
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
		if(source.clip == Clip_BGM[(int)bgm]) return;
		else{
			source.clip = Clip_BGM[(int)bgm];
			source.Play();
		}
	}

	public void Stop(){
		source.Stop();
	}
}