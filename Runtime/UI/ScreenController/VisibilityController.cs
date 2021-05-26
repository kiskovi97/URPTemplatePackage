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
        if (Gamepad.all.Count > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
