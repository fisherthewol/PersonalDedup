namespace PersonalDedupeLib;

public class ImageDedup
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
        if (image1.Extension == image2.Extension) isLikelyDupe++;
        // Check names:
        if (image2.Name.Contains(image1.Name) || image1.Name.Contains(image2.Name)) isLikelyDupe++;
        return isLikelyDupe;
    }
}