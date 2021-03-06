using MigSharp.Core.Commands;

namespace MigSharp.Core.Entities
{
    internal class TableCollection : AdHocCollection<IExistingTable>, IExistingTableCollection
    {
        private readonly MigrateCommand _migrateCommand;

        internal TableCollection(MigrateCommand migrateCommand)
        {
            _migrateCommand = migrateCommand;
        }

        protected override IExistingTable CreateItem(string name)
        {
            AlterTableCommand alterTableCommand = new AlterTableCommand(_migrateCommand, name);
            _migrateCommand.Add(alterTableCommand);
            return new ExistingTable(alterTableCommand);
        }
    }
}