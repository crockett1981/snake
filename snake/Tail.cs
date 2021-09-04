using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace snake
{
    public class Tail
    {
        public Vector2 PreviousPosition;
        public Vector2 Position;

        public Tail(Vector2 position)
        {   
            Position = position;
        }

        public static void Init(List<Tail> tails, int length)
        {
            for(int i = 0; i < length; ++i)
                tails.Add(new Tail(new Vector2(tails[0].Position.X + (8 * i), tails[0].Position.Y)));
        }

        public static void Move(List<Tail> tails)
        {
            for (int i = 1; i < tails.Count; ++i)
            {
                tails[i].PreviousPosition = tails[i].Position;
                tails[i].Position = tails[i - 1].PreviousPosition;
            }
        }
    }
}