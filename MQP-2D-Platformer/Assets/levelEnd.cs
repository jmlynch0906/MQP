using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelEnd : MonoBehaviour
{
    public static int iniEnemyCount = 0;

    public int currEnemyCount = 0;
    GameObject[] enemies; 


    // Start is called before the first frame update
    void Start()
    {
       enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        iniEnemyCount = enemies.Length;
        currEnemyCount = iniEnemyCount;

       
        Debug.Log("Initial enemy count: " + iniEnemyCount);
    }


    private void Update()
    {
        currEnemyCount = enemies.Length; 
        Debug.Log("Current Enemy count: " + currEnemyCount);

        if(currEnemyCount == 0)
        {
            Debug.Log("All enemies defeated!");
            SceneManager.LoadScene("Starting Area"); 
        }
    }
}
