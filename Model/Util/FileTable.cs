using System;
using System.IO;
using System.Text;

namespace Lab9.Model.Util
{
    public class FileTable: MyDict<int, Tuple<string, TextReader>>
    {
        private int key;

        public FileTable()
        {
            key = 0;
        }

        public int Add(Tuple<string, TextReader> value)
        {
            key++;
            base.Add(key, value);
            return key;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int k in Keys){
                stringBuilder
                    .Append(k)
                    .Append("=")
                    .Append(this[k].Item1)
                    .AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}