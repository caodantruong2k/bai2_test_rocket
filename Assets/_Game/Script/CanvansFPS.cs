using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvansFPS : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float pollingTime = 1f;
    private float time;
    private int frameCont;
    private void Update()
    {
        time += Time.deltaTime;
        frameCont++;
        if (time > pollingTime)
        {
            int frame = Mathf.RoundToInt(frameCont / pollingTime);
            FpsText.text = frame.ToString() + " FPS";
            time -= pollingTime;
            frameCont = 0;
        }
    }
}
