﻿using JetBrains.Annotations;

namespace Microsoft.EntityFrameworkCore.Scaffolding.Metadata
{
    public static class SqlCeDatabaseModelExtensions
    {
        public static SqlCeColumnModelAnnotations SqlCe([NotNull] this ColumnModel column)
            => new SqlCeColumnModelAnnotations(column);
    }
}
