using System;
using System.Collections.Generic;

namespace DataBaseWork
{
    public class DataRows
    {
        public List<DataField> fields = new List<DataField>();
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRows"/> class.
        /// </summary>
        public DataRows()
        {
            fields = new List<DataField>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRows"/> class.
        /// </summary>
        /// <param name="fields">fields of row</param>
        public DataRows(IEnumerable<DataField> fields)
        {
            this.fields = new List<DataField>(fields);
        }
        /// <summary>
        /// Adds the field.
        /// </summary>
        /// <param name="field">The field.</param>
        public void AddField(DataField field)
        {
            if (field != null)
                fields.Add(field);
        }
        /// <summary>
        /// Return Field by its name.
        ///     throws: ArgumentException if no such field
        /// </summary>
        /// <param name="Name">fields name.</param>
        /// <returns></returns>
        public string FieldByName(string Name)
        {
            foreach (DataField field in fields)
            {
                if (field.Field.ToUpper() == Name.ToUpper())
                    return field.Value;
            }
            throw new ArgumentException("No such field:" + Name);
        }
        /// <summary>
        /// Deletes the field.
        /// </summary>
        /// <param name="Name">The name.</param>
        public void DeleteField(string Name)
        {
            foreach (DataField field in fields)
            {
                if (field.Field.ToUpper() == Name.ToUpper())
                {
                    fields.Remove(field);
                    return;
                }
            }
            throw new ArgumentException("No such field:" + Name);           
        }

        public string FieldByNameDef(string FieldName, string DefValue)
        {
            string rets = FieldByNameDefEmpty(FieldName, DefValue);
            if (rets == "")
                rets = DefValue;
            return rets;
        }

        public string FieldByNameDefEmpty(string FieldName, string DefValue)
        {
            try
            {
                return FieldByName(FieldName);
            }
            catch (ArgumentException)
            {
                return DefValue;
            }

        }
    }
}