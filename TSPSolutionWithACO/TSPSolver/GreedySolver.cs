namespace TSPSolutionServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TSPClassLib;

    /// <summary>
    /// Class to TSP greedy solver
    /// </summary>
    public class GreedySolver : TSPSolver
    {
        #region Constructors and Destructors

        public GreedySolver(CityGraph cities)
            : base(cities)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// function to Solve travelling salesman problem
        /// </summary>
        /// <param name="externalAct"></param>
        /// <returns></returns>
        public override SolverResult SolveTSP(Action<double> externalAct)
        {
            this.externalProgressFunc = externalAct;
            return this.SolveTSP();
        }

        /// <summary>
        /// overloaded function to Solve travelling salesman problem
        /// </summary>
        /// <returns></returns>
        public override SolverResult SolveTSP()
        {
            City source = null, desCity = null;

            int totalCityCount = 0;
            int processedCityCount = 0;

            City startCity = null;
            City endCity = null;

            this.solverResult.ProcessStartTime = DateTime.Now;

            if (this.CityGraph.Cities.Any())
            {
                totalCityCount = this.CityGraph.Cities.Count();

                City currentCity = this.CityGraph.Cities.FirstOrDefault();

                for (int i = 0; i < this.CityGraph.Cities.Count(); i++) //foreach (var currentCity in this.CityGraph.Cities)
                {
                    double minDistance = -1.0;
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

                        double distance = this.GetDistanceBetweenCity(currentCity, city);

                        if (minDistance > distance || minDistance.CompareTo(-1) == 0)
                        {
                            minDistance = distance;
                            source = currentCity;
                            desCity = city;
                        }
                    }

                    currentCity.IsVisited = true;

                    this.AddPathToResult(source, desCity);
                    endCity = currentCity;
                    currentCity = desCity;

                    processedCityCount++;

                    if (this.externalProgressFunc != null)
                    {
                        this.externalProgressFunc(processedCityCount / (double)totalCityCount);
                    }
                }

                this.AddPathToResult(endCity, startCity);
            }

            this.solverResult.ProcessEndime = DateTime.Now;

            return this.solverResult;
        }

        #endregion
    }
}