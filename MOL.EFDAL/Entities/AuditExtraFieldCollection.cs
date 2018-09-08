using System;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL
{
    /// <summary>
    /// When add item to this collection. A prefix "ExtraField_" will be added to the fieldName.  See IAuditable comments.
    /// </summary>
    public class AuditExtraFieldCollection
    {
        private Dictionary<String, String> hashTableExtraFields = new Dictionary<string, string>(16);

        public void Add(string fieldName, string value)
        {
            hashTableExtraFields.Add("ExtraField_" + fieldName, value);
        }

        public string this[string fieldName]
        {
            get { return hashTableExtraFields["ExtraField_" + fieldName]; }
        }

        public List<KeyValuePair<string, string>> ToList()
        {
            return hashTableExtraFields.ToList();
        }

        public int Count
        {
            get { return hashTableExtraFields.Count; }
        }
    }
}
