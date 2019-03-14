using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    #region Singleton

    public static TrackPlayer instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject target; //Select what object the player is
}
