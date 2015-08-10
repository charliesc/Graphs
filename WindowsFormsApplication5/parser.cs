using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    class Parser
    {
        private String input;

        public Parser(String input)
        {
            this.input = input;
        }

        private bool delim(char c)
        {
            return c == ' ';
        }

        private bool is_op(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^'
                || (c >= 10 && c <= 14);
        }

        private int priority(char op)
        {
            return
                op == '+' || op == '-' ? 1 :
                op == '*' || op == '/' || op == '%' ? 2 :
                op == '^' || (op >= 10 && op <= 14) ? 3 :
                -1;
        }

        private void process(Stack<double> st, char op)
        {
            if (op > 65000)
            {
                double l = st.Pop();
                switch ((char)(op - 65000))
                {
                    case '+': st.Push(l); break;
                    case '-': st.Push(-l); break;
                    case (char)(10): st.Push(Math.Sin(l)); break;
                    case (char)(11): st.Push(Math.Cos(l)); break;
                    case (char)(12): if (l <= 0) st.Push(99999); else st.Push(Math.Log10(l)); break;
                    case (char)(13): st.Push(Math.Tan(l)); break;
                    case (char)(14): st.Push(1.0 / Math.Tan(l)); break;
                }
            }
            else
            {
                double r = st.Pop();
                double l = st.Pop();
                switch (op)
                {
                    case '+': st.Push(l + r); break;
                    case '-': st.Push(l - r); break;
                    case '*': st.Push(l * r); break;
                    case '/': if (r == 0) st.Push(99999); else st.Push(l / r); break;
                    case '%': if (r == 0) st.Push(99999); else st.Push(l % r); break;
                    case '^': st.Push(Math.Pow(l, r)); break;
                }
            }
        }

        private bool isDigit(char c)
        {
            return (c >= '0' && c <= '9') || c == ',' || c == '.';
        }

        public double Calculate(double x)
        {
            bool mayBeUnary = true;
            String text = input.Replace("x", "(" + x.ToString() + ")");
            //text = text.Replace("sin", ((char)10).ToString());
            //text = text.Replace("cos", ((char)11).ToString());
            //text = text.Replace("lg", ((char)12).ToString());
            //text = text.Replace("tg", ((char)13).ToString());
            //text = text.Replace("ctg", ((char)14).ToString());
            text = Regex.Replace(text, @"sin\((.+)\)", "(" + ((char)10).ToString() + "($1))");
            text = Regex.Replace(text, @"cos\((.+)\)", "(" + ((char)11).ToString() + "($1))");
            text = Regex.Replace(text, @"log\((.+)\)", "(" + ((char)12).ToString() + "($1))");
            text = Regex.Replace(text, @"ctg\((.+)\)", "(" + ((char)14).ToString() + "($1))");
            text = Regex.Replace(text, @"tg\((.+)\)", "(" + ((char)13).ToString() + "($1))");
            Stack<double> st = new Stack<double>();
            Stack<Char> op = new Stack<char>();
            for (int i = 0; i < text.Length; ++i)
                if (!delim(text[i]))
                    if (text[i] == '(') {
                        op.Push('(');
                        mayBeUnary = true;
                    }
                    else if (text[i] == ')')
                    {
                        while (op.Peek() != '(')
                            process(st, op.Pop());
                        op.Pop();
                        mayBeUnary = false;
                    }
                    else if (is_op(text[i]))
                    {
                        char curop = text[i];
                        if (mayBeUnary && isunary(curop)) curop = (char)(65000+curop);
                        while (op.Count != 0 && priority(op.Peek()) >= priority(text[i]))
                            process(st, op.Pop());
                        op.Push(curop);
                        mayBeUnary = true;
                    }
                    else
                    {
                        String operand = String.Empty;
                        while (i < text.Length && isDigit(text[i]))
                            operand += text[i++];
                        --i;
                        if (isDigit(operand[0]))
                            st.Push(Double.Parse(operand));
                        else
                            MessageBox.Show("Lol " + operand);
                        mayBeUnary = false;
                    }
            while (op.Count != 0)
                process(st, op.Pop());
            if (st.Count == 0) return double.MaxValue;
            return st.Peek();
        }

        private bool isunary(char curop)
        {
            return curop == '+' || curop == '-' || (curop >= 10 && curop <= 14);
        }
    }
}
