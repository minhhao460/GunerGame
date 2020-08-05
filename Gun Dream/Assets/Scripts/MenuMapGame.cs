using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMapGame : MonoBehaviour
{
    public Shooter[] GunStart;
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.Player.transform.position = new Vector3(0, PlayerManager.Instance.posY[PlayerPrefs.GetInt("Player_int")], 40);
        for (int i = 0; i < GunStart.Length; i++)
        {
            GetGunFromMap a = EffectIsHere.Instance.SpawnEffect(EffectIsHere.Instance.GunSpawner.gameObject, gameObject.transform, true).GetComponent<GetGunFromMap>();
            a.AddGun(GunStart[i], false);
            a.gameObject.transform.localPosition = new Vector3(90 - 15 * i, 0, 50);
        }
    }


}
