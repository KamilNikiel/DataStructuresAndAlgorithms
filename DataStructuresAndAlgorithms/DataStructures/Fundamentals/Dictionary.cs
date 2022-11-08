namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    internal class Dictionary
    {
        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }
            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private LinkedList<Entry>[] _linkedList = new LinkedList<Entry>[5];

        public void Put(int key, string value)
        {
            var index = Hash(key);
            if (_linkedList[index] == null)
                _linkedList[index] = new LinkedList<Entry>();

            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            _linkedList[Hash(key)].AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);

            return entry == null ? null : entry.Value;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);

            if (entry == null)
                throw new KeyNotFoundException();

            GetBucket(key).Remove(entry);
            var index = Hash(key);
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);

            if (bucket != null)
            {
                foreach (var entry in bucket)
                    if (entry.Key == key)
                        return entry;
            }
            return null;
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            return _linkedList[Hash(key)];
        }

        private int Hash(int key)
        {
            return key % _linkedList.Length;
        }
    }
}
