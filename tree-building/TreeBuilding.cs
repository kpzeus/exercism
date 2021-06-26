using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        if (records == null || records.Count() == 0)
            throw new ArgumentException();

        Tree t = null;

        var rows = records.OrderBy(x => x.RecordId).ToList();

        var root = rows[0];

        if (root.RecordId != root.ParentId)
            throw new ArgumentException();

        t = new Tree();
        t.Children = new List<Tree>();
        t.Id = root.RecordId;
        t.ParentId = root.ParentId;

        Tree curr = t;
        for (var i = 1; i < rows.Count; i++)
        {
            if (rows[i].RecordId == rows[i].ParentId)
                throw new ArgumentException();

            if (rows[i].RecordId <= curr.Id)
                throw new ArgumentException();

            if (rows[i].ParentId < curr.ParentId)
                throw new ArgumentException();

            if (curr.Id != rows[i].ParentId)
            {
                curr = Find(t, rows[i].ParentId);

                if (curr == null)
                    throw new ArgumentException();
            }

            var n = new Tree();
            n.Children = new List<Tree>();
            n.Id = rows[i].RecordId;
            n.ParentId = rows[i].ParentId;
            curr.Children.Add(n);
        }

        return t;
    }

    private static Tree Find(Tree root, int id)
    {
        if (root == null || root.Id == id)
            return root;

        foreach (var n in root.Children)
        {
            if (n.Id == id)
            {
                return n;
            }

            var c = Find(n, id);

            if (c != null)
                return c;
        }

        return null;
    }
}