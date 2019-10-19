using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniDraw
{
    [Serializable]
    class LinesStorage : IEnumerator, IEnumerable<Line>
    {
        private LinkedList<Line> lines;
        private int currentCounter;

        public LinesStorage()
        {
            lines = new LinkedList<Line>();
            currentCounter = 0;
        }

        public int Length
        {
            get { return lines.Count; }
        }

        public Line GetLine(int index)
        {
            return lines.ElementAt(index);
        }

        public void AppendLine(Line line)
        {
            lines.AddLast(line);
        }

        public void RemoveLastLine()
        {
            if (lines.Count > 0) lines.RemoveLast();
        }
        
        public void Clear()
        {
            lines.Clear();
        }

        public bool MoveNext()
        {
            currentCounter++;
            return (currentCounter < lines.Count);
        }

        public void Reset()
        {
            currentCounter = 0;
        }


        IEnumerator<Line> IEnumerable<Line>.GetEnumerator()
        {
            return ((IEnumerable<Line>)lines).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<Line>)lines).GetEnumerator();
        }

        public object Current
        {
            get { return lines.ElementAt(currentCounter); }
        }
    }
}
