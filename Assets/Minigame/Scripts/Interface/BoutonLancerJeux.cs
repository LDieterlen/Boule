using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BoutonLancerJeux : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public RawImage boutonImage;
    public Texture bouton1;
    public Texture bouton2;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        SceneManager.LoadScene("Level1");
    }
    void onPointerEnter(PointerEventData eventData)
    {       
        boutonImage.texture = (Texture)bouton2;
    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        boutonImage.texture = (Texture)bouton2;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        boutonImage.texture = (Texture)bouton1;
    }
}
