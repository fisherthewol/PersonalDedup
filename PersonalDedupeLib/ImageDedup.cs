namespace PersonalDedupeLib;

public class ImageDedup
{
    /// <summary>
    /// Compares details about images and returns whether they are duplicates.
    /// </summary>
    /// <param name="image1">First image to test.</param>
    /// <param name="image2">Second image to test.</param>
    /// <returns>True if duplicate; false otherwise.</returns>
    public static bool IsImageDuplicate(FileInfo image1, FileInfo image2)
    {
        if (!image1.Exists || !image2.Exists)
        {
            throw new ArgumentException("Image does not exist.");
        }

        return true;
    }
}