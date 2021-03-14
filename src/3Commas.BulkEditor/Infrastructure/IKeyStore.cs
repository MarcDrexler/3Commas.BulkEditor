using _3Commas.BulkEditor.Misc;

namespace _3Commas.BulkEditor.Infrastructure
{
    public interface IKeyStore
    {
        XCommasAccounts Read();
        void Save(XCommasAccounts accounts);
        void Clear();
    }
}