using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [SerializeField]
    private Audio_ShootQ[] Audio_Shoot;
    [Serializable]
    private class Audio_ShootQ
    {
        public string codeAudio;
        public AudioSource Source;
    }
    // Start is called before the first frame update
    private void Awake()
    {
          Instance = this;
    }

    public void PlayAudio(string code)
    {
        for (int i = 0; i < Audio_Shoot.Length; i++)
        {
            if (code == Audio_Shoot[i].codeAudio)
            {
                PlayAudio(i);
                return;
            }
        }
        Debug.LogWarning("Khong tim thay code (string) audio");
    }

    public void PlayAudio(int code)
    {
        if (Audio_Shoot[code] != null)
        {
            Audio_Shoot[code].Source.Play();
        } else
        {
            Debug.LogWarning("Audio ko được tìm thấy. Mã code: " + Audio_Shoot[code].codeAudio + ".");
        }
    }
}
