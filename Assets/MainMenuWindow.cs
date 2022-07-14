using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    public GameObject creditsWindow;
    public GameObject levelSelectWindow;
    public GameObject clickSound;
    public static MainMenuWindow currentLockedWindow;
    private Vector2 _mouseDragPosition;
    private Vector2 _startPosition;
    private bool _dragging;

    public void PlayClick()
    {
        Instantiate(clickSound, transform.position, quaternion.identity);
    }
        
    public void CreditButton()
    {
        PlayClick();
        creditsWindow.SetActive(true);
    }

    public void PlayButton()
    {
        PlayClick();
        levelSelectWindow.SetActive(true);
    }

    public void CloseGameButton()
    {
        Application.Quit();
    }

    public void CloseWindowButton()
    {
        PlayClick();
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (currentLockedWindow != this && currentLockedWindow != null) return;
        currentLockedWindow = this;
        _mouseDragPosition = Input.mousePosition;
        _startPosition = GetComponent<RectTransform>().position;
        _dragging = true;
    }

    public void OnMouseDrag()
    {
        
        Vector2 a = _mouseDragPosition - (Vector2) Input.mousePosition;
        print(a);
        if (_dragging) GetComponent<RectTransform>().position = _startPosition - a;
    }

    public void OnMouseUp()
    {
        currentLockedWindow = null;
        _dragging = false;
    }
}
