using UnityEngine;
using TMPro;

public class Combat_Text_Box_UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI description;

    public void SetText(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }
}
