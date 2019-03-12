using System;
using System.Reflection;
using static GetNonPublicMember;
class Program
{
    static void Main(string[] args)
    {
        object imPrivateMemberOnly = new ImPrivateMemberOnly();
        object privateMember1 = GetNonPublicMember.ByPropertyName(typeof(ImPrivateMemberOnly), imPrivateMemberOnly, "strPrivated");
        object privateMember2 = GetNonPublicMember.ByPropertyName(typeof(ImPrivateMemberOnly), imPrivateMemberOnly, "tuplePrivated");
        var privateTuple = privateMember2 as Tuple<double, int>;

        Console.WriteLine(privateMember1.ToString());
        Console.WriteLine(String.Format("{0}, {1}", privateTuple.Item1, privateTuple.Item2));
    }
}

public class ImPrivateMemberOnly
{
    private string strPrivated = "The string in the private member.";
    private Tuple<double, int> tuplePrivated = new Tuple<double, int>(55.66, 7788);
}