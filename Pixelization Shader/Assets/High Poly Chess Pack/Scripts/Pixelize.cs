using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Pixelize : MonoBehaviour {
    public Material material;

    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        material.SetFloat("_ScreenWidth", Screen.width);
        material.SetFloat("_ScreenHeight", Screen.height);
        Graphics.Blit(src, dest, material);
    }
}
