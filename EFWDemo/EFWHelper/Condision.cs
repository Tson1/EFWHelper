using System.Collections.Generic;

namespace EFWHelper
{
    public class Condisions
    {
        const string Adn = " AND ";
        const string Or = " OR ";
        public string ClassChar = "c";
        readonly IList<Condision> _ls=new List<Condision>(); 
        public void Clear()
        {
            _ls.Clear();
        }
        //public Condisions Add(object pro, object v,Match m)
        //{
        //    object o = pro;
        //    return null;
        //}
        public Condisions Add(string pro, object v, Match m)
        {
            _ls.Add(new Condision(pro, v, m){ClassChar = ClassChar});
            return this;
        }
        public string GetAndEsql()
        {
            return GetEsql(Adn);
        }
        public string GetOrEsql()
        {
            return GetEsql(Or);
        }
        private string GetEsql(string andOr)
        {
            var result = string.Empty;
            foreach (var condision in _ls)
            {
                if (!string.IsNullOrEmpty(result))
                    result += andOr;
                result += condision.GetJudge();
            }

            return result;
        }
    }

    public class Condision
    {
        public string ClassChar { get; set; } 
        private readonly string _proName;
        private readonly object _value;
        private readonly Match _match;
        public Condision(string pro,object v,Match m)
        {
            _proName = pro;
            _value = v;
            _match = m;
        }
        public string GetJudge()
        {
            return _match.GetMatchPerten(ClassChar+"."+_proName, _value);
        }
    }
}
