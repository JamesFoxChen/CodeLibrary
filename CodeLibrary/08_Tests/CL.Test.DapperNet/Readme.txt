
Dapper.Contrib.SqlMapperExtensions
1、扩展方法中的Insert<T>只适合主键是自增长类型，因为最终生成的SQL语句会排除主键字段
2、Insert返回自增长Key值
3、Insert使用变量绑定