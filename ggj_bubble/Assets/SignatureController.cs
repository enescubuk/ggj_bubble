using DG.Tweening;
using UnityEngine;

public class SignatureController : MonoBehaviour
{
    private Vector3 _intialPosition;
    public void Sign()
    {
        _intialPosition = transform.position;
        transform.position = GameManager.Instance.TablePointForPaperUp.transform.position;
        Invoke("GoSign", 0.5f);
    }

    private void GoSign()
    {
        transform.DOMove(GameManager.Instance.TablePointForPaperDown.transform.position, 0.5f).OnComplete(() => {
            GameManager.Instance.PrintedPaper.GetComponent<PaperController>().currentState = PaperController.State.Approved;
            transform.DOMove(GameManager.Instance.TablePointForPaperUp.transform.position, 0.5f).OnComplete(() => {
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
