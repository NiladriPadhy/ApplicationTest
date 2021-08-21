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

        private List<string> _validScores = new List<string>() { "MCS", "SCM" };

        private int _wildCardCharRowIndex = 0, _wildCardCharColumnIndex = 0;

        private int _scoreCount=0, _totalScore=0;
        private Random _random = new Random();

        public MainPageViewModel()
        {
            RunCommand = new Command(() => Run());
            ValidScoreStr = string.Join(",", _validScores);
            Run();
        }

        private void Run()
        {
            RandomRow0Col0Text = PickRandomText();
            RandomRow0Col0TextColor = PickRandomColor();

            RandomRow0Col1Text = PickRandomText();
            RandomRow0Col1TextColor = PickRandomColor();

            RandomRow0Col2Text = PickRandomText();
            RandomRow0Col2TextColor = PickRandomColor();

            RandomRow1Col0Text = PickRandomText();
            RandomRow1Col0TextColor = PickRandomColor();

            RandomRow1Col1Text = PickRandomText();
            RandomRow1Col1TextColor = PickRandomColor();

            RandomRow1Col2Text = PickRandomText();
            RandomRow1Col2TextColor = PickRandomColor();

            RandomRow2Col0Text = PickRandomText();
            RandomRow2Col0TextColor = PickRandomColor();

            RandomRow2Col1Text = PickRandomText();
            RandomRow2Col1TextColor = PickRandomColor();

            RandomRow2Col2Text = PickRandomText();
            RandomRow2Col2TextColor = PickRandomColor();

            _scoreCount = 0;
            _totalScore = 0;
            GetHorizontalScore();
            GetVerticalScore();
            GetDiagonalScore();
            if (_scoreCount > 0)
            {
                MatrixScore = Math.Pow(_totalScore, _scoreCount - 1);
            }
            else
            {
                MatrixScore = 0;
            }
            var wildCardIndex = PickRandomWildCardIndex();
            WildCardIndex = wildCardIndex.Item1+"," + wildCardIndex.Item2;

        }

        private Tuple<int,int> PickRandomWildCardIndex()
        {
            var randomRowIndex = _random.Next(0, _textArray.Count);
            var randomColumnIndex = _random.Next(0, _textArray.Count);
            return new Tuple<int,int>(randomRowIndex,randomColumnIndex);
        }
        private string PickRandomText()
        {
            var randomTextIndex = _random.Next(0, _textArray.Count);
            return _textArray[randomTextIndex];
        }

        private Color PickRandomColor()
        {
            var randomColorIndex = _random.Next(0, _colorArray.Count);
            return _colorArray[randomColorIndex];
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

        

        private void GetHorizontalScore()
        {
            int row0Score = 0,row1Score = 0,row2Score = 0;
            string row0TextArray = RandomRow0Col0Text + RandomRow0Col1Text + RandomRow0Col2Text;
            List<Color> row0TextColorArray = new List<Color>() { RandomRow0Col0TextColor, RandomRow0Col1TextColor, RandomRow0Col2TextColor };

            string row1TextArray = RandomRow1Col0Text + RandomRow1Col1Text + RandomRow1Col2Text ;
            List<Color> row1TextColorArray = new List<Color>() { RandomRow1Col0TextColor, RandomRow1Col1TextColor, RandomRow1Col2TextColor };

            string row2TextArray =  RandomRow2Col0Text+ RandomRow2Col1Text+ RandomRow2Col2Text;
            List<Color> row2TextColorArray = new List<Color>() { RandomRow2Col0TextColor, RandomRow2Col1TextColor, RandomRow2Col2TextColor };

            if (_validScores.Contains(row0TextArray) || _validScores.Contains(Reverse(row0TextArray))){
                row0Score = 1;
                if (row0TextColorArray.Distinct().Count() == row0TextColorArray.Count())
                {
                    row0Score = 2;
                }
                if (AreAllSame<Color>(row0TextColorArray))
                {
                    row0Score = 3;
                }
                _scoreCount += 1;
                _totalScore += row0Score;
            }

            if (_validScores.Contains(row1TextArray) || _validScores.Contains(Reverse(row1TextArray)))
            {
                row1Score = 1;
                if (row1TextColorArray.Distinct().Count() == row1TextColorArray.Count())
                {
                    row1Score = 2;
                }
                if (AreAllSame<Color>(row1TextColorArray))
                {
                    row1Score = 3;
                }
                _scoreCount += 1;
                _totalScore += row1Score;
            }

            if (_validScores.Contains(row2TextArray) || _validScores.Contains(Reverse(row2TextArray)))
            {
                row2Score = 1;
                if (row2TextColorArray.Distinct().Count() == row2TextColorArray.Count())
                {
                    row2Score = 2;
                }
                if (AreAllSame<Color>(row2TextColorArray))
                {
                    row2Score = 3;
                }
                _scoreCount += 1;
                _totalScore += row2Score;
            }

            HorizontalScore = row0Score + "::" + row1Score + "::" + row2Score;
        }

        private void GetVerticalScore()
        {
            int col0Score = 0, col1Score = 0, col2Score = 0;
            string col0TextArray = RandomRow0Col0Text + RandomRow1Col0Text + RandomRow2Col0Text;
            List<Color> col0TextColorArray = new List<Color>() { RandomRow0Col0TextColor, RandomRow1Col0TextColor, RandomRow2Col0TextColor };

            string col1TextArray = RandomRow0Col1Text + RandomRow1Col1Text + RandomRow2Col1Text;
            List<Color> col1TextColorArray = new List<Color>() { RandomRow0Col1TextColor, RandomRow1Col1TextColor, RandomRow2Col1TextColor };

            string col2TextArray = RandomRow0Col2Text + RandomRow1Col2Text + RandomRow2Col2Text;
            List<Color> col2TextColorArray = new List<Color>() { RandomRow0Col2TextColor, RandomRow1Col2TextColor, RandomRow2Col2TextColor };

            if (_validScores.Contains(col0TextArray) || _validScores.Contains(Reverse(col0TextArray)))
            {
                col0Score = 1;
                if (col0TextArray.Distinct().Count() == col0TextArray.Count())
                {
                    col0Score = 2;
                }
                if (AreAllSame<Color>(col0TextColorArray))
                {
                    col0Score = 3;
                }
                _scoreCount += 1;
                _totalScore += col0Score;
            }

            if (_validScores.Contains(col1TextArray) || _validScores.Contains(Reverse(col1TextArray)))
            {
                col1Score = 1;
                if (col1TextColorArray.Distinct().Count() == col1TextColorArray.Count())
                {
                    col1Score = 2;
                }
                if (AreAllSame<Color>(col1TextColorArray))
                {
                    col1Score = 3;
                }
                _scoreCount += 1;
                _totalScore += col1Score;
            }

            if (_validScores.Contains(col2TextArray) || _validScores.Contains(Reverse(col2TextArray)))
            {
                col2Score = 1;
                if (col2TextColorArray.Distinct().Count() == col2TextColorArray.Count())
                {
                    col2Score = 2;
                }
                if (AreAllSame<Color>(col2TextColorArray))
                {
                    col2Score = 3;
                }
                _scoreCount += 1;
                _totalScore += col2Score;
            }

            VerticalScore = col0Score + "::" + col1Score + "::" + col2Score;
        }

        private void GetDiagonalScore()
        {
            int dig0Score = 0, dig1Score = 0;
            string dig0TextArray = RandomRow0Col0Text + RandomRow1Col1Text + RandomRow2Col2Text;
            List<Color> dig0TextColorArray = new List<Color>() { RandomRow0Col0TextColor, RandomRow1Col1TextColor, RandomRow2Col2TextColor };

            string dig1TextArray = RandomRow0Col2Text + RandomRow1Col1Text + RandomRow2Col0Text;
            List<Color> dig1TextColorArray = new List<Color>() { RandomRow0Col1TextColor, RandomRow1Col1TextColor, RandomRow2Col1TextColor };

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


        private string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
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
    }
}
