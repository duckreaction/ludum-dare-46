﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailSequence : MonoBehaviour
{
    [SerializeField]
    private TMP_Text failText;

    private SwitchProcessProfile _switchProcess;
    public SwitchProcessProfile switchProcess
    {
        get
        {
            if(_switchProcess == null)
            {
                _switchProcess = Camera.main.GetComponent<SwitchProcessProfile>();
            }
            return _switchProcess;
        }
    }

    public void Show(Action userAction, Action wantedAction)
    {
        gameObject.SetActive(true);
        switchProcess.SetProfile(1);
        failText.text = CreateFailText(userAction, wantedAction);
    }

    private string CreateFailText(Action userAction, Action wantedAction)
    {
        string userActionMsg = userAction == null ? 
            "You have done nothing" : "You have done '" + userAction.ShortLabel() +"'";
        string fishMsg = wantedAction.doIt ? 
            "But Fish says '" + wantedAction.ShortLabel() + "'" : "But Fish says nothing";
        return ""+userActionMsg+ "\n" +
             fishMsg + "\n" +
            "Fish died and it's entire your fault... Hope you'll sleep well...";
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
        switchProcess.SetProfile(0);
        ActionManager.Instance.Restart();
    }
}