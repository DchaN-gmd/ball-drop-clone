using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _beam;
    [SerializeField] private GameObject _tower;
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionScale;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishAdditionScale = 0.5f;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionScale+_additionScale/2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y-_additionScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, _tower.transform);

        for(int i=0; i<_levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, _tower.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, _tower.transform);
    }
    
    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
