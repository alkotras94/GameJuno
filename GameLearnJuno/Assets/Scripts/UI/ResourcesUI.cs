using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textResources;
    [SerializeField] private ResourcesFortrres _resourcesFortrres;

    private void Update()
    {
        _textResources.text = _resourcesFortrres.Resorsec.ToString();
    }

}
