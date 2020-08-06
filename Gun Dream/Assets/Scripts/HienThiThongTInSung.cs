using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HienThiThongTInSung : MonoBehaviour
{
    public Sprite Imagedamage;
    public Sprite ImageAS;

    public Image MainImage;
    public Text MainText;
    public Image damageInamge;
    public Slider SliDamage;
    public Image ASImage;
    public Slider SliAS;
    public Text Info;
    public Text InfoHe;
    public Image fixecolor;

    private Shooter shooter;
    private void OnEnable()
    {
        shooter = GunManager.Instance.GunFromMap.GetComponent<Shooter>();
        SetStart();
    }

    public void SetStart()
    {
        MainImage.sprite = shooter.getImage();
        MainText.text = shooter.getName();
        damageInamge.sprite = Imagedamage;
        ASImage.sprite = ImageAS;

        SliDamage.maxValue = GunManager.Instance.MaxDamage;
        SliDamage.value = shooter.getDamage();

        SliAS.maxValue = GunManager.Instance.MaxAS;
        SliAS.value = shooter.getAS();

        Info.text = shooter.getInfo();

        InfoHe.text = shooter.getInfoHe();
        InfoHe.color = shooter.getColorHe();

        fixecolor.color = shooter.getFixedColorHe();
    }
}
