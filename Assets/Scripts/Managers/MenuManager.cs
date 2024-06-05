using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Panel
{
    public string name;
    public GameObject panelObject;
}

public class MenuManager : MonoBehaviour
{

    [Header("MenuManager Settings")]
    public List<Panel> panels;

    private GameObject currentPanel;
    private bool isGameStart = true;

    private void Start()
    {
        foreach (Panel panel in panels)
        {
            panel.panelObject.SetActive(false);
        }

        if (panels.Count > 0)
        {
            OpenPanel(panels[0].name);
            isGameStart = false;
        }
    }

    public void OpenPanel(string panelName)
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        if (!isGameStart)
            AudioManager.Instance.PlayOneShot();

        Panel newPanel = panels.Find(p => p.name == panelName);
        if (newPanel != null)
        {
            newPanel.panelObject.SetActive(true);
            currentPanel = newPanel.panelObject;
        }
        else
        {
            Debug.LogError("Panel with name " + panelName + " not found.");
        }
    }

    public void OpenPanelByIndex(int index)
    {
        if (index < 0 || index >= panels.Count)
        {
            Debug.LogError("Invalid panel index: " + index);
            return;
        }

        OpenPanel(panels[index].name);
    }
}

