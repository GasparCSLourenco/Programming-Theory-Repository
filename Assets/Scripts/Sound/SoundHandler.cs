using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    public AudioClip bgMusic;
    public AudioClip dmgSound;
    public AudioClip deathSound;
    public AudioClip pointPickupSound;
    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.1f;
        source.PlayOneShot(bgMusic);
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayDmgSound()
    {
        source.PlayOneShot(dmgSound,0.5f);
    }

    public void PlayPointPickupSound()
    {
        source.PlayOneShot(pointPickupSound,2f);
    }

    public void PlayDeathSound()
    {
        source.PlayOneShot(dmgSound,0.5f);
    }

}
