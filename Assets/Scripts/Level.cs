using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int SIZE_X = 11;
    public int SIZE_Y = 7;

    public List<byte[,]> Levels;

    byte[,] Level1;
    
    public Level()
    {
        Level1 = new byte[,] {
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 0 = Void        
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 2 = Plains     // 5 = Lake     // 8 =
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 }};

        Levels = new List<byte[,]>();
        Levels.Insert(0, Level1);
    }
}
