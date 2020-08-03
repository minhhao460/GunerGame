using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : GunController
{
    public override string getInfo()
    {
        return STRINGS.Instance.SungTr_AK47_Info;
    }


    public override string getName()
    {
        return STRINGS.Instance.SungTr_AK47_Name;
    }

    public override float getDamage()
    {
        return GetComponent<Shooter>().Damage;
    }

    public override float getAS()
    {
        return GetComponent<Shooter>().TocDoBan;
    }
}
