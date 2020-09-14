using System;
using System.Collections.Generic;

using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.EntityCodeGenerator
{
    /// <summary>
    /// 实体类代码生成器基类，包含创建实体类代码的构建过程
    /// </summary>
    public abstract class BaseEntityCodeGenerator : IEntityCodeGenerator
    {
        /// <summary>
        /// 代码生成的选项
        /// </summary>
        /// <value></value>
        protected CodeGenerationOptions Options { get; set; }

        public BaseEntityCodeGenerator(CodeGenerationOptions options)
        {
            Options = options;
        }

        /// <inheritdoc />
        public virtual string Generate(TableInfo tableInfo, List<ColumnInfo> columns)
        {
            return string.Empty;
        }

        /// <summary>
        /// 用于生成代码中引用其他包的语句
        /// </summary>
        /// <returns></returns>
        protected abstract string GenerateImportStatement();

        /// <summary>
        /// 用于生成本实体类代码所处的代码包/命名空间的语句块
        /// </summary>
        /// <returns></returns>
        protected abstract string GenerateNamespaceRegion();

        /// <summary>
        /// 用于生成具体实体类的语句块
        /// </summary>
        /// <param name="tableInfo">表信息</param>
        /// <returns></returns>
        protected abstract string GenerateClassContentRegion(TableInfo tableInfo);

        /// <summary>
        /// 用于为具体的列生成对应的实体类属性代码
        /// </summary>
        /// <param name="columnInfo">列信息</param>
        /// <returns></returns>
        protected abstract string GeneratePropertyForColumn(ColumnInfo columnInfo);

        /// <summary>
        /// 字符串添加缩进
        /// </summary>
        /// <param name="content">要添加缩进的字符串</param>
        /// <param name="indentCount">要添加缩进的个数（非长度）</param>
        /// <returns></returns>
        protected string IndentString(string content, int indentCount)
        {
            if (indentCount == 0)
            {
                return content;
            }
            else
            {
                var indentedContent = string.Concat(Options.IndentingString, content);
                return IndentString(indentedContent, --indentCount);
            }
        }
    }
}