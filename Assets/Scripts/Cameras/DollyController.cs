using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyController : MonoBehaviour
{
    public static DollyController instance;

    private CinemachineVirtualCamera cam;
    [HideInInspector] public CinemachineTrackedDolly dolly;

    private int maxPathDolly;

    private bool move;

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
        maxPathDolly = 1;
        cam = GetComponent<CinemachineVirtualCamera>();
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        dolly.m_PathPosition = 0f;
    }

    public void ChangePathDolly(float amount) {
        dolly.m_PathPosition = Mathf.Clamp((dolly.m_PathPosition + amount), 0, maxPathDolly);
    }

    public IEnumerator MoveDollyToPosition(int newPos) {
        move = true;
        while (move) {
            if (dolly.m_PathPosition != newPos)
            {
                if (dolly.m_PathPosition < newPos)
                {
                    ChangePathDolly(0.1f);
                }
                else {
                    ChangePathDolly(-0.1f);
                }
            }
            else {
                move = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
