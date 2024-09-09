using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private RoomConnection _roomConnection;
    [SerializeField] private Transform _pointTransform;

    private bool _isSpawnSuitable => _pointTransform != null && GameVariables.Instance.ActiveConnection == _roomConnection;

    private void Start()
    {
        SpawnAtPoint();
    }
    public void SpawnAtPoint()
    {
        if (_isSpawnSuitable)
        {
            SpawnPlayerEvent spawn = new SpawnPlayerEvent { spawnPos = _pointTransform.position };
            EventDispatcher.Raise(spawn);
        }
    }

    public void SetActiveConnection()
    {
        GameVariables.Instance.SetActiveRoomConnection(_roomConnection);
    }
}
