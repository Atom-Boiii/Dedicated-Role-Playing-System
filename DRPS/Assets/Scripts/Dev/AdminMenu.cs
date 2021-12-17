using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminMenu : MonoBehaviour
{
    public string keyBind;
    public GameObject view;
    public GameObject[] menus;

    public Toggle godModeToggle;

    private bool godMode;

    public void Update()
    {
        if (DevConsole.instance == null)
        {
            view.SetActive(false);
            Debug.LogError("No devconsole component found!");
            return;
        }

        if (!DevConsole.instance.isOpened)
        {
            if (keyBind != "")
            {
                if (Input.GetKeyDown(keyBind))
                {
                    for (int i = 0; i < menus.Length; i++)
                    {
                        menus[i].SetActive(false);
                    }

                    menus[0].SetActive(true);

                    view.SetActive(!view.activeSelf);
                }
            }
            else
            {
                DevConsole.instance.ErrorLog("No keybind assigned for Mod Menu! Please assign it in the configuration!");
            }
        }
        else
        {
            view.SetActive(false);
        }
    }

    public void OpenMenu(int index)
    {
        menus[index].SetActive(true);
    }

    public void CloseMenu(int index)
    {
        menus[index].SetActive(false);
    }

    public void ToggleGodMode()
    {
        godModeToggle.isOn = !godModeToggle.isOn;
        godMode = !godMode;

        if (godMode)
        {
            DevConsole.instance.Log("ID {id} now has godmode!");
        }
        else
        {
            DevConsole.instance.Log("ID {id} no longer has godmode!");
        }
    }

    public void Heal()
    {
        // Find if the local player has a player component setup. If not send an error message. If they do heal them.
        DevConsole.instance.ErrorLog("No player component found in the world. Please add it to the player!");
    }
}
