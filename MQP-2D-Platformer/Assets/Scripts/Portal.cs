using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Portal : MonoBehaviour
{


    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked on portal 1-1");
        SceneManager.LoadScene("Level 1-1");
    }
}
