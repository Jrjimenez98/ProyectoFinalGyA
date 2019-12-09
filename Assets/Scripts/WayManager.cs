﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 11.0f;      // desde que cuadro empieza a generar piso
	private float tileLength = 12.0f;  //separacion de pisos (cada piso mide +12 z)
	private float safeZone = 15.0f;    //zona que desaparece piso
	private int amnTilesOnScreen = 8; //objWays que se muestran en la pantalla
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;

	// Start is called before the first frame update
    private void Start()
    {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
     	for (int i = 0; i < amnTilesOnScreen; i++)
		{
			SpawnTile ();
			
		}
		
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - safeZone> (spawnZ - amnTilesOnScreen * tileLength)) 
		{
			SpawnTile ();
			DeleteTile ();
		}
    }
	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}
	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt(0);
	}
	private int RandomPrefabIndex()
	{
		if(tilePrefabs.Length <= 1)
			return 0;
		
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}

}
