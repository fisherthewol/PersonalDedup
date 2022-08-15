namespace PersonalDedupeLib;

public interface IFileDedup
{
    int DuplicateLevel { get; }
    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromList(List<FileInfo> list);
    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromFolders(DirectoryInfo dir1, DirectoryInfo dir2);
}