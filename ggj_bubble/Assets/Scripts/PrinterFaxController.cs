using DG.Tweening;
using UnityEngine;

public class PrinterFaxController : MonoBehaviour
{
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform paperSpawnPoint;
    [SerializeField] private Transform paperTargetPoint;

    public void Print()
    {
        GameObject _paper = Instantiate(paperPrefab, paperSpawnPoint.position, Quaternion.Euler(349.622803f,90,0));
        _paper.transform.DOMove(paperTargetPoint.position, 1f);
        GameManager.Instance.PrintedPaper = _paper;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Print();
        }
    }
}
