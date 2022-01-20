using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class main_choice_color : MonoBehaviour {

    Animator anim;
    SpriteRenderer sr;

    private Button button;
    private Button button_next;
    private Button  random_color;
    public GameObject form;
    public GameObject logo;

    private int shader_count = 0;
    public int press = 1;


    void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        form = GameObject.Find("formImage");
        logo = GameObject.Find("LogoImage");
        random_color = GameObject.Find("Random_Color_Button").GetComponent<Button>();
        button_next = GameObject.Find("Next_button").GetComponent<Button>();
    }
    // если далее нажато 3 и более раза, другая сцена
    public void counter() {
        press++;
        if(press >= 3) {
            SceneManager.LoadScene(1);
        }
    } 
    // рандомный цвет сразу для 3х частей
    public void random_Color() {
        if (press == 1) {
            form.GetComponent<Image>().material.SetColor("_Color1", new Color(Random.value, Random.value, Random.value, 1));
            form.GetComponent<Image>().material.SetColor("_Color2", new Color(Random.value, Random.value, Random.value, 1));
            form.GetComponent<Image>().material.SetColor("_Color3", new Color(Random.value, Random.value, Random.value, 1));
        }
        if (press == 2) {
            logo.GetComponent<Image>().material.SetColor("_ColorLogo1", new Color(Random.value, Random.value, Random.value, 1));
            logo.GetComponent<Image>().material.SetColor("_ColorLogo2", new Color(Random.value, Random.value, Random.value, 1));
            logo.GetComponent<Image>().material.SetColor("_ColorLogo3", new Color(Random.value, Random.value, Random.value, 1));

        }
    }
    // изменение объекта окраски после нажатия кнопки далее
    public void button_color(string name) {
        button = GameObject.Find(name).GetComponent<Button>();
        if(press == 1 && shader_count == 0) {
            form.GetComponent<Image>().material.SetColor("_Color1", button.GetComponent<Image>().color);
        } else if (press == 1 && shader_count == 1) {
            form.GetComponent<Image>().material.SetColor("_Color2", button.GetComponent<Image>().color);
        } else if (press == 1 && shader_count == 2) {
            form.GetComponent<Image>().material.SetColor("_Color3", button.GetComponent<Image>().color);
        } else if (press == 1) {
            form.GetComponent<Image>().material.SetColor("_Color1", button.GetComponent<Image>().color);
        }
        if(press == 2 && shader_count == 0) {
            logo.GetComponent<Image>().material.SetColor("_ColorLogo1", button.GetComponent<Image>().color);
        } else if (press == 2 && shader_count == 1) {
            logo.GetComponent<Image>().material.SetColor("_ColorLogo2", button.GetComponent<Image>().color);
        } else if (press == 2 && shader_count == 2) {
            logo.GetComponent<Image>().material.SetColor("_ColorLogo3", button.GetComponent<Image>().color);
        }  else if (press == 2) {
            logo.GetComponent<Image>().material.SetColor("_ColorLogo1", button.GetComponent<Image>().color);
        }
    }
    // в зависимости от выбора кнопки по центру выбирается материал и окрашиваемая область
    public void shader_change(string name) {
        if (name == "Color_but_left") {
            shader_count = 0;
        } else if (name == "Color_but_midlle") {
            shader_count = 1;
        } else if (name == "Color_but_right") {
            shader_count = 2;
        }
        // form.GetComponent<Image>().material = meshRen.materials[shader_count];
        // Debug.Log(form.GetComponent<Image>().material);
        // Debug.Log(meshRen.materials[shader_count]);
    }
}
