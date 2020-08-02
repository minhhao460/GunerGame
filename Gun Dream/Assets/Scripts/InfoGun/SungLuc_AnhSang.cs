using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SungLuc_AnhSang : GunController
{
    public override float getAS()
    {
        return GetComponent<Shooter>().TocDoBan;
    }
    public override float getDamage()
    {
        return GetComponent<Shooter>().Damage;
    }

    public override string getInfo()
    {
        return STRINGS.Instance.SungLuc_Info;
    }

    public override string getInfoHe()
    {
        return STRINGS.Instance.SungLuc_InfoChoang;
    }

    public override string getName()
    {
        return STRINGS.Instance.SungLuc_Name_Choang;
    }
}
