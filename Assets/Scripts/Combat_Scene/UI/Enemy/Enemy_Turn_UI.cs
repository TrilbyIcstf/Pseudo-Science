using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enemy_Turn_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image intentImage;
    private MoveType intent;
    private Bestiary enemy;

    private const float baseHeight = 110;

    private int turnNumber = 0;

    [SerializeField]
    private TextMeshProUGUI turnText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        string title = GameManager.instance.ll.enemyRepository.GetInformation(enemy).EnemyName;
        string description = $"The enemy intends to use a {intent.ToDisplayString()} in {turnNumber} turn";
        description += turnNumber == 1 ? "." : "s.";
        GameManager.instance.combat.combatUI.DisplayTextBox(title, description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.combat.combatUI.HideTextBox();
    }

    public void SetTurnNumber(int val)
    {
        turnNumber = val;
        turnText.text = turnNumber.ToString();
    }

    public void SetIntent(MoveType type)
    {
        intent = type;
        intentImage.sprite = GameManager.instance.ll.intentIcons.GetValue(intent);
    }

    public void SetEnemy(Bestiary enemy)
    {
        this.enemy = enemy;
    }

    public void SetHeight(float height)
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, baseHeight + height, 0);
    }
}
