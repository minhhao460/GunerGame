using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] Audio_Shoot;
    public string[] codeAudio;
    public static AudioController Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
          Instance = this;
    }

    public void PlayAudio(string code)
    {
        for (int i = 0; i < Audio_Shoot.Length; i++)
        {
            if (code == codeAudio[i])
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
            Audio_Shoot[code].Play();
        } else
        {
            Debug.LogWarning("Audio ko được tìm thấy: Mã code: " + codeAudio[code] + ".");
        }
    }
}
