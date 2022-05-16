using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Image))]
public class ColorLerp : MonoBehaviour {

    private Image image;

    private void Start() {
        image = gameObject.GetComponent<Image>();
    }

    private void Update() {
        
    }

}
