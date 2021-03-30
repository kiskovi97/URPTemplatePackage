using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace URPTemplate.UI
{
    public class ScrollView : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject[] constantPrefabs;
        public Transform contentView;

        // Start is called before the first frame update
        void Start()
        {
            foreach(var pref in constantPrefabs)
            {
                Instantiate(pref, contentView);
            }
        }

        public void Generate(int db)
        {
            for (int i = 0; i < db; i++)
                Instantiate(prefab, contentView);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
