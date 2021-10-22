using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	[SerializeField] private Color _offsetColor, _baseColor;
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private GameObject _highlight; 


    public void Init (bool isOdd) {
    	_renderer.color = isOdd ? _offsetColor : _baseColor;

    }

    void OnMouseEnter () {
    	Debug.Log("highlight");
    	_highlight.SetActive(true);
    }

    void OnMouseExit () {
    	    	Debug.Log(" no highlight");
    	_highlight.SetActive(false);    	
    }
}
