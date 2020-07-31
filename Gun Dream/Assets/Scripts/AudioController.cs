using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource ThaySung;
    public AudioSource SungLucShoot;
    public static AudioController Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void Play_ThaySung()
    {
        ThaySung.Play();
    }

    public void Play_SungLucShoot()
    {
        SungLucShoot.Play();
    }
}
