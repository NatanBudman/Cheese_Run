using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class nav : MonoBehaviour
{
    public Tilemap map;

    private int[,] distMap;
    private List<Vector3> path;

    private void Start()
    {
        this.path = new List<Vector3>();
        this.distMap = new int[this.map.size.x, this.map.size.y];

        var min = this.map.localBounds.min;

        for (int x = 0; x < this.map.size.x; x++)
        {
            for (int y = 0; y < this.map.size.y; y++)
            {
                int mapX = (int)(x + min.x);
                int mapY = (int)(y + min.x);

                var tile = this.map.GetTile(new Vector3Int(mapX, mapY, 0));


                if (tile != null)
                {
                    this.distMap[x, y] = -1;
                }
                else
                {
                    this.distMap[x, y] = 0;
                }
            }
        } 
       
        
    }

    Vector3Int ToLocal(Vector3 world)
    {
        var local = (world - this.map.transform.position) - this.map.localBounds.min;
        return new Vector3Int((int)local.x, (int)local.y, 0);
    }
    Vector3 ToGlobal(Vector3Int local)
    {
        var f_local = new Vector3(local.x,local.y, 0);
        return f_local + this.transform.position + this.map.localBounds.min;
    }
    Vector3 ToGlobal(Vector3 local)
    {
        return local + this.transform.position + this.map.localBounds.min;
    }

    private void GetLocalUbication(Vector3Int localStart, Vector3Int localTarget)
    {
        for (int x = 0; x < this.map.size.x; x++)
        {
            for (int y = 0; y < this.map.size.y; y++)
            {
                if (this.distMap[x,y] != -1)
                {
                    this.distMap[x, y] = 0;
                }
            }
        } 
        this.path.Clear();
        
        //evitar muros
        if (this.distMap[localTarget.x, localTarget.y] != 0 || this.distMap[localStart.x, localStart.y] != 0)
        {
            return;
        }

        int dis = 1;

        Queue<Vector3Int> VisitCell = new Queue<Vector3Int>();
        this.distMap[localTarget.x, localTarget.y] = dis;
        VisitCell.Enqueue(localTarget);

        while (VisitCell.Count != 0 && VisitCell.Count < 1000)
        {
            dis += 1;

            var cell = VisitCell.Dequeue();
            this.Visit(VisitCell, dis, cell.x, cell.y + 1);
            this.Visit(VisitCell, dis, cell.x, cell.y - 1);
            this.Visit(VisitCell, dis, cell.x + 1, cell.y);
            this.Visit(VisitCell, dis, cell.x - 1, cell.y);

            ComputePath(localStart);
        }

    }

    private void ComputePath(Vector3Int localStart)
    {
        Vector3Int currentLocalTile = localStart;

        bool working = true;

        while (working)
        {
            path.Add(this.ToGlobal(currentLocalTile));
            
            var (x,y) = ((int)currentLocalTile.x ,(int)currentLocalTile.y);
            var d = this.distMap[x, y];

            working = false;

            if (distMap[x,y+1] < d && distMap[x,y+1] != -1)
            {
                currentLocalTile.Set(x,y + 1,0);
                working = true;
                continue;
            }
            if (distMap[x,y-1] < d && distMap[x,y-1] != -1)
            {
                currentLocalTile.Set(x,y - 1,0);
                working = true;
                continue;
            }
            if (distMap[x + 1,y] < d && distMap[x + 1,y] != -1)
            {
                currentLocalTile.Set(x + 1,y,0);
                working = true;
                continue;
            }
            if (distMap[x - 1,y] < d && distMap[x - 1,y] != -1)
            {
                currentLocalTile.Set(x - 1,y,0);
                working = true;
                continue;
            }
            

        }
    }

    private void Visit(Queue<Vector3Int> visitCell, int dist, int x, int y)
    {
        if (x < 0 || x >= this.map.size.x)
        {
         return;   
        }
        if (y < 0 || y >= this.map.size.y)
        {
            return;   
        }

        if (this.distMap[x,y] == 0)
        {
            this.distMap[x, y] = dist;
            visitCell.Enqueue(new Vector3Int(x,y,0));
        }
    }

    public List<Vector3> GetPath(Vector3 start, Vector3 end)
    {
        var Istart = this.ToLocal(start);
        var IEnd = this.ToLocal(end);

        this.GetLocalUbication(Istart, IEnd);

        for (int i = 0; i < this.path.Count; i++)
        {
            var loc = this.path[i] + Vector3.one * 0.5f;
            loc.z = 0;

            this.path[i] = loc;
        }
        return this.path;
    }
}
