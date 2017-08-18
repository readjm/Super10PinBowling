using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class OptionsController : MonoBehaviour {

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;
    //public Slider difficultySlider;
    public LevelManager levelManager;
    public AudioMixer masterMixer;
	
	void Start ()
	{
		masterVolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        masterMixer.SetFloat("masterVolume", masterVolumeSlider.value);

        musicVolumeSlider.value = PlayerPrefsManager.GetMusicVolume();
        masterMixer.SetFloat("musicVolume", musicVolumeSlider.value);

        effectsVolumeSlider.value = PlayerPrefsManager.GetEffectsVolume();
        masterMixer.SetFloat("effectsVolume", effectsVolumeSlider.value);

        //difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
    public void SetMasterVolume(float masterVol)
    {
        masterMixer.SetFloat("masterVolume", masterVol);
    }

    public void SetMusicVolume(float musicVol)
    {
        masterMixer.SetFloat("musicVolume", musicVol);
    }

    public void SetEffectsVolume(float effectsVol)
    {
        masterMixer.SetFloat("effectsVolume", effectsVol);
    }

    public void SaveAndExit()
	{
        PlayerPrefsManager.SetMasterVolume(masterVolumeSlider.value);
        PlayerPrefsManager.SetMusicVolume(musicVolumeSlider.value);
        PlayerPrefsManager.SetEffectsVolume(effectsVolumeSlider.value);

        //masterMixer.SetFloat("masterVolume", masterVolumeSlider.value);
        //masterMixer.SetFloat("musicVolume", musicVolumeSlider.value);
        //masterMixer.SetFloat("effectsVolume", effectsVolumeSlider.value);

        //PlayerPrefsManager.SetDifficulty(difficultySlider.value);
    }
	
	public void SetDefaults()
	{
        masterVolumeSlider.value = 1f;
        musicVolumeSlider.value = .8f;
        effectsVolumeSlider.value = 1f;
        //effectsVolumeSlider.value = 1f;
        //difficultySlider.value = 2f;
    }
}
