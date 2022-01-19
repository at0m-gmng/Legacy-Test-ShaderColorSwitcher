using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States_palit {
    palit_ON,
    palit_OFF
}

public class AnimPalit : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;

    private Button button;
    public GameObject form;


    private States_palit State_palit {
        get { 
            return (States_palit)anim.GetInteger("AnimPalit"); 
            }
        set { 
            anim.SetInteger("AnimPalit", (int)value);
        }
    }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 

        // button = gameObject.GetComponentInChildren<Button>();
        form = GameObject.Find("formImage");
        
        // button_color();
        // form.SetActive(false);
    }

    public void button_color(string name) {
        // string name = GameObject.GetComponent<Button>().name;
        button = GameObject.Find(name).GetComponent<Button>();
        // Debug.Log(form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee"));
        // var value = button.GetComponent<Image>().color;
        // Debug.Log(button.GetComponent<Image>().color);
        form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", button.GetComponent<Image>().color);
        
    }

    public void Form_off() {
        State_palit = States_palit.palit_OFF;
    }
}
