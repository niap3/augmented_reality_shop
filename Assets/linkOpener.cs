using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyRA1 : MonoBehaviour
{
    public void OpenURL(string url) {
        Application.OpenURL(url);
    }
}
