using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class notificationController : MonoBehaviour {

    public TextMeshProUGUI tmProNotification;

    bool gameStarted = false;

    float timer;

    private void Start()
    {
        timer = 0;
        tmProNotification.text = "GROUP TOGETHER TO BEGIN";
    }

    private void Update()
    {
        if(gameStarted)
            timer += Time.deltaTime;
    }
}
