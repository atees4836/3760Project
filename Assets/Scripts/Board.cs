using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject AddPiece (GameObject prefab, Player player, int col, int row) {
    	Vector3 vec = new Vector3 (col, row, 1);
        GameObject newPiece = Instantiate(prefab, vec, Quaternion.identity, gameObject.transform);
        return newPiece;
    }

}
