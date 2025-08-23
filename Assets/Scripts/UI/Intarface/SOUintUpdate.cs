using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUintUpdate : MonoBehaviour
{
    public SOint soInt;
    public TextMeshProUGUI textMeshUi;
    // Start is called before the first frame update
    void Start()
    {
       textMeshUi.text = soInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshUi.text = soInt.value.ToString();
    }
}
