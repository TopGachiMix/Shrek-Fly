
using UnityEngine;
using UnityEngine.UI;

public class AudioManage : MonoBehaviour
{
   
	
	public static bool musicOn = true;

	// Menu scene music clip
	public AudioClip musicClip;
	public static AudioSource musicSource;

	public GameObject MusicButton;

	public Sprite[] SoundIcons;



	// Variable to store current Game Mode
	public static int modeNum = 0;

	// Ninja Sprites
	// private GameObject ninja1, ninja2;

	private static int musicOnIcon = 0;
	private static int musicOffIcon = 1;
	

	// Boolean for paused and game over states
	public static bool paused;
	public static bool isGameOver;

	// Variable to store current score in each game mode
	public static int scoreNum;
	

	// Use this for initialization
	void Start () {

		// Get ninjas sprites from scene
		// ninja1 = GameObject.Find("HoleL");
		// ninja2 = GameObject.Find("HoleR");

		// Loop ninjas show/hid	StartCoroutine(loopNinjas());

		// Initialize music
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.playOnAwake = false;
		musicSource.rolloffMode = AudioRolloffMode.Linear;
		musicSource.loop = true;
		musicSource.clip = musicClip;

		Time.timeScale = 1; // Use normal game speed. If previously paused, it would be 0


		int mOn = PlayerPrefs.GetInt("mOn", 1);
	
		
		if(mOn == 1) {
			musicOn = true;
		}else {
			musicOn = false;
		}

		musicSource.volume = 2;


		if(musicOn){
			musicSource.Play(); // Play music if sound is on
			MusicButton.GetComponent<Image>().sprite = SoundIcons[musicOnIcon];
		}else {
			MusicButton.GetComponent<Image>().sprite = SoundIcons[musicOffIcon];
		}


	}
	
	// Update is called once per frame


	

	// Method to loop ninjas
	
    




	



	public void OnMusicButtonClick() {
		if(musicOn){
			MusicButton.GetComponent<Image>().sprite = SoundIcons[musicOffIcon];
			musicOn = false;
			musicSource.Stop();
			PlayerPrefs.SetInt("mOn", 0);
		}else{
			MusicButton.GetComponent<Image>().sprite = SoundIcons[musicOnIcon];
			musicOn = true;
			musicSource.Play();
			PlayerPrefs.SetInt("mOn", 1);
		}
	}

}









