namespace TSPClassLib
{
    /// <summary>
    /// Class to save Coordinates
    /// </summary>
    public class Coordinates
    {
        #region Constructors and Destructors

        public Coordinates(int x, int y)
        {
            this.XValue = x;
            this.YValue = y;
        }

        #endregion

        #region Public Properties

        public int XValue { get; set; }

        public int YValue { get; set; }

        #endregion
    }
}