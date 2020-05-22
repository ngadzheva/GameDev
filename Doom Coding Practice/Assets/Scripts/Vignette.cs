using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Vignette : MonoBehaviour {
    public Material material;
    private float radius = 0.1f;
    private float currentRadius = 0.792f;

    private void Update() {
        radius = -radius;
        currentRadius += radius;
        material.SetFloat("_VRadius", currentRadius);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, material);
    }
}
