namespace PersonalDedupeLib;

public class ImageDedup: IFileDedup
{
    public ImageDedup(int duplicateLevel)
    {
        DuplicateLevel = duplicateLevel > 1 ? duplicateLevel : 1;
    }

    /// <summary>
    /// Compares details about images and returns whether they are duplicates.
    /// </summary>
    /// <param name="image1">First image to test.</param>
    /// <param name="image2">Second image to test.</param>
    /// <returns>True if duplicate; false otherwise.</returns>
    public static int ImagesLikelyDuplicate(FileInfo image1, FileInfo image2)
    {
        if (!image1.Exists || !image2.Exists) throw new ArgumentException("Image does not exist.");
        int isLikelyDupe = 0;
        // Check length is same:
        if (image1.Length == image2.Length) isLikelyDupe++;
        // Check creation time:
        if (image1.CreationTimeUtc == image2.CreationTimeUtc) isLikelyDupe++;
        // Check extension:
        if (string.Equals(image1.Extension, image2.Extension, StringComparison.CurrentCultureIgnoreCase)) isLikelyDupe++;
        // Check names:
        if (image2.Name
                .ToLowerInvariant()
                .Contains(image1.Name.ToLowerInvariant()) 
            || image1.Name
                .ToLowerInvariant()
                .Contains(image2.Name.ToLowerInvariant())) isLikelyDupe++;
        return isLikelyDupe;
    }

    /// <summary>
    /// Level at which files should be considered duplicate.
    /// </summary>
    public int DuplicateLevel { get; }

    /// <summary>
    /// Given a list of files, return pairings that are likely duplicate; based on <see cref="DuplicateLevel"/>.
    /// </summary>
    /// <param name="list">List of files to check.</param>
    /// <returns>List of pairings likely similar.</returns>
    /// <exception cref="ArgumentException">Thrown if list is size 0 or 1; in these cases, nothing can be checked.</exception>
    /// <exception cref="NotImplementedException"></exception>
    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromList(List<FileInfo> list)
    {
        if (list.Count is 0 or 1) throw new ArgumentException($"List was of size {list.Count}.");
        throw new NotImplementedException();
    }

    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromFolders(DirectoryInfo dir1, DirectoryInfo dir2)
    {
        throw new NotImplementedException();
    }
}