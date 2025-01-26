using UnityEngine;
using DG.Tweening;
public class TelephoneController : MonoBehaviour
{
    public GameObject Phone;
    internal bool isCalling;

    public void GetIdle()
    {
        Phone.SetActive(true);
        Phone.transform.DOKill(); // Mevcut titremeyi durdur
    }
    public void CallingPhone()
    {
        isCalling = true;
        Phone.transform.DOShakeRotation(1f, new Vector3(15f, 15f, 15f), 7, 15)
            .SetEase(Ease.Linear) // Hızın sürekli olmasını sağlıyoruz
            .SetLoops(-1, LoopType.Restart); // Sonsuz döngü ile tekrar et
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CallingPhone();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopCallingPhone();
        }
    }

    public void StopCallingPhone()
    {
        isCalling = false;
        Phone.transform.DOKill();
        Phone.SetActive(false);
    }

}