namespace Itmo.ObjectOrientedProgramming.Lab4.TreeOutputConfigurators;

public class TreeOutputConfigurator
{
    public TreeOutputConfigurator()
    {
        BranchLine = "\u2514";
        DirectoryIcon = "\ud83d\udcc1";
        FileIcon = "\ud83d\udcda";
        NoAccessIcon = "\ud83d\udd75\ufe0f\u200d\u2642\ufe0f";
        BranchLenght = 3;
    }

    public string BranchLine { get; set; }
    public string DirectoryIcon { get; set; }
    public string FileIcon { get; set; }
    public string NoAccessIcon { get; set; }
    public int BranchLenght { get; set; }
}