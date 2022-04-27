using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.D0044;


namespace R5T.D0042.Default
{
    public abstract class StringSerializerBasedTypedListTextFileSerializerBase<TList, TValue> : ITextFileSerializer<TList>
        where TList: TypedList<TValue>, new()
    {
        private IStringSerializer<TValue> StringSerializer { get; }


        public StringSerializerBasedTypedListTextFileSerializerBase(
            IStringSerializer<TValue> stringSerializer)
        {
            this.StringSerializer = stringSerializer;
        }

        public async Task<TList> Deserialize(string textFilePath)
        {
            var lines = File.ReadAllLines(textFilePath);

            var list = new TList();
            foreach (var line in lines)
            {
                var value = await this.StringSerializer.Deserialize(line);

                list.Values.Add(value);
            }

            return list;
        }

        public async Task Serialize(string textFilePath, TList list, bool overwrite = true)
        {
            FileHelper.HandleOverwrite(textFilePath, overwrite);

            var lines = new List<string>(list.Values.Count);
            foreach (var value in list.Values)
            {
                var line = await this.StringSerializer.Serialize(value);

                lines.Add(line);
            }

            File.WriteAllLines(textFilePath, lines);
        }
    }
}
