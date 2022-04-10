using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class button_action : MonoBehaviour
{
    private Button button;
    //[SerializeField] private string asd;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var asd = FindObjectOfType<main_choice_color>();
        asd.button_color(gameObject.name);
    }
}
