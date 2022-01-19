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

    public int press;

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

    }

    public void Form_off() {
        State_form = States_form.form_anim;
        Invoke("Form_background", 0.8f);
    }

    private void Form_background() {
        if(press == 2) {
            gameObject.transform.localScale += new Vector3(0.1f,0.1f,0);
        }
        State_form = States_form.form_background;
    }

}
