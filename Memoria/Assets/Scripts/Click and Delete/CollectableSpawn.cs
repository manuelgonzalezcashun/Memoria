using UnityEngine;
using System.Linq;

public class CollectableSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _blockingObjects = null;
    [SerializeField] GameObject _collectable;
    void OnEnable()
    {
        ChangeActionMapEvent mapEvent = new ChangeActionMapEvent { newActionMap = "Disable" };
        EventDispatcher.Raise(mapEvent);

        EventDispatcher.AddListener<RemoveItemEvent>(CheckListIfAllActive);
    }
    void OnDisable()
    {
        ChangeActionMapEvent mapEvent = new ChangeActionMapEvent { newActionMap = "Player" };
        EventDispatcher.Raise(mapEvent);

        EventDispatcher.RemoveListener<RemoveItemEvent>(CheckListIfAllActive);
    }
    void CheckListIfAllActive(RemoveItemEvent evtData) => CheckListIfAllActive();


    void CheckListIfAllActive()
    {
        if (_blockingObjects == null) return;

        bool allActive = _blockingObjects.All(b => b.activeInHierarchy);

        if (!allActive) SpawnCollectable();
    }

    void SpawnCollectable()
    {
        if (_collectable == null) return;

        _collectable.SetActive(true);
    }
}
