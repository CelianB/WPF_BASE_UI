using System;
using System.Collections.Generic;
using System.Data;

namespace WPF_TEMPLATE_UI
{
    public static class Pagging
    {
        public static DataTable PagedTable<T>(IList<T> SourceList)
        {
            Type columnType = typeof(T);
            DataTable TableToReturn = new DataTable();
            try
            {
                foreach (var Column in columnType.GetProperties())
                {
                    TableToReturn.Columns.Add(Column.Name, Nullable.GetUnderlyingType(Column.PropertyType) ?? Column.PropertyType);
                }

                foreach (object item in SourceList)
                {
                    DataRow ReturnTableRow = TableToReturn.NewRow();
                    foreach (var Column in columnType.GetProperties())
                    {
                        if (Column.GetValue(item) != null)
                            ReturnTableRow[Column.Name] = Column.GetValue(item);
                    }
                    TableToReturn.Rows.Add(ReturnTableRow);
                }
                return TableToReturn;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
