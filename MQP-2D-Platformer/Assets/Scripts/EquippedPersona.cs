//original code from Emergence documentation, altered to suit our needs

using System;
using EmergenceSDK.Internal.Utils;
using EmergenceSDK.Services;
using EmergenceSDK.Types;
using UnityEditor.PackageManager;
using UnityEngine;

namespace EmergenceSDK.Samples.Examples
{
    public class EquippedPersona : MonoBehaviour
    {



        private void Awake()
        {
            personaManager pM = FindObjectOfType<personaManager>();

            if (pM != null)
            {

                if (pM.persona != "")
                {
                    personaName = pM.persona;
                }
            }

        }

        public Persona p;

     public string personaName;

     public void SetPersona(Persona playerPersona){

        
        p = playerPersona;
        personaName = p.name;
     }

     public String getName(){
        return personaName;
     }
    }
}