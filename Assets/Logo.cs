using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States_logo {
    Logo_ON,
    Logo_OFF
}


public class Logo : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;

    [SerializeField] GameObject logo;

    private States_logo State_logo {
        get { 
            return (States_logo)anim.GetInteger("LogoAnim"); 
            }
        set { 
            anim.SetInteger("LogoAnim", (int)value);
        }
    }

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        State_logo = States_logo.Logo_ON;
        logo.SetActive(false);
    }

    public void Form_off() {
        logo.SetActive(true);
        State_logo = States_logo.Logo_OFF;
    }

}
