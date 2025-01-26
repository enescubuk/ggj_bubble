using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class TrashController : MonoBehaviour
{
    internal void MoveToTrash()
    {
        if (GameManager.Instance.PrintedPaper && GameManager.Instance.PrintedPaper.GetComponent<PaperController>().currentState == PaperController.State.OnTable)
        {
            transform.DOShakeRotation(0.5f, 15, 15);
            GameManager.Instance.PrintedPaper.GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().Play(); 
            GameManager.Instance.PrintedPaper.GetComponent<MeshRenderer>().enabled = false;
            Destroy(GameManager.Instance.PrintedPaper,1f); 
            GameManager.Instance.ActionIsDone();
        }
    }
}
