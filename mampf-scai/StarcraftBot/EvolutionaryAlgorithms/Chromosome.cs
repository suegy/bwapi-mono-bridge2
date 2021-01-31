using System;
using System.Collections.Generic;

namespace StarcraftBot.EvolutionaryAlgorithms
{

	/// <summary>
	/// This class holds a list of genes whose values can be adjusted to solve a specific problem.
	/// The class also holds the fitness value used to deside how well the Chromosome solves the specific problem.
	/// @author Thomas Willer Sandberg (http://twsandberg.dk/)
	/// @version (1.0, January 2011)
	/// </summary>
	class Chromosome
	{ 
		protected static GaussianRandom GausianRandom = new GaussianRandom();

		public Chromosome()
		{
			Gene = new List<float>();
		}

		public Chromosome(List<float> gene)
		{
			Gene = gene;
		}
		
		public Chromosome(float[] genesFloat)
		{
			Gene = new List<float>();
			
			SetGene(genesFloat);
		}

		/// <summary>
		///  Mutate a randomly number of the genes/values in the current Chromosome with a random number drawn from a Gaussian distribution. with a mean and standard deviation
		/// </summary>
		/// <param name="mean"></param>
		/// <param name="deviation"></param>
		public void MutateGaussianRandom(float mean, float deviation)
		{
			int y = RandomNumber.RandomInt(0, 5);
			int numberOfRuns = Gene.Count;
			while (y < numberOfRuns)	
			{
				Gene[y] += Convert.ToSingle(GausianRandom.NextGaussian(mean, deviation));
				y += RandomNumber.RandomInt(1, 5);
			}
		}

		/**
		 * Mutate all the genes/values in the current Chromosome with a random number drawn from a Gaussian distribution. with a mean and standard deviation
		 * @param float mean
		 * @param float deviation - standard deviation
		 */
		public void MutateGaussian(float mean, float deviation)
		{
			int numberOfRuns = Gene.Count;

			for (int y = 0; y < numberOfRuns; y++)
			{
				Gene[y] += Convert.ToSingle(GausianRandom.NextGaussian(mean, deviation));//r;
			}
		}
		
		private float FlipFloatRandom(float aFloat)
		{
			float r = RandomNumber.RandomInt(0,1);
			if(r==0)
				r = -1;
			return aFloat*r;
		}
		
		public void FlipRandomAllWeights()
		{
			foreach (float f in Gene)
				FlipFloatRandom(f);
		}
		
		//Properties
		public void SetGene(float[] genesFloat)
		{
			foreach (float f in genesFloat)
				Gene.Add(f);
		}

		public List<float> Gene { get; set; }
		public int Fitness { get; set; }
	}
}