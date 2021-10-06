using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveListener : MonoBehaviour
{

	GameManager gameManager;

	private Vector3 mousePos;
	private Vector3 offset; 
	private bool holding;

	public GameObject selectedObject;
	private Collider2D targetObject;

	void Start() {
		gameManager = FindObjectOfType<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && !selectedObject) {

        	targetObject = Physics2D.OverlapPoint(mousePos);

        	if (targetObject)
	        {
	        	Debug.Log(targetObject.gameObject.name + " Picked up");
	            selectedObject = targetObject.transform.gameObject;
	            offset = selectedObject.transform.position - mousePos;
	        }

        }

        if (Input.GetMouseButtonUp(0) && selectedObject) {
        	holding = true;
        }


        if (Input.GetMouseButtonDown(0) && selectedObject && holding) {
	        	Debug.Log(targetObject.gameObject.name + " Dropped");

	            selectedObject.transform.position = mousePos + offset;
	            selectedObject = null;
	            holding = false;

	            gameManager.turnSwitch();
        }


    }




}
