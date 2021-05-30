using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisibilityController : MonoBehaviour
{
    public bool Phone = true;

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (!Phone)
            gameObject.SetActive(false);
#else
        if (Phone)
            gameObject.SetActive(false);
#endif
    }
}
