using Unity.Netcode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : Singleton<ObjectHandler>
{
    public GameObject serverInstance(GameObject go, Vector3 pos, Quaternion rotation)
    {
        GameObject newObject = Instantiate(go, pos, rotation);
        newObject.GetComponent<NetworkObject>().Spawn();
        return newObject;
    }
}
