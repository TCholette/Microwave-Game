using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{

    public GameObject[] meals;
    private int mealIndex = 0;
    private int mealLength;

    public GameObject openDoor;
    public GameObject microwave;

    public GameObject[] mealsPerfect;

    public GameObject[] mealsDestroyed;

    public GameObject[] mealsRaw;

    public AudioSource sound;

    public AudioSource start;

    public AudioSource end;

    public int[] mealTimeMin;
    public int[] mealTimeMax;

    private bool firstTimePressed = true;



    public bool restart;
    public bool stop;

    public int time;
 

    void Start()
    {
        mealLength = meals.Length;
        sound = GetComponent<AudioSource>();
    }


    void Update()
    {
        

    }


    public void StartCooking() {
        if (firstTimePressed) {
            start.Play();
            sound.Play();
            restart = true;
            stop = false;
            openDoor.SetActive(false);
            microwave.SetActive(true);
            firstTimePressed = false;
            Debug.Log("aaa");
            meals[mealIndex].SetActive(false);
            var trans = 0.5f;
            var col = meals[mealIndex].GetComponent<Renderer>().material.color;
            col.a = trans;

            mealsDestroyed[mealIndex].SetActive(false);
            mealsRaw[mealIndex].SetActive(false);
            mealsPerfect[mealIndex].SetActive(false);




        } else if (!firstTimePressed) {
            sound.Stop();
            end.Play();
            time = GetComponent<Timer>().seconds + 60 * GetComponent<Timer>().minutes;
            openDoor.SetActive(true);
            microwave.SetActive(false);
            firstTimePressed = true;
            if (time >= mealTimeMax[mealIndex]) {
                meals[mealIndex].SetActive(false);
                mealsDestroyed[mealIndex].SetActive(true);
                Debug.Log("overcooked");
            } else if (time >= mealTimeMin[mealIndex] && time <= mealTimeMax[mealIndex]) {
                meals[mealIndex].SetActive(false);
                mealsPerfect[mealIndex].SetActive(true);
                Debug.Log("perf");
            } else if (time <= mealTimeMin[mealIndex]) {
                meals[mealIndex].SetActive(false);
                mealsRaw[mealIndex].SetActive(true);
                Debug.Log("raw");
            }
            stop = true;
        }
    }

}
