using System;
using System.Collections.Generic;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.EvolutionaryAlgorithms
{
	/// <summary>
	/// UnitAgentChromosome class. Inherits Chromosome and implements IComparable and ICloneable.
	/// @author Thomas Willer Sandberg (http://twsandberg.dk/)
	/// @version (1.0, January 2011)
	/// </summary>
	class UnitAgentChromosome : Chromosome, IComparable, ICloneable 
	{
		private const int NumberOfUnitAgentOptimizedProperties = 19;

		public UnitAgentChromosome()
		{
			Gene = new List<float>();
		}

		public UnitAgentChromosome(List<float> gene)
			: base(gene)
		{
			Gene = gene;
		}

		public UnitAgentChromosome(float[] genesFloat)
			: base(genesFloat)
		{
			Gene = new List<float>();
			SetGene(genesFloat);
		}

		/// <summary>
		/// Clone/Copy all variables from this Chromosome to a new Chromosome.
		/// </summary>
		/// <returns></returns>
		public Object Clone()
		{
			var tmpGene = new List<float>();
			foreach (float f in Gene)
				tmpGene.Add(f);

			var tmpChromo = new UnitAgentChromosome(tmpGene);
			tmpChromo.Fitness = Fitness;

			return tmpChromo;
		}

		/// <summary>
		/// Compare two fitness (double) values.
		/// It returns 0 if both the values are equal,
		/// returns value less than 0 if this Double object is less than the argument,
		/// and returns value grater than 0 if this Double object is grater than the argument.
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public int CompareTo(Object o)
		{
			return ((Chromosome)o).Fitness.CompareTo(this.Fitness);
		}

		public void ConvertAndAddOptimizedValuesToUnitAgentChromosome(UnitAgentOptimizedProperties opProp)//String unitTypeName)//ref UnitAgent unitAgent)
		{
			if (Gene == null)
				Gene = new List<float>();
			else if (Gene.Count > 0)
			{
				Logger.Logger.AddAndPrint("WARNING: There was already values in the UnitAgentChromosome, when it was initialized. They have been deleted");
				Gene = new List<float>();
			}

			Fitness = opProp.Fitness;
			
			//Force
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float) opProp.ForceOwnUnitsRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceOwnUnitsRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceEnemyUnitsRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceEnemyUnitsRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceMSD, OptimizedPropertiesMultiplyers.Instance.ForceMSDMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceSquadAttraction, OptimizedPropertiesMultiplyers.Instance.ForceSquadAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceMapCenterAttraction, OptimizedPropertiesMultiplyers.Instance.ForceMapCenterAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceMapEdgeRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceMapEdgeRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceWeaponCoolDownRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceWeaponCoolDownRepulsionMultiplyer));

			//ForceStep
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepOwnUnitsRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceStepOwnUnitsRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepEnemyUnitsRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceStepEnemyUnitsRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepMSD, OptimizedPropertiesMultiplyers.Instance.ForceStepMSDMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepSquadAttraction, OptimizedPropertiesMultiplyers.Instance.ForceStepSquadAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepMapCenterAttraction, OptimizedPropertiesMultiplyers.Instance.ForceStepMapCenterAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepMapEdgeRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceStepMapEdgeRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome((float)opProp.ForceStepWeaponCoolDownRepulsion, OptimizedPropertiesMultiplyers.Instance.ForceStepWeaponCoolDownRepulsionMultiplyer));

			//Range
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome(opProp.RangeOwnUnitsRepulsion, OptimizedPropertiesMultiplyers.Instance.RangeOwnUnitsRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome(opProp.RangePercentageSquadAttraction, OptimizedPropertiesMultiplyers.Instance.RangePercentageSquadAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome(opProp.RangePecentageMapCenterAttraction, OptimizedPropertiesMultiplyers.Instance.RangePecentageMapCenterAttractionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome(opProp.RangeMapEdgeRepulsion, OptimizedPropertiesMultiplyers.Instance.RangeMapEdgeRepulsionMultiplyer));
			Gene.Add(ConvertOptimizedValueToUnitAgentChromosome(opProp.RangeWeaponCooldownRepulsion, OptimizedPropertiesMultiplyers.Instance.RangeWeaponCooldownRepulsionMultiplyer));
		}

		/// <summary>
		/// Checks if a value_multiplyer is zero, then return zero else return value divided by value_multiplyer.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="valueMultiplyer"></param>
		private static float ConvertOptimizedValueToUnitAgentChromosome(float value, int valueMultiplyer)
		{
			if (valueMultiplyer != 0)
				return value / valueMultiplyer;
			return 0;
		}

		public UnitAgentOptimizedProperties ConvertUnitAgentChromosomeToOptimizedValues()
		{
			if (Gene != null && Gene.Count > 0 && Gene.Count == NumberOfUnitAgentOptimizedProperties)
			{
				var opProp = new UnitAgentOptimizedProperties();

				//Force
				opProp.ForceOwnUnitsRepulsion = Gene[0] * OptimizedPropertiesMultiplyers.Instance.ForceOwnUnitsRepulsionMultiplyer;
				opProp.ForceEnemyUnitsRepulsion = Gene[1] * OptimizedPropertiesMultiplyers.Instance.ForceEnemyUnitsRepulsionMultiplyer;
				opProp.ForceMSD = Gene[2] * OptimizedPropertiesMultiplyers.Instance.ForceMSDMultiplyer;
				opProp.ForceSquadAttraction = Gene[3] * OptimizedPropertiesMultiplyers.Instance.ForceSquadAttractionMultiplyer;
				opProp.ForceMapCenterAttraction = Gene[4] * OptimizedPropertiesMultiplyers.Instance.ForceMapCenterAttractionMultiplyer;
				opProp.ForceMapEdgeRepulsion = Gene[5] * OptimizedPropertiesMultiplyers.Instance.ForceMapEdgeRepulsionMultiplyer;
				opProp.ForceWeaponCoolDownRepulsion = Gene[6] * OptimizedPropertiesMultiplyers.Instance.ForceWeaponCoolDownRepulsionMultiplyer;
				
				//ForceStep
				opProp.ForceStepOwnUnitsRepulsion = Gene[7] * OptimizedPropertiesMultiplyers.Instance.ForceStepOwnUnitsRepulsionMultiplyer;
				opProp.ForceStepEnemyUnitsRepulsion = Gene[8] * OptimizedPropertiesMultiplyers.Instance.ForceStepEnemyUnitsRepulsionMultiplyer;
				opProp.ForceStepMSD = Gene[9] * OptimizedPropertiesMultiplyers.Instance.ForceStepMSDMultiplyer;
				opProp.ForceStepSquadAttraction = Gene[10] * OptimizedPropertiesMultiplyers.Instance.ForceStepSquadAttractionMultiplyer;
				opProp.ForceStepMapCenterAttraction = Gene[11] * OptimizedPropertiesMultiplyers.Instance.ForceStepMapCenterAttractionMultiplyer;
				opProp.ForceStepMapEdgeRepulsion = Gene[12] * OptimizedPropertiesMultiplyers.Instance.ForceStepMapEdgeRepulsionMultiplyer;
				opProp.ForceStepWeaponCoolDownRepulsion = Gene[13] * OptimizedPropertiesMultiplyers.Instance.ForceStepWeaponCoolDownRepulsionMultiplyer;

				//Range
				opProp.RangeOwnUnitsRepulsion = Convert.ToInt32(Gene[14] * OptimizedPropertiesMultiplyers.Instance.RangeOwnUnitsRepulsionMultiplyer);
				opProp.RangePercentageSquadAttraction = Convert.ToInt32(Gene[15] * OptimizedPropertiesMultiplyers.Instance.RangePercentageSquadAttractionMultiplyer);
				opProp.RangePecentageMapCenterAttraction = Convert.ToInt32(Gene[16] * OptimizedPropertiesMultiplyers.Instance.RangePecentageMapCenterAttractionMultiplyer);
				opProp.RangeMapEdgeRepulsion = Convert.ToInt32(Gene[17] * OptimizedPropertiesMultiplyers.Instance.RangeMapEdgeRepulsionMultiplyer);
				opProp.RangeWeaponCooldownRepulsion = Convert.ToInt32(Gene[18] * OptimizedPropertiesMultiplyers.Instance.RangeWeaponCooldownRepulsionMultiplyer);

				return opProp;
			}
			Logger.Logger.AddAndPrint("ERROR: In Method AddOptimizedValuesToUnitAgentChromosome in UnitAgentChromosome, the Gene was null or had none elements.");
			throw new Exception("ERROR: In Method AddOptimizedValuesToUnitAgentChromosome in UnitAgentChromosome, the Gene was null or had none elements.");
		}

		public void InitRandomChromosome()
		{
			for (int i = 0; i < NumberOfUnitAgentOptimizedProperties; i++)
			{
				Gene.Add(RandomNumber.RandomFloat(0, 2));
			}
		}
	}
}