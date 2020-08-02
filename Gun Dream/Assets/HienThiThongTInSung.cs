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
    public Text InfoMore;

    private GunController guncontroller;
    private void OnEnable()
    {
        guncontroller = GunManager.GunFromMap.GetComponent<GunController>();
        SetStart();
    }

    public void SetStart()
    {
        MainImage.sprite = guncontroller.getImage();
        MainText.text = guncontroller.getName();
        damageInamge.sprite = Imagedamage;
        ASImage.sprite = ImageAS;

        SliDamage.maxValue = GunController.MaxDamage;
        SliDamage.value = guncontroller.getDamage();

        SliAS.maxValue = GunController.MaxAttrackSpeed;
        SliAS.value = guncontroller.getAS();

        InfoMore.text = guncontroller.getInfoHe();
        InfoMore.color = guncontroller.getColorHe();

    }
}
