using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class main_choice_color : MonoBehaviour {

    Animator anim;
    SpriteRenderer sr;
    // MeshRenderer r;

    

    private Button button;
    private Button button_next;
    private Button  random_color;
    public GameObject form;
    public GameObject logo;
    public MeshRenderer meshRen;

    private int shader_count = 0;
    public int press = 1;


    void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        form = GameObject.Find("formImage");
        logo = GameObject.Find("LogoImage");
        random_color = GameObject.Find("Random_Color_Button").GetComponent<Button>();
        button_next = GameObject.Find("Next_button").GetComponent<Button>();

        meshRen = GameObject.Find("formImage").GetComponent<MeshRenderer>();
        // form.GetComponent<MeshRenderer>().material = materials[1];
    }

    // void Awake() {
    //     form.GetComponent<Image>().material = meshRen.materials[0];
    // }
    // если далее нажато 3 и более раза, другая сцена
    public void counter() {
        press++;
        if(press >= 3) {
            SceneManager.LoadScene(1);
        }
    } 
    // рандомный цвет 
    public void random_Color() {
        if(press == 1) {
            form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", new Color(Random.value, Random.value, Random.value, 1));
            // Color asd = form.GetComponent<Image>().material.GetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee");
            // Debug.Log(asd.ToString());
        } else if (press == 1 && shader_count == 0) {
            form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", new Color(Random.value, Random.value, Random.value, 1));
        } else if (press == 1 && shader_count == 1) {
            form.GetComponent<Image>().material.SetColor("Color_9f093fb7ba4d4bd29dbeed0782cde146", new Color(Random.value, Random.value, Random.value, 1));
        } else if (press == 1 && shader_count == 2) {
            form.GetComponent<Image>().material.SetColor("Color_512d3fa795384b0887119d5596b3fc16", new Color(Random.value, Random.value, Random.value, 1));
        }
        if(press == 2) {
            logo.GetComponent<Image>().material.SetColor("Color_000bb06fd1f649eaa94ec8e769a24fec", new Color(Random.value, Random.value, Random.value, 1));
        }
        
    }
    // изменение объекта окраски после нажатия кнопки далее 
    public void button_color(string name) {
        button = GameObject.Find(name).GetComponent<Button>();
        if(press == 1 && shader_count == 0) {
            form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", button.GetComponent<Image>().color);
        } else if (press == 1 && shader_count == 1) {
            form.GetComponent<Image>().material.SetColor("Color_9f093fb7ba4d4bd29dbeed0782cde146", button.GetComponent<Image>().color);
        } else if (press == 1 && shader_count == 2) {
            form.GetComponent<Image>().material.SetColor("Color_512d3fa795384b0887119d5596b3fc16", button.GetComponent<Image>().color);
        } else if (press == 1) {
            form.GetComponent<Image>().material.SetColor("Color_52742d5ce3ce4fd7a98ef170efce1cee", button.GetComponent<Image>().color);
        }
        if(press == 2) {
            logo.GetComponent<Image>().material.SetColor("Color_000bb06fd1f649eaa94ec8e769a24fec", button.GetComponent<Image>().color);
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
        form.GetComponent<Image>().material = meshRen.materials[shader_count];
        // Debug.Log(form.GetComponent<Image>().material);
        Debug.Log(meshRen.materials[shader_count]);
    }
}
