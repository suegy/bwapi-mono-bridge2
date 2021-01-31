using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StarcraftBot.UnitAgents;

namespace StarcraftBot.EvolutionaryAlgorithms
{
    /// <summary>
    /// This class contains methods for a Genetic Algorithm to optimize values in a gene representing 
    /// different Potential Field Values for a StarCraft agent. 
    /// The main purpose of the class is to find the best StarCraft agent candidate.
    /// @author Thomas Willer Sandberg (http://twsandberg.dk/)
    /// @version (1.0, January 2011)
    /// </summary>
    class EvolutionaryAlgorithm 
    {
        public XmlFileHandler UnitAgentXMLFileHandler { get; protected set; }
        public List<UnitAgentChromosome> Population { get; protected set; }
        public int PopulationSize { get; protected set; }
        public List<UnitAgentOptimizedProperties> OptimizedPropertiesGenes { get; protected set; }

        public EvolutionaryAlgorithm(int populationSize)
        {
            if (populationSize < 10)
                throw new ArgumentException("Invalid populationSize. The population should at least be 10.");

            PopulationSize = populationSize;
            OptimizedPropertiesGenes = new List<UnitAgentOptimizedProperties>();
            UnitAgentXMLFileHandler = new XmlFileHandler();

            Population = new List<UnitAgentChromosome>();
            InitPopulation();   // Initialise population

            try
            {
                ConvertPopulationToUnitAgentOptimizedProperties();//Convert the Chromosome values to optimized property values that UnitAgent understand.
            }
            catch (Exception e) { Logger.Logger.AddAndPrint(e.StackTrace); }
        }

        /// <summary>
        /// Used for loading already optimized values from an serialized XML file.
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="percentOfOpPropsToLoad"></param>
        /// <param name="dataFileName"></param>
        public EvolutionaryAlgorithm(int populationSize, int percentOfOpPropsToLoad, String dataFileName)
        {
            PopulationSize = populationSize;
            UnitAgentXMLFileHandler = new XmlFileHandler(dataFileName);
            OptimizedPropertiesGenes = new List<UnitAgentOptimizedProperties>();
            Population = new List<UnitAgentChromosome>();

            try
            {// Initialise population from an existing file
                //InitPopulationFromExistingFile(25);
                InitPopulationFromExistingFile(percentOfOpPropsToLoad);//100);
            }
            catch (Exception e) { Logger.Logger.AddAndPrint(e.StackTrace); }
        }

        /// <summary>
        /// Used for loading the fittest optimized values from an serialized XML file. Can be used for playing StarCraft without training.
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="dataFileName"></param>
        public EvolutionaryAlgorithm(int populationSize, String dataFileName)
        {
            PopulationSize = populationSize;
            UnitAgentXMLFileHandler = new XmlFileHandler(dataFileName);
            OptimizedPropertiesGenes = new List<UnitAgentOptimizedProperties>();
            Population = new List<UnitAgentChromosome>();

            try
            {// Initialise population from an existing file
                //InitPopulationFromExistingFile(25);
                OptimizedPropertiesGenes.Add(LoadGetFittestUAOptPropFromExistingFile(dataFileName));
            }
            catch (Exception e) { Logger.Logger.AddAndPrint(e.StackTrace); }
        }

        /// <summary>
        /// MULTI LOAD OF SEVERAL UNIT TYPES. 
        /// </summary>
        /// <param name="populationSize"></param>
        /// <param name="dataFileNames"></param>
        public EvolutionaryAlgorithm(int populationSize, IEnumerable<String> dataFileNames)
        {
            PopulationSize = populationSize;
            UnitAgentXMLFileHandler = new XmlFileHandler();
            OptimizedPropertiesGenes = new List<UnitAgentOptimizedProperties>();
            Population = new List<UnitAgentChromosome>();

            try
            {// Initialise population from an existing file
                //InitPopulationFromExistingFile(25);
                foreach (var fileName in dataFileNames)
                    OptimizedPropertiesGenes.Add(LoadGetFittestUAOptPropFromExistingFile(fileName));

            }
            catch (Exception e) { Logger.Logger.AddAndPrint(e.StackTrace); }
        }

        /// <summary>
        /// Initialize the population in GA.
        /// </summary>
        private void InitPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                var c = new UnitAgentChromosome();
                c.InitRandomChromosome();
                Population.Add(c);//The constructor in UAChromosome automatically initializes all the values/genes.
            }
        }

        /// <summary>
        /// Convert Population (List<Chromosome>) to UnitAgentOptimizedProperties (List<UnitAgentOptimizedProperties>).
        /// </summary>
        public void ConvertPopulationToUnitAgentOptimizedProperties()
        {
            //OptimizedPropertiesGenes = null;
            OptimizedPropertiesGenes = new List<UnitAgentOptimizedProperties>();

            if (Population != null && Population.Count > 0)
            {
                int rank = 1;

                Population.Sort();

                foreach (UnitAgentChromosome chromosome in Population)
                {
                    UnitAgentOptimizedProperties opProps = chromosome.ConvertUnitAgentChromosomeToOptimizedValues();
                    opProps.Fitness = chromosome.Fitness;
                    opProps.Rank = rank;
                    OptimizedPropertiesGenes.Add(opProps);
                    rank++;
                }
            }
            else
            {
                Logger.Logger.AddAndPrint("ERROR: In Method ConvertPopulationToUnitAgentOptimizedProperties in GeneticAlgorithm, the Population was null or had none elements.");
                throw new Exception("ERROR: In Method ConvertPopulationToUnitAgentOptimizedProperties in GeneticAlgorithm, the Population was null or had none elements.");
            }

            if (OptimizedPropertiesGenes.Count != Population.Count)
            {
                Logger.Logger.AddAndPrint("ERROR: In Method ConvertPopulationToUnitAgentOptimizedProperties in GeneticAlgorithm, the OptimizedPropertiesGenes and the Population List didn't have the same number of elements.");
                throw new Exception("ERROR: In Method ConvertPopulationToUnitAgentOptimizedProperties in GeneticAlgorithm, the OptimizedPropertiesGenes and the Population List didn't have the same number of elements.");
            }
        }

        /// <summary>
        /// Convert UnitAgentOptimizedProperties (List<UnitAgentOptimizedProperties>) to Population (List<Chromosome>).
        /// </summary>
        public void ConvertUnitAgentOptimizedPropertiesToPopulation()
        {
            Population = new List<UnitAgentChromosome>();

            if (OptimizedPropertiesGenes != null && OptimizedPropertiesGenes.Count > 0)
            {
                foreach (UnitAgentOptimizedProperties uAOptProp in OptimizedPropertiesGenes)
                {
                    var uaChrom = new UnitAgentChromosome();
                    uaChrom.ConvertAndAddOptimizedValuesToUnitAgentChromosome(uAOptProp); //DeepCopy(uAOptProp));
                    Population.Add(uaChrom);
                }
            }
            else
            {
                Logger.Logger.AddAndPrint("ERROR: In Method ConvertUnitAgentOptimizedPropertiesToPopulation in GeneticAlgorithm, the OptimizedPropertiesGenes was null or had none elements.");
                throw new Exception("ERROR: In Method ConvertUnitAgentOptimizedPropertiesToPopulation in GeneticAlgorithm, the OptimizedPropertiesGenes was null or had none elements.");
            }

            if (OptimizedPropertiesGenes.Count != Population.Count)
            {
                Logger.Logger.AddAndPrint("ERROR: In Method ConvertUnitAgentOptimizedPropertiesToPopulation in GeneticAlgorithm, the OptimizedPropertiesGenes and the Population List didn't have the same number of elements.");
                throw new Exception("ERROR: In Method ConvertUnitAgentOptimizedPropertiesToPopulation in GeneticAlgorithm, the OptimizedPropertiesGenes and the Population List didn't have the same number of elements.");
            }
        }

        /// <summary>
        /// Initialize the population in EA with already existing optimized values from a XML file.
        /// </summary>
          private void InitPopulationFromExistingFile(int percentOfOpPropsToLoad)
          {
              //Loads all the UAOptimizedProperties into a List (Property).
              OptimizedPropertiesGenes = UnitAgentXMLFileHandler.DeserializeFromXml();
              if (OptimizedPropertiesGenes != null && OptimizedPropertiesGenes.Count > 0)
              {
                  int numberOfOpProps =  (int) Math.Round((double) (percentOfOpPropsToLoad*OptimizedPropertiesGenes.Count/100),MidpointRounding.AwayFromZero);
                  if (numberOfOpProps > 100)
                      numberOfOpProps = 100;
                  else if (numberOfOpProps < 0)
                      numberOfOpProps = 0;

                  for (int i = 0; i < OptimizedPropertiesGenes.Count; i++)//PopulationSize; i++)
                  {
                      //Load, convert and add the specified percentage of the already existing optimized values from XML to the corresponding UAChromosomes in the population.
                      if (i < numberOfOpProps) // 10)
                      {
                          //UnitAgentOptimizedProperties uAOptProp = OptimizedPropertiesGenes[0];
                          var uaChromLoaded = new UnitAgentChromosome();
                          //uaChromLoaded.ConvertAndAddOptimizedValuesToUnitAgentChromosome(OptimizedPropertiesGenes[0]);//DeepCopy(OptimizedPropertiesGenes[0]));
                          uaChromLoaded.ConvertAndAddOptimizedValuesToUnitAgentChromosome(OptimizedPropertiesGenes[i]);//DeepCopy(OptimizedPropertiesGenes[0]));
                          Population.Add(uaChromLoaded);
                      }
                      else //The rest of the chromosomes get random values.
                      {
                          var c = new UnitAgentChromosome();
                          c.InitRandomChromosome();
                          Population.Add(c);//The constructor in UAChromosome automatically initializes all the values/genes.
                      }
                  }

                  //Convert and add all the Chromosomes in the population to the UnitAgentOptimizedProperties List.
                  ConvertPopulationToUnitAgentOptimizedProperties();
              }
              else
              {
                  Logger.Logger.AddAndPrint("Cannot find the StarCraft Unit Agent data file. The input OptimizedPropertiesGenes is null.");
                  throw new Exception("Cannot find the StarCraft Unit Agent data file. The input OptimizedPropertiesGenes is null.");
              }
          }


        /// <summary>
        /// Load at get the fittest unit agent optimized property from existing data (xml) file.
        /// </summary>
        /// <returns></returns>
          public UnitAgentOptimizedProperties LoadGetFittestUAOptPropFromExistingFile(String fileName)
          {
              //Loads all the UAOptimizedProperties into a List (Property).

              UnitAgentXMLFileHandler.Filename = fileName;
            List<UnitAgentOptimizedProperties> opPropGen = UnitAgentXMLFileHandler.DeserializeFromXml();

            //if (OptimizedPropertiesGenes != null && OptimizedPropertiesGenes.Count > 0)
            if (opPropGen != null && opPropGen.Count > 0)
                return opPropGen[0];//UnitAgentXMLFileHandler.DeserializeFromXml()[0];//OptimizedPropertiesGenes[0];
              Logger.Logger.AddAndPrint("Cannot find the StarCraft Unit Agent data file. The input OptimizedPropertiesGenes is null.");
              throw new Exception("Cannot find the StarCraft Unit Agent data file. The input OptimizedPropertiesGenes is null.");
          }

        /// <summary>
        /// Generic method to make a deep copy on result returned from for instance List.GetRange 
        /// (instead of just making a shallow copy (reference copy), that GetRange returns).
        /// Borrowed from: http://www.codeproject.com/Messages/3470965/how-to-return-sublist.aspx
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T DeepCopy<T>(T obj)
        {
            object result = null;

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                result = formatter.Deserialize(ms);
                ms.Close();
            }

            return (T)result;
        }

        /// <summary>
        /// Clone a Chromosome List.
        /// </summary>
        /// <param name="listToClone"></param>
        /// <returns></returns>
        public List<UnitAgentChromosome> CloneChromosomeList(List<UnitAgentChromosome> listToClone)
        {
            List<UnitAgentChromosome> tmpCromosomeList = new List<UnitAgentChromosome>();
            foreach (UnitAgentChromosome c in listToClone)
                tmpCromosomeList.Add((UnitAgentChromosome)c.Clone());
            return tmpCromosomeList;
            //return listToClone.Select(c => (UnitAgentChromosome)c.Clone()).ToList();
        }

        public void LogBestWorstAverageFitness()
        {
            SortPopulationAfterFitness();
            Logger.Logger.AddAndPrint("" + Population[0].Fitness + " ; " + Population[Population.Count - 1].Fitness +
                          " ; " + AverageFitness());
        }

        /// <summary>
        /// Repopulates the population (executes variation operations and creates the new population by selecting the fittest (also called: Survivor Selection or replacement)). 
        /// After 1 run remember to call ConvertPopulationToUnitAgentOptimizedProperties() 
        /// before running this method.
        /// </summary>
        /// <param name="nuberOfCrossOvers">Make one point cross over on the specified number of best candidates, and randomly pick the half of the new chromosomes.</param>
        public void Repopulate(int nuberOfCrossOvers)
        {
            if (Population != null && Population.Count > 0)
            {
                if ((nuberOfCrossOvers % 2) == 0 && nuberOfCrossOvers <= Population.Count)
                {
                Population.Sort();

                List<UnitAgentChromosome> newPopulation = CloneChromosomeList(Population.GetRange(0, 10));//Save the 10 best candidates each time.

                if (nuberOfCrossOvers >= 2)
                {
                    List<UnitAgentChromosome> newPopulationPart2 = CloneChromosomeList(Population.GetRange(0, nuberOfCrossOvers));//Make one point cross over on the specified best, and randomly pick the half of the new chromosomes.
                    newPopulation.AddRange(MultiCrossOver(newPopulationPart2, false));
                }

                int rest = Population.Count - newPopulation.Count; 
                if (rest > 0)
                {
                    List<UnitAgentChromosome> newPopulationPart3 = CloneChromosomeList(Population.GetRange(0, rest));
                    newPopulation.AddRange(MultiMutate(newPopulationPart3));//For the rest of the population: mutate
                }

                //VERY IMPORTANT: Copy the new Population back to the original Population, else there will be no optimization.
                Population = newPopulation;
                ConvertPopulationToUnitAgentOptimizedProperties();
                }
                else
                {
                    Logger.Logger.AddAndPrint("nuberOfCrossOvers  must be an even number and less than the population size.");
                    throw new Exception("nuberOfCrossOvers  must be an even number and less than the population size.");
                }
            }
            else
            {
                Logger.Logger.AddAndPrint("Population is null in EvolutionaryAlgorithm-Repopulate() or has no values.");
                throw new Exception("Population is null in EvolutionaryAlgorithm->Repopulate() or has no values.");
            }
        }

        /// <summary>
        /// Calculates the average fitness of all chromosomes in the population.
        /// </summary>
        /// <returns>The average fitness of all chromosomes in the population</returns>
        public int AverageFitness()
        {
            int sum = Population.Sum(chromosome => chromosome.Fitness);
            return sum/Population.Count;
        }

        /// <summary>
        /// Sort the population after the genes fitness and print best and worst to the console.         
        /// </summary>
        public void SortPopulationAfterFitness()
        {
            if (Population != null && Population.Count > 0)
            { 
                Population.Sort();

            String bestFitnessStr = "Best " + Population[0].Fitness + "FIRST Value: " + Population[0].Gene[0] + "Last value: " +
                          Population[0].Gene[Population[0].Gene.Count - 1];//Population[0].Gene[Population[0].Gene.Count -1] EQUALS LAST ELEMENT/GENE OF THE Chromosome.
            String worstFitnessStr = "Worst " + Population[Population.Count - 1].Fitness + " " +
                                     Population[Population.Count - 1].Gene[0];

            Console.WriteLine(bestFitnessStr);
            Console.WriteLine(worstFitnessStr);

            }
            else
            {
                Logger.Logger.AddAndPrint("Population is null in EvolutionaryAlgorithm->SortPopulationAfterFitness or has no values and can't be sorted.");
                throw new Exception("Population is null in EvolutionaryAlgorithm->SortPopulationAfterFitness or has no values and can't be sorted.");
            }
            //Logger.Logger.AddAndPrint("" + Population[0].Fitness + " ; " + Population[Population.Count - 1].Fitness + " ; " + AverageFitness());
           // Logger.Logger.AddAndPrint("" + Population[Population.Count - 1].Fitness);
        }

        /// <summary>
        /// Serialize and save all the optimized properties into an XML file. 
        /// Very IMPORTANT: Remember to call the ConvertPopulationToUnitAgentOptimizedProperties 
        /// before calling this method, else it will not be the newest optimized properties that
        /// will be saved.
        /// </summary>
        public void SaveOptimizedPropertiesToXMLFile()
        {
            //ConvertPopulationToUnitAgentOptimizedProperties();
            //Population.Sort();
            try
            {
                UnitAgentXMLFileHandler.SerializeToXml(OptimizedPropertiesGenes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Mutate randomly different values from all Chromosomes in a List.
        /// </summary>
        /// <param name="listToMutate"></param>
        /// <returns></returns>
        public List<UnitAgentChromosome> MultiMutate(List<UnitAgentChromosome> listToMutate)
        {
            foreach (UnitAgentChromosome chromosome in listToMutate)
                chromosome.MutateGaussianRandom(0.0f, 0.1f);//(0.0f, 5f); //MutateGaussian(0.0f, 5f);
            return listToMutate;
        }

        /// <summary>
        ///  Takes a list where all chromosomes should be crossed over. 
        ///  The method returns a new list with the crossed over chromosomes.
        ///  The new list is half the size as the input list. 
        /// </summary>
        /// <param name="listToCrossover"></param>
        /// <param name="shuffle"></param>
        /// <returns></returns>
        public List<UnitAgentChromosome> MultiCrossOver(List<UnitAgentChromosome> listToCrossover, Boolean shuffle)
        {
            if (listToCrossover.Count % 2 != 0)
                throw new ArgumentOutOfRangeException("ERROR in MultiCrossOver: The number of chromosome is odd, but should have been even.");

            if (shuffle)
                RandomNumber.ShuffleList(listToCrossover);

            var crossOverList = new List<UnitAgentChromosome>();
            for (int i = 0; i < listToCrossover.Count; i += 2)
                crossOverList.Add(CrossOver(listToCrossover[i], listToCrossover[i + 1]));
            return crossOverList;
        }

        /// <summary>
        /// Creates a one-point crossover between 2 chromosomes. It creates 
        /// a new chromosome combined of the 2 input chromosomes, by splitting the
        /// 2 chromosomes up at a random place and combine the two parts randomly.
        /// </summary>
        /// <param name="chromo1"></param>
        /// <param name="chromo2"></param>
        /// <returns></returns>
        public UnitAgentChromosome CrossOver(UnitAgentChromosome chromo1, UnitAgentChromosome chromo2)
        {
            int geneLength = chromo2.Gene.Count;
            var newCromosome = new UnitAgentChromosome();
            int whereToSplit = RandomNumber.RandomInt(1, geneLength - 1);//Should not split on the last index, because then there would not be any newGenePart2.

          //  Logger.AddAndPrint("whereToSplit: " + whereToSplit);

            int howToCombine = RandomNumber.RandomInt(0, 2);
            //Logger.AddAndPrint("howToCombine: " + howToCombine);
            List<float> newGenePart1;
            List<float> newGenePart2;

            var tmpChromosome = new List<float>();

            if (howToCombine == 0)
            {
                newGenePart1 = DeepCopy(chromo1.Gene.GetRange(0, whereToSplit + 1));
                newGenePart2 = DeepCopy(chromo2.Gene.GetRange(whereToSplit + 1, geneLength - (whereToSplit + 1)));
            }
            else
            {
                newGenePart1 = DeepCopy(chromo2.Gene.GetRange(0, whereToSplit + 1));
                newGenePart2 = DeepCopy(chromo1.Gene.GetRange(whereToSplit + 1, geneLength - (whereToSplit + 1)));
            }

            tmpChromosome.AddRange(newGenePart1);
            tmpChromosome.AddRange(newGenePart2);

            newCromosome.Gene = tmpChromosome;
            if (chromo1.Gene.Count != newCromosome.Gene.Count)
                throw new ArgumentOutOfRangeException("Invalid number of values in one of the chromosomes in the Crossover.");
            return newCromosome;
        }
    }
}