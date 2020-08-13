using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucLac_Shooter : Shooter
{
    public GameObject[] HieuUngBan;

    private int idEffect;

    public override void Shoot()
    {
        idEffect = Random.Range(0, viendan.Length);
        Vector3 a;
        if (FindEnemy.Instance.HaveEnemy())
        {
            Vector3 huong = (FindEnemy.Instance.getPosEnemy() - spawnDan.transform.position);
            a = Quaternion.LookRotation(huong).eulerAngles;
        }
        else
        {
            a = dk.getHuong().eulerAngles;
        }
        float giat = doGiat;
        if (!player.GetComponent<PlayerController>().IsMoving())
        {
            giat /= 2;
        }
        a.y = a.y + Random.Range(-giat, giat);
        a.x = a.x + Random.Range(-giat, giat);
        VienDan dan = Instantiate(viendan[idEffect], spawnDan.transform.position, Quaternion.Euler(a)) as VienDan;
        dan.setSpeed(TocDoBay);
        dan.setDamage(Damage);
    }

    protected override void ShowEffectShoot()
    {
        if (HieuUngBan[idEffect] != null)
        {
            GameObject ef = Instantiate(HieuUngBan[idEffect], spawnDan.transform, false);
            Destroy(ef, 0.2f);
        }
        else
        {
            LogW("Chưa kh báo HIỆU ỨNG BẮN cho súng " + gameObject.name);
        }
    }
}
