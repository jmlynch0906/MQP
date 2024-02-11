using EmergenceSDK.Samples.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaManager : MonoBehaviour
{
    public string persona;

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
        EquippedPersona equippedPersonaScript = FindObjectOfType<EquippedPersona>();

        if (equippedPersonaScript != null)
        {
            if(equippedPersonaScript.personaName != "")
            {
                persona = equippedPersonaScript.personaName;
            }
            
        }
    }
}

