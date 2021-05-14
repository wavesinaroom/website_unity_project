using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject prefabWave;

    private Camera mainCamera;    
    private Vector3 mousePos;
    private Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            mousePos = Input.mousePosition;
            mousePos.z = 10f;
            worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            Instantiate(prefabWave, worldPos, Quaternion.identity);
        }

        if (!GameController.instance.finishIntro)
            return;

        if (Input.mouseScrollDelta.y > 0) {
            DollyController.instance.ChangePathDolly(0.1f);
        }

        if (Input.mouseScrollDelta.y < 0) {
            DollyController.instance.ChangePathDolly(-0.1f);
        }
    }
}
