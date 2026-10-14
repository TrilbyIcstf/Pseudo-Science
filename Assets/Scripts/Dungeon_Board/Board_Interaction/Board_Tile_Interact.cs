using UnityEngine;

public class Board_Tile_Interact : MonoBehaviour
{
    [SerializeField]
    private Color baseColor;

    [SerializeField]
    private Color highlightColor;

    [SerializeField]
    private Color hoverColor = Color.yellowNice;

    private Vector2Int pos;

    private Renderer tileRenderer;

    private bool interactable = false;
    private bool highlighted = false;
    private bool hovered = false;

    
    public void Setup(Vector2Int pos)
    {
        this.pos = pos;
    }

    void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        hovered = true;
        if (interactable)
        {
            //TileRenderer.material.color = hoverColor;
            SetColor(hoverColor);

            GameManager.instance.dungeon.Board.HoverTile(pos);
        }
    }

    private void OnMouseExit()
    {
        if (hovered)
        {
            if (highlighted)
            {
                //TileRenderer.material.color = highlightColor;
                SetColor(highlightColor);
            } else
            {
                //TileRenderer.material.color = baseColor;
                SetColor(baseColor);
            }
            hovered = false;
        }
    }

    private void OnMouseDown()
    {
        if (hovered && interactable)
        {
            GameManager.instance.dungeon.Board.SelectTile(pos);
        }
    }

    public void HighlightTile()
    {
        highlighted = true;
        //TileRenderer.material.color = highlightColor;
        SetColor(highlightColor);
    }

    public void UnhighlightTile()
    {
        highlighted = false;
        //TileRenderer.material.color = baseColor;
        SetColor(baseColor);
    }

    public float HalfHeight()
    {
        return GetComponent<MeshFilter>().sharedMesh.bounds.size.y / 2 * transform.localScale.y;
    }

    private void SetColor(Color color)
    {
        foreach (Material mat in TileRenderer.materials)
        {
            mat.color = color;
        }
    }

    private Renderer TileRenderer
    {
        get {
            if (tileRenderer == null)
            {
                tileRenderer = GetComponent<Renderer>();
            }
            return tileRenderer;
        }
    }

    public bool Interactable { set => interactable = value; }
}
