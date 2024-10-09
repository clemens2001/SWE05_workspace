using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace HashDictionary.Impl;

public class HashDictionary<K, V> : IDictionary<K, V>
{

    #region inner class node

    private class Node
    {
        public required K Key { get; init; }
        public required V Value { get; set; }
        public Node Next { get; set; }

    }

    #endregion

    #region constants and private members

    private const int INITIAL_HASH_TABLE_SIZE = 8;

    private Node[] ht = new Node[INITIAL_HASH_TABLE_SIZE];

    #endregion

    #region helper methods

    private int IndexFor(K key) => Math.Abs(key.GetHashCode()) % ht.Length;

    private Node FindNode(K key)
    {
        Node n = ht[IndexFor(key)];
        for (; n is not null; n = n.Next)
        {
            if(comparer.Equals(n.Key, key)) return n;
        }

        return null;
    }

    private static readonly EqualityComparer<K> comparer = EqualityComparer<K>.Default;

    private bool TryAdd(K key, V value, out Node node)
    {
        node = FindNode(key);
        if (node is not null) return false;     // key already exists

        int idx = IndexFor(key);
        node = ht[idx] = new Node{ Key = key, Value = value, Next = ht[idx] };
        Count++;

        return true;

    }

    #endregion


    public V this[K key] {
        //get
        //{
        //    Node node = FindNode(key);
        //    if (node is null) throw new KeyNotFoundException();
        //    return node.Value;
        //}
        get => (FindNode(key) ?? throw new KeyNotFoundException()).Value;
        set
        {
            if (!TryAdd(key, value, out Node node))
            {
                node.Value = value;
            }
        }
    }

    public ICollection<K> Keys
    {
        get
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < ht.Length; i++) {
                for (Node n = ht[i]; n is not null; n = n.Next) {
                    keys.Add(n.Key);
                }
            }

            return keys;
        }
    }

    public ICollection<V> Values
    {
        get
        {
            List<V> vals = new List<V>();
            for (int i = 0; i < ht.Length; i++) {
                for (Node n = ht[i]; n is not null; n = n.Next) {
                    vals.Add(n.Value);
                }
            }

            return vals;
        }
    }


    public int Count { get; private set; }
    public bool IsReadOnly => false;


    public void Add(K key, V value)
    {
        if (!TryAdd(key, value, out _))
        {
            throw new ArgumentException("Item has already been added.");
        }

    }

    public void Add(KeyValuePair<K, V> item) => this.Add(item.Key, item.Value);

    public bool ContainsKey(K key) => FindNode(key) is not null;
    public bool Contains(KeyValuePair<K, V> item) => this.ContainsKey(item.Key);

    public bool Remove(K key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<K, V> item)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
    {
        Node n = FindNode(key);
        value = n is not null ? n.Value : default;
        return n is not null;
    }

    public void Clear()
    {
        ht = new Node[INITIAL_HASH_TABLE_SIZE];
        Count = 0;
    }


    public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        for(int i = 0; i < ht.Length; i++) {
            for (Node n = ht[i]; n is not null; n = n.Next) {
                yield return new KeyValuePair<K, V>(n.Key, n.Value);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}