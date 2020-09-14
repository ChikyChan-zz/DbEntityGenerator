using System;
using System.Collections.Generic;
using System.Text;

using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.EntityCodeGenerator.CSharp
{
    /// <summary>
    /// CSharp语言实体类代码生成器，包含创建实体类具体代码的逻辑
    /// </summary>
    public class CSharpEntityCodeGenerator : BaseEntityCodeGenerator
    {
        /// <summary>
        /// 定义CSharp类型的别名
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        protected readonly Dictionary<Type, string> TypeAliasDict = new Dictionary<Type, string>()
        {
            [typeof(bool)] = "bool",
            [typeof(decimal)] = "decimal",
            [typeof(ushort)] = "ushort",
            [typeof(short)] = "short",
            [typeof(uint)] = "unit",
            [typeof(int)] = "int",
            [typeof(ulong)] = "ulong",
            [typeof(long)] = "long",
            [typeof(byte)] = "byte",
            [typeof(sbyte)] = "sbyte",
            [typeof(double)] = "double",
            [typeof(float)] = "float",
            [typeof(char)] = "char",
            [typeof(string)] = "string"
        };

        public CSharpEntityCodeGenerator(CodeGenerationOptions options) : base(options) { }

        /// <inheritdoc />
        protected override string GenerateImportStatement()
        {
            var importStatementBuilder = new StringBuilder();

            importStatementBuilder.AppendLine("using System;");
            importStatementBuilder.AppendLine("using System.Collections.Generic");
            importStatementBuilder.AppendLine("using System.ComponentModel;");

            return importStatementBuilder.ToString();
        }

        /// <inheritdoc />
        protected override string GenerateNamespaceRegion()
        {
            var namespaceRegionBuilder = new StringBuilder();

            namespaceRegionBuilder.AppendLine($"namespace {Options.CodePackageName}");
            namespaceRegionBuilder.AppendLine("{");
            namespaceRegionBuilder.AppendLine("{0}"); // 此处不须要做Indent，由ClassContent在生成的时候自己进行Indent
            namespaceRegionBuilder.AppendLine("}");

            return namespaceRegionBuilder.ToString();
        }

        /// <inheritdoc />
        protected override string GenerateClassContentRegion(TableInfo tableInfo)
        {
            var classContentRegionBuilder = new StringBuilder();

            var indentCount = 1;

            classContentRegionBuilder.AppendLine(IndentString(@"/// <summary>", indentCount));
            classContentRegionBuilder.AppendLine(IndentString(@"/// " + tableInfo.Description, indentCount));
            classContentRegionBuilder.AppendLine(IndentString(@"/// </summary>", indentCount));
            classContentRegionBuilder.AppendLine(IndentString("public class " + tableInfo.TableName, indentCount));
            classContentRegionBuilder.AppendLine(IndentString("{", indentCount));
            classContentRegionBuilder.AppendLine("{0}"); // 此处不须要做Indent，由Property在生成的时候自己进行Indent
            classContentRegionBuilder.AppendLine(IndentString("}", indentCount));

            return classContentRegionBuilder.ToString();
        }

        /// <inheritdoc />
        protected override string GeneratePropertyForColumn(ColumnInfo columnInfo)
        {
            var propertyBuilder = new StringBuilder();

            var indentCount = 2;

            propertyBuilder.AppendLine(IndentString(string.Join(" ", new List<string> { "public", GetTypeName(columnInfo.DataType), columnInfo.ColumnName, "{ get; set; }" }), indentCount));

            return propertyBuilder.ToString();
        }

        /// <summary>
        /// 获取类型的名称
        /// </summary>
        /// <param name="dataType">列的数据类型</param>
        /// <returns></returns>
        private string GetTypeName(Type dataType)
        {
            if (TypeAliasDict.TryGetValue(dataType, out var aliasTypeName))
            {
                // 类型别名字典中存在，直接使用别名
                return aliasTypeName;
            }
            else
            {
                return dataType.Name;
            }
        }
    }
}