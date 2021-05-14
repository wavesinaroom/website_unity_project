using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public Color newColor;
    public Color originalColor;

    private TextMeshProUGUI text;
    private bool enter;
    private Vector3 newScale;

    // Start is called before the first frame update
    void Start()
    {
        newScale = new Vector3(1.05f, 1.05f, 1.05f);
        enter = false;
        text = GetComponent<TextMeshProUGUI>();
        text.color = originalColor;
    }


    void Update()
    {
        if (enter)
        {
            text.color = Color.Lerp(text.color, newColor, Time.deltaTime*10f);
        }
        else {
            text.color = Color.Lerp(text.color, originalColor, Time.deltaTime * 10f);
        }
    }

    public void EnterClick() {
        transform.localScale = newScale;
        enter = true;
    }

    public void ExitClick() {
        transform.localScale = Vector3.one;
        enter = false;
    }
}
