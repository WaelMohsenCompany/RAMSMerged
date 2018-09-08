using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public enum EnumLookupAutoSearch
    {
        GetAll = 1

    }
    public class CustomExecute
    {
        #region

        /// <summary>
        /// ExcutelookUpSearchString
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TableName"></param>
        /// <param name="KeyColumn"></param>
        /// <param name="ValueColumn"></param>
        /// <param name="SearchText"></param>
        /// <param name="AdditionalWhere"></param>
        /// <returns></returns>
        public List<T> ExcutelookUpSearchString<T>(string TableName, string KeyColumn, string ValueColumn, string SearchText,string AdditionalWhere) where T : class
        {
            List<T> listT = null;
            string execSql=string.Empty;
            using (var context = new MOLEFEntities())
            {
                if (EnumLookupAutoSearch.GetAll.ToString().ToLower() == SearchText.ToLower())
                {
                    //Select * without where
                    execSql = string.Format("SELECT {0} [Key], convert(varchar,{1}) [Value]   FROM  {2}", KeyColumn, ValueColumn, TableName.ToString());
                    if (!string.IsNullOrEmpty(AdditionalWhere))
                    {
                        execSql = execSql + " where " + AdditionalWhere;
                    }
                }
                else
                {
                    execSql = string.Format("SELECT  {0} [Key], convert(varchar,{1})  [Value]   FROM {2}  where  {3}  like '%{4}%' ", KeyColumn, ValueColumn, TableName.ToString(), KeyColumn, SearchText);
                    if (!string.IsNullOrEmpty(AdditionalWhere))
                    {
                        execSql = execSql + " and " + AdditionalWhere;
                    }
                }



                listT = context.Database.SqlQuery<T>(execSql).ToList<T>();
            }

            return listT;
        }
        #endregion
    }
}
