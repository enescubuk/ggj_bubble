using DG.Tweening;
using UnityEngine;

public class SignatureController : MonoBehaviour
{
    private Vector3 _intialPosition;
    public Transform Up,Down;
    public void Sign()
    {
        _intialPosition = transform.position;
        transform.position = Up.position;
        Invoke("GoSign", 0.5f);
    }

    private void GoSign()
    {
        transform.DOMove(Down.position, 0.5f).OnComplete(() => {
            GameManager.Instance.PrintedPaper.GetComponent<PaperController>().GetApproved();
            GetComponent<AudioSource>().Play();
            transform.DOMove(Up.position, 0.5f).OnComplete(() => {
                Invoke("GoBack", 0.2f);
            });
        });
    }

    private void GoBack()
    {
        transform.position = _intialPosition;
        Invoke("WaitAndGoToApprovedDocs", 0.2f);
    }

    private void WaitAndGoToApprovedDocs()
    {
        GameManager.Instance.PrintedPaper.GetComponent<PaperController>().GoToApprovedDocs();
    }
}
