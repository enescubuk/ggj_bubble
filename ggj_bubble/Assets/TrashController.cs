using System;
using DG.Tweening;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    internal void MoveToTrash()
    {
        if (GameManager.Instance.PrintedPaper && GameManager.Instance.PrintedPaper.GetComponent<PaperController>().currentState == PaperController.State.OnTable)
        {
            transform.DOShakeRotation(0.5f, 10, 10);
            Destroy(GameManager.Instance.PrintedPaper); 
        }
    }
}
