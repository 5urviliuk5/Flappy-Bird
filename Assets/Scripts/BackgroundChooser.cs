using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChooser : MonoBehaviour
{
    void Start()
    {
        int i = Random.Range(0, transform.childCount);

        transform.GetChild(i).gameObject.SetActive(true);
    }
}
