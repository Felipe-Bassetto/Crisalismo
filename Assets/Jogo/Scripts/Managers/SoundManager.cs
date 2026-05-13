using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource loopSource;
    public AudioClip[] audiosSFX;
    public AudioClip[] audiosOST;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        sfxSource.PlayOneShot(audiosSFX[index]);
    }

    public void PlayLoop(int index)
    {
        loopSource.clip = audiosOST[index];
        loopSource.Play();
    }
}
