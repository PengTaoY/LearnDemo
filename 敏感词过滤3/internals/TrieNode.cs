﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 敏感词过滤3.internals
{
    public class TrieNode
    {
        //public byte Type { get; set; }
        public bool End { get; set; }
        public List<string> Results { get; private set; }
        internal Dictionary<char, TrieNode> m_values;
        private uint minflag = uint.MaxValue;
        private uint maxflag = uint.MinValue;


        public TrieNode()
        {
            m_values = new Dictionary<char, TrieNode>();
            Results = new List<string>();
        }

        public bool TryGetValue(char c, out TrieNode node)
        {
            if (minflag <= (uint)c && maxflag >= (uint)c)
            {
                return m_values.TryGetValue(c, out node);
            }
            node = null;
            return false;
        }
        public ICollection<TrieNode> Transitions()
        {
            return m_values.Values;
        }

        public TrieNode Add(char c)
        {
            TrieNode node;

            if (m_values.TryGetValue(c, out node))
            {
                return node;
            }

            if (minflag > c) { minflag = c; }
            if (maxflag < c) { maxflag = c; }

            node = new TrieNode();
            m_values[c] = node;
            //m_values.Add(c, node);
            return node;
        }

        public void SetResults(string text)
        {
            if (End == false)
            {
                End = true;
            }
            Results.Add(text);
        }

        public void Merge(TrieNode node)
        {
            if (node.End)
            {
                if (End == false)
                {
                    End = true;
                }
                foreach (var item in node.Results)
                {
                    Results.Add(item);
                }
            }

            foreach (var item in node.m_values)
            {
                //if (minflag > (uint)item.Key) {
                //    minflag = (uint)item.Key;
                //    m_values[item.Key] = item.Value;
                //} else if (maxflag < (uint)item.Key) {
                //    maxflag = (uint)item.Key;
                //    m_values[item.Key] = item.Value;
                //} else if (m_values.ContainsKey(item.Key) == false)  {
                //    m_values[item.Key] = item.Value;
                //}

                if (m_values.ContainsKey(item.Key) == false)
                {
                    if (minflag > item.Key) { minflag = item.Key; }
                    if (maxflag < item.Key) { maxflag = item.Key; }
                    m_values[item.Key] = item.Value;
                    //m_values.Add(item.Key, item.Value);
                }
            }
        }

        public TrieNode[] ToArray()
        {
            TrieNode[] first = new TrieNode[char.MaxValue + 1];
            foreach (var item in m_values)
            {
                first[item.Key] = item.Value;
            }
            return first;
        }
    }
}
