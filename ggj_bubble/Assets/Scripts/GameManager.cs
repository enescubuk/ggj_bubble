using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public GameObject TablePointForPaperUp;
    public GameObject TablePointForPaperDown;
    public GameObject ApprovedDocsUp;
    public GameObject ApprovedDocsDown;
    public GameObject PrintedPaper;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
