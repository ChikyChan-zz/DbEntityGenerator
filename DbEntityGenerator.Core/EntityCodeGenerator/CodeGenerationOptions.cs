namespace DbEntityGenerator.Core.EntityCodeGenerator
{
    public class CodeGenerationOptions
    {
        private static CodeGenerationOptions _default;

        /// <summary>
        /// 获取默认的生成选项
        /// </summary>
        /// <value></value>
        public static CodeGenerationOptions Default
        {
            get
            {
                if (_default == default(CodeGenerationOptions))
                {
                    _default = new CodeGenerationOptions();
                }
                return _default;
            }
        }

        /// <summary>
        /// 类名是否使用表名的复数形式
        /// </summary>
        /// <value></value>
        public bool UsePulralForTableName { get; set; }

        /// <summary>
        /// 实体代码的软件包名称
        /// </summary>
        /// <value></value>
        public string CodePackageName { get; set; }

        /// <summary>
        /// 缩进长度
        /// </summary>
        /// <value></value>
        public int IndentLength
        {
            get
            {
                return IndentingString.Length;
            }
            set
            {
                IndentingString = "".PadLeft(IndentLength, ' ');
            }
        }

        /// <summary>
        /// 缩进字符串
        /// </summary>
        /// <value></value>
        public string IndentingString { private set; get; }

        private CodeGenerationOptions()
        {
            UsePulralForTableName = false;
            CodePackageName = "DbEntityCodeGenerator.Generated";
            IndentLength = 4;
        }
    }
}