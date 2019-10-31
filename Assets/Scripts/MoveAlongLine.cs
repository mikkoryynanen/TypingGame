using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongLine : MonoBehaviour
{
    public GameObject movingObject;
    public float speed = 20;
    public Vector3 targetPosition;

    LineRenderer _line;
    List<GameObject> _spawnedObjecs = new List<GameObject>();

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (_spawnedObjecs.Count > 0)
        {
            for (int i = 0; i < _spawnedObjecs.Count; i++)
            {
                _spawnedObjecs[i].transform.position = Vector2.MoveTowards(_spawnedObjecs[i].transform.position, _line.GetPosition(1), Time.deltaTime * speed);

                if (Vector2.Distance(_spawnedObjecs[i].transform.position, _line.GetPosition(1)) < .5f)
                {
                    Destroy(_spawnedObjecs[i]);
                    _spawnedObjecs.Remove(_spawnedObjecs[i]);
                }
            }
        }
    }

    public void ResetToDefault()
    {
        for (int i = 0; i < _spawnedObjecs.Count; i++)
        {
            Destroy(_spawnedObjecs[i]);
        }
        _spawnedObjecs.Clear();
    }

    public void Setup()
    {
        _spawnedObjecs.Add(Instantiate(movingObject, _line.GetPosition(0), Quaternion.identity));
    }
}
