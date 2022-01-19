using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States_logoText {
    use_logo,
    use_logo_OFF
}

public class AnimUseLogo : MonoBehaviour {
    Animator anim;
    SpriteRenderer sr;

    private GameObject logoText;

    private States_logoText State_logoText {
        get { 
            return (States_logoText)anim.GetInteger("AnimLogoText"); 
            }
        set { 
            anim.SetInteger("AnimLogoText", (int)value);
        }
    }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        logoText = GameObject.Find("use_logo");
        State_logoText = States_logoText.use_logo;
        logoText.SetActive(false);
    }

    public void Form_off() {
        logoText.SetActive(true);
        State_logoText = States_logoText.use_logo_OFF;
    }
}
