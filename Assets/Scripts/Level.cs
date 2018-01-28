using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int SIZE_X = 11;
    public int SIZE_Y = 7;

    public List<byte[,]> Levels;

    byte[,] Level1;
    byte[,] Level2;
    byte[,] Level3;
    byte[,] Level4;
    byte[,] Level5;
    byte[,] Level6;

    public Level()
    {
        Level1 = new byte[,] {
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 0 = Void        
            { 0,0,0,0,0,1,0,0,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,0,0,6,0,0,0,0,0 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,0,0,0,0,6,0,0,0,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,0,0,6,0,0,0,0,0 },
            { 0,0,0,0,0,9,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 }};

        Level2 = new byte[,] {
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 0 = Void        
            { 0,0,1,6,6,0,0,0,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,0,0,6,0,0,0,0,0 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,0,0,0,2,0,5,0,0,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,0,0,9,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 }};

        Level3 = new byte[,] {
            { 0,0,0,0,0,0,3,3,3,0,0 },      // 0 = Void        
            { 0,0,0,0,0,0,0,2,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,6,0,0,0,0,0,0,0 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,0,1,0,0,0,0,0,9,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,2,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,6,0,0,0 },
            { 0,0,0,0,0,0,6,3,3,0,0 }};

        Level4 = new byte[,] {
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 0 = Void        
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,5,0,0,2,0,0,0,0 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,1,2,0,0,0,0,6,6,9,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,4,0,0,5,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 }};

        Level5 = new byte[,] {
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 0 = Void        
            { 0,0,1,5,5,0,0,0,0,0,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,5,5,3,3,3,4,4,0,0 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,0,0,6,6,0,0,2,4,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,6,6,3,3,2,4,0,0 },
            { 0,0,0,0,0,0,0,2,2,9,0 },
            { 0,0,0,0,0,0,0,0,0,0,0 }};

        Level6 = new byte[,] {
            { 0,0,0,0,0,0,0,5,0,0,0 },      // 0 = Void        
            { 0,0,0,0,0,0,2,0,6,6,0 },      // 1 = Start      // 4 = Mountains// 7 =
            { 0,0,0,0,4,0,0,0,1,0,4 },      // 2 = Plains     // 5 = Desert   // 8 =
            { 0,0,0,0,0,0,0,0,0,0,0 },      // 3 = Forest     // 6 = City     // 9 = End
            { 0,0,0,3,0,0,0,0,5,0,0 },
            { 0,0,0,0,0,9,6,6,0,4,0 },
            { 0,0,0,0,0,0,0,0,0,0,4 }};

        Levels = new List<byte[,]>();
        Levels.Insert(0, Level1);
        Levels.Insert(1, Level2);
        Levels.Insert(2, Level3);
        Levels.Insert(3, Level4);
        Levels.Insert(4, Level5);
        Levels.Insert(5, Level6);
    }
}
