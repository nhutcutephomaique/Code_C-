using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpBasic;

public class HuffmanCodingDemo
{
    private class Node
    {
        public char? Character { get; set; }
        public int Frequency { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    public void Run()
    {
        var text = "huffman coding example";
        var frequencies = new Dictionary<char, int>();

        foreach (var ch in text)
        {
            if (frequencies.ContainsKey(ch))
            {
                frequencies[ch]++;
            }
            else
            {
                frequencies[ch] = 1;
            }
        }

        var queue = new PriorityQueue<Node, int>();

        foreach (var pair in frequencies)
        {
            queue.Enqueue(new Node { Character = pair.Key, Frequency = pair.Value }, pair.Value);
        }

        while (queue.Count > 1)
        {
            var left = queue.Dequeue();
            var right = queue.Dequeue();
            var parent = new Node
            {
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            queue.Enqueue(parent, parent.Frequency);
        }

        var root = queue.Dequeue();
        var codes = new Dictionary<char, string>();
        BuildCodes(root, string.Empty, codes);

        Console.WriteLine("Text: " + text);
        Console.WriteLine("Huffman codes:");

        foreach (var code in codes.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{code.Key}: {code.Value}");
        }

        var encoded = Encode(text, codes);
        Console.WriteLine("Encoded: " + encoded);

        var decoded = Decode(encoded, root);
        Console.WriteLine("Decoded: " + decoded);
    }

    private static void BuildCodes(Node node, string code, Dictionary<char, string> codes)
    {
        if (node.Character.HasValue)
        {
            codes[node.Character.Value] = code;
            return;
        }

        BuildCodes(node.Left!, code + "0", codes);
        BuildCodes(node.Right!, code + "1", codes);
    }

    private static string Encode(string text, Dictionary<char, string> codes)
    {
        var encoded = string.Empty;

        foreach (var ch in text)
        {
            encoded += codes[ch];
        }

        return encoded;
    }

    private static string Decode(string encoded, Node root)
    {
        var decoded = string.Empty;
        var current = root;

        foreach (var bit in encoded)
        {
            current = bit == '0' ? current.Left! : current.Right!;

            if (current.Character.HasValue)
            {
                decoded += current.Character.Value;
                current = root;
            }
        }

        return decoded;
    }
}
