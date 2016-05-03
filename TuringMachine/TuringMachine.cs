using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TuringMachine
    {
        public TuringMachine(Func<int, char, Transition> transitionFunction) : this(0, new int[] { int.MaxValue, int.MinValue }, ' ', transitionFunction)
        {
        }
        public TuringMachine(int startState, IEnumerable<int> endStates, char blankSpaceSymbol, Func<int, char, Transition> transitionFunction)
        {
            StartState = startState;
            EndStates = endStates;
            BlankSpaceSymbol = blankSpaceSymbol;
            TransitionFunction = transitionFunction;
        }

        public int StartState { get; set; }
        public IEnumerable<int> EndStates { get; set; }
        public char BlankSpaceSymbol { get; set; }

        public Func<int, char, Transition> TransitionFunction { get; set; }

        public Tuple<int, string> ProcessWord(string word)
        {
            int State = StartState;
            int HeadPosition = 0;
            char[] Tape = word.ToCharArray();

            while (!EndStates.Contains(State))
            {
                char currentSymbol = GetSymbol(Tape, HeadPosition);
                Transition t = TransitionFunction(State, currentSymbol);

                Debug.WriteLine($"({State}, {currentSymbol}) -> ({t.NextState}, {t.Write ?? currentSymbol}, {t.MovementDirection}); {new String(Tape).Insert(HeadPosition, $"(q{State})")}");

                State = t.NextState;
                if (t.Write.HasValue)
                    Tape[HeadPosition] = t.Write.Value;
                if (t.MovementDirection == Direction.Left)
                    HeadPosition--;
                else HeadPosition++;
            }
            return new Tuple<int, string>(State, new string(Tape));
        }

        private char GetSymbol(char[] word, int head)
        {
            if (head >= 0 && head < word.Length)
                return word[head];
            else return BlankSpaceSymbol;
        }
    }
}
