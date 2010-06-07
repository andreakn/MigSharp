﻿using System.Collections;
using System.Data;

using MigSharp.Core;

using NUnit.Framework;

namespace MigSharp.NUnit
{
    internal static class TestCaseGenerator
    {
        public static IEnumerable GetDatabaseCases()
        {
            IDatabase db = new Database();
            db.CreateTable("Customers")
                .WithPrimaryKeyColumn("ObjectKey", DbType.Int32)
                .WithPrimaryKeyColumn("AnalysisKey", DbType.Int32)
                .WithNullableColumn("Name", DbType.String);
            yield return new TestCaseData(db).SetDescription("CreateTable");

            db = new Database();
            db.Tables["Customers"]
                .AddColumn("NewNonNullableColumn", DbType.Int32)
                .AddColumn("NewNonNullableColumnWithTempDflt7", DbType.Int32).WithTemporaryDefault(7)
                .AddNullableColumn("NewNullableColumn", DbType.Int32);
            yield return new TestCaseData(db).SetDescription("AddColumns");

            db = new Database();
            db.Tables["Customers"].Rename("Customer");
            yield return new TestCaseData(db).SetDescription("RenameTable");

            db = new Database();
            db.Tables["Customers"].Columns["ColumnName"].Rename("LastName");
            yield return new TestCaseData(db).SetDescription("RenameColumn");

            db = new Database();
            db.Tables["Customers"].Columns["ColumnName"].DropDefaultConstraint();
            yield return new TestCaseData(db).SetDescription("DropDefaultConstraint");
        }
    }
}