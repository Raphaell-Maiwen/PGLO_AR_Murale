using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePostProcess : MonoBehaviour
{
    //using material with unlit/color
    public Material fadeMaterial = null;
    private Material mat;

    public float fadeValue = 0f;

    public Color color;

    // Will be called from camera after regular rendering is done.
    public void OnPostRender()
    {

        GL.PushMatrix();
        GL.LoadOrtho();

        // activate the first shader pass (in this case we know it is the only pass)
        fadeMaterial.color = new Color(color.r, color.g, color.b, fadeValue);
        fadeMaterial.SetPass(0);

        // draw a quad over whole screen
        GL.Begin(GL.QUADS);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(1, 0, 0);
        GL.Vertex3(1, 1, 0);
        GL.Vertex3(0, 1, 0);
        GL.End();

        GL.PopMatrix();
    }
}
