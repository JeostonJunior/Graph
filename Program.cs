using System;

namespace Grafos
{
	class Program
	{
		public static void Main(string[] args)
		{
			Graph graph = new Graph();

			graph.insertCorner(5);
			graph.insertCorner(2);
			graph.insertCorner(3);
			graph.insertCorner(8);
			graph.insertEdges("x", 1, 5, 2);
			graph.insertEdges("h", 3, 3, 5);
			graph.insertEdges("i", 1, 5, 8);
			graph.insertEdges("j", 2, 8, 5);
			graph.insertEdges("k", 3, 3, 8);


			//Console.WriteLine("\n");
			//Console.WriteLine("Removing corners");
			//graph.removeCorner(2);

			//Console.WriteLine("\n");
	        //Console.WriteLine("Removing edges");
			//graph.removeEdges(5,2);

			Console.WriteLine("\n");
			Console.WriteLine("All corners");
			graph.printCorners();

			Console.WriteLine("\n");
			Console.WriteLine("All edges connected");
			graph.printEdges();

			Console.WriteLine("\n");
			Console.WriteLine("Minimum degree");
			graph.minDegree();

			Console.WriteLine("\n");
			Console.WriteLine("Maximum degree");
			graph.maxDegree();

			Console.WriteLine(" ");
			Console.WriteLine("Middle degree");
			graph.middleDegree();

			Console.WriteLine("\n");
			Console.WriteLine("Show degree of a especif corner");
			graph.showCornerDegree(5);

			Console.WriteLine("\n");
			Console.WriteLine("Show all corners connected to the current corner");
			graph.showAdj(1);
			
			Console.WriteLine("\n");
            Console.WriteLine("Verify if the graph is conneted");
			graph.showConnectivity();

			Console.WriteLine("\n");
			Console.WriteLine("Verify an Euler patch");
			graph.verifyEuler();

			Console.WriteLine("\n");
            Console.WriteLine("This is the adjacency matrix:\n");
			graph.showAdjacencyMatrix();

			Console.ReadLine();
		}
	}
}