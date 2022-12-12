using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArbolNode : MonoBehaviour
{
    public int value;
    public ArbolNode parentNode;
    public ArbolNode lowNode;
    public ArbolNode highNode;
    public Transform tf;
    private Text textValue;
    public bool isRoot;
    public Vector3 rootPosition;

    private void Start()
    {
        textValue = GetComponent<Text>();
        textValue.text = value.ToString();
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isRoot)
        {
            tf.position = rootPosition;
        }
        if (lowNode)
        {
            lowNode.tf.position = tf.position - tf.up * 60 - tf.right * 100;
        }
        if (highNode)
        {
            highNode.tf.position = tf.position + tf.right * 100 - tf.up * 60;
        }
    }
}
