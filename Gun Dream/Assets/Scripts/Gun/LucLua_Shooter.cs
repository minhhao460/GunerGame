using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucLua_Shooter : Shooter
{
    protected override void PlayAudioShoot()
    {
        AudioController.Instance.PlayAudio("SungLuc");
    }

    protected override void ShowEffectShoot()
    {
        EffectIsHere.Instance.SpawnEffect(EffectIsHere.Instance.getEffect("Shoot_LucLua"), spawnDan.transform, true);
    }
}
