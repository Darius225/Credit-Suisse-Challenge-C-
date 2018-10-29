using System;

namespace C_Sharp_Challenge_Skeleton.Beans
{
    public class Server
    {
        public int numServers { get; set; }
        public int target { get; set; }
        public int[,] arcs { get; set; }

        public Server()
        {
        }

    }
}