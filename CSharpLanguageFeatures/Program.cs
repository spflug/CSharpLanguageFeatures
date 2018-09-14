namespace CSharpLanguageFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    #region

    using static System.Math;
    using static System.FormattableString;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
            var demo = new Demo6();
            Console.WriteLine((Text: "kldafladf", Alter: 42));
            Console.ReadKey();
        }
    }

    class Dummy
    {
        public string Text { get; set; }
    }

    internal class Demo6
    {
        // 0
        #region nameof

        void Foo0()
        {
            Console.WriteLine(nameof(Dummy.Text));
            Console.WriteLine(nameof(Dummy.Text));
        }

        #endregion

        // 1
        #region readonly property

        /// <inheritdoc />
        public Demo6()
        {
            this.New = 42;
        }

        void Fooakldsfklakdlf()
        {
            this.Old = 287;
        }

        public int Old { get; private set; }
        public int New { get; }

        #region initialized

        public int NewInitialized { get; } = 42;
        public IEnumerable<int> Ints { get; } = Enumerable.Range(0, 42);

        #endregion

        #region so nicht

        //public IEnumerable<int> IntsError { get; } = Enumerable.Range(0, this.NewInitialized);

        #endregion
        #endregion

        // 2
        #region expression bodies

        #region methods

        /// <inheritdoc />
        public override string ToString() => "uninteressante Klasse :(";

        #endregion

        #region properties

        public int Constant => 42;

        // C# 7.0
        public int GetSet
        {
            get => this.Constant;
            set => Console.WriteLine("sorry {0} ist konstant.", value);
        }

        #endregion

        #region functional voodoo

        public Func<string, int> Answer => text => 42;
 
        #endregion

        #endregion

        // 3
        #region using static

        public double SinPi => Sin(PI);

        #endregion

        // 4
        #region ?.??

        public string Foo4(Dummy maybeNull) => maybeNull?.Text?.Length.ToString() ?? "Dummy oder Dummy.Text war null";

        #endregion

        // 5
        #region strings, strings, strings

        public void Foo5()
        {
            string.Format(CultureInfo.InvariantCulture, "{0}", this.Old);
            var s = $"{this.Old}";
        }

        #region cultures

        public void Foo51()
        {
            var i = 42M;
            var s = $"bla{i}foo";
            FormattableString f = $"Die Antwort auf alles ist {i:C2}";
            Console.WriteLine(f.ToString(CultureInfo.CreateSpecificCulture("de-DE")));
            Console.WriteLine(f.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(f.ToString(CultureInfo.CreateSpecificCulture("en-JM")));
            Console.WriteLine(Invariant(f));
            Console.ReadKey();
        }

        #endregion

        #region 2 & 5 => :)

        public class Local
        {
            public int X => 42;

            /// <inheritdoc />
            public override string ToString() => $"Die Antwort auf alles ist {this.X}!";
        }

        #endregion

        #endregion

        // 6
        #region Exception filter

        public void Foo6()
        {
            try
            {
                throw new Exception("adBfasdfaoom");
            }
            catch (Exception e) when (e.Message.StartsWith("Boom"))
            {
            }
        }

        #endregion

        // 7
        #region await in try/catch

        

        #endregion

        // 8
        #region index initializer

        public void Foo8()
        {
            var oldDic = new Dictionary<int, string>
            {
                { 0, ":(" },
                { 42, ":)" }
            };

            var newDic = new Dictionary<int, string>
            {
                [0 ] = ":(",
                [42] = ":)"
            };
        }

        #endregion
    }

    class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Demo7
    {
        // default (7.1)
        // ValueTuple
        // inferred tuple names (7.1)
        // equality != / == on tuples (7.3)
        // Pattern matching
        // deconstruction
        // Discardscw   cw  
        // throw expression
        // binary literal
        // literal separator
        // local functions
        void Fo(object t)
        {
            int i = 0b0_1__01__0_0101;
            var (x,y,z,_,_) = (1, 1, 2, 2, 3);
            switch (t)
            {
                case string text when text.Length > 0:
                    Console.WriteLine(text);
                    break;
                case null:
                    break;
                default:
                    break;
            }
        }

        IEnumerable<int> F()
        {
            while (true)
            {
                yield return 42;
            }
        }

        string Fooooooo(int anzahl)
        {
            var o = new object();
            var x42 = F().Take(21983);

            return FooLocal(anzahl);

            IEnumerable<int> F()
            {
                while (true)
                {
                    yield return 42;
                }
            }

            string FooLocal(int i)
            {
                Console.WriteLine(o);
                return new string('F', i);
            }
        }
    }
}