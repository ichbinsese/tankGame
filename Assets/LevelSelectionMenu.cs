using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelectionMenu : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI briefingTextBox;
    public GameObject briefingWindow;
    public List<GameObject> buttonsSelected;
    public int selectedLevel;

    private string[] _briefings =
    {
        "Dieses Level Funktioniert noch nicht lol" ,
        "Die Fortnite Mobile Server in Israel sind schon wieder ausgefallen </p>" +
        "Wie du dir sicher vorstellen kannst, hat das eine Massenpanik ausgeloesst \n" +
        "Die Israelis sind verrückt geworden und fahren mit Panzern durch die Wueste </p>" +
        "Du bist der einzige freie Pilot, den wir haben \n" +
        "Flieg nach Israle und versuche die Server neu zu starten </p>" +
        "Das Schicksal der Freien Welt liegt in deinen Haenden \n" +
        "Viel Erfolg "
    };

    private string _currentText = "";

    private void OnEnable()
    {
        _currentText = "";
    }

    private void Update()
    {
        briefingTextBox.text = _currentText;
    }

    private string[] SplitBriefing(string str)
    {
        string[] splitePage = str.Split("</p>");
        return splitePage.ToArray();

    }
    
    IEnumerator EnumText(String text)
    {
        foreach (char c in text)
        {
            _currentText += c;
            yield return new WaitForSeconds (0.07f);
        }
        
    }

    IEnumerator PrintPages(String[] pages)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            _currentText = "";
            yield return StartCoroutine("EnumText", pages[i]);;
            yield return new WaitForSeconds (1f);
        }
        
    }

    private void PrintText(int index)
    {
        StopAllCoroutines();
        StartCoroutine("PrintPages", SplitBriefing(_briefings[index]));
    }
    
    
    

    public void SelectLevel(int index)
    {
        GetComponent<MainMenuWindow>().PlayClick();
        startButton.interactable = true;
        foreach(GameObject bs in buttonsSelected)
        {
            bs.SetActive(false);
        }
        selectedLevel = index;
        buttonsSelected[index].SetActive(true);
        briefingWindow.SetActive(true);
        PrintText(index);
    }

    public void StartLevel()
    {
        GetComponent<MainMenuWindow>().PlayClick();
        SceneManager.LoadScene(selectedLevel);
    }
    
    
}
