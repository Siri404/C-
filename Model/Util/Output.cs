using System.Text;

namespace Lab9.Model.Util
{
    public class Output<T>: MyList<T>
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in this)
            {
                stringBuilder
                    .Append(item)
                    .AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}