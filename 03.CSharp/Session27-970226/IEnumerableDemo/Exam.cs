using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    class Exam:IEnumerable<Question>
    {
        public List<Question> Questions { get; set; }

        public IEnumerator GetEnumerator()
        {
            //return this.Questions.GetEnumerator();
            return new ExamEnumerator(this.Questions);
        }

        IEnumerator<Question> IEnumerable<Question>.GetEnumerator()
        {
            return new ExamEnumerator(this.Questions);
        }
    }
}
