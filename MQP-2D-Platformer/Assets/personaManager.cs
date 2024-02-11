using EmergenceSDK.Samples.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaManager : MonoBehaviour
{
    public string persona;
    public GameObject player;

    // Ensure only one instance of personaManager exists
    private void Awake()
    {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("Persona Manager");

        if (managers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        persona = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            EquippedPersona equippedPersonaScript = player.GetComponent<EquippedPersona>();

            if (equippedPersonaScript != null)
            {
                string equippedPersonaName = equippedPersonaScript.getName();

                if (!string.IsNullOrEmpty(equippedPersonaName))
                {
                    Debug.Log("EQUIPPED PERSONA FOUND: " + equippedPersonaName);
                    
                    persona = equippedPersonaName;
                }
            }
        }
    }
}

