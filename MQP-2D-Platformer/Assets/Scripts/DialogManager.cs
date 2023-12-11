using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    void Start()
    {
        dialogBox.SetActive(false);
    }

    void Update()
    {
        if (dialogBox.activeSelf && (Input.GetKeyDown("d") || Input.GetKeyDown("a")))
        {
            dialogBox.SetActive(false);
        }
    }

    public void StartDialog(string dialog)
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
    }
}
