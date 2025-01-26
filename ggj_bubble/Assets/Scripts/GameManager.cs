using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Counter = 0;

    [Header("References")]
    public GameObject TablePointForPaperUp;
    public GameObject TablePointForPaperDown;
    public GameObject ApprovedDocsUp;
    public GameObject ApprovedDocsDown;
    public GameObject PrintedPaper;

    [Header("Communication Method")]
    public GameObject PrinterFax;
    public GameObject Telephone;
    public RawImage TeletextImage;

    public Element[] Elements;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        ActionIsDone();
    }

    public void ActionIsDone()
    {
        Invoke("DoAction",2f);
    }

    private void DoAction()
    {
        switch (Elements[Counter].communicationMethod)
        {
            case Element.CommunicationMethod.Telephone:
                Telephone.GetComponent<TelephoneController>().texts.Clear();
                Telephone.GetComponent<TelephoneController>().texts = Elements[Counter].TelephoneDialoguesList;
                Telephone.GetComponent<TelephoneController>().CallingPhone();
                break;  
            case Element.CommunicationMethod.Fax:

                PrinterFax.GetComponent<PrinterFaxController>().Print(Elements[Counter].PrintedMaterial, Elements[Counter].ApprovedMaterial);
                break;
            case Element.CommunicationMethod.Teletext:
                TeletextImage.texture = Elements[Counter].TTRawImage;
                break;
            
        }

        Counter++;
    }
}

[Serializable]
public class Element
{
    public enum CommunicationMethod
    {
        Telephone,
        Fax,
        Teletext
    }

    public CommunicationMethod communicationMethod;
    public Material PrintedMaterial;
    public Material ApprovedMaterial;

    public List<string> TelephoneDialoguesList;

    public Texture TTRawImage;
}
