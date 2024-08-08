using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private RoomConnection _roomConnection;
    [SerializeField] private Transform _pointTransform;

    private bool _isSpawnSuitable => _pointTransform != null && RoomConnection.ActiveConnection == _roomConnection;


    public void SpawnAtPoint()
    {
        if (_isSpawnSuitable)
        {
            EventDispatcher.Raise(new SpawnPlayerEvent { spawnPos = _pointTransform.position });
        }
    }

    public void SetActiveConnection()
    {
        RoomConnection.ActiveConnection = _roomConnection;
    }
}
