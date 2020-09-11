using System;

namespace CSharpDbEntityGenerator.Core.Model
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }

        public Type DataType { get; set; }

        public bool Nullable { get; set; }

        public string Description { get; set; }
    }
}