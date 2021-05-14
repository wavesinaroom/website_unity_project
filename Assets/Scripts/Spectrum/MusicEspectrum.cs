using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MusicEspectrum : MonoBehaviour
{

    #region Variables

    [Header("Images")]
    public List<VisualizerObject> visualizerObject;

    [Header("Stats")]
    public Color visualizerColor;
    public float minHeight = 20f;
    public float maxHeight = 780f;
    public float sensibility = 0.5f;

    [Range(64, 8192)]
    public int visualizerSamples = 64;

    [Header("AudioSource")]
    public AudioSource source;
    private AudioClip clip;
    public float timeStart;

    private float[] spectrumData;

    public float radius;
    public Vector2 center;

    public int multiply;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        source.time = timeStart;

        visualizerObject = new List<VisualizerObject>();
        foreach (VisualizerObject visual in GetComponentsInChildren<VisualizerObject>()) {
            visualizerObject.Add(visual);
            visual.InitColor(visualizerColor);
        }

        spectrumData = new float[visualizerSamples];
        //SpawnCircle();
    }

    public void SpawnCircle()
    {
        for (int i = 0; i < visualizerObject.Count; i++) {
            float ang = i * 1.0f / visualizerObject.Count;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Sin(ang) * radius;

            Vector2 pos = center + new Vector2(x, y);
            visualizerObject[i].transform.position = pos;
            visualizerObject[i].transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
        }

        Vector3 position = new Vector3();

        position.x = 540;
        position.y = 375;
        position.z = this.transform.localPosition.z;
        this.transform.localPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Triangle);    

        for (int i = 0; i < visualizerObject.Count; i++) {
            visualizerObject[i].UpdateSize((spectrumData[i]*multiply), minHeight, maxHeight, sensibility);
        }

    }
}
