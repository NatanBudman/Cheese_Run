using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovWhitDijkar : MonoBehaviour
{
    [SerializeField] private float Speed;

    [SerializeField] private nav _dijkstra;
    // Start is called before the first frame update
    void Start()
    {
        _dijkstra = FindObjectOfType<nav>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            var screen = Input.mousePosition;
            var world = Camera.main.ScreenToWorldPoint(screen);
            world.z = 0;

            var path = this._dijkstra.GetPath(this.transform.position,world);
            
            StopAllCoroutines();
            StartCoroutine(RunPath(path));

        }

        IEnumerator RunPath(List<Vector3> path)
        {
            foreach (var target in path)
            {
                var origin = this.transform.position;
                float porcent = 0;

                while (porcent < 1f)
                {
                    this.transform.position = Vector3.Lerp(origin, target, porcent);

                    porcent += Time.deltaTime * this.Speed;

                    yield return null;
                }
            }
        } 
    }
    
}
