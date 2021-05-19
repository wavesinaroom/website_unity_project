using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoControllerUI : MonoBehaviour
{

    [Header("UI")]
    public TextMeshProUGUI txtTitle;
    public TextMeshProUGUI txtDescription;
    public TextMeshProUGUI txtTime;

    [Header("UI Buttons")]
    public TextMeshProUGUI txtTitleLegends;
    public TextMeshProUGUI txtTitleTBO;
    public TextMeshProUGUI txtTitleTyping;
    public TextMeshProUGUI txtTitleWiar;
    [Space]
    public TextMeshProUGUI txtDescriptionLegends;
    public TextMeshProUGUI txtDescriptionTBO;
    public TextMeshProUGUI txtDescriptionTyping;
    public TextMeshProUGUI txtDescriptionWiar;

    // Start is called before the first frame update
    void Start()
    {
        SetInformationUI(0);
    }

    public void SetInformationUI(int num) {
        switch (num) {
            case 0:
                txtTitle.text = txtTitleLegends.text;
                txtDescription.text = txtDescriptionLegends.text;
                break;
            case 1:
                txtTitle.text = txtTitleTBO.text;
                txtDescription.text = txtDescriptionTBO.text;
                break;
            case 2:
                txtTitle.text = txtTitleTyping.text;
                txtDescription.text = txtDescriptionTyping.text;
                break;
            case 3:
                txtTitle.text = txtTitleWiar.text;
                txtDescription.text = txtDescriptionWiar.text;
                break;
        }
    }

    private void Update()
    {
        //txtTime.text = VideoController.instance.videoPlayer.time.ToString();
    }


}
