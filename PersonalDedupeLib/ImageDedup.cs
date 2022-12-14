namespace PersonalDedupeLib;

public class ImageDedup: IFileDedup
{
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

    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromList(List<FileInfo> list)
    {
        throw new NotImplementedException();
    }

    public List<(FileInfo, FileInfo)> LikelyDuplicatesFromFolders(DirectoryInfo dir1, DirectoryInfo dir2)
    {
        throw new NotImplementedException();
    }
}