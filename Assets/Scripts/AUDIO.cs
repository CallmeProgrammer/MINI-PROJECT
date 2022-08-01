using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO : MonoBehaviour
{
    public AudioSource ShortGun_Audio;
    public AudioSource ZombieMoarning_Audio;
    public AudioSource ZombieAttack_Audio;
    public AudioSource  Ak47_Audio;
    public AudioSource  Footsteps_Audio;
    public AudioSource  Background_Audio;
    public AudioSource  Glass_Break_Audio;
    public static AUDIO audio_instance;


    // Start is called before the first frame update
    private void Awake()
    {
        audio_instance = this;

        if(audio_instance != null)
        {
            return;
        }
        audio_instance = this;
    }
    void Start()
    {
        Background_Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play_ShortGun_Audio()
    {
        ShortGun_Audio.Play();
    }
    public void Play_ZombieMoarning_Audio()
    {
        ZombieMoarning_Audio.Play();
    }
    public void Play_AK47_Sound()
    {
        Ak47_Audio.Play();
    }

    public void Play_Footsteps_audio()
    {
        Footsteps_Audio.Play();
    } 
    
    public void Play_ZombieAttack_audio()
    {
        ZombieAttack_Audio.Play();
    }
    public void Play_GlassBreak_audio()
    {
        Glass_Break_Audio.Play();
    }
}
