using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectSlot : MonoBehaviour
{
    [Header("Information")]
    public InformationProject info;

    [Header("Panels")]
    public GameObject panelInformation;
    [Space]
    public TextMeshProUGUI txtTitle;
    public TextMeshProUGUI txtInformation;
    public TextMeshProUGUI txtCompany;
    public TextMeshProUGUI txtDate;
    [Space]
    public Image background;
    public Hyperlink hyperlink;
    public Button btnhyper;

    public Animator animator;

    private void OnEnable()
    {
        if (this.info.title == "Music production course") {
            ClickOverProject();
        }
    }


    public void EnterClick() {
        animator.SetTrigger("Wave");
        #region Audio
        AudioManager.instance.sfxAudioSource[9].Play(); 
        #endregion
    }

    public void ClickOverProject() {
        btnhyper.onClick.RemoveAllListeners();
        panelInformation.SetActive(true);
        background.sprite = info.background;
        txtTitle.text = info.title;
        txtInformation.text = info.information;
        txtCompany.text = info.company;
        txtDate.text = info.date;

        btnhyper.onClick.AddListener(() => hyperlink.ShowExternalURL(info.link));
    }

    public void CloseInfoProject() {
        panelInformation.SetActive(false);
    }

}



[System.Serializable]
public struct InformationProject {
    public Sprite background;
    public string title;
    [TextArea(2, 6)]
    public string information;
    public string company;
    public string date;
    public string link;
}
