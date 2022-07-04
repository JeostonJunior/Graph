using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Grafos
{
	public class Graph
	{
		private List<Corner> corners = new List<Corner>();
		private List<Edge> edges = new List<Edge>();
		public List<Corner> getCorners()
        {
			return corners;
        }
		public List<Edge> getEdges()
        {
			return edges;
        }
		public int searchCorner(int value)
        {
			for(int i = 0; i < corners.Count(); i++)
            {
				if(corners[i].getCorner() == value)
                {
					return i;
                }
            }
			return -1;
        }
		public void insertCorner(int value)
        {
			if(searchCorner(value) != -1)
            {
				Console.WriteLine("This Corner has already been inserted");
            }

			Corner corner = new Corner(value);
			corners.Add(corner);

			Console.WriteLine("Corner successfully inserted");
        }
		public int searchEdge(int outputEdge, int inputEdge)
        {
			for(int i = 0; i < edges.Count(); i++)
            {
				if((edges[i].getOutputCorner().getCorner() == outputEdge) && (edges[i].getInputCorner().getCorner() == inputEdge))
                {
					return i;
                }

				if((edges[i].getInputCorner().getCorner() == outputEdge) && (edges[i].getOutputCorner().getCorner() == inputEdge))
                {
					return i;
                }
            }
			return -1;
        }		
		public void insertEdges(string name, int weight, int output, int input)
        {
			Edge edge = new Edge(name, weight);

			int valueOutput = searchCorner(output);
			int valueInput = searchCorner(input);

			if (valueOutput == -1)
            {
				Console.WriteLine("Output corner doesn't exist");
				return;
            }

			if(valueInput == -1)
            {
				Console.WriteLine("Input Corner doesn't exist");
				return;
            }
			
			if(corners[valueOutput] == corners[valueInput])
            {
				Console.WriteLine("It's not possible to create an edge with a single Corner");
				return;
            }

			if(searchEdge(valueOutput, valueInput) != -1)
            {
                Console.WriteLine("It's not possible to create equals Edges");
				return;
            }

			edge.setOutputCorner(corners[valueOutput]);
			edge.setInputCorner(corners[valueInput]);

			edges.Add(edge);
            Console.WriteLine("Edge successfully inserted");
        }
		public void removeEdges(int valueOutput, int valueInput)
        {
			int currentEdge = searchEdge(valueOutput, valueInput);

			if(currentEdge != -1)
            {
				edges.RemoveAt(currentEdge);
                Console.WriteLine("The edge has been removed");
            }
        }
		public void removeCorner(int value)
        {
			for(int i = 0; i < corners.Count(); i++)
            {
				removeEdges(value, corners[i].getCorner());
				removeEdges(corners[i].getCorner(), value);
            }

			for (int i = 0; i < corners.Count(); i++)
            {
				if(corners[i].getCorner() == value)
                {
					corners.RemoveAt(i);
                    Console.WriteLine("The Corner has been removed");
                }
            }
		}
		public void printCorners()
        {
			for (int i = 0; i < corners.Count(); i++)
            {
                Console.Write($"[{corners[i].getCorner()}]");
            } 
        }	
		public void printEdges()
        {
			for(int i = 0; i < edges.Count(); i++)
            {
				edges[i].print();
            }
        }
		public int noFound()
        {
			if (corners.Count() == 0)
			{
				Console.WriteLine("No edges found");
			}
			return 0;
		}
		public int getVertexDegree(int value)
        {
			if(searchCorner(value) == -1)
            {
				return -1;
            }

			int degree = 0;

            for (int i = 0; i < edges.Count(); i++)
            {
                if (edges[i].getOutputCorner().getCorner() == value || edges[i].getInputCorner().getCorner() == value)
                {
					degree++;
                }
            }
			return degree;
        }
		
		public void showCornerDegree(int value)
        {
			int vertex = getVertexDegree(value);
			if(vertex != -1)
            {
				Console.WriteLine($"The degree of corner {value} is {vertex}");
            }
            else
            {
                Console.WriteLine("This corner doesn't exists");
            }
            
        }

		public int minDegree()
        {
			noFound();

            int minCornerDegree = int.MaxValue;

            for (int i = 0; i < corners.Count(); i++)
            {
                int cornerValue = corners[i].getCorner();
                if (getVertexDegree(cornerValue) <= minCornerDegree)
                {
                    minCornerDegree = getVertexDegree(cornerValue);
                }
            }

            Console.WriteLine($"The minimum degree of the graph is: {minCornerDegree}");
            return minCornerDegree;
        }
		public int maxDegree()
        {
			noFound();

			int maxCornerDegree = int.MinValue;

			for (int i = 0; i < corners.Count(); i++)
			{
				int cornerValue = corners[i].getCorner();
				if (getVertexDegree(cornerValue) >= maxCornerDegree)
				{
					maxCornerDegree = getVertexDegree(cornerValue);
				}
			}

			Console.WriteLine($"The maximum degree of the graph is: {maxCornerDegree}");
			return maxCornerDegree;
		}
		public decimal middleDegree()
        {
			decimal sum = 0m;

			noFound();

            for (int i = 0; i < corners.Count(); i++)
            {
				int valueCorner = corners[i].getCorner();
				sum += getVertexDegree(valueCorner);
            }

			decimal result = sum / corners.Count();
            Console.WriteLine($"The middle degree is {result}");
			return result;
        }
		public List<Corner> catchAdjacents(int value)
		{
			List<Edge> edgesAdj = new List<Edge>();
			List<Corner> cornersAdj = new List<Corner>();

			int valueEdge;

			for (int i = 0; i < corners.Count(); i++)
			{
				valueEdge = searchEdge(value, corners[i].getCorner());
				if(valueEdge != -1)
                {
					edgesAdj.Add(edges[valueEdge]);
                }
			}

            for (int i = 0; i < corners.Count(); i++)
            {
				valueEdge = searchEdge(corners[i].getCorner(), value);
				if(valueEdge != -1)
                {
					edgesAdj.Add(edges[valueEdge]);
                }
            }

            for (int i = 0; i < edgesAdj.Count(); i++)
            {
				if(edgesAdj[i].getInputCorner().getCorner() != value)
                {
                    if (!cornersAdj.Contains(edgesAdj[i].getInputCorner()))
                    {
						cornersAdj.Add(edgesAdj[i].getInputCorner());
                    }
                }
				if (edgesAdj[i].getOutputCorner().getCorner() != value)
                {
                    if (!cornersAdj.Contains(edgesAdj[i].getOutputCorner()))
                    {
						cornersAdj.Add(edgesAdj[i].getOutputCorner());
                    }
                }

			}
			return cornersAdj;		
		}

		public void showAdj(int value)
        {
			List<Corner> cornersAdj;
			cornersAdj = catchAdjacents(value);

            for (int i = 0; i < cornersAdj.Count(); i++)
            {
                Console.Write($"{cornersAdj[i].getCorner()} ");
            }
        }

		public List<Corner> Find(Corner corner, List<Corner> cornersConected)
        {
			cornersConected.Add(corner);
			List<Corner> cornersAdj = new List<Corner>();
			cornersAdj = catchAdjacents(corner.getCorner());

			for (int i = 0; i < cornersAdj.Count(); i++)
            {
                if (!cornersConected.Contains(cornersAdj[i]))
                {
					cornersConected = Find(cornersAdj[i], cornersConected);
                }
            }
			return cornersConected;
        }
		public int verifyConnectivity()
        {
			List<Corner> cornersConected = new List<Corner>();
			List<Corner> connectivity = this.Find(corners[0], cornersConected);

			if (corners.Count() == 0)
            {     
				return 0;
            }

			if(connectivity.Count() == corners.Count())
            {              
				return 1;
			}
            else
            {			
				return -1;
			}
        }

		public void showConnectivity()
        {
			if(verifyConnectivity() != 0)
            {
				if (verifyConnectivity() == 1)
				{
					Console.WriteLine("This graph is Connected");
				}
				else
				{
					Console.WriteLine("This graph is not Connected");
				}
            }
            else
            {
				Console.WriteLine("No corners Found");
			}
        }
		public void verifyEuler()
        {
			int odd = 0;

			int conneted = verifyConnectivity();

			if (conneted == 1)
            {
                for (int i = 0; i < corners.Count(); i++)
                {
					int cornerDegree = getVertexDegree(corners[i].getCorner());
					if(cornerDegree % 2 != 0)
                    {
						odd++;
                    }
                }

				if(odd == 0)
                {
                    Console.WriteLine("Euler exists");
                }
				if(odd == 2)
                {
					Console.WriteLine("Euler exists");
				}
            }
            else
            {
                Console.WriteLine("Euler doesn't exists");
            }
        }

		public void showAdjacencyMatrix()
        {
			int valueEdge;

            for (int i = 0; i < corners.Count(); i++)
            {
				Console.Write($"[[{corners[i].getCorner()}]");

                for (int j = 0; j <corners.Count(); j++)
                {
					valueEdge = searchEdge(corners[i].getCorner(), corners[j].getCorner());

					if(valueEdge == -1)
                    {
						valueEdge = searchEdge(corners[j].getCorner(), corners[i].getCorner());

                    }
					if(valueEdge != -1)
                    {
                        Console.Write($"[{edges[valueEdge].getEdgeWeight()}]");
                    }
                    else
                    {
                        Console.Write("["+ 0 +"]");
                    }
                }
                Console.WriteLine("]\n");
			}
        }

	}
}
