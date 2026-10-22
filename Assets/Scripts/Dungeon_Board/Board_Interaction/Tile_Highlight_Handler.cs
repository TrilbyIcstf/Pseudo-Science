using UnityEngine;

public class Tile_Highlight_Handler : MonoBehaviour
{
    private Renderer rend;
    private MaterialPropertyBlock properties;

    private const float HIGHLIGHTOPACITY = 0.66f;
    private const float HOVEROPACITY = 0.85f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rend = GetComponent<Renderer>();
        properties = new MaterialPropertyBlock();
    }

    public void SetHighlight()
    {
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.GetPropertyBlock(properties, i);
            properties.SetFloat("_HighlightOpacity", HIGHLIGHTOPACITY);
            rend.SetPropertyBlock(properties, i);
        }
    }
    
    public void SetHover()
    {
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.GetPropertyBlock(properties, i);
            properties.SetFloat("_HighlightOpacity", HOVEROPACITY);
            rend.SetPropertyBlock(properties, i);
        }
    }
    
    public void SetNone()
    {
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.GetPropertyBlock(properties, i);
            properties.SetFloat("_HighlightOpacity", 0);
            rend.SetPropertyBlock(properties, i);
        }
    }
}
