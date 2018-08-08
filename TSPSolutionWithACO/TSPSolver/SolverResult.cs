namespace TSPSolutionServices
{
    using System;
    using System.Collections.Generic;

    using TSPClassLib;

    /// <summary>
    /// Class to contain TSP solver result
    /// </summary>
    public class SolverResult
    {
        #region Fields

        public Queue<CityResult> CityQueue;

        private DateTime processEndime;

        private DateTime processStartTime;

        #endregion

        #region Constructors and Destructors

        public SolverResult()
        {
            this.CityQueue = new Queue<CityResult>();
            this.TotalDistance = 0;
        }

        #endregion

        #region Public Properties

        public DateTime ProcessEndime
        {
            get
            {
                return this.processEndime;
            }
            set
            {
                this.processEndime = value;
                this.TimeToSolve = this.processEndime.Subtract(this.processStartTime);
            }
        }

        public DateTime ProcessStartTime
        {
            get
            {
                return this.processStartTime;
            }
            set
            {
                this.processStartTime = value;
            }
        }

        public TimeSpan TimeToSolve { get; set; }

        public double TotalDistance { get; set; }

        #endregion
    }
}