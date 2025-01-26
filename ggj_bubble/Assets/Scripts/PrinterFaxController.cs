using DG.Tweening;
using UnityEngine;

public class PrinterFaxController : MonoBehaviour
{
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform paperSpawnPoint;
    [SerializeField] private Transform paperTargetPoint;

    public void Print(Material _printedMaterial, Material _approvedMaterial)
    {
        GameObject _paper = Instantiate(paperPrefab, paperSpawnPoint.position, Quaternion.Euler(279.753235f,270.000122f,89.9998856f));
        _paper.GetComponent<Renderer>().material = _printedMaterial;
        _paper.GetComponent<PaperController>().ApprovedMaterial = _approvedMaterial;
        _paper.transform.DOMove(paperTargetPoint.position, 1f);
        GameManager.Instance.PrintedPaper = _paper;
    }
}
