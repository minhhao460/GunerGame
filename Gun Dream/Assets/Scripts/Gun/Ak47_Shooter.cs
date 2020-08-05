using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47_Shooter : Shooter
{
    protected override void PlayAudioShoot()
    {
        AudioController.Instance.PlayAudio("AK47_Shoot");
    }

}
