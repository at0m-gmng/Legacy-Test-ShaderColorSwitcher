using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_choice_color : MonoBehaviour {

    [SerializeField] private dataData data;

    Animator anim;
    SpriteRenderer sr;

    private Button button;
    private Button button_next;
    private Button button_main_color_left;
    private Button button_main_color_midlle;
    private Button button_main_color_right;

    private Button  random_color;
    private GameObject form;
    private GameObject logo;

    private int shader_count = 0;
    public int press = 1;
    float x, y, z;

    void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        form = GameObject.Find("formImage");
        logo = GameObject.Find("LogoImage");
        random_color = GameObject.Find("Random_Color_Button").GetComponent<Button>();
        button_next = GameObject.Find("Next_button").GetComponent<Button>();
        button_main_color_left = GameObject.Find("Color_but_left").GetComponent<Button>();
        button_main_color_midlle = GameObject.Find("Color_but_midlle").GetComponent<Button>();
        button_main_color_right = GameObject.Find("Color_but_right").GetComponent<Button>();

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
        Color color_random = new Color(Random.value, Random.value, Random.value, 1);
        Color.RGBToHSV(color_random, out x, out y, out z);
        if(press == 1) {
                form.GetComponent<Image>().material.SetColor("_Color_1", color_random);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_1", new Vector4(x, y, (z-.6f), 0));

                color_random = new Color(Random.value, Random.value, Random.value, 1);
                Color.RGBToHSV(color_random, out x, out y, out z);

                form.GetComponent<Image>().material.SetColor("_Color_2", color_random);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_2", new Vector4(x, y, (z-.6f), 0));
                
                color_random = new Color(Random.value, Random.value, Random.value, 1);
                Color.RGBToHSV(color_random, out x, out y, out z);

                form.GetComponent<Image>().material.SetColor("_Color_3", color_random);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_3", new Vector4(x, y, (z-.6f), 0));
            }
        if(press == 2) {
                logo.GetComponent<Image>().material.SetColor("_Color_1", color_random);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_1", new Vector4(x, y, (z-.6f), 0));

                color_random = new Color(Random.value, Random.value, Random.value, 1);
                Color.RGBToHSV(color_random, out x, out y, out z);

                logo.GetComponent<Image>().material.SetColor("_Color_2", color_random);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_2", new Vector4(x, y, (z-.6f), 0));
                
                color_random = new Color(Random.value, Random.value, Random.value, 1);
                Color.RGBToHSV(color_random, out x, out y, out z);

                logo.GetComponent<Image>().material.SetColor("_Color_3", color_random);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_3", new Vector4(x, y, (z-.6f), 0));
            }
        for (int i = 0; i <= 2; i++) {
            shader_count = i;
            main_color_buttons();
        }

    }
    // изменение объекта окраски после нажатия кнопки далее
    public void button_color(string name) {
        button = GameObject.Find(name).GetComponent<Button>();
        //Debug.Log(name);
        Color.RGBToHSV(button.GetComponent<Image>().color, out x, out y, out z);
        if(x ==0 && y == 0) 
            y = -3f;
        if(press == 1) {
            if (shader_count == 0) {
                form.GetComponent<Image>().material.SetColor("_Color_1", button.GetComponent<Image>().color);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_1", new Vector4(x, y, (z-.6f), 0));
            } else if (shader_count == 1) {
                form.GetComponent<Image>().material.SetColor("_Color_2", button.GetComponent<Image>().color);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_2", new Vector4(x, y, (z-.6f), 0));
            } else if (shader_count == 2) {
                form.GetComponent<Image>().material.SetColor("_Color_3", button.GetComponent<Image>().color);
                form.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_3", new Vector4(x, y, (z-.6f), 0));
            }
        }
        if(press == 2) {
            if (shader_count == 0) {
                logo.GetComponent<Image>().material.SetColor("_Color_1", button.GetComponent<Image>().color);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_1", new Vector4(x, y, (z-.8f), 0));
            } else if (shader_count == 1) {
                logo.GetComponent<Image>().material.SetColor("_Color_1", button.GetComponent<Image>().color);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_2", new Vector4(x, y, (z-.8f), 0));
            } else if (shader_count == 2) {
                logo.GetComponent<Image>().material.SetColor("_Color_1", button.GetComponent<Image>().color);
                logo.GetComponent<Image>().material.SetVector("_HSVA_Color_Adjust_3", new Vector4(x, y, (z-.8f), 0));
            }
        }
        main_color_buttons();
    }

    private void main_color_buttons() {
        if(press == 1) {
            if (shader_count == 0) {
                button_main_color_left.GetComponent<Image>().color = form.GetComponent<Image>().material.GetColor("_Color_1");
            } else if (shader_count == 1) {
                button_main_color_midlle.GetComponent<Image>().color = form.GetComponent<Image>().material.GetColor("_Color_2");
            } else if (shader_count == 2) {
                button_main_color_right.GetComponent<Image>().color = form.GetComponent<Image>().material.GetColor("_Color_3");
            }
        }
        if(press == 2) {
            if (shader_count == 0) {
                button_main_color_left.GetComponent<Image>().color = logo.GetComponent<Image>().material.GetColor("_Color_1");
            } else if (shader_count == 1) {
                button_main_color_midlle.GetComponent<Image>().color = logo.GetComponent<Image>().material.GetColor("_Color_2");
            } else if (shader_count == 2) {
                button_main_color_right.GetComponent<Image>().color = logo.GetComponent<Image>().material.GetColor("_Color_3");
            }
        }
    }
    // в зависимости от выбора кнопки по центру выбирается материал и окрашиваемая область
    public void shader_change(string name) {
        // button_main_color = GameObject.Find(name).GetComponent<Button>();
        if(press == 1) {
            if (name == "Color_but_left") {
                shader_count = 0;
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_1", data.HSV_Color_Range_Min_1[0]);
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_1", data.HSV_Color_Range_Max_1[0]);
            } else if (name == "Color_but_midlle") {
                shader_count = 1;
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_2", data.HSV_Color_Range_Min_2[0]);
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_2", data.HSV_Color_Range_Max_2[0]);
            } else if ( name == "Color_but_right") {
                shader_count = 2;
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_3", data.HSV_Color_Range_Min_3[0]);
                form.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_3", data.HSV_Color_Range_Max_3[0]);
            }
        }
        if(press == 2) {
            if (name == "Color_but_left") {
                shader_count = 0;
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_1", data.HSV_Color_Range_Min_1[1]);
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_1", data.HSV_Color_Range_Max_1[1]);
            } else if (name == "Color_but_midlle") {
                shader_count = 1;
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_2", data.HSV_Color_Range_Min_2[1]);
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_2", data.HSV_Color_Range_Max_2[1]);
            } else if ( name == "Color_but_right") {
                shader_count = 2;
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Min_3", data.HSV_Color_Range_Min_3[1]);
                logo.GetComponent<Image>().material.SetFloat("_HSV_Color_Range_Max_3", data.HSV_Color_Range_Max_3[1]);
            }
        }
        // form.GetComponent<Image>().material = meshRen.materials[shader_count];
        // Debug.Log(form.GetComponent<Image>().material);
        // Debug.Log(meshRen.materials[shader_count]);
        Debug.Log(shader_count);
    }
}
