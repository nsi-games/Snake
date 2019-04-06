using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
