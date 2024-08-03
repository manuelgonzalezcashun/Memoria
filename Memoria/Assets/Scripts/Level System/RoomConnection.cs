using UnityEngine;
[CreateAssetMenu(fileName = "Create new door connection")]
public class RoomConnection : ScriptableObject
{
    public static RoomConnection ActiveConnection { get; set; }
}
