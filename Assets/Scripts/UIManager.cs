using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager ui;

    public Image ui_Recticle;
    public Sprite ui_Normal;
    public Sprite ui_Available;

    [Header("TextBox")]
    public GameObject ui_TextBackGround;
    public TMP_Text heading, details;
    public float distanceIn, distanceBack, timeIn, timeBack;

    // Start is called before the first frame update
    void Start()
    {
        ui = this;
    }

    public void ChangeToNormalRectilce()
    {
        ui_Recticle.sprite = ui_Normal;
    }

    public void ChangeToAvailbleRectilce()
    {
        ui_Recticle.sprite = ui_Available;
    }

    public void LeanIn(string name, string facts)
    {
        heading.text = name;
        details.text = facts;
        LeanTween.moveLocalX(ui_TextBackGround, distanceIn, timeIn).setEase(LeanTweenType.easeInCubic);
    }

    public void LeanOut()
    {
        LeanTween.moveLocalX(ui_TextBackGround, distanceBack, timeBack).setEase(LeanTweenType.easeInCubic);
    }
}
