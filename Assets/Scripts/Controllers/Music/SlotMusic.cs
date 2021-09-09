using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMusic : MonoBehaviour
{
    public static SlotMusic last;

    [Header("UI General")]
    public Image imgBig;
    public TextMeshProUGUI txtTitleBig;
    public TextMeshProUGUI txtGameBig;
    public TextMeshProUGUI txtCompanyBig;

    [Space]
    public TextMeshProUGUI txtInformation;

    [Header("Current UI")]
    public TextMeshProUGUI txtTitle;
    public TextMeshProUGUI txtGame;
    public TextMeshProUGUI txtCompany;

    [Space]
    public Image imgIcon;
    public Image imgOutline;

    [TextArea(2, 6)]
    public string information;

    public bool active;

    private void Start() {
        if(gameObject.name == "Slot1")
        {
            active = true;
            last = this; 
            imgOutline.enabled = true; 
        }
    }

    public void ChangeInformationMusic() {
        if (!active) {
            active = true;
            imgBig.sprite = imgIcon.sprite;

            txtTitleBig.text = txtTitle.text;
            txtCompanyBig.text = txtCompany.text;
            txtGameBig.text = txtGame.text;

            txtInformation.text = information;
            imgOutline.enabled = true;

            if (last != null) {
                last.CloseInformationMusic();
            }

            last = this;
            
        }
    }

    public void CloseInformationMusic() {
        if (active) {
            imgOutline.enabled = false;
            active = false;
        }
    }

    
}
