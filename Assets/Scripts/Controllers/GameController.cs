using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Variables

    public static GameController instance;

    [Header("Logo")]
    public GameObject logo;

    [Header("Zones")]
    public GameObject door;
    public GameObject room;
    public Element allRoomElement;

    [Header("Interactuables Room")]
    public Element controlXboxObj;
    public Element mouseObj;
    public Element consolaObj;
    public Element tecladoObj;
    public Element pianoObj;
    public Element pantallaObj;
    public Element spekersLeftObj;
    public Element spekersRigthObj;
    public Element retratoObj;
    public Element foxObj;
    public Element tokyObj;
    public Element notebookObj;
    public Element postItObj;
    public Element phoneObj;

    [Header("Informations panels")]
    public GameObject panelWeb;
    [Space]
    public GameObject panelAbout;
    [Space]
    public GameObject panelSkills;
    [Space]
    public GameObject panelTecnologies;
    [Space]
    public GameObject panelContact;
    [Space]
    public GameObject panelCredits;
    [Space]
    public GameObject panelNote;
    [Space]
    public GameObject panelProjects;
    [Space]
    public GameObject panelMusicPortfolio;
    [Space]
    public GameObject panelSoundDesign;
    [Space]
    public GameObject panelSalida;

    [Header("Panel Fade")]
    public GameObject panelFade;

    [Header("UI Text")]
    public GameObject txtClickToContinue;
    public GameObject txtScreenGeneral;

    public bool finishIntro;

    private Animator animator;

    #endregion

    #region Init

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        finishIntro = false;
        panelFade.SetActive(false);
        animator = GetComponent<Animator>();
        room.SetActive(false);
        door.SetActive(true);
    }

    #endregion

    #region Introduction

    public IEnumerator OpenDoor()
    {
        //StartCoroutine(FadeOUTIN());

        panelFade.SetActive(true);
        panelFade.GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);
        logo.SetActive(true);
        yield return new WaitForSeconds(.2f);
        panelFade.SetActive(false);

        yield return new WaitForSeconds(3.8f);
        panelFade.SetActive(true);
        txtClickToContinue.SetActive(true);
        panelFade.GetComponent<Animator>().SetTrigger("FadeIn");

        logo.SetActive(false);
        room.SetActive(true);
        door.SetActive(false);

        yield return new WaitForSeconds(1.1f);
        panelFade.SetActive(false);

    }

    IEnumerator FirstInteraction() {
        //yield return new WaitUntil(() => DollyController.instance.dolly.m_PathPosition == 1);

        CameraController.instance.ChangeCamera(LabelCamera.Desk);
        yield return new WaitForSeconds(2f);
        panelFade.SetActive(false);
        allRoomElement.GetComponent<PolygonCollider2D>().enabled = false;
        
        txtClickToContinue.GetComponent<TextMeshProUGUI>().text = "Turn the speakers on to enjoy catalogue";
        spekersLeftObj.UpdateOutline(true);
    }

    void SpekersIntro()
    {
        txtClickToContinue.GetComponent<TextMeshProUGUI>().text = "Turn on the screen monitor";

        spekersLeftObj.UpdateOutline(false);
        spekersLeftObj.spriteRenderer.transform.localScale = spekersLeftObj.originalScale;

        pantallaObj.UpdateOutline(true);

        //finishIntro = true;
        //pantallaObj.SetActive(true);
    }

    void ScreenIntro() {

        txtClickToContinue.SetActive(false);
        txtScreenGeneral.SetActive(true);

        txtScreenGeneral.GetComponent<TextMeshProUGUI>().text = "Click on the objects to interact with them";

        pantallaObj.spriteRenderer.transform.localScale = pantallaObj.originalScale;
        pantallaObj.UpdateOutline(false);

        pianoObj.UpdateOutline(true);
        phoneObj.UpdateOutline(true);
        tecladoObj.UpdateOutline(true);
        mouseObj.UpdateOutline(true);
        retratoObj.UpdateOutline(true);
        controlXboxObj.UpdateOutline(true);
        consolaObj.UpdateOutline(true);
        postItObj.UpdateOutline(true);
        foxObj.UpdateOutline(true);
        tokyObj.UpdateOutline(true);
        notebookObj.UpdateOutline(true);


        allRoomElement.transform.position = new Vector3(-0.19f, -0.86f, 8.5f);
        allRoomElement.label = LabelElement.AllRoom;
        allRoomElement.GetComponent<SpriteShapeRenderer>().sortingLayerName = "Background";
        allRoomElement.GetComponent<PolygonCollider2D>().enabled = true;
    }


    #endregion

    #region InteraccionesObjetos

    public void InteractionObject(LabelElement label) {
        switch (label) {

            #region Intro
            case LabelElement.IntroScreen:
                //StartCoroutine(DollyController.instance.MoveDollyToPosition(1));
                StartCoroutine(FirstInteraction());
                break;

            case LabelElement.ParlanteIntro:
                SpekersIntro();
                break;

            case LabelElement.Pantalla:
                ScreenIntro();
                break;

            #endregion

            case LabelElement.Retrato:
                ClosePanels();
                StartCoroutine(ShowRetrato());
                CameraController.instance.ChangeCamera(LabelCamera.Retrato);
                break;
            
            case LabelElement.ControlXbox:
                ClosePanels();
                StartCoroutine(ShowPanelProjects());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Mouse:
                ClosePanels();
                StartCoroutine(ShowPanelSkills());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Consola:
                ClosePanels();
                StartCoroutine(ShowPanelSoundDesign());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Piano:
                ClosePanels();
                StartCoroutine(ShowPanelMusic());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Teclado:
                ClosePanels();
                StartCoroutine(ShowPanelTecnologies());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Fox:
                ClosePanels();
                StartCoroutine(ShowPanelCredit());
                CameraController.instance.ChangeCamera(LabelCamera.Animals);
                break;

            case LabelElement.Toky:
                ClosePanels();
                StartCoroutine(ShowPanelCredit());
                CameraController.instance.ChangeCamera(LabelCamera.Animals);
                break;

            case LabelElement.Libreta:
                ClosePanels();
                StartCoroutine(ShowPanelNotebook());
                CameraController.instance.ChangeCamera(LabelCamera.Notebook);
                break;

            case LabelElement.PostIt:
                ClosePanels();
                StartCoroutine(ShowPanelSalida());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.Phone:
                ClosePanels();
                StartCoroutine(ShowPanelContact());
                CameraController.instance.ChangeCamera(LabelCamera.Screen);
                break;

            case LabelElement.AllRoom:
                ClosePanels();
                StartCoroutine(ReturnCamera());
                break;
        }
    }

    private void ClosePanels() {
        txtScreenGeneral.SetActive(false);
        panelWeb.SetActive(false);
        panelMusicPortfolio.SetActive(false);
        panelSkills.SetActive(false);
        panelTecnologies.SetActive(false);
        panelContact.SetActive(false);
        panelCredits.SetActive(false);
        panelNote.SetActive(false);
        panelProjects.SetActive(false);
        panelAbout.SetActive(false);
        panelSoundDesign.SetActive(false);
    }

    public IEnumerator ReturnCamera() {

        switch (CameraController.instance.currentCamera) {
            case LabelCamera.Retrato:
                //panelAbout.GetComponent<Animator>().SetTrigger("FadeOut");
                yield return new WaitForSeconds(0.1f);

                break;
        }

        CameraController.instance.ReturnCamera();
    }

    IEnumerator ShowRetrato() {
        yield return new WaitForSeconds(2f);
        panelAbout.SetActive(true);
        //panelAbout.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    IEnumerator ShowPanelMusic() {
        yield return new WaitForSeconds(2f);
        panelWeb.SetActive(true);
        panelMusicPortfolio.SetActive(true);
    }

    IEnumerator ShowPanelSkills() {
        yield return new WaitForSeconds(2f);
        panelWeb.SetActive(true);
        panelSkills.SetActive(true);
    }

    IEnumerator ShowPanelTecnologies() {
        yield return new WaitForSeconds(2f);
        panelWeb.SetActive(true);
        panelTecnologies.SetActive(true);
    }

    IEnumerator ShowPanelContact() {
        yield return new WaitForSeconds(2f);
        panelContact.SetActive(true);
    }

    IEnumerator ShowPanelCredit() {
        yield return new WaitForSeconds(2f);
        panelCredits.SetActive(true);
    }

    IEnumerator ShowPanelNotebook()
    {
        yield return new WaitForSeconds(2f);
        panelNote.SetActive(true);
    }

    IEnumerator ShowPanelProjects() {
        yield return new WaitForSeconds(2f);
        panelWeb.SetActive(true);
        panelProjects.SetActive(true);
    }

    IEnumerator ShowPanelSoundDesign() {
        yield return new WaitForSeconds(2f);
        panelWeb.SetActive(true);
        panelSoundDesign.SetActive(true);
    }

    IEnumerator ShowPanelSalida() {
        yield return new WaitForSeconds(2f);
        panelSalida.SetActive(true);
    }

    public void ResetExperence() {
        SceneManager.LoadScene("Main");
    }

    #endregion

    #region Screens

    IEnumerator FadeScreen(SpriteRenderer sprite, float newValue) {
        bool fade = true;
        Color newColor = new Color();
        newColor = sprite.color;
        while (fade) {
            if (sprite.color.a != newValue)
            {
                if (newColor.a < newValue)
                {
                    newColor.a = Mathf.Clamp(newColor.a + 0.01f, 0, newValue);
                }
                else {
                    newColor.a = Mathf.Clamp(newColor.a - 0.01f, 0, newValue);
                }
                sprite.color = newColor;
            }
            else {
                fade = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion

}
