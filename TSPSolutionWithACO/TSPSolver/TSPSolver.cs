namespace TSPSolutionServices
{
    using System;
    using System.Collections.Generic;

    using TSPClassLib;

    /// <summary>
    /// Abstract Class to define implement travelling salesman problem
    /// </summary>
    public abstract class TSPSolver
    {
        #region Fields

        protected Action<double> externalProgressFunc;

        protected SolverResult solverResult;

        private readonly Dictionary<string, double> cityDistances;

        private readonly Dictionary<string, bool> cityVisited;

        private CityGraph cityGraph;

        #endregion

        #region Constructors and Destructors

        public TSPSolver(CityGraph graph)
        {
            this.cityGraph = graph;
            this.cityDistances = new Dictionary<string, double>();
            this.cityVisited = new Dictionary<string, bool>();
            this.solverResult = new SolverResult();
        }

        #endregion

        #region Public Properties

        public CityGraph CityGraph
        {
            get
            {
                return this.cityGraph;
            }
            set
            {
                this.cityGraph = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// function to Get distance between two cities
        /// </summary>
        /// <param name="city_1_Id"></param>
        /// <param name="city_2_Id"></param>
        /// <returns></returns>
        public virtual double GetDistanceBetweenCity(string city_1_Id, string city_2_Id)
        {
            if (this.cityDistances.ContainsKey(city_1_Id + "_" + city_2_Id))
            {
                return this.cityDistances[city_1_Id + "_" + city_2_Id];
            }

            if (this.cityDistances.ContainsKey(city_2_Id + "_" + city_1_Id))
            {
                return this.cityDistances[city_2_Id + "_" + city_1_Id];
            }
            return this.cityDistances[city_1_Id + "_" + city_2_Id] = this.cityGraph.GetDistance(city_1_Id, city_2_Id);
        }

        /// <summary>
        /// overloaded function to Get distance between two cities
        /// </summary>
        /// <param name="city1"></param>
        /// <param name="city2"></param>
        /// <returns></returns>
        public virtual double GetDistanceBetweenCity(City city1, City city2)
        {
            if (city1 == null || city2 == null)
            {
                return -2;
            }

            if (this.cityDistances.ContainsKey(city1.Id + "_" + city2.Id))
            {
                return this.cityDistances[city1.Id + "_" + city2.Id];
            }

            if (this.cityDistances.ContainsKey(city2.Id + "_" + city1.Id))
            {
                return this.cityDistances[city2.Id + "_" + city1.Id];
            }
            return this.cityDistances[city1.Id + "_" + city2.Id] = this.cityGraph.GetDistance(city1, city2);
        }

        /// <summary>
        /// function to solve TSP
        /// </summary>
        /// <returns></returns>
        public abstract SolverResult SolveTSP();

        /// <summary>
        /// overloaded function to solve TSP
        /// </summary>
        /// <param name="externalAct"></param>
        /// <returns></returns>
        public abstract SolverResult SolveTSP(Action<double> externalAct);

        #endregion

        #region Methods

        /// <summary>
        /// function to add city to result
        /// </summary>
        /// <param name="source"></param>
        /// <param name="desCity"></param>
        protected void AddPathToResult(City source, City desCity)
        {
            var result = new CityResult(source, desCity);
            this.solverResult.CityQueue.Enqueue(result);
            this.solverResult.TotalDistance += this.GetDistanceBetweenCity(source, desCity);
        }

        /// <summary>
        /// function to flush city visited after any run in implementation
        /// </summary>
        private void FlushCityVisited()
        {
            this.cityVisited.Clear();
        }

        #endregion
    }
}