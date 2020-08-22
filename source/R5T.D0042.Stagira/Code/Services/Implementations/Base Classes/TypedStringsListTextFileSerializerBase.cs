using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar.IO;
using R5T.Stagira;


namespace R5T.D0042.Stagira
{
    public abstract class TypedStringsListTextFileSerializerBase<TList, TTypedString> : ITextFileSerializer<TList>
        where TList : TypedStringsList<TTypedString>, new()
        where TTypedString : TypedString
    {
        protected abstract Func<string, TTypedString> TypedStringConstructor { get; }


        public Task<TList> Deserialize(string textFilePath)
        {
            var values = File.ReadAllLines(textFilePath).Select(this.TypedStringConstructor);

            var list = new TList();

            list.Values.AddRange(values);

            return Task.FromResult(list);
        }

        public Task Serialize(string textFilePath, TList list, bool overwrite = true)
        {
            FileHelper.HandleOverwrite(textFilePath, overwrite);

            var lines = list.Values.Select(x => x.Value);

            File.WriteAllLines(textFilePath, lines);

            return Task.CompletedTask;
        }
    }
}
