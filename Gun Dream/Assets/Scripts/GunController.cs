using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour, ThongTInSungManager
{
    public static float MaxDamage = 100;
    public static float MaxAttrackSpeed = 10;
    public Sprite HinhAnh;
    public Color colorhe;
    public Color fixedcolorhe = new Color(0, 0.475f, 1, 0.439f);

    #region Bắt buộc Overide
    public virtual float getAS()
    {
        throw new NotImplementedException();
    }

    public virtual float getDamage()
    {
        throw new NotImplementedException();
    }
    public virtual string getInfo()
    {
        throw new NotImplementedException();
    }
    public virtual string getName()
    {
        throw new NotImplementedException();
    }
    #endregion
    #region Không bắc buộc Overide
    public virtual Sprite getImage()
    {
        return HinhAnh;
    }

    public virtual string getInfoHe()
    {
        return STRINGS.Instance.InfoNone;
    }

    public Color getColorHe()
    {
        return colorhe;
    }

    public Color getFixedColor()
    {
        return fixedcolorhe;
    }
    #endregion
}
