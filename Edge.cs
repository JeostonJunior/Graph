using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grafos
{
    public class Edge
    {
        private Corner InputCorner;
        private Corner OutputCorner;
        private int EdgeWeight;
        private string EdgeName;

        public Edge(string name, int weight)
        {
            EdgeName = name;
            EdgeWeight = weight;
        }

        //public void setEdgeName(string name)
        //{
        //    EdgeName = name;
        //}

        //public string getEdgeName()
        //{
        //    return EdgeName;
        //}

        public void setEdgeWeight(int weight)
        {
            EdgeWeight = weight;
        }

        public int getEdgeWeight()
        {
            return EdgeWeight;
        }

        public void setInputCorner(Corner inputCorner)
        {
            InputCorner = inputCorner;
        }

        public Corner getInputCorner()
        {
            return InputCorner;
        }

        public void setOutputCorner(Corner outputCorner)
        {
            OutputCorner = outputCorner;
        }

        public Corner getOutputCorner()
        {
            return OutputCorner;
        }

        public void print()
        {
            Console.Write($"[{getOutputCorner().getCorner()} === {getInputCorner().getCorner()}] ");
        }

    }
}
