using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class PercentageCalculator : MonoBehaviour
{
    [SerializeField] private Renderer wall;
    RenderTexture rt;
    Texture2D texture2D;
    private Color[] pixels;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetTextures", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Percentage());
        }


    }
    public float Percentage()
    {
        int counter = 0;
        RenderTexture.active = rt;
        texture2D.ReadPixels(new Rect(0, 0, texture2D.width, texture2D.height), 0, 0);
        texture2D.Apply();
        pixels = texture2D.GetPixels();
        //Debug.Log(pixels.Length);
        for (int i = 0; i < pixels.Length; i++)
        {
            if (pixels[i].r == 1)
            {
                counter++;
               // Debug.Log("Counter is" + counter);
            }
           // Debug.Log("if içine girmedi");
        }
        return ((float)counter / (float)pixels.Length) * 100;
    }
    void SetTextures()
    {
        Texture texture = wall.material.mainTexture;
        rt = (RenderTexture)wall.material.mainTexture;
        texture2D = new Texture2D(rt.width, rt.height); 
    }
}
