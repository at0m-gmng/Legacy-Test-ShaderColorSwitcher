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
    }

    public void Form_off() {
        State_palit = States_palit.palit_OFF;
    }
}
