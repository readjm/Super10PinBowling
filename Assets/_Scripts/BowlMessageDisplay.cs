using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class BowlMessageDisplay : MonoBehaviour {
    public enum BowlMessage { GUTTERBALL, SPARE, STRIKE, DOUBLE, TURKEY };

    public Image bowlMessageDisplay;
    public Sprite gutterBallSprite;
    public Sprite spareSprite;
    public Sprite strikeSprite;
    public Sprite doubleSprite;
    public Sprite turkeySprite;
    public Sprite[] messageSprites;

    public AudioClip gutterBallAudio;
    public AudioClip spareAudio;
    public AudioClip strikeAudio;
    public AudioClip doubleAudio;
    public AudioClip turkeyAudio;

    private AudioSource audioSource;
    private bool playMessage = false;
    const float maxTime = 3;
    private float playTime = 0;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bowlMessageDisplay.color = new Color(bowlMessageDisplay.color.r, bowlMessageDisplay.color.g, bowlMessageDisplay.color.b, 0);
    }

    void Update()
    {
        if (playMessage)
        {
            if (playTime <= maxTime / 3)
            {
                bowlMessageDisplay.color += new Color(0, 0, 0, 1 * Time.deltaTime);
                playTime += Time.deltaTime;
            }
            if (playTime > maxTime/3 && playTime < (maxTime/3)*2)
            {
                playTime += Time.deltaTime;
            }
            if (playTime >= (maxTime / 3) * 2)
            {
                bowlMessageDisplay.color -= new Color(0, 0, 0, 1 * Time.deltaTime);
                playTime += Time.deltaTime;
            }
            if (playTime > maxTime)
            {
                playMessage = false;
                playTime = 0;
                bowlMessageDisplay.color = new Color(bowlMessageDisplay.color.r, bowlMessageDisplay.color.g, bowlMessageDisplay.color.b, 0);
            }
        }
    }
    public void PlayMessage(BowlMessage message)
    {
        if (message == BowlMessage.GUTTERBALL)
        {
            bowlMessageDisplay.sprite = gutterBallSprite;
            audioSource.clip = gutterBallAudio;
            audioSource.Play();
            playMessage = true;
        }
        if (message == BowlMessage.SPARE)
        {
            bowlMessageDisplay.sprite = spareSprite;
            audioSource.clip = spareAudio;
            audioSource.Play();
            playMessage = true;
        }
        if (message == BowlMessage.STRIKE)
        {
            bowlMessageDisplay.sprite = strikeSprite;
            audioSource.clip = strikeAudio;
            audioSource.Play();
            playMessage = true;
        }
        if (message == BowlMessage.DOUBLE)
        {
            bowlMessageDisplay.sprite = doubleSprite;
            audioSource.clip = doubleAudio;
            audioSource.Play();
            playMessage = true;
        }
        if (message == BowlMessage.TURKEY)
        {
            bowlMessageDisplay.sprite = turkeySprite;
            audioSource.clip = turkeyAudio;
            audioSource.Play();
            playMessage = true;
        }
    }
}
