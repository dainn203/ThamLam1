namespace Huffman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace HuffmanCoding
    {
        class Node
        {
            public char Character { get; set; }
            public int Frequency { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                string inputText = "Nguyen Tran The Vy"; // Chuỗi đầu vào

                // Tính tần suất của các ký tự
                var charFrequencies = inputText
                    .Where(c => !char.IsWhiteSpace(c)) // Bỏ qua ký tự khoảng trắng
                    .GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());

                // Tạo danh sách các nút từ tần suất ký tự
                var nodes = charFrequencies
                    .Select(pair => new Node { Character = pair.Key, Frequency = pair.Value })
                    .ToList();

                // Xây dựng cây Huffman
                while (nodes.Count > 1)
                {
                    nodes = nodes.OrderBy(n => n.Frequency).ToList(); // Sắp xếp theo tần suất

                    // Tạo nút mới
                    var left = nodes[0];
                    var right = nodes[1];
                    var newNode = new Node
                    {
                        Character = '\0',
                        Frequency = left.Frequency + right.Frequency,
                        Left = left,
                        Right = right
                    };

                    // Loại bỏ hai nút nhỏ nhất và thêm nút mới vào danh sách
                    nodes.RemoveRange(0, 2);
                    nodes.Add(newNode);
                }

                var root = nodes[0]; // Nút gốc của cây Huffman

                // Tạo bảng mã Huffman
                var encodingTable = new Dictionary<char, string>();
                BuildEncodingTable(root, "", encodingTable);

                // In kết quả
                Console.WriteLine("Character\tFrequency\tHuffman Code");
                foreach (var pair in charFrequencies)
                {
                    Console.WriteLine($"{pair.Key}\t\t{pair.Value}\t\t{encodingTable[pair.Key]}");
                }
            }

            // Hàm xây dựng bảng mã Huffman từ cây Huffman
            static void BuildEncodingTable(Node node, string code, Dictionary<char, string> encodingTable)
            {
                if (node.Left == null && node.Right == null)
                {
                    encodingTable[node.Character] = code;
                    return;
                }
                BuildEncodingTable(node.Left, code + "0", encodingTable);
                BuildEncodingTable(node.Right, code + "1", encodingTable);
            }
        }
    }

}