using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRangeObj : MonoBehaviour
{
    /// <summary>
    /// �p�G�Ŀ�A�OtargetTag������h���|�Q�[�J�P�w
    /// </summary>
    public bool isExcept;
    public List<string> targetTag;
    [SerializeField]
    private List<GameObject> inGameObj = new List<GameObject>();
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isExcept)
        {
            if (!targetTag.Contains(collision.tag) && !inGameObj.Contains(collision.gameObject))
            {
                inGameObj.Add(collision.gameObject);
            }
        }
        else
        {
            if (targetTag.Contains(collision.tag)&& !inGameObj.Contains(collision.gameObject))
            {
                inGameObj.Add(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (inGameObj.Contains(collision.gameObject))
        {
            inGameObj.Remove(collision.gameObject);
        }
    }
    public List<GameObject> GetObjects()
    {
        return inGameObj;
    }
}
