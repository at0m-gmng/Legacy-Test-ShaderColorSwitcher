using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum States_form {
    form_ON,
    form_anim,
    form_background
}

public class AnimForm : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;

    // public GameObject form;

    private States_form State_form {
        get { 
            return (States_form)anim.GetInteger("Anim"); 
            }
        set { 
            anim.SetInteger("Anim", (int)value);
        }
    }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        State_form = States_form.form_ON;

        // form = GameObject.Find("formImage");
        // установка цвета шейдера
        // Debug.Log(form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee"));
        // form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", Color.grey);

    }

    public void Form_off() {
        State_form = States_form.form_anim;
        Invoke("Form_background", 0.8f);
        // State_form = States_form.form_background;
    }

    private void Form_background() {
        // form.scale
        gameObject.transform.localScale += new Vector3(0.1f,0.1f,0);
        State_form = States_form.form_background;
    }

}
