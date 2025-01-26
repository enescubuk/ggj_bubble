using UnityEngine;
using DG.Tweening;
using System;

public class PaperController : MonoBehaviour
{
    public enum State
    {
        Printed,
        MovingToTable,
        OnTable,
        Approved,
        Rejected
    }

    public State currentState;

    private Vector3 _targetPos;
    public Material ApprovedMaterial;

    void Start()
    {
        currentState = State.Printed;
    }
    public void MoveToTable()
    {
        currentState = State.MovingToTable;
        transform.rotation = Quaternion.Euler(-90, 90, 0);
        transform.position = GameManager.Instance.TablePointForPaperUp.transform.position;
        _targetPos = GameManager.Instance.TablePointForPaperDown.transform.position;
        Invoke("MoveToDown", 0.5f);
        currentState = State.OnTable;
    }

    private void MoveToDown()
    {
        transform.DOMove(_targetPos, 0.5f);
    }

    public void GetApproved()
    {
        currentState = State.Approved;
        GetComponent<Renderer>().material = ApprovedMaterial;
    }

    internal void GoToApprovedDocs()
    {
        transform.position = GameManager.Instance.ApprovedDocsUp.transform.position;
        float randomYRotation = UnityEngine.Random.Range(-5f, 5f);
        transform.rotation = Quaternion.Euler(-90, 90+randomYRotation, 0);
        _targetPos = GameManager.Instance.ApprovedDocsDown.transform.position;
        Invoke("MoveToDown", 0.5f);
        GameManager.Instance.ActionIsDone();
    }
}