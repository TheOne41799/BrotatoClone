using UnityEngine;

namespace BrotatoClone.Main
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Debug.Log("Brotato Clone");
        }
    }
}