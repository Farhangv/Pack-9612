using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    class ExamEnumerator : IEnumerator<Question>
    {
        private int currentIndex = -1;
        protected List<Question> Questions { get; set; }
        public ExamEnumerator(List<Question> _questions)
        {
            this.Questions = _questions;
        }


        public object Current => this.Questions[currentIndex];

        Question IEnumerator<Question>.Current => this.Questions[currentIndex];

        public bool MoveNext()
        {
            return ++currentIndex < this.Questions.Count;
            //this.currentIndex++;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public void Dispose()
        {
            ;
        }
    }
}
