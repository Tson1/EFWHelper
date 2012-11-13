using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFWHelper
{
    
    public class Match
    {
        //Enum 相当
        public static Match Eq = new Match(" = ");
        public static Match Ue=new Match(" <> ");
        public static Match Gt=new Match(" > ");
        public static Match Lt=new Match(" < ");
        public static Match Ge=new Match(" >= ");
        public static Match Le=new Match(" <= ");
        public static Match Like=new Match(" Like '%","%' ");
        public static Match IsNull = new Match(" IS NULL ",true);
        public static Match NotNull=new Match(" IS Not NULL ",true);


        private readonly bool _isSingle;
        private readonly string _judgePre;
        private readonly string _judgeAft;
        public Match(string judge)
        {
            _judgePre = judge;
            _judgeAft = string.Empty;
        }
        public Match(string judge,string aft)
        {
            _judgePre = judge;
            _judgeAft = aft;
        }
        public Match(string judge, bool issingle)
        {
            _judgePre = judge;
            _isSingle = issingle;
        }
        public string GetMatchPerten(string property,object value)
        {
            //TODO:
            return _isSingle
                ?property + _judgePre //値不要条件　Null、NotNull
                :property + _judgePre + value+_judgeAft;//
        }
        //public string GetMatchPerten(string property)
        //{
        //    return _isSingle
        //        ? property + _judgePre //値不要条件　Null、NotNull
        //        : string.Empty;//
        //}
    }
}
