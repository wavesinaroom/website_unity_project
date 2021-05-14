using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    public void ShowExternalURL(string url) {
        print("Hola");
        Application.ExternalEval("window.open(\'" + url +"\')");
    }
}
