using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wisp
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance = null;
        public int signProgress = 0;

        public bool doorTalkEnabled = true;
        public bool endGameEnabled = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}