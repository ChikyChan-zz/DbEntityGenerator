using System;

using DbEntityGenerator.Core.Model;
using DbEntityGenerator.Core.EntityCodeGenerator.CSharp;

namespace DbEntityGenerator.Core.EntityCodeGenerator
{
    public class EntityCodeGeneratorFactory
    {
        /// <summary>
        /// 获取实体类生成器
        /// </summary>
        /// <param name="codeLanguage">代码的语言</param>
        /// <returns></returns>
        public static IEntityCodeGenerator GetDbTableCodeGenerator(CodeLanguage codeLanguage, CodeGenerationOptions options = null)
        {
            switch (codeLanguage)
            {
                case CodeLanguage.CSharp:
                    return new CSharpEntityCodeGenerator(options ?? CodeGenerationOptions.Default);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}