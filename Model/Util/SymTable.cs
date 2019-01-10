using System.Text;

namespace Lab9.Model.Util
{
    public class SymTable<K, V>: MyDict<K, V>{
        public override string ToString(){
            StringBuilder stringBuilder = new StringBuilder();
            foreach (K key in Keys){
                stringBuilder
                    .Append(key)
                    .Append("=")
                    .Append(this[key])
                    .AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}