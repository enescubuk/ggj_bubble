using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] private Transform hourHand;
    [SerializeField] private Transform minuteHand;

    public void IncreaseTime(int minutes)
    {
        float minuteAngle = minutes * 6f; // Yelkovanın açısı
        float hourAngle = (minutes / 60f) * 30f; // Akrep açısı

        minuteHand.Rotate(Vector3.up, minuteAngle);
        hourHand.Rotate(Vector3.up, hourAngle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseTime(30);
        }
    }
}
