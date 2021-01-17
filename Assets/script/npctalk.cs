using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npctalk : MonoBehaviour
{
    public Talk NPCDate;
    public Text dialogText;
    public Text NPCname;
    public GameObject dialogUI;

    public enum NPCDialogState
    {
        FirstDialog, MissionDialog, FinishDialog
    }

    public NPCDialogState NPCState = NPCDialogState.FirstDialog;

    private void OnTriggerEnter(Collider other)
    {
        //如果玩家近來
        if (other.name == "Player")
        {
            dialogUI.SetActive(true);

            NPCname.text = name;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //如果玩家離開
        if (other.name == "Player")
        {
            dialogUI.SetActive(false);
        }
    }

    void StopDialoug()
    {
        //激活對話框
        dialogUI.SetActive(false);
        StopCoroutine(Dialog());
    }

    string dialog;

    IEnumerator Dialog()
    {
        dialogText.text = "";

        switch (NPCState)
        {
            case NPCDialogState.FirstDialog:
                dialog = NPCDate.dialoug1;
                break;
        }  

        for (int i = 0; i < NPCDate.dialoug1.Length; i++)
        {
            dialogText.text += NPCDate.dialoug1[i];

            yield return new WaitForSeconds(0.1f);
            print("test");
        }
    }
}

