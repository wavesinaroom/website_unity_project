using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public enum LabelElement { 
    Door, ParlanteIntro, Retrato, ControlXbox, Salir, IntroScreen, Mouse, 
    Consola, Teclado, Piano, Pantalla, Fox, Toky, Libreta, PostIt, AllRoom, Phone, None
}

public class Element : MonoBehaviour
{
    public LabelElement label;

    private Animator animator;
    public GameObject trail;

    [Header("Shader")]
    public SpriteRenderer spriteRenderer;
    public Material outlineMaterial;
    public Material defaultMaterial;

    [Header("Prefab waves")]
    public GameObject prefabWaves;

    [Space]
    [Range(0,500)]
    public float min = 20;
    [Range(0, 500)]
    public float max = 250;
    [Space]
    public Color colorNormal;
    public Color colorOver;

    private float current;
    private bool enterMouse;

    public Vector3 originalScale;
    public Vector3 newScale;

    public bool interactuable;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        current = min;
        UpdateOutline(interactuable);

        if (label != LabelElement.IntroScreen)
        {
            if (label == LabelElement.Door) {
                originalScale = Vector3.one;
                spriteRenderer.transform.localScale = originalScale;
            }

            originalScale = spriteRenderer.transform.localScale;
            Vector3 aux = new Vector3();
            aux = originalScale + (originalScale * 0.01f);
            newScale = aux;
        }

    }

  
  /*  void Update()
    {
        if (enterMouse)
        {
            current = Mathf.Clamp((current + Time.deltaTime * 200f), min, max);

            if (outlineMaterial != null)
                outlineMaterial.SetColor("_OutlineColor", colorOver);
        }
        else {
            current = min;

            if (outlineMaterial != null)
                outlineMaterial.SetColor("_OutlineColor", colorNormal);
        }

        if(outlineMaterial != null)
            outlineMaterial.SetFloat("_NoisePower", current);
    }
  */

    private void OnMouseEnter()
    {
        if (!interactuable)
            return;

        //if(animator != null)
        //animator.SetTrigger("FadeIn");

        if (spriteRenderer != null) {
            //trail.SetActive(true);
            //Instantiate(prefabWaves, this.transform);
            spriteRenderer.transform.localScale = newScale;
            enterMouse = true;
        }

    }

    private void OnMouseExit()
    {
        if (!interactuable)
            return;

        //if (animator != null)
        //animator.SetTrigger("FadeOut");

        if (spriteRenderer != null)
        {
            //trail.SetActive(false);
            spriteRenderer.transform.localScale = originalScale;
            enterMouse = false;
        }
    }

    private void OnMouseDown()
    {
        if (!interactuable)
            return;

        if (label == LabelElement.Door) {
            GetComponent<SpriteShapeRenderer>().enabled = false;
            StartCoroutine(GameController.instance.OpenDoor());
            return;
        }
            
        GameController.instance.InteractionObject(label);
    }

    public void UpdateOutline(bool value) {
        if (spriteRenderer == null)
            return;


        interactuable = value;

        if (!interactuable)
        {
            //spriteRenderer.material = defaultMaterial;
            trail.SetActive(false);
        }
        else
        {
            //spriteRenderer.material = outlineMaterial;
            trail.SetActive(true);
        }
    }

}
