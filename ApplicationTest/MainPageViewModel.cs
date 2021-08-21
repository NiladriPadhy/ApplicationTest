using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ApplicationTest
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand RunCommand { get; set; }
        private List<Color> _colorArray = new List<Color>() { Color.Blue, Color.Gray, Color.Yellow };
        private List<string> _textArray = new List<string>() { "S", "C", "M" };
        private List<string> _validScores = new List<string>() { "MCS", "SCM", "*CS", "M*S", "MC*", "*CM", "S*M", "SC*" };
        private enum TYPE {HORIZONTAL, VERTICAL, DIAGONAL };
        private int _matrixDimention = 3;
        private int _scoreCount = 0, _totalScore = 0;
        private Random _random = new Random();

        public MainPageViewModel()
        {
            RunCommand = new Command(() => Run());
            ValidScoreStr = string.Join(",", _validScores);
            Run();
        }
        #region Properties
        private List<List<Item>> _matrix;
        public List<List<Item>> Matrix
        {
            get { return this._matrix; }
            set { this.SetPropertyValue(ref this._matrix, value); }
        }

        private string _randomRow0Col0Text;
        public string RandomRow0Col0Text
        {
            get { return this._randomRow0Col0Text; }
            set { this.SetPropertyValue(ref this._randomRow0Col0Text, value); }
        }

        private Color _randomRow0Col0TextColor;
        public Color RandomRow0Col0TextColor
        {
            get { return this._randomRow0Col0TextColor; }
            set { this.SetPropertyValue(ref this._randomRow0Col0TextColor, value); }
        }

        private string _randomRow0Col1Text;
        public string RandomRow0Col1Text
        {
            get { return this._randomRow0Col1Text; }
            set { this.SetPropertyValue(ref this._randomRow0Col1Text, value); }
        }

        private Color _randomRow0Col1TextColor;
        public Color RandomRow0Col1TextColor
        {
            get { return this._randomRow0Col1TextColor; }
            set { this.SetPropertyValue(ref this._randomRow0Col1TextColor, value); }
        }

        private string _randomRow0Col2Text;
        public string RandomRow0Col2Text
        {
            get { return this._randomRow0Col2Text; }
            set { this.SetPropertyValue(ref this._randomRow0Col2Text, value); }
        }

        private Color _randomRow0Col2TextColor;
        public Color RandomRow0Col2TextColor
        {
            get { return this._randomRow0Col2TextColor; }
            set { this.SetPropertyValue(ref this._randomRow0Col2TextColor, value); }
        }

        private string _randomRow1Col0Text;
        public string RandomRow1Col0Text
        {
            get { return this._randomRow1Col0Text; }
            set { this.SetPropertyValue(ref this._randomRow1Col0Text, value); }
        }

        private Color _randomRow1Col0TextColor;
        public Color RandomRow1Col0TextColor
        {
            get { return this._randomRow1Col0TextColor; }
            set { this.SetPropertyValue(ref this._randomRow1Col0TextColor, value); }
        }

        private string _randomRow1Col1Text;
        public string RandomRow1Col1Text
        {
            get { return this._randomRow1Col1Text; }
            set { this.SetPropertyValue(ref this._randomRow1Col1Text, value); }
        }

        private Color _randomRow1Col1TextColor;
        public Color RandomRow1Col1TextColor
        {
            get { return this._randomRow1Col1TextColor; }
            set { this.SetPropertyValue(ref this._randomRow1Col1TextColor, value); }
        }

        private string _randomRow1Col2Text;
        public string RandomRow1Col2Text
        {
            get { return this._randomRow1Col2Text; }
            set { this.SetPropertyValue(ref this._randomRow1Col2Text, value); }
        }

        private Color _randomRow1Col2TextColor;
        public Color RandomRow1Col2TextColor
        {
            get { return this._randomRow1Col2TextColor; }
            set { this.SetPropertyValue(ref this._randomRow1Col2TextColor, value); }
        }


        private string _randomRow2Col0Text;
        public string RandomRow2Col0Text
        {
            get { return this._randomRow2Col0Text; }
            set { this.SetPropertyValue(ref this._randomRow2Col0Text, value); }
        }

        private Color _randomRow2Col0TextColor;
        public Color RandomRow2Col0TextColor
        {
            get { return this._randomRow2Col0TextColor; }
            set { this.SetPropertyValue(ref this._randomRow2Col0TextColor, value); }
        }

        private string _randomRow2Col1Text;
        public string RandomRow2Col1Text
        {
            get { return this._randomRow2Col1Text; }
            set { this.SetPropertyValue(ref this._randomRow2Col1Text, value); }
        }

        private Color _randomRow2Col1TextColor;
        public Color RandomRow2Col1TextColor
        {
            get { return this._randomRow2Col1TextColor; }
            set { this.SetPropertyValue(ref this._randomRow2Col1TextColor, value); }
        }

        private string _randomRow2Col2Text;
        public string RandomRow2Col2Text
        {
            get { return this._randomRow2Col2Text; }
            set { this.SetPropertyValue(ref this._randomRow2Col2Text, value); }
        }

        private Color _randomRow2Col2TextColor;
        public Color RandomRow2Col2TextColor
        {
            get { return this._randomRow2Col2TextColor; }
            set { this.SetPropertyValue(ref this._randomRow2Col2TextColor, value); }
        }

        private string _horizontalScore;
        public string HorizontalScore
        {
            get { return this._horizontalScore; }
            set { this.SetPropertyValue(ref this._horizontalScore, value); }
        }

        private string _verticalScore;
        public string VerticalScore
        {
            get { return this._verticalScore; }
            set { this.SetPropertyValue(ref this._verticalScore, value); }
        }
        private string _diagonalScore;
        public string DiagonalScore
        {
            get { return this._diagonalScore; }
            set { this.SetPropertyValue(ref this._diagonalScore, value); }
        }
        private double _matrixScore;
        public double MatrixScore
        {
            get { return this._matrixScore; }
            set { this.SetPropertyValue(ref this._matrixScore, value); }
        }

        private string _validScoreStr;
        public string ValidScoreStr
        {
            get { return this._validScoreStr; }
            set { this.SetPropertyValue(ref this._validScoreStr, value); }
        }

        private string _wildCardIndex;
        public string WildCardIndex
        {
            get { return this._wildCardIndex; }
            set { this.SetPropertyValue(ref this._wildCardIndex, value); }
        }

        #endregion

        #region Methods
        private void Run()
        {
            /*
             * Re Initialze Matrix on Each Run
             */
            var list = new List<List<Item>>();
            for (int i = 0; i < _matrixDimention; i++)
            {
                List<Item> row = new List<Item>();
                for (int j = 0; j < _matrixDimention; j++)
                {
                    Item item = new Item();
                    item.Text = PickRandomText();
                    item.Color = PickRandomColor();
                    row.Add(item);
                }
                list.Add(row);
                Matrix = list;
            }

            /*
             * Set Wild Card Element
             */
            var wildCardIndex = PickRandomWildCardIndex();
            Item wildCardItem = new Item();
            wildCardItem.Text = "*";
            wildCardItem.Color = Color.Red;
            Matrix[wildCardIndex.Item1][wildCardIndex.Item2] = wildCardItem;
            WildCardIndex = wildCardIndex.Item1 + "," + wildCardIndex.Item2;
            Matrix = new List<List<Item>>(Matrix);

            /*
             * Data binding with UI Layer
             */
            BindDataToUI();

            /*
             * Calculate Score
             */

            _scoreCount = 0;
            _totalScore = 0;
            GetScore(TYPE.HORIZONTAL);
            GetScore(TYPE.VERTICAL);
            GetDiagonalScore();
            if (_scoreCount > 0)
            {
                MatrixScore = Math.Pow(_totalScore, _scoreCount - 1);
            }
            else
            {
                MatrixScore = 0;
            }
        }

        /*
         *Data Binding with UI (For Testing Created Static UI with Matrix 3*3 With Grid. For dynamic matrix need to design dynamic ui.
         */
        private void BindDataToUI()
        {
            RandomRow0Col0Text = Matrix[0][0].Text;
            RandomRow0Col0TextColor = Matrix[0][0].Color;

            RandomRow0Col1Text = Matrix[0][1].Text;
            RandomRow0Col1TextColor = Matrix[0][1].Color;

            RandomRow0Col2Text = Matrix[0][2].Text;
            RandomRow0Col2TextColor = Matrix[0][2].Color;

            RandomRow1Col0Text = Matrix[1][0].Text;
            RandomRow1Col0TextColor = Matrix[1][0].Color;

            RandomRow1Col1Text = Matrix[1][1].Text;
            RandomRow1Col1TextColor = Matrix[1][1].Color;

            RandomRow1Col2Text = Matrix[1][2].Text;
            RandomRow1Col2TextColor = Matrix[1][2].Color;

            RandomRow2Col0Text = Matrix[2][0].Text;
            RandomRow2Col0TextColor = Matrix[2][0].Color;

            RandomRow2Col1Text = Matrix[2][1].Text;
            RandomRow2Col1TextColor = Matrix[2][1].Color;

            RandomRow2Col2Text = Matrix[2][2].Text;
            RandomRow2Col2TextColor = Matrix[2][2].Color;
        }

        /*
         * Get Random Index for WildCard Character
         */
        private Tuple<int, int> PickRandomWildCardIndex()
        {
            var randomRowIndex = _random.Next(0, _textArray.Count);
            var randomColumnIndex = _random.Next(0, _textArray.Count);
            return new Tuple<int, int>(randomRowIndex, randomColumnIndex);
        }

        /*
         * Get Random Text For Matrix Item
         */
        private string PickRandomText()
        {
            var randomTextIndex = _random.Next(0, _textArray.Count);
            return _textArray[randomTextIndex];
        }
        /*
        * Get Random Color For Matrix Item
        */
        private Color PickRandomColor()
        {
            var randomColorIndex = _random.Next(0, _colorArray.Count);
            return _colorArray[randomColorIndex];
        }

        

        private void GetScore(TYPE traverseType)
        {
            List<int> scores = new List<int>();
            for (int i = 0; i < _matrixDimention; i++)
            {
                scores.Add(0);
                string textArray = "";
                List<Color> textColorArray = new List<Color>();
                for (int j = 0; j < _matrixDimention; j++)
                {
                    if (traverseType == TYPE.HORIZONTAL)
                    {
                        textArray += Matrix[i][j].Text;
                        textColorArray.Add(Matrix[i][j].Color);
                    }
                    if (traverseType == TYPE.VERTICAL)
                    {
                        textArray += Matrix[j][i].Text;
                        textColorArray.Add(Matrix[j][i].Color);
                    }
                }
                if (_validScores.Contains(textArray) || _validScores.Contains(Reverse(textArray)))
                {
                    scores[i] = 1;
                    if (textColorArray.Distinct().Count() == textColorArray.Count())
                    {
                        scores[i] = 2;
                    }
                    if (AreAllSame<Color>(textColorArray))
                    {
                        scores[i] = 3;
                    }
                    _scoreCount += 1;
                    _totalScore += scores[i];
                }
                if (traverseType == TYPE.HORIZONTAL)
                {
                    HorizontalScore = string.Join<int>("::", scores);
                }
                else if (traverseType == TYPE.VERTICAL)
                {
                    VerticalScore = string.Join<int>("::", scores);
                }
            }
        }

        private void GetDiagonalScore()
        {
            int dig0Score = 0, dig1Score = 0;
            string dig0TextArray = Matrix[0][0].Text + Matrix[1][1].Text + Matrix[2][2].Text;
            List<Color> dig0TextColorArray = new List<Color>() { Matrix[0][0].Color, Matrix[1][1].Color, Matrix[2][2].Color };

            string dig1TextArray = Matrix[0][2].Text + Matrix[1][1].Text + Matrix[2][0].Text;
            List<Color> dig1TextColorArray = new List<Color>() { Matrix[0][2].Color, Matrix[1][1].Color, Matrix[2][0].Color };

            if (_validScores.Contains(dig0TextArray) || _validScores.Contains(Reverse(dig0TextArray)))
            {
                dig0Score = 1;
                if (dig0TextColorArray.Distinct().Count() == dig0TextColorArray.Count())
                {
                    dig0Score = 2;
                }
                if (AreAllSame<Color>(dig0TextColorArray))
                {
                    dig0Score = 3;
                }
                _scoreCount += 1;
                _totalScore += dig0Score;
            }

            if (_validScores.Contains(dig1TextArray) || _validScores.Contains(Reverse(dig1TextArray)))
            {
                dig1Score = 1;
                if (dig1TextColorArray.Distinct().Count() == dig1TextColorArray.Count())
                {
                    dig1Score = 2;
                }
                if (AreAllSame<Color>(dig1TextColorArray))
                {
                    dig1Score = 3;
                }
                _scoreCount += 1;
                _totalScore += dig1Score;
            }

            DiagonalScore = dig0Score + "::" + dig1Score;
        }

        /*
         * String Reverse
         */
        private string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        /*
         * Check all items same in collection
         */
        private bool AreAllSame<T>(IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            using (var enumerator = enumerable.GetEnumerator())
            {
                var toCompare = default(T);
                if (enumerator.MoveNext())
                {
                    toCompare = enumerator.Current;
                }

                while (enumerator.MoveNext())
                {
                    if (toCompare != null && !toCompare.Equals(enumerator.Current))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
