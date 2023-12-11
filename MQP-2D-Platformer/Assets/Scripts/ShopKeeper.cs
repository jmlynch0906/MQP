using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public string shopKeeperDialog;
    private DialogManager dialogManager;

    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Clicked on Shopkeeper");
        if (!dialogManager.dialogBox.activeSelf)
        {
            dialogManager.StartDialog(shopKeeperDialog);
        }
    }

}
