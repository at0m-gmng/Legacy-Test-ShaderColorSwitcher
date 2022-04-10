using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class animations : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject form;
    [SerializeField] private GameObject text_use_any;
    [SerializeField] private GameObject text_use_any_logo;
    [SerializeField] private float duration;
    [SerializeField] private float skip_duration;

    private int counterButton;
    private Vector3 target_formPos;
    private Vector3 target_logoPos;
    private Vector3 target_text_use_any;
    private Vector3 target_text_use_any_logo;

    private Sequence sequence; // переменная для очереди

    void Start()
    {
        target_formPos = new Vector3(form.transform.position.x - 5.5f, form.transform.position.y, form.transform.position.z);
        target_text_use_any = new Vector3(text_use_any.transform.position.x - 5.5f, text_use_any.transform.position.y, text_use_any.transform.position.z);
        target_logoPos = new Vector3(logo.transform.position.x, logo.transform.position.y - 4f, logo.transform.position.z);
        target_text_use_any_logo = new Vector3(text_use_any_logo.transform.position.x, text_use_any_logo.transform.position.y -4f, text_use_any_logo.transform.position.z);
    }

    void Update()
    {
        counterButton = FindObjectOfType<main_choice_color>().press;
    }

    public void all_animation()
    {
        form_animation();
        text_form_animation();
        logo_animation();
        text_logo_animation();
    }

    private void form_animation()
    {
        form.transform.DOMove(target_formPos, duration, false);
    }    
    private void text_form_animation()
    {
        text_use_any.transform.DOMove(target_text_use_any, duration, false);
    }   
    private void logo_animation()
    {
        logo.transform.DOMove(target_logoPos, duration, false);
    }
    private void text_logo_animation()
    {
        text_use_any_logo.transform.DOMove(target_text_use_any_logo, duration, false);
    }

    public void form_animation_skip(float direction)
    {
        if(counterButton == 1)
        {
            sequence = DOTween.Sequence();
            sequence.Append(form.transform.DOMove(new Vector3(form.transform.position.x + direction, form.transform.position.y, form.transform.position.z), skip_duration, false))
                    .Append(form.transform.DOMove(new Vector3(form.transform.position.x - direction * 2, form.transform.position.y, form.transform.position.z), 0, false))
                    .Append(form.transform.DOMove(new Vector3(form.transform.position.x, form.transform.position.y, form.transform.position.z), skip_duration, false));
        } 
        else if(counterButton == 2)
        {
            sequence = DOTween.Sequence();
            sequence.Append(logo.transform.DOMove(new Vector3(logo.transform.position.x + direction, logo.transform.position.y, logo.transform.position.z), skip_duration, false))
                    .Append(logo.transform.DOMove(new Vector3(logo.transform.position.x - direction * 2, logo.transform.position.y, logo.transform.position.z), 0, false))
                    .Append(logo.transform.DOMove(new Vector3(logo.transform.position.x, logo.transform.position.y, logo.transform.position.z), skip_duration, false));
        }
    }
}
