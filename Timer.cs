using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public Cook cook;
    public TextMeshProUGUI time;
    public int minutes;
    public int seconds;
    bool canContinue = true;
    // Start is called before the first frame update
    void Start()
    {
        cook = GetComponent<Cook>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (minutes < 10) {
            time.text = "0" + minutes + ":";
        } else time.text = minutes + ":";
        if (seconds < 10) {
            time.text += ("0" + seconds);
        } else time.text += seconds;
        if (canContinue && cook.stop == false) {
            canContinue = false;
            StartCoroutine(AdvanceTime());
        }
        if (cook.restart) {
            seconds = 0;
            minutes = 0;
            cook.restart = false;
        }

    }

    private IEnumerator AdvanceTime() {
        yield return new WaitForSeconds(1f);
        seconds++;
        if (seconds >= 60) {
            minutes++;
            seconds = 0;
        }
        canContinue = true;
    }


}
