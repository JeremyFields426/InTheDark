using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName = "Casket")]
public class CasketData : ScriptableObject, IGiveInfo
{
    [SerializeField] private string title = "New Casket";
    [SerializeField] [Multiline] private string description = "Casket Description";
    [SerializeField] private Color casketColor = Color.white;

    [SerializeField] private SpawnablePickup[] spawnablePickups = null;


    public Color CasketColor => casketColor;

    public SpawnablePickup[] SpawnablePickupsClone => (SpawnablePickup[])spawnablePickups.Clone();


    public string GetInfo()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("Name: ").Append(title).AppendLine();
        builder.Append("Description: ").Append(description).AppendLine();

        return builder.ToString();
    }
}
