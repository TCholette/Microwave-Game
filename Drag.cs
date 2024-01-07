using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {





    public Transform parentToReturnTo = null;

    public GameObject microwave;


    void Start() {

    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("begin");
        parentToReturnTo = transform.parent;
    }

    public void OnDrag(PointerEventData eventData) {

        transform.position = eventData.position;
       
    }
    public void OnEndDrag(PointerEventData eventData) {
        transform.position = parentToReturnTo.position;
        

        transform.SetParent(parentToReturnTo);
    }




    void Update() {



    }






}
