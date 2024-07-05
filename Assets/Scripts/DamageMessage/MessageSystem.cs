using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject DamageMessage;

    private List<TMPro.TextMeshPro> messagepool;
    private int objectCount = 10;
    private int count;

    private void Start()
    {
        messagepool = new List<TextMeshPro>();
        for (int i = 0; i < objectCount; i++)
        {
            Populate();
        }
    }

    public void Populate()
    {
        GameObject go = Instantiate(DamageMessage, transform);
        messagepool.Add(go.GetComponent<TMPro.TextMeshPro>());
        go.SetActive(false);
    }
    public void postMessage(String text, Vector3 worldPosition)
    {
        messagepool[count].gameObject.SetActive(true);
        messagepool[count].transform.position = worldPosition;
        messagepool[count].text = text;
        count += 1;

        if (count >= objectCount)
        {
            count = 0;
        }
        // GameObject go = Instantiate(DamageMessage, transform);
        // go.transform.position = worldPosition;
        // go.GetComponent<TMPro.TextMeshPro>().text = text;
    }
}
