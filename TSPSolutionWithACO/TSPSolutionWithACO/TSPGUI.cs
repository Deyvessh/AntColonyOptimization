namespace TSPSolutionWithACO
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    using TSPClassLib;

    using TSPSolutionServices;

    /// <summary>
    ///     CLass to generate TSP form
    /// </summary>
    public partial class TSPGUI : Form
    {
        #region Fields

        private readonly int NoOfAnts;

        private readonly int NoOfIteration;

        private readonly Bitmap bmp;

        private readonly Color canvasBackColor;

        private readonly int filenameDisplayMaxLength;

        private readonly Graphics g;

        private readonly Color lineColor;

        private readonly Color pointColor;

        private readonly Size pointSize;

        private readonly int pointwidth;

        private CityGraph cityGraph;

        private int dimension;

        private string filename;

        private TSPSolver solver;

        private SolverResult solverResult;

        #endregion

        #region Constructors and Destructors

        public TSPGUI()
        {
            this.InitializeComponent();

            this.filename = string.Empty;
            this.NoOfAnts = 20;
            this.NoOfIteration = 3;

            this.filenameDisplayMaxLength = 80;

            this.pointwidth = 4;
            this.pointSize = new Size(this.pointwidth, this.pointwidth);
            this.pointColor = Color.SaddleBrown;
            this.lineColor = Color.Purple;
            this.canvasBackColor = Color.White;
            this.Canvas.BackColor = this.canvasBackColor;
            this.bmp = new Bitmap(this.Canvas.Width, this.Canvas.Height);
            this.g = Graphics.FromImage(this.bmp);
            this.Canvas.Image = this.bmp;

            this.labelfileName.Text = string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     function to draw City on Canvas
        /// </summary>
        private void DrawCityOnCanvas()
        {
            this.FlushCanvas();

            foreach (City city in this.cityGraph.Cities)
            {
                this.DrawPointOnCanvas(
                    new Point(city.CityCoordinates.XValue, city.CityCoordinates.YValue),
                    this.pointColor);
            }

            this.Canvas.Refresh();
        }

        /// <summary>
        ///     Draws a line on canvas to connect different cities
        /// </summary>
        /// <param name="coor1"></param>
        /// <param name="coor2"></param>
        /// <param name="color"></param>
        private void DrawLineOnCanvas(Coordinates coor1, Coordinates coor2, Color color)
        {
            var brush = new SolidBrush(color);
            //var rect = new ;
            //g.DrawRectangle(brush,);
            this.g.DrawLine(
                new Pen(brush),
                new Point(coor1.XValue, coor1.YValue),
                new Point(coor2.XValue, coor2.YValue));
            //g.DrawLine(new Pen(brush), new Point(12, 13), new Point(100, 100));

            this.Canvas.Image = this.bmp;
        }

        /// <summary>
        ///     Draws a point on canvas
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        private void DrawPointOnCanvas(Point point, Color color)
        {
            if (point.X > this.Canvas.Width || point.Y > this.Canvas.Height)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                        "point can not go beyond following co-ordinates (0,0) - ({0},{1})",
                        this.Canvas.Width,
                        this.Canvas.Height));
            }

            var brush = new SolidBrush(color);
            var rect = new Rectangle(point, this.pointSize);
            this.g.FillRectangle(brush, rect);
        }

        /// <summary>
        ///     Clear the canvas before drawing again
        /// </summary>
        private void FlushCanvas()
        {
            this.g.Clear(this.canvasBackColor);
        }

        /// <summary>
        ///     Get Shorten name of Filename
        /// </summary>
        /// <returns></returns>
        private string GetShortenFilename()
        {
            return this.filename.Length < this.filenameDisplayMaxLength
                       ? this.filename
                       : string.Format(
                           "{0}...{1}",
                           this.filename.Substring(0, this.filenameDisplayMaxLength / 2),
                           this.filename.Substring(
                               this.filename.Length - this.filenameDisplayMaxLength / 2,
                               this.filenameDisplayMaxLength / 2));
        }

        /// <summary>
        ///     Load cities from file
        /// </summary>
        private void LoadCityGraph()
        {
            if (this.filename != string.Empty)
            {
                this.cityGraph = new CityGraph(this.filename, this.Canvas.Width, this.Canvas.Height);

                if (this.cityGraph.Cities != null)
                {
                    this.dimension = this.cityGraph.Cities.Count;
                    this.labelDimension.Text = Convert.ToString(this.dimension);
                    this.labelTourLen.Text = string.Empty;
                    this.labelTime.Text = string.Empty;
                }

                this.DrawCityOnCanvas();

                this.labelfileName.Text = string.Format("Data Loaded from : {0}", this.GetShortenFilename());
            }
        }

        /// <summary>
        ///     function handler for on click of load data tool strip menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openDataFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.filename = this.openDataFileDialog.FileName;

                this.LoadCityGraph();
            }
        }

        /// <summary>
        ///     function to save canvas bitmap to image
        /// </summary>
        /// <param name="location"></param>
        private void SaveBitmap(string location)
        {
            var bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

            using (var saveStream = new FileStream(location + ".png", FileMode.OpenOrCreate))
            {
                bmp.Save(saveStream, ImageFormat.Png);
            }
        }

        /// <summary>
        ///     internal function to setting solver
        /// </summary>
        /// <param name="tspsolver"></param>
        private void SetSolver(TSPSolver tspsolver)
        {
            this.solver = tspsolver;

            this.solverResult = this.solver.SolveTSP(this.ShowProgressOnProgressBar);

            if (this.solverResult != null && this.solverResult.CityQueue != null
                && this.solverResult.CityQueue.Count > 0)
            {
                this.labelTourLen.Text = this.solverResult.TotalDistance.ToString("0.##");
                this.labelTime.Text = this.solverResult.TimeToSolve.TotalMilliseconds.ToString("0.##") + @" ms";

                this.FlushCanvas();

                this.DrawCityOnCanvas();

                foreach (CityResult cityResult in this.solverResult.CityQueue)
                {
                    Coordinates coor1 = cityResult.StartCity.CityCoordinates;
                    Coordinates coor2 = cityResult.EndCity.CityCoordinates;

                    this.DrawLineOnCanvas(coor1, coor2, this.lineColor);
                }
            }
        }

        /// <summary>
        ///     function to show progess bar on UI
        /// </summary>
        /// <param name="progressfactor"></param>
        private void ShowProgressOnProgressBar(double progressfactor)
        {
            this.progressBarAlgo.Value = (int)(progressfactor * 100) % 101;
            //System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        ///     function to load GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSPGUI_Load(object sender, EventArgs e)
        {
            this.filename = @"D:\Projects\pproj\c#\ACO Algo\Test Data\data.txt";

            // this.LoadCityGraph();

            //this.FlushCanvas();
        }

        /// <summary>
        ///     function handler for tool strip menu ACO implementation click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aCOImplementationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.cityGraph == null)
            {
                MessageBox.Show(@"Please load the data first.");
                return;
            }

            this.lblAlgoNameLabel.Text = string.Format("{0} Algorithm Progress", "ACO");

            this.SetSolver(new AcoSolver(this.cityGraph.Clone(), this.NoOfAnts, this.NoOfIteration));
        }

        /// <summary>
        ///     function handler for tool strip menu About Us click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutus = new AboutUs();
            aboutus.Show();
        }

        /// <summary>
        ///     function handler for tool strip menu Solve TSP click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (this.cityGraph == null)
            {
                MessageBox.Show(@"Please load the data first.");
                return;
            }

            this.lblAlgoNameLabel.Text = string.Format("{0} Algorithm Progress", "Greedy");

            this.SetSolver(new GreedySolver(this.cityGraph.Clone()));
        }

        /// <summary>
        ///     function handler for tool strip menu exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///     function handler for tool strip menu Save as Image click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveImageFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.SaveBitmap(this.saveImageFileDialog.FileName);
                MessageBox.Show(string.Format("Image Saved at {0}", this.saveImageFileDialog.FileName));
            }
        }

        #endregion
    }
}