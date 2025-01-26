using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;
using System.Collections.Generic;
public class TelephoneController : MonoBehaviour
{
    public GameObject Phone;
    internal bool isCalling;

    public List<string> texts = new List<string>();
    private Quaternion _initialRotation;

    [SerializeField] private float typingSpeed = 0.05f; 
    [SerializeField] private float dialogueDuration = 2f;
    public TMP_Text dialogueText;

    private void EventTriggered()
    {
        StartCoroutine(PlayDialogue());
    }

    private IEnumerator PlayDialogue()
    {

        foreach (string sentence in texts)
        {
            yield return StartCoroutine(TypeSentence(dialogueText, sentence)); // Harf harf yaz
            yield return new WaitForSeconds(dialogueDuration); // Diyalog sonrası bekleme süresi
        }
        
        dialogueText.text = "";
        Phone.SetActive(true);
        GameManager.Instance.ActionIsDone();
    }

    private IEnumerator TypeSentence(TMP_Text dialogueTextComponent, string sentence)
    {
        dialogueTextComponent.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTextComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Harf arası yazma hızı
        }
    }

    public void GetIdle()
    {
        Phone.SetActive(true);
        Phone.transform.DOKill(); // Mevcut titremeyi durdur
    }
    public void CallingPhone()
    {
        GetComponent<AudioSource>().Play();
        isCalling = true;
        Phone.transform.DOShakeRotation(1f, new Vector3(15f, 15f, 15f), 7, 15)
            .SetEase(Ease.Linear) // Hızın sürekli olmasını sağlıyoruz
            .SetLoops(-1, LoopType.Restart); // Sonsuz döngü ile tekrar et
    }


    public void StopCallingPhone()
    {
        Phone.transform.rotation = _initialRotation;
        GetComponent<AudioSource>().Stop();
        EventTriggered();
        isCalling = false;
        Phone.transform.DOKill();
        Phone.SetActive(false);
    }

}