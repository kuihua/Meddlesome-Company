using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    // public Char[] chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_ abcdefghijklmnopqrstuvwxyz{|}~";

    private void Start() {
        textLabel.text = "Hello\nSecond line";
    }
}
