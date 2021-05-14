using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum LabelCamera{ 
    None, AllRoom, Desk, Screen, Retrato, Animals, Notebook
}

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private CinemachineStateDrivenCamera stateDriven;

    public LabelCamera currentCamera;

    private Animator animatorCameras;

    public bool moving;

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
        moving = false;
        stateDriven = GetComponent<CinemachineStateDrivenCamera>();
        animatorCameras = GameController.instance.GetComponent<Animator>();
        currentCamera = LabelCamera.AllRoom;
    }

    public void ChangeCamera(LabelCamera label) {
        if (!moving) {
            moving = true;
            StartCoroutine(WaitToNewCamera(label));
        }
    }

    IEnumerator WaitToNewCamera(LabelCamera label) {
        animatorCameras.SetTrigger(label.ToString());
        currentCamera = label;
        yield return new WaitForSeconds(2f);
        moving = false;
    }

    public void ReturnCamera() {
        switch (currentCamera) {

            case LabelCamera.Retrato:
            case LabelCamera.Screen:
                ChangeCamera(LabelCamera.Desk);
                break;

            case LabelCamera.Notebook:
            case LabelCamera.Animals:
            case LabelCamera.Desk:
                ChangeCamera(LabelCamera.AllRoom);
                break;
        }
    }

}
