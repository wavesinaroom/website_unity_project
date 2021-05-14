using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerObject : MonoBehaviour
{
    [HideInInspector] public Vector2 barSize;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        barSize = rectTransform.rect.size;
    }

    public void InitColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }

    public void UpdateSize(float espectrum, float min, float max, float sensibility) {
        barSize.y = Mathf.Clamp(Mathf.Lerp(barSize.y, min + (espectrum * (max - min) * 5f), sensibility),min,max);
        rectTransform.sizeDelta = barSize;
    }

}
