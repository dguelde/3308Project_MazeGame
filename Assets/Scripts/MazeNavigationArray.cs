﻿using UnityEngine;
using System.Collections;

public class MazeNavigationArray : MonoBehaviour {
	// Use this for initialization
	
	public GameObject[] destinationList;
	public GameObject previousDestination;
	RaycastHit pieceFound;
	public GameObject destination;
	public GameObject collidingWith;
	
	void Start () {
		int terrainLayerMask = 1 << 8; //ignore all objects not in Terran Layer
		destinationList = new GameObject[4];
		if (Physics.Raycast(transform.position + 0.25F * Vector3.up, Vector3.forward, out pieceFound, 15, terrainLayerMask)==true)
			destinationList[0] = pieceFound.collider.gameObject;
		if (Physics.Raycast(transform.position + 0.25F * Vector3.up, Vector3.right,out pieceFound, 15, terrainLayerMask)==true)
			destinationList[1] = pieceFound.collider.gameObject;
		if (Physics.Raycast(transform.position + 0.25F * Vector3.up, Vector3.back,out pieceFound, 15, terrainLayerMask)==true)
			destinationList[2] = pieceFound.collider.gameObject;
		if (Physics.Raycast(transform.position + 0.25F * Vector3.up, Vector3.left,out pieceFound, 15, terrainLayerMask)==true)
			destinationList[3] = pieceFound.collider.gameObject;
	}	
	
	void setPreviousDestination(GameObject previousDestinationFromAI)
	{
		previousDestination = previousDestinationFromAI;
	}
	
	void OnTriggerEnter(Collider collision)
	{	
		collidingWith = collision.gameObject;
		if (previousDestination = gameObject)
		{
			do
			{int index = Random.Range (0,4);
				destination = destinationList[index];}
			while (destination==null || destination == previousDestination);
			collidingWith.SendMessage("nextDestination",destination);}
	}
	

}
