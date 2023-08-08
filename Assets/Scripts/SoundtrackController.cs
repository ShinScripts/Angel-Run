using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{

    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject menu;
   

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = levelMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeMusic()
    {
        if (menu.activeInHierarchy == true) {
            audioSource.Stop();
            audioSource.clip = menuMusic;
            audioSource.Play();
        } else if (menu.activeInHierarchy == false) {
            audioSource.Stop();
            audioSource.clip = levelMusic;
            audioSource.Play();
        }
    }

}
