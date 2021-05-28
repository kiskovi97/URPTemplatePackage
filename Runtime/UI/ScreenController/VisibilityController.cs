using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisibilityController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE
#else
        gameObject.SetActive(false);
#endif
    }
}
