using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> :MonoBehaviour where T  : MonoBehaviour
{
    [SerializeField] private bool dontDestroyOnLoad = true;
    public string Name { get; set; }
    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
    }
    public void Awake()
    {
        if (Instance == null)
        {
            _instance = GetComponent<T>();
            if (dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
        else if (Instance == this)
        {
            if (dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
