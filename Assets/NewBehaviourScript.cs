using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Output(""));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string Output(string Input)
    {
        Dictionary<string, int> database = new Dictionary<string, int>();
        for (int i = 0; i < Input.Length; i++)
        {
            string s = Input.Substring(i, 1);
            if (database.ContainsKey(s))
            {
                database[s] += 1;
            }
            else
            {
                database.Add(s, 1);
            }
        }
        string result = "";
        foreach (var data in database)
        {
            if (data.Value > 1)
            {
                result += data.Key + " appeared " + data.Value + " times. ";
            }
            
        }
        if (result.Length > 0)
        {
            return result;
        }
        else
            return "no reoccurrence";
    }
}
