using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "ScriptableObjetcs/Items")]
public class ItemSO : ScriptableObject
{
    public int idItem;
    public string nameItem;
    public Sprite iconItem;
}
