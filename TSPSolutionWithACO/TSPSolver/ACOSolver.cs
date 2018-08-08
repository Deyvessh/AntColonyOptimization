namespace TSPSolutionServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TSPClassLib;

    /// <summary>
    /// TSP solver using ACO implemetation with basic algorithm
    /// inherited from TSP solver class
    /// </summary>
    public class AcoSolver : TSPSolver
    {
        #region Fields

        /// <summary>
        /// Constants to define parameters used to run ACO implementation
        /// </summary>

        private readonly Dictionary<int, List<CityResult>> antVisitedCities;

        private readonly double betaCoffiecient;

        private readonly double evaporationConstant;

        private readonly int noOfAnts;

        private readonly int noOfIteration;

        private readonly Object phermoneLock;

        private readonly Random randomizer;

        private readonly double stagnationCoffiecient;

        private int currentIteration;

        private int useSequenceAntDistribution;
        
        private volatile Dictionary<string, double> pheromoneAmountPerArc;

        private int processedMilestones;

        #endregion

        #region Constructors and Destructors

        public AcoSolver(CityGraph cities, int noOfAnts, int noOfIteration)
            : base(cities)
        {
            this.noOfAnts = noOfAnts;
            this.noOfIteration = noOfIteration;

            this.betaCoffiecient = 1;  
            this.evaporationConstant = 0.5;
            this.stagnationCoffiecient = 100;

            this.processedMilestones = 0;
            useSequenceAntDistribution = 0;

            this.antVisitedCities = new Dictionary<int, List<CityResult>>();
            this.pheromoneAmountPerArc = new Dictionary<string, double>();
            this.phermoneLock = new object();
            this.randomizer = new Random();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Overloaded method for Solveing the Travelling salesman problem
        /// </summary>
        /// <param name="externalAct"></param>
        /// <returns></returns>
        public override SolverResult SolveTSP(Action<double> externalAct)
        {
            this.externalProgressFunc = externalAct;
            return this.SolveTSP();
        }

        /// <summary>
        /// Overloaded method to solve the travelling saslesman problem
        /// </summary>
        /// <returns></returns>
        public override SolverResult SolveTSP()
        {
            this.solverResult.ProcessStartTime = DateTime.Now;

            for (int i = 0; i < this.noOfIteration; i++)
            {
                this.currentIteration = i;

                this.FlushLastIterationResults(i);

                for (int j = 0; j < this.noOfAnts; j++)
                {
                    this.RunIterationForAnt(j);

                    FlushLastAntRunChanges(j);

                    this.processedMilestones++;

                    if (this.externalProgressFunc != null)
                    {
                        this.externalProgressFunc(this.processedMilestones / ((double)this.noOfAnts * this.noOfIteration));
                    }
                }

                this.RunStagnationAndEvaporationProcess(i);
            }

            this.solverResult.ProcessEndime = DateTime.Now;

            return this.GetACORunResult();
        }

        /// <summary>
        /// Method to flush changes made in last run Iteration of Ants 
        /// </summary>
        /// <param name="j"></param>
        private void FlushLastAntRunChanges(int j)
        {
            this.CityGraph.Cities.ForEach(c => c.IsVisited = false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Function to add delta pheromone into pheromone on all of the arcs
        /// </summary>
        /// <param name="currentIteration"></param>
        /// <param name="city_id_1"></param>
        /// <param name="city_id_2"></param>
        /// <param name="addedPheromone"></param>
        private void AddDeltaPheromone(int currentIteration, string city_id_1, string city_id_2, double addedPheromone)
        {
            lock (this.phermoneLock)
            {
                if (currentIteration != this.currentIteration)
                {
                    return;
                }

                double pheromoneValue = this.GetPheromoneValue(city_id_1, city_id_2);
                string key = string.Format("{0}_{1}", city_id_1, city_id_2);

                this.pheromoneAmountPerArc[key] = pheromoneValue + addedPheromone;
            }
        }

        /// <summary>
        /// function to calculate probability for an ant to move from city_i to city_j
        /// </summary>
        /// <param name="city_i"></param>
        /// <param name="city_j"></param>
        /// <returns></returns>
        private double CalculateProbability(City city_i, City city_j)
        {
            double Tij = this.GetPheromoneValue(city_i.Id, city_j.Id);

            //in the first iteration returning distance.
            if ((int)Tij == 0)
            {
                return 1 / this.GetDistanceBetweenCity(city_i, city_j);
            }

            double denominator = this.GetDenominatorForProbability(city_i);

            return Tij
                   / ((Math.Pow(this.GetDistanceBetweenCity(city_i, city_j), this.betaCoffiecient))
                      * this.GetDenominatorForProbability(city_i));
        }

        /// <summary>
        /// Flush last iteration results 
        /// </summary>
        /// <param name="i"></param>
        private void FlushLastIterationResults(int i)
        {
            this.antVisitedCities.Clear();
        }

        /// <summary>
        /// function to get the ACO result generated after all iteration of all Ants
        /// </summary>
        /// <returns></returns>
        private SolverResult GetACORunResult()
        {
            City source = null, desCity = null;

            int totalCityCount = 0;

            City startCity = null;
            City endCity = null;

            if (this.CityGraph.Cities.Any())
            {
                totalCityCount = this.CityGraph.Cities.Count();

                City currentCity = this.CityGraph.Cities.FirstOrDefault();

                for (int i = 0; i < this.CityGraph.Cities.Count(); i++) //foreach (var currentCity in this.CityGraph.Cities)
                {
                    double maxPheronome = -1.0;
                    IEnumerable<City> citiesToVisit = this.CityGraph.Cities.Where(c => c.Id != currentCity.Id);
                    if (startCity == null)
                    {
                        startCity = currentCity;
                    }

                    foreach (City city in citiesToVisit)
                    {
                        //if city been visited
                        if (city.IsVisited)
                        {
                            continue;
                        }

                        double pheromoneValue = this.GetPheromoneValue(currentCity.Id, city.Id);

                        if (maxPheronome < pheromoneValue || maxPheronome.CompareTo(-1) == 0)
                        {
                            maxPheronome = pheromoneValue;
                            source = currentCity;
                            desCity = city;
                        }
                    }

                    currentCity.IsVisited = true;

                    this.AddPathToResult(source, desCity);
                    endCity = currentCity;
                    currentCity = desCity;
                }

                this.AddPathToResult(endCity, startCity);
            }

            return this.solverResult;
        }

        /// <summary>
        /// Internal function  to calculate the denominator whle calculating probability for ant to move from city_i to city_j
        /// </summary>
        /// <param name="currentCity"></param>
        /// <returns></returns>
        private double GetDenominatorForProbability(City currentCity)
        {
            IEnumerable<City> citiesToVisit = this.CityGraph.Cities.Where(c => c.Id != currentCity.Id);

            return
                citiesToVisit.Sum(
                    city =>
                    this.GetPheromoneValue(currentCity.Id, city.Id)
                    / Math.Pow(this.GetDistanceBetweenCity(currentCity, city), this.betaCoffiecient));
        }

        /// <summary>
        /// Gets pheromone value between two cities
        /// </summary>
        /// <param name="city_id_1"></param>
        /// <param name="city_id_2"></param>
        /// <returns></returns>
        private double GetPheromoneValue(string city_id_1, string city_id_2)
        {
            string key = string.Format("{0}_{1}", city_id_1, city_id_2);

            if (this.pheromoneAmountPerArc.ContainsKey(key))
            {
                return this.pheromoneAmountPerArc[key];
            }

            return this.pheromoneAmountPerArc[key] = 0;
        }

        /// <summary>
        /// function to allocate a randon number for Ant allocation
        /// </summary>
        /// <returns></returns>
        private int GetRandomNumberForCity()
        {
            int aa = (int)(Math.Abs((this.randomizer.NextDouble() + 1) * this.randomizer.Next()) % this.CityGraph.Cities.Count);

            return aa;
        }

        /// <summary>
        /// function to calculate pheromone value on stagnation
        /// </summary>
        /// <param name="city1"></param>
        /// <param name="city2"></param>
        /// <returns></returns>
        private double GetStagnationPheromoneValue(City city1, City city2)
        {
            double pheromoneValue = 0;

            foreach (var antCities in this.antVisitedCities)
            {
                double summedDistance = antCities.Value.Sum(c => c.CityDistance);
                Double deltaPheromonoe = 0;

                if (
                    antCities.Value.Any(
                        c =>
                        (c.StartCity.Id == city1.Id && c.EndCity.Id == city2.Id)
                        || (c.StartCity.Id == city2.Id && c.EndCity.Id == city1.Id)))
                {
                    deltaPheromonoe = (this.stagnationCoffiecient ) / summedDistance;
                }

                pheromoneValue += deltaPheromonoe;
            }

            return pheromoneValue;
        }

        /// <summary>
        /// function to run iteration for Ant
        /// </summary>
        /// <param name="antId"></param>
        private void RunIterationForAnt(int antId)
        {
            Console.Write("running iteration");

            City source = null, desCity = null;

            City startCity = null;
            City endCity = null;

            int totalCityCount = this.CityGraph.Cities.Count;

            if (totalCityCount > 0)
            {
                City currentCity = this.CityGraph.Cities[0];
                //City currentCity = this.useSequenceAntDistribution == 1 ? this.CityGraph.Cities[this.GetRandomNumberForCity() % totalCityCount] : this.CityGraph.Cities[antId % totalCityCount];

                for (int i = 0; i < totalCityCount; i++)
                {
                    double maxprobability = -1;
                    IEnumerable<City> citiesToVisit = this.CityGraph.Cities.Where(c => c.Id != currentCity.Id);

                    if (startCity == null) startCity = currentCity;

                    foreach (City city in citiesToVisit)
                    {
                        if (city.IsVisited)
                        {
                            continue;
                        }

                        double probability = this.CalculateProbability(currentCity, city);

                        if (maxprobability < probability || maxprobability.CompareTo(-1) == 0)
                        {
                            maxprobability = probability;
                            source = currentCity;
                            desCity = city;
                        }
                    }
                    currentCity.IsVisited = true;

                    if (currentCity != desCity)
                    {
                        if (this.antVisitedCities.ContainsKey(antId))
                        {
                            this.antVisitedCities[antId].Add(new CityResult(currentCity, desCity));
                        }
                        else
                        {
                            this.antVisitedCities.Add(
                                antId,
                                new List<CityResult> { new CityResult(currentCity, desCity) });
                        }
                    }

                    endCity = currentCity;
                    currentCity = desCity;
                }
            }
        }

        /// <summary>
        /// function to calculate pheromone after each iteration. Stagnation and evoration 
        /// </summary>
        /// <param name="iterationCount"></param>
        private void RunStagnationAndEvaporationProcess(int iterationCount)
        {
            int count = this.CityGraph.Cities.Count;
            City[] cities = this.CityGraph.Cities.ToArray();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    double pheronomeValue = (1 - this.evaporationConstant)
                                            * this.GetPheromoneValue(cities[i].Id, cities[j].Id)
                                            + this.GetStagnationPheromoneValue(cities[i], cities[j]);

                    this.AddDeltaPheromone(iterationCount, cities[i].Id, cities[j].Id, pheronomeValue);
                }
            }
        }

        #endregion
    }
}