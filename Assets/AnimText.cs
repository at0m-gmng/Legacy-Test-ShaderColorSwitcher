using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum States_text {
    use_form_ON,
    use_form_OFF
}

public class AnimText : MonoBehaviour
{
   Animator anim;
    SpriteRenderer sr;

    private States_text State_text {
        get { 
            return (States_text)anim.GetInteger("AnimText"); 
            }
        set { 
            anim.SetInteger("AnimText", (int)value);
        }
    }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        State_text = States_text.use_form_ON;
    }

    public void Form_off() {
        State_text = States_text.use_form_OFF;
    }
}
