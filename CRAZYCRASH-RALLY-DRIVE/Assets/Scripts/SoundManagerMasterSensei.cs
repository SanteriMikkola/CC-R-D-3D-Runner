using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerMasterSensei : MonoBehaviour
{
    public AudioSource mainS;

    public float volume = 1f;
    public Slider volumeSlide;

    public static SoundManagerMasterSensei Instance = null;

    public AudioClip crash;
    public AudioClip driveSound;
    public AudioClip ignitionSound;
    public AudioClip menuClick;
    public AudioClip turnOffCar;
    public AudioClip breakDownCar;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        
    }

    public void PlayCrashSound()
    {
        mainS.PlayOneShot(crash, volume);
    }

    public void PlayDriveSound()
    {
        mainS.PlayOneShot(driveSound, volume);
    }

    public void PlayIgnitionSound()
    {
        mainS.PlayOneShot(ignitionSound, volume);
    }

    public void PlayMenuClickSound()
    {
        mainS.PlayOneShot(menuClick, volume);
    }

    public void PlayTurnOffSound()
    {
        mainS.PlayOneShot(turnOffCar, volume);
    }

    public void PlayBreakDownSound()
    {
        mainS.PlayOneShot(breakDownCar, volume);
    }
}
