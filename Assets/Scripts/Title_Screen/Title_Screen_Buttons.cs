using UnityEngine;

public class Title_Screen_Buttons : MonoBehaviour
{
    [SerializeField]
    private Dungeon_Layout defaultDungeon;

    public void StartButton()
    {
        GameManager.instance.dungeon.SetDungeon(defaultDungeon);
        GameManager.instance.dungeon.BeginDungeon();
        GameManager.instance.transition.TransitionToNewRoom();
    }
}
