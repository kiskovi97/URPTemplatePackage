using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AspectRatioFitter))]
public class BackgroundImageLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var image = GetComponent<Image>();
        var settings = URPTemplateSettings.GetOrCreateSettings();
        image.sprite = settings.BackgroundSprite;
        var ratio = GetComponent<AspectRatioFitter>();
        ratio.aspectRatio = settings.AspectRatio;
    }
}
