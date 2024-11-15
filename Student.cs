using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class Student
    {
        private string _name;
        private int _score;

        public Student(string name , int score)
        {
            this._name = name;
            this._score = score;
        }
        public string Name
        {
           set {this. _name = value; }
            get { return _name; }
        }
        public int Score
        {
            set
            {
                if(_score > 100 || _score < 0)
                {
                    this._score = 0;
                }
                else
                {
                    this.Score = value;
                }
            }
            get
            {
                return _score;
            }
        }
    }
}
