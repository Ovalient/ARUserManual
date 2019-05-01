using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    public static Color defaultColor;
    public static Color selectedColor;
    public static Material mat;
        
    void Start()
    {
        mat = GetComponent<Renderer>().material;

        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        defaultColor = new Color32(255, 255, 255, 255);
        selectedColor = new Color32(255, 0, 0, 255);

        mat.color = defaultColor;
    }
    
    void touchBegan()
    {
        if(this.enabled)
        {
            mat.color = selectedColor;
        }        
    }

    void touchEnded()
    {
        if (this.enabled)
        {
            mat.color = defaultColor;
        }
    }

    void touchStay()
    {
        if(this.enabled)
        {
            mat.color = selectedColor;
        }
    }

    void touchExit()
    {
        if(this.enabled)
        {
            mat.color = defaultColor;
        }
    }
}
