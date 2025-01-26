using DG.Tweening;
using UnityEngine;

public class PrinterFaxController : MonoBehaviour
{
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform paperSpawnPoint;
    [SerializeField] private Transform paperTargetPoint;

    public void Print(Material _printedMaterial, Material _approvedMaterial)
    {
        GetComponent<AudioSource>().Play();
        GameObject _paper = Instantiate(paperPrefab, paperSpawnPoint.position, Quaternion.Euler(-90,90,0));
        _paper.GetComponent<Renderer>().material = _printedMaterial;
        _paper.GetComponent<PaperController>().ApprovedMaterial = _approvedMaterial;
        _paper.transform.DOMove(paperTargetPoint.position, 1f);
        GameManager.Instance.PrintedPaper = _paper;
    }
}
