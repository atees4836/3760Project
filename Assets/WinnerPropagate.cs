using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerPropagate : MonoBehaviour
{
    void OnEnable() 
    {
        transform.gameObject.GetComponent<Text>().text = "Someone Won!";
    }
}
