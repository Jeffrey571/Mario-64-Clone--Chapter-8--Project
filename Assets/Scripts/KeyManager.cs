using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public TextMeshProUGUI KeyText;
    public int NumberOfKeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public bool HasKey()
    {
        return NumberOfKeys > 0;
    }

    public void UseKey()
    {
        NumberOfKeys--;
        UpdateUI();
    }
    public void GetAKey()
    {
        NumberOfKeys++;
        UpdateUI();
    }
    public void UpdateUI()
    {
        KeyText.text = "Keys: " + NumberOfKeys;
    }

}
